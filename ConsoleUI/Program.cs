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
            ProductManager productManger = new ProductManager(new EfProductDal());

            //foreach (var product in productManger.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //foreach (var product in productManger.GetAllByUnitPrice(10,30))
            //{
            //    Console.WriteLine(product.ProductName + " Fiyat : " + product.UnitPrice);
            //} 
            
            foreach (var product in productManger.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName );
            }
            
        }
    }
}
