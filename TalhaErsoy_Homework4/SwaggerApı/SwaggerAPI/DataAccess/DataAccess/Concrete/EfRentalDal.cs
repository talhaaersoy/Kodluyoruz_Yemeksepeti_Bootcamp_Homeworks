using System;
using System.Collections.Generic;
using System.Text;
using _4SwaggerAPI.DataAccess;
using _4SwaggerAPI.Domain;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,RentContext>,IRentalDal
    {
    }
}
