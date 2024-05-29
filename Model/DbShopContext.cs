using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormShopORM.Model
{
    internal class DbShopContext: DbContext
    {
        public DbShopContext():base("DbShopContext")
        {

        }
        public DbSet<Product> Products { get; set;}

        public DbSet<ProductType> ProductTypes { get; set;}
    }
}
