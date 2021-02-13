using Core.DataAccsess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetail();
    }
}
// Code refactoring kod iyleştirmesi
