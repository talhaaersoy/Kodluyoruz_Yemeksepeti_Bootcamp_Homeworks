using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Domain.Concrete;

namespace DataAccess.Abtract
{
    public interface IFoodRepository : IReadRepository<Food>,IWriteRepository<Food>
    {
       

    }
}
