using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Models;
using UniversityShopProjectRepository.GenericRepository;

namespace UniversityShopProjectRepository.Repository
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
    }
}
