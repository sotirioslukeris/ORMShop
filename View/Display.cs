using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormShopORM.Controller;
using WinFormShopORM.Model;

namespace WinFormShopORM.View
{
    public class Display
    {
        private ProductLogic productLogic = new ProductLogic();
        private int closeOperation = 4;
        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new entry");
            Console.WriteLine("2. Update entry");
            Console.WriteLine("3. Delete entry");
            Console.WriteLine("4. Exit");
        }

        private void ShowProduct(Product product)
        {
            Console.WriteLine($"{product.Id}. Вид : {product.ProductType.Name} Марка : {product.Brand} Цена : {product.Price}" +
                    $" Описание : {product.Description} Срок на годност : {product.Expiry}");
        }

        private void Input()
        {
            int operation;

            do
            {
                operation = int.Parse(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        Add();
                        break;

                    case 2:
                        Update();
                        break;

                    case 3:
                        Delete();
                        break;


                    default:
                        break;
                }

            } while (operation!= closeOperation);
        }

        private void Add()
        {
            Product product = new Product();

            Console.Write("Brand : ");
            product.Brand = Console.ReadLine();

            Console.Write("Price : ");
            product.Price = double.Parse(Console.ReadLine());

            Console.Write("Description : ");
            product.Description = Console.ReadLine();

            Console.WriteLine("Expiry : ");
            product.Expiry = Console.ReadLine();

            ProductTypeLogic productType = new ProductTypeLogic();

            List<ProductType> allTypes = productType.GetProductTypes();

            Console.Write("Product types : ");
            Console.WriteLine(new string('-',4));

            foreach(var type in allTypes)
            {
                Console.WriteLine($"{type.Id}. {type.Name}");
            }

            Console.WriteLine("Choose product type : ");
            product.ProductTypeId = int.Parse(Console.ReadLine());

            ProductLogic productLogic = new ProductLogic();
            productLogic.Create(product);

            Console.WriteLine($"{product.Id}. Вид : {product.ProductType.Name} Марка : {product.Brand} Цена : {product.Price}" +
                $" Описание : {product.Description} Срок на годност : {product.Expiry}");


        }

        private void Delete()
        {
            Console.Write("Enter fetch ID : ");
            int id = int.Parse(Console.ReadLine());
            ProductLogic productController = new ProductLogic();
            Product product = productController.Get(id);
            if (product!=null)
            {
                productController.Delete(id);
            }
        }

        private void Update()
        {
            Console.Write("Enter fetch ID : ");
            int id = int.Parse(Console.ReadLine());
            ProductLogic productController = new ProductLogic();
            Product product = productController.Get(id);
            if (product == null)
            {
                Console.WriteLine("No product available with the specified ID!");
                return;
            }

            else
            {
                ShowProduct(product);

                Console.WriteLine("Enter the new values");

                Console.Write("Description : ");
                product.Description = Console.ReadLine();

                Console.Write("Price : ");
                product.Price = double.Parse(Console.ReadLine());

                Console.Write("Brand : ");
                product.Brand = Console.ReadLine();

                Console.WriteLine("Expiry date : ");
                product.Expiry = Console.ReadLine();

                ProductTypeLogic productType = new ProductTypeLogic();
                List<ProductType> allTypes = productType.GetProductTypes();

                Console.WriteLine("Product types : ");
                Console.WriteLine(new string('-',4));

                foreach (var i in allTypes)
                {
                    Console.WriteLine($"{i.Id}. {i.Name}");
                }

                Console.WriteLine("Select product type");
                product.Id = int.Parse(Console.ReadLine());

                ProductLogic productLogic = new ProductLogic();
                productLogic.Update(id, product);
            }
        }

        
    }
}
