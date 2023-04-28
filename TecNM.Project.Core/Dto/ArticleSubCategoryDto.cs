using TecNM.Project.Core.Entities;
namespace TecNM.Project.Core.Dto;

public class ArticleSubCategoryDto : DtoBase
{
    public string Name { get; set; }
    public int Category_id { get; set; }

    public ArticleSubCategoryDto()
    {
        
    }

    public ArticleSubCategoryDto(ArticleSubCategory category)
    {
        Id = category.Id;
        Name = category.Name;
        Category_id = category.Category_id;
    }
}