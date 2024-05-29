using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormShopORM.Model;

namespace WinFormShopORM.Controller
{
    public class ProductTypeLogic
    {
        DbShopContext _shopDbContext = new DbShopContext();

        public List<ProductType> GetProductTypes()
        {
            return _shopDbContext.ProductTypes.ToList();
        }

        public string GetProductType(int id)
        {
            return _shopDbContext.ProductTypes.Find(id).Name;
        }


    }
}
