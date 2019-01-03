using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BusinessLayer
{
    public class ContextResolver
    {
        public static ClientDbContext GetContext()=> new ClientDbContext();
    }
}
