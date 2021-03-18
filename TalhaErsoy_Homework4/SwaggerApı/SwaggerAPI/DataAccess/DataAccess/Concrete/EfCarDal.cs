using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _4SwaggerAPI.DataAccess;
using _4SwaggerAPI.Domain;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,RentContext>,ICarDal
    {
      
    }
}
