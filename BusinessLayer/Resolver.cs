using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BusinessLayer
{
    public class Resolver
    {
        public string GetContext()=> ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        
    }
}
