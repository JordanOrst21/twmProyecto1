using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _categories;

    public InMemoryUserRepository()
    {
        _categories = new List<User>();
    }
    public async Task<User> SaveAsync(User category)
    {
        category.Id = _categories.Count + 1;
        _categories.Add(category);

        return category;
    }
    
    public async Task<User> UpdateAsync(User category)
    {
        var index = _categories.FindIndex(x => x.Id == category.Id);

        if (index != -1)
            _categories[index] = category;
        return await Task.FromResult(category);
    }
    
    public async Task<List<User>> GetAllAsync()
    {
        return _categories;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        _categories.RemoveAll(x => x.Id == id);
        return true;
    }
    public async Task<User> GetById(int id)
    {
        var category = _categories.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(category);
    }
}