using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class ArticleCategoryRepositories : IArticleCategoryRepository
{
    public Task<ArticleCategory> SaveAsync(ArticleCategory category)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleCategory> UpdateAsync(ArticleCategory category)
    {
        throw new NotImplementedException();
    }

    public Task<List<ArticleCategory>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleCategory> GetById(int id)
    {
        throw new NotImplementedException();
    }
}