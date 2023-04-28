using Microsoft.VisualBasic;
using TecNM.Project.Core.Entities;
namespace TecNM.Project.Core.Dto;

public class UserDto : DtoBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserDto()
    {
        
    }

    public UserDto(User category)
    {
        Id = category.Id;
        Name = category.Name;
        Email = category.Email;
        Password = category.Password;
    }
}