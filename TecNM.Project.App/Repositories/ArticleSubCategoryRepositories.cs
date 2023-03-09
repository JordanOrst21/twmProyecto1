using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class ArticleSubCategoryRepositories : IArticleSubCategoryRepository
{
    public Task<ArticleSubCategory> SaveAsync(ArticleSubCategory subcategory)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleSubCategory> UpdateAsync(ArticleSubCategory subcategory)
    {
        throw new NotImplementedException();
    }

    public Task<List<ArticleSubCategory>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleSubCategory> GetById(int id)
    {
        throw new NotImplementedException();
    }
}