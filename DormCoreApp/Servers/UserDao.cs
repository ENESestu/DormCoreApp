using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DormCoreApp.Servers
{
    public class UserDao : DbContext
    {
        string ConnectionString;
        public void ConnectionClass(IConfiguration _configuration)
        {
            ConnectionString = _configuration.GetConnectionString("DormDatabse");
          
        }


         
    }
}
