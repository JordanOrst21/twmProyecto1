using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services;
//Creamos el arcivo y luego implementamos la interfaz y agregamos todos Luego modificacmos y agregamos lo sig
public class ImageService : IImageService
{

    private readonly IImageRepository _imageRepository;//Como trabajara con Dto debe apuntar hacia alla

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    
    public async Task<ImageDto> SaveAsync(ImageDto categoryDto)
    {
        // throw new NotImplementedException();
        var category = new Image
        {
            Name = categoryDto.Name,
            Article_id = categoryDto.Article_id,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now,
        };
    
        category = await _imageRepository.SaveAsync(category);
        category.Id = category.Id;

        return categoryDto;
    }

    // public Task<ArticleCategoryDto> UpdateAsync(ArticleCategoryDto category)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<ImageDto> UpdateAsync(ImageDto categoryDto)
    {
        var category = await _imageRepository.GetById(categoryDto.Id);

        if (category == null)
            throw new Exception("Image not found");
        category.Name = categoryDto.Name;
        category.Article_id = categoryDto.Article_id;
        category.UpdateDate = DateTime.Now;
        category.UpdatedBy = "";
        await _imageRepository.UpdateAsync(category);

        return categoryDto;
    }

    public async Task<List<ImageDto>> GetAllAsync()
    {
        // throw new NotImplementedException();
        var categories = await _imageRepository.GetAllAsync();
        var categoriesDto = 
            categories.Select(c => new ImageDto(c)).ToList();
        return categoriesDto;
    }

    // public Task<bool> ArticleCategoryExist(int id)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<bool> ImageExist(int id)
    {
        var category = await _imageRepository.GetById(id);
        return (category != null);
    }

    public async Task<ImageDto> GetById(int id)
    {
        // throw new NotImplementedException();
        var category = await _imageRepository.GetById(id);
        if (category == null)
            throw new Exception("Image Category not found");
        var categoryDto = new ImageDto(category);
        return categoryDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _imageRepository.DeleteAsync(id);
    }


}