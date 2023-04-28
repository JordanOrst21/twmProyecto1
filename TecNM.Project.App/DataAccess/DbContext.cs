using System.Data.Common;
using MySqlConnector;
using TecNM.Project.App.DataAccess.Interfaces;

namespace TecNM.Project.App.DataAccess;

public class DbContext : IDbContext
{
    private readonly string _connectionString = "server=localhost;user=root;pwd=Osfed#1991;database=twm;port=3306";
    
    private MySqlConnection _connection;

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }

            return _connection;
        }
    }
}