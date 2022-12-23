using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {

            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var c in categoryManager.GetAll())
            {
                Console.WriteLine(c.CategoryId + " " + c.CategoryName);
            }
            
            
        }

        private static void OrderConsole()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal()); 

            foreach (var order in orderManager.GetAll())
            {
                Console.WriteLine(order.CustomerId + " " + order.OrderId + " " + order.ShipCity);
            }

            foreach (var order in orderManager.GetAllByCustomerId("hanar"))
            {
                Console.WriteLine(order.CustomerId + " " + order.OrderId + " " + order.ShipCity);
            }
            
        }

        private static void ProductConsole()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(40, 50))
            {
                Console.WriteLine(product.ProductName);
            }

            foreach (var product in productManager.GetByUnitPrice(40, 50))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }

    
}
