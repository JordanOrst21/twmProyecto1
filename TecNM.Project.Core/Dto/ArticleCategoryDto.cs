using TecNM.Project.Core.Entities;
namespace TecNM.Project.Core.Dto;

public class ArticleCategoryDto : DtoBase
{
    public string Name { get; set; }

    public ArticleCategoryDto()
    {
        
    }

    public ArticleCategoryDto(ArticleCategory category)
    {
        Id = category.Id;
        Name = category.Name;
    }
}