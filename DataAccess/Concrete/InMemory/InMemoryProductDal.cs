using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {

                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitInStock=15,UnitPrice=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Musluk",UnitInStock=5,UnitPrice=50 },
                new Product{ProductId=2,CategoryId=1,ProductName="Musluk",UnitInStock=5,UnitPrice=50 },
                new Product{ProductId=2,CategoryId=1,ProductName="Musluk",UnitInStock=5,UnitPrice=50 },
                new Product{ProductId=2,CategoryId=1,ProductName="Musluk",UnitInStock=5,UnitPrice=50 },
                new Product{ProductId=2,CategoryId=1,ProductName="Musluk",UnitInStock=5,UnitPrice=50 }

            };
        }
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
