using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryArticleCategoryRepository : IArticleCategoryRepository
{
    private readonly List<ArticleCategory> _categories;

    public InMemoryArticleCategoryRepository()
    {
        _categories = new List<ArticleCategory>();
    }
    public async Task<ArticleCategory> SaveAsync(ArticleCategory category)
    {
        category.Id = _categories.Count + 1;
        _categories.Add(category);

        return category;
    }
    
    public async Task<ArticleCategory> UpdateAsync(ArticleCategory category)
    {
        var index = _categories.FindIndex(x => x.Id == category.Id);

        if (index != -1)
            _categories[index] = category;
        return await Task.FromResult(category);
    }
    
    public async Task<List<ArticleCategory>> GetAllAsync()
    {
        return _categories;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        _categories.RemoveAll(x => x.Id == id);
        return true;
    }

    public Task<bool> ArticleCategoryExist(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ArticleCategory> GetById(int id)
    {
        var category = _categories.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(category);
    }
}