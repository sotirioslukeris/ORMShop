using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormShopORM.Model
{
    public class DbShopContext: DbContext
    {
        public DbShopContext():base("MAGAZINE")
        {

        }
        public DbSet<Product> Products { get; set;}

        public DbSet<ProductType> ProductTypes { get; set;}
    }
}
