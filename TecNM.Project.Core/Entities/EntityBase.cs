namespace TecNM.Project.Core.Entities;

public class EntityBase
{
    public int Id { get; set; }
    public bool IsDelete { get; set; }
    public string CreateBy { get; set; }
    public DateTime CreateDate { get; set; }
    public string UpdateBy { get; set; }
    public DateTime UpdateDate { get; set; }
}

public class Test1 : EntityBase
{
    
}