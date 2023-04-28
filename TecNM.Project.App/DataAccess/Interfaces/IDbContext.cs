namespace TecNM.Project.App.DataAccess.Interfaces;
using System.Data.Common;

public interface IDbContext
{   
    DbConnection Connection { get; } 
}