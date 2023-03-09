using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class UserRepositories : IUserRepository
{
    public Task<User> SaveAsync(User category)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User category)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }
}