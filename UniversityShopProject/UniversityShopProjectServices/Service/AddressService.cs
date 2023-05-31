using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;

namespace UniversityShopProjectServices.Service
{
    public class AddressService : GenericService<Address>, IAddressService
    {
        public AddressService(UniversityShopProjectContext context) : base(context)
        {
        }
    }
}
