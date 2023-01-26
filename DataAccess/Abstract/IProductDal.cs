using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null);
    }
}
