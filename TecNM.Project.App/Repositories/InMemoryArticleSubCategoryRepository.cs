using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryArticleSubCategoryRepository : IArticleSubCategoryRepository
{
    private readonly List<ArticleSubCategory> _subcategories;

    public InMemoryArticleSubCategoryRepository()
    {
        _subcategories = new List<ArticleSubCategory>();
    }
    public async Task<ArticleSubCategory> SaveAsync(ArticleSubCategory subcategory)
    {
        subcategory.Id = _subcategories.Count + 1;
        _subcategories.Add(subcategory);

        return subcategory;
    }
    
    public async Task<ArticleSubCategory> UpdateAsync(ArticleSubCategory subcategory)
    {
        var index = _subcategories.FindIndex(x => x.Id == subcategory.Id);

        if (index != -1)
            _subcategories[index] = subcategory;
        return await Task.FromResult(subcategory);
    }
    
    public async Task<List<ArticleSubCategory>> GetAllAsync()
    {
        return _subcategories;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        _subcategories.RemoveAll(x => x.Id == id);
        return true;
    }
    public async Task<ArticleSubCategory> GetById(int id)
    {
        var subcategory = _subcategories.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(subcategory);
    }
}