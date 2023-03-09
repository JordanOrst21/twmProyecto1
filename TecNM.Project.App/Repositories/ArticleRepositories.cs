using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class ArticleRepositories : IArticleRepository
{
    public Task<Article> SaveAsync(Article category)
    {
        throw new NotImplementedException();
    }

    public Task<Article> UpdateAsync(Article category)
    {
        throw new NotImplementedException();
    }

    public Task<List<Article>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Article> GetById(int id)
    {
        throw new NotImplementedException();
    }
}