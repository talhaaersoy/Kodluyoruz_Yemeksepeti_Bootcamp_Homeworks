using System;
using System.Collections.Generic;
using System.Text;
using _4SwaggerAPI.Domain;
using Core.DataAccess;
namespace DataAccess.Abstract
{
    public interface IUserDal :IEntityRepository<User>
    {
    }
}
