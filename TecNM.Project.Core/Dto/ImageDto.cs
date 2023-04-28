using Microsoft.VisualBasic;
using TecNM.Project.Core.Entities;
namespace TecNM.Project.Core.Dto;

public class ImageDto : DtoBase
{
    public int Article_id { get; set; }
    public string Name { get; set; }

    public ImageDto()
    {
        
    }

    public ImageDto(Image category)
    {
        Id = category.Id;
        Article_id = category.Article_id;
        Name = category.Name;
    }
}