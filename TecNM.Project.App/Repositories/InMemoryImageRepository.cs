using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryImageRepository : IImageRepository
{
    private readonly List<Image> _categories;

    public InMemoryImageRepository()
    {
        _categories = new List<Image>();
    }
    public async Task<Image> SaveAsync(Image category)
    {
        category.Id = _categories.Count + 1;
        _categories.Add(category);

        return category;
    }
    
    public async Task<Image> UpdateAsync(Image category)
    {
        var index = _categories.FindIndex(x => x.Id == category.Id);

        if (index != -1)
            _categories[index] = category;
        return await Task.FromResult(category);
    }
    
    public async Task<List<Image>> GetAllAsync()
    {
        return _categories;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        _categories.RemoveAll(x => x.Id == id);
        return true;
    }
    public async Task<Image> GetById(int id)
    {
        var category = _categories.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(category);
    }
}