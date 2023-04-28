using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface IArticleRepository
{
    //metodo para guardar article
    Task<Article> SaveAsync(Article article);
    
    //metodo para actualizar las article
    Task<Article> UpdateAsync(Article article);
    
    //metodo para retornar una lista de article
    Task<List<Article>> GetAllAsync();

    //metodo para retornar el id de las article que borrara
    Task<bool> DeleteAsync(int id);
    
    //metodo para obtener una article por id
    Task<Article> GetById(int id);
}