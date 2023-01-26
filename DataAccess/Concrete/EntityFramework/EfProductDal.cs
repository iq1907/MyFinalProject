using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>,IProductDal
    {
        
        public List<ProductDetailDto> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using(NorthwindContext northwindContext =  new NorthwindContext())
            {

                var result = from p in northwindContext.Set<Product>()
                             join c in northwindContext.Set<Category>()
                             on p.CategoryId equals c.CategoryId  
                             select new ProductDetailDto
                             {
                                 CategoryName = c.CategoryName,
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 UnitsInStock = p.UnitsInStock
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
            
        }
        
    }
}
