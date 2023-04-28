using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services;
//Creamos el arcivo y luego implementamos la interfaz y agregamos todos Luego modificacmos y agregamos lo sig
public class ArticleCategoryService : IArticleCategoryService
{

    private readonly IArticleCategoryRepository _articleCategoryRepository;//Como trabajara con Dto debe apuntar hacia alla

    public ArticleCategoryService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }
    
    public async Task<ArticleCategoryDto> SaveAsync(ArticleCategoryDto categoryDto)
    {
        // throw new NotImplementedException();
        var category = new ArticleCategory
        {
            Name = categoryDto.Name,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now,
        };
    
        category = await _articleCategoryRepository.SaveAsync(category);
        category.Id = category.Id;

        return categoryDto;
    }

    // public Task<ArticleCategoryDto> UpdateAsync(ArticleCategoryDto category)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<ArticleCategoryDto> UpdateAsync(ArticleCategoryDto categoryDto)
    {
        var category = await _articleCategoryRepository.GetById(categoryDto.Id);

        if (category == null)
            throw new Exception("Article Category not found");
        category.Name = categoryDto.Name;
        category.UpdateDate = DateTime.Now;
        category.UpdatedBy = "";
        await _articleCategoryRepository.UpdateAsync(category);

        return categoryDto;
    }

    public async Task<List<ArticleCategoryDto>> GetAllAsync()
    {
        // throw new NotImplementedException();
        var categories = await _articleCategoryRepository.GetAllAsync();
        var categoriesDto = 
            categories.Select(c => new ArticleCategoryDto(c)).ToList();
        return categoriesDto;
    }

    // public Task<bool> ArticleCategoryExist(int id)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<bool> ArticleCategoryExist(int id)
    {
        var category = await _articleCategoryRepository.GetById(id);
        return (category != null);
    }

    public async Task<ArticleCategoryDto> GetById(int id)
    {
        // throw new NotImplementedException();
        var category = await _articleCategoryRepository.GetById(id);
        if (category == null)
            throw new Exception("Article Category not found");
        var categoryDto = new ArticleCategoryDto(category);
        return categoryDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _articleCategoryRepository.DeleteAsync(id);
    }


}