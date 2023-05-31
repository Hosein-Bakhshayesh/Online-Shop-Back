using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectRepository.GenericRepository;

namespace UniversityShopProjectServices.Service
{
    public class GenericService<T> : GenericRepository<T> where T : BaseEntity
    {
        public GenericService(UniversityShopProjectContext context) : base(context)
        {
        }
    }
}
