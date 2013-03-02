using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Context
{
    public class BaseContext<T> : DbContext where T : DbContext
    {
        protected BaseContext()
            : base("Base")//use specified database
        {
            Database.SetInitializer<T>(null);//prevent database initialization
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;//required by webApi
        }

    }
}
