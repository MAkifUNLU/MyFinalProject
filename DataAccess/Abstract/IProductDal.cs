using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //İnterface'in default'u public değil, operasyonları public
    public interface IProductDal:IEntityRepository<Product>
    {

    }
}
