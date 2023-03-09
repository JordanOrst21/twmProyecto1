using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface IArticleSubCategoryRepository
{
    //metodo para guardar categoria
    Task<ArticleSubCategory> SaveAsync(ArticleSubCategory subcategory);
    
    //metodo para actualizar las categorias
    Task<ArticleSubCategory> UpdateAsync(ArticleSubCategory subcategory);
    
    //metodo para retornar una lista de categorias
    Task<List<ArticleSubCategory>> GetAllAsync();

    //metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //metodo para obtener una categoria por id
    Task<ArticleSubCategory> GetById(int id);
}