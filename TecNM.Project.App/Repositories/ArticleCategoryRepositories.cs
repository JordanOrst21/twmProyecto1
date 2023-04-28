using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.App.DataAccess.Interfaces;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class ArticleCategoryRepositories : IArticleCategoryRepository
{
    private readonly IDbContext _dbContext;

    public ArticleCategoryRepositories(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<ArticleCategory> SaveAsync(ArticleCategory category)
    {
        category.Id = await _dbContext.Connection.InsertAsync(category);
        //throw new NotImplementedException();
        return category;
    }

    public async Task<ArticleCategory> UpdateAsync(ArticleCategory category)
    {
        await _dbContext.Connection.UpdateAsync(category);

        return category;
    }
    
    public async Task<List<ArticleCategory>> GetAllAsync()
    {
        const string sql = "SELECT * FROM articlecategory WHERE IsDeleted = 0";

        var categories = await _dbContext.Connection.QueryAsync<ArticleCategory>(sql);
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

    public async Task<ArticleCategory> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<ArticleCategory>(id);

        if (category == null)
            return null;

        return category.IsDeleted == true ? null : category;
    }

    // public async Task<ArticleCategory> UpdateAsync(ArticleCategory category)
    // {
    //     var index = await _dbContext.ArticleCategories.FindAsync(category.Id);
    //
    //     if (index == null)
    //     {
    //         throw new ArgumentException("La categoría especificada no existe.", nameof(category));
    //     }
        
        //throw new NotImplementedException();
        
        //var existingCategory = await _dbContext.ArticleCategories.FindAsync(category.Id);

        //if (existingCategory == null)
        //{
            //throw new ArgumentException("La categoría especificada no existe.", nameof(category));
        //}

        //existingCategory.Name = category.Name;
        //existingCategory.Description = category.Description;

        //await _dbContext.SaveChangesAsync();
        //return existingCategory;
    //}
    // }
    //
    // public Task<List<ArticleCategory>> GetAllAsync()
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<bool> DeleteAsync(int id)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<ArticleCategory> GetById(int id)
    // {
    //     throw new NotImplementedException();
    // }
}