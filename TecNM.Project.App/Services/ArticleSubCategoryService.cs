using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services;
//Creamos el arcivo y luego implementamos la interfaz y agregamos todos Luego modificacmos y agregamos lo sig
public class ArticleSubCategoryService : IArticleSubCategoryService
{

    private readonly IArticleSubCategoryRepository _articleSubCategoryRepository;//Como trabajara con Dto debe apuntar hacia alla

    public ArticleSubCategoryService(IArticleSubCategoryRepository articleSubCategoryRepository)
    {
        _articleSubCategoryRepository = articleSubCategoryRepository;
    }
    
    public async Task<ArticleSubCategoryDto> SaveAsync(ArticleSubCategoryDto categoryDto)
    {
        if (string.IsNullOrEmpty(categoryDto.Name))
        {
            throw new ArgumentException("El nombre de la subcategoría no puede estar vacío o nulo.", nameof(categoryDto.Name));
        }
        // throw new NotImplementedException();
        var category = new ArticleSubCategory
        {
            Name = categoryDto.Name, 
            Category_id = categoryDto.Category_id,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now,
        };
    
        category = await _articleSubCategoryRepository.SaveAsync(category);
        category.Id = category.Id;

        return categoryDto;
    }

    // public Task<ArticleCategoryDto> UpdateAsync(ArticleCategoryDto category)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<ArticleSubCategoryDto> UpdateAsync(ArticleSubCategoryDto categoryDto)
    {
        var category = await _articleSubCategoryRepository.GetById(categoryDto.Id);

        if (category == null)
            throw new Exception("Article Subcategory not found");
        category.Name = categoryDto.Name;
        category.Category_id = categoryDto.Category_id;
        category.UpdateDate = DateTime.Now;
        category.UpdatedBy = "";
        await _articleSubCategoryRepository.UpdateAsync(category);

        return categoryDto;
    }

    public async Task<List<ArticleSubCategoryDto>> GetAllAsync()
    {
        // throw new NotImplementedException();
        var categories = await _articleSubCategoryRepository.GetAllAsync();
        var categoriesDto = 
            categories.Select(c => new ArticleSubCategoryDto(c)).ToList();
        return categoriesDto;
    }

    // public Task<bool> ArticleCategoryExist(int id)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<bool> ArticleSubCategoryExist(int id)
    {
        var category = await _articleSubCategoryRepository.GetById(id);
        return (category != null);
    }

    public async Task<ArticleSubCategoryDto> GetById(int id)
    {
        // throw new NotImplementedException();
        var category = await _articleSubCategoryRepository.GetById(id);
        if (category == null)
            throw new Exception("Article Subcategory not found");
        var categoryDto = new ArticleSubCategoryDto(category);
        return categoryDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _articleSubCategoryRepository.DeleteAsync(id);
    }


}