using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Repositories;
using DataAccess.Abtract;
using DataAccess.Context;
using Domain.Concrete;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class OrderRepository :RepositoryCore<Order,OrderContext>,IOrderRepository
    {
       
    }
}
