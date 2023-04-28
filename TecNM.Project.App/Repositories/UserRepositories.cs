using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.App.DataAccess.Interfaces;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class UserRepositories : IUserRepository
{
    private readonly IDbContext _dbContext;

    public UserRepositories(IDbContext context)
    {
        _dbContext = context;
    }
    public async Task<User> SaveAsync(User category)
    {
        category.Id = await _dbContext.Connection.InsertAsync(category);
        //throw new NotImplementedException();
        return category;
    }
    public async Task<User> UpdateAsync(User category)
    {
        await _dbContext.Connection.UpdateAsync(category);

        return category;   
    }
    public async Task<List<User>> GetAllAsync()
    {
        const string sql = "SELECT * FROM user WHERE IsDeleted = 0";

        var categories = await _dbContext.Connection.QueryAsync<User>(sql);
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
    public async Task<User> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<User>(id);

        if (category == null)
            return null;

        return category.IsDeleted == true ? null : category;
    }
    // public Task<User> SaveAsync(User category)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<User> UpdateAsync(User category)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<List<User>> GetAllAsync()
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<bool> DeleteAsync(int id)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<User> GetById(int id)
    // {
    //     throw new NotImplementedException();
    // }
}