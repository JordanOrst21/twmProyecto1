using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.App.DataAccess.Interfaces;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class ArticleRepositories : IArticleRepository
{
    private readonly IDbContext _dbContext;

    public ArticleRepositories(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Article> SaveAsync(Article category)
    {
        category.Id = await _dbContext.Connection.InsertAsync(category);
        //throw new NotImplementedException();
        return category;
    }
    public async Task<Article> UpdateAsync(Article category)
    {
        await _dbContext.Connection.UpdateAsync(category);

        return category;   
    }
    public async Task<List<Article>> GetAllAsync()
    {
        const string sql = "SELECT * FROM article WHERE IsDeleted = 0";

        var categories = await _dbContext.Connection.QueryAsync<Article>(sql);
        return categories.ToList();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var category = await GetById(id);
        //throw new NotImplementedException();

        if (category == null)
        {
            return false;
        }

        category.IsDeleted = true;

        return await _dbContext.Connection.UpdateAsync(category);
    }
    public async Task<Article> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<Article>(id);

        if (category == null)
            return null;

        return category.IsDeleted == true ? null : category;
    }
}