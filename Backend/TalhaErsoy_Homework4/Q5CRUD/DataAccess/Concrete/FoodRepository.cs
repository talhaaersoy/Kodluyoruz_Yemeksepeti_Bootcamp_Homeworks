using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using DataAccess.Abtract;
using DataAccess.Context;
using Domain.Concrete;

namespace DataAccess.Concrete
{
    public class FoodRepository : RepositoryCore<Food,OrderContext>,IFoodRepository
    {
      
    }
}
