using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryArticleRepository : IArticleRepository
{
    private readonly List<Article> _categories;

    public InMemoryArticleRepository()
    {
        _categories = new List<Article>();
    }
    public async Task<Article> SaveAsync(Article category)
    {
        category.Id = _categories.Count + 1;
        _categories.Add(category);

        return category;
    }
    
    public async Task<Article> UpdateAsync(Article category)
    {
        var index = _categories.FindIndex(x => x.Id == category.Id);

        if (index != -1)
            _categories[index] = category;
        return await Task.FromResult(category);
    }
    
    public async Task<List<Article>> GetAllAsync()
    {
        return _categories;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        _categories.RemoveAll(x => x.Id == id);
        return true;
    }
    public async Task<Article> GetById(int id)
    {
        var category = _categories.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(category);
    }
}