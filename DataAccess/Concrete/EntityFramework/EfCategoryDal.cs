using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
