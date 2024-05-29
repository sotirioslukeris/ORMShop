using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormShopORM.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Expiry { get; set; }

        //relation M --> 1
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
    }
}
