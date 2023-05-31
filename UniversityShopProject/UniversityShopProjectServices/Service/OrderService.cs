using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;

namespace UniversityShopProjectServices.Service
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        public OrderService(UniversityShopProjectContext context) : base(context)
        {
        }
    }
}
