using TecNM.Project.App.DataAccess.Interfaces;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;

namespace TecNM.Project.App.Repositories;

public class ArticleSubCategoryRepositories : IArticleSubCategoryRepository
{
    
    private readonly IDbContext _dbContext;

    public ArticleSubCategoryRepositories(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<ArticleSubCategory> SaveAsync(ArticleSubCategory category)
    {
        category.Id = await _dbContext.Connection.InsertAsync(category);
        //throw new NotImplementedException();
        return category;
    }

    public async Task<ArticleSubCategory> UpdateAsync(ArticleSubCategory category)
    {
        await _dbContext.Connection.UpdateAsync(category);

        return category;
    }
    
    public async Task<List<ArticleSubCategory>> GetAllAsync()
    {
        const string sql = "SELECT * FROM articlesubcategory WHERE IsDeleted = 0";

        var categories = await _dbContext.Connection.QueryAsync<ArticleSubCategory>(sql);
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

    public async Task<ArticleSubCategory> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<ArticleSubCategory>(id);

        if (category == null)
            return null;

        return category.IsDeleted == true ? null : category;
    }
    
    // public Task<ArticleSubCategory> SaveAsync(ArticleSubCategory subcategory)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<ArticleSubCategory> UpdateAsync(ArticleSubCategory subcategory)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<List<ArticleSubCategory>> GetAllAsync()
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<bool> DeleteAsync(int id)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<ArticleSubCategory> GetById(int id)
    // {
    //     throw new NotImplementedException();
    // }
}