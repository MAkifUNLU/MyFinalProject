using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            ProductManger productManager = new ProductManger(new EfProductDal());

            foreach (var product in productManager.GetAllByUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName);
            }


            
        }
    }
}
    