using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class ImageRepositories : IImageRepository
{
    public Task<Image> SaveAsync(Image category)
    {
        throw new NotImplementedException();
    }

    public Task<Image> UpdateAsync(Image category)
    {
        throw new NotImplementedException();
    }

    public Task<List<Image>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Image> GetById(int id)
    {
        throw new NotImplementedException();
    }
}