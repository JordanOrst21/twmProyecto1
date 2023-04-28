using Microsoft.VisualBasic;
using TecNM.Project.Core.Entities;
namespace TecNM.Project.Core.Dto;

public class ArticleDto : DtoBase
{
    public int Category_id { get; set; }
    public string Information { get; set; }

    public ArticleDto()
    {
        
    }

    public ArticleDto(Article category)
    {
        Id = category.Id;
        Category_id = category.Category_id;
        Information = category.Information;
    }
}