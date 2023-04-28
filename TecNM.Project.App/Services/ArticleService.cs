using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services;
//Creamos el arcivo y luego implementamos la interfaz y agregamos todos Luego modificacmos y agregamos lo sig
public class ArticleService : IArticleService
{

    private readonly IArticleRepository _articleRepository;//Como trabajara con Dto debe apuntar hacia alla

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }
    
    public async Task<ArticleDto> SaveAsync(ArticleDto categoryDto)
    {
        // throw new NotImplementedException();
        var category = new Article
        {
            Information = categoryDto.Information,
            Category_id = categoryDto.Category_id,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now,
        };
    
        category = await _articleRepository.SaveAsync(category);
        category.Id = category.Id;

        return categoryDto;
    }

    // public Task<ArticleCategoryDto> UpdateAsync(ArticleCategoryDto category)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<ArticleDto> UpdateAsync(ArticleDto categoryDto)
    {
        var category = await _articleRepository.GetById(categoryDto.Id);

        if (category == null)
            throw new Exception("Article not found");
        category.Information = categoryDto.Information;
        category.Category_id = categoryDto.Category_id;    
        category.UpdateDate = DateTime.Now;
        category.UpdatedBy = "";
        await _articleRepository.UpdateAsync(category);

        return categoryDto;
    }

    public async Task<List<ArticleDto>> GetAllAsync()
    {
        // throw new NotImplementedException();
        var categories = await _articleRepository.GetAllAsync();
        var categoriesDto = 
            categories.Select(c => new ArticleDto(c)).ToList();
        return categoriesDto;
    }

    // public Task<bool> ArticleCategoryExist(int id)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<bool> ArticleExist(int id)
    {
        var category = await _articleRepository.GetById(id);
        return (category != null);
    }

    public async Task<ArticleDto> GetById(int id)
    {
        // throw new NotImplementedException();
        var category = await _articleRepository.GetById(id);
        if (category == null)
            throw new Exception("Article Category not found");
        var categoryDto = new ArticleDto(category);
        return categoryDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _articleRepository.DeleteAsync(id);
    }


}