using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test
            ProductTest();
            //CategoryTest();

          
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine("Kategori adı : " + category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManger = new ProductManager(new EfProductDal());

            foreach (var product in productManger.GetProductDetails())
            {
                Console.WriteLine("Ürün adı : " +product.ProductName + " Kategorisi : " + product.CategoryName);
            }
        }
    }
}
