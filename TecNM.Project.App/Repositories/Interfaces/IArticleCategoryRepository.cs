using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface IArticleCategoryRepository
{
    //metodo para guardar categoria
    Task<ArticleCategory> SaveAsync(ArticleCategory category);
    
    //metodo para actualizar las categorias
    Task<ArticleCategory> UpdateAsync(ArticleCategory category);
    
    //metodo para retornar una lista de categorias
    Task<List<ArticleCategory>> GetAllAsync();

    //metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //metodo para obtener una categoria por id
    Task<ArticleCategory> GetById(int id);
}