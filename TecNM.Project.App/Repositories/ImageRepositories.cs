using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.App.DataAccess.Interfaces;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class ImageRepositories : IImageRepository
{
    private readonly IDbContext _dbContext;

    public ImageRepositories(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<Image> SaveAsync(Image category)
    {
        category.Id = await _dbContext.Connection.InsertAsync(category);
        //throw new NotImplementedException();
        return category;
    }
    public async Task<Image> UpdateAsync(Image category)
    {
        await _dbContext.Connection.UpdateAsync(category);

        return category;   
    }
    public async Task<List<Image>> GetAllAsync()
    {
        const string sql = "SELECT * FROM image WHERE IsDeleted = 0";

        var categories = await _dbContext.Connection.QueryAsync<Image>(sql);
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
    public async Task<Image> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<Image>(id);

        if (category == null)
            return null;

        return category.IsDeleted == true ? null : category;
    }
    // public Task<Image> SaveAsync(Image category)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<Image> UpdateAsync(Image category)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<List<Image>> GetAllAsync()
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<bool> DeleteAsync(int id)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<Image> GetById(int id)
    // {
    //     throw new NotImplementedException();
    // }
}