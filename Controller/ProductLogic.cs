using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormShopORM.Model;

namespace WinFormShopORM.Controller
{
    public class ProductLogic
    {
        DbShopContext _shopDbContext = new DbShopContext();

        public Product Get(int id)
        {
            Product findProduct = _shopDbContext.Products.Find(id);
            
            if (findProduct != null)
            {
                _shopDbContext.Entry(findProduct).Reference(x => x.ProductType).Load();
            }
            return findProduct;

        }

        public List<Product> GetProducts()
        {
            return _shopDbContext.Products.Include("ProductType").ToList();
        }

        public void Create(Product product)
        {
            _shopDbContext.Products.Add(product);
            _shopDbContext.SaveChanges();
        }
        public void Update(int id, Product product) 
        {
            Product findProduct = _shopDbContext.Products.Find(id);

            if (findProduct!= null)
            {
                return;
            }

            findProduct.Brand = product.Brand;
            findProduct.Expiry = product.Expiry;
            findProduct.Description = product.Description;
            findProduct.ProductTypeId = product.ProductTypeId;
            findProduct.Price = product.Price;
        }

        public void Delete(int id)
        {
            Product findProduct = _shopDbContext.Products.Find(id);
            _shopDbContext.Products.Remove(findProduct);
            _shopDbContext.SaveChanges();
        }
    }
}
