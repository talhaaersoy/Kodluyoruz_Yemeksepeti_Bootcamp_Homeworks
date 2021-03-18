using System;
using System.Collections.Generic;
using System.Text;
using Core.Repositories;
using DataAccess.Abtract;
using DataAccess.Context;
using Domain.Concrete;

namespace DataAccess.Concrete
{
    public class OrderRepository :RepositoryCore<Order,OrderContext>,IOrderRepository
    {
    }
}
