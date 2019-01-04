using DataAccessLayer;
using System.Configuration;

namespace BusinessLayer
{
    public class ContextResolver
    {
        public static ClientDbContext GetContext()=> new ClientDbContext(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        
    }
}