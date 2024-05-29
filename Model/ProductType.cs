using System.Collections;
using System.Collections.Generic;

namespace WinFormShopORM.Model
{
    public class ProductType
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        //relation 1 --> M
        public ICollection<Product> Products { get; set; }
    }
}