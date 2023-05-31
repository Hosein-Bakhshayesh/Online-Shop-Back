using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectRepository.GenericRepository;

namespace UniversityShopProjectRepository.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(UniversityShopProjectContext context) : base(context)
        {
        }
    }
}
