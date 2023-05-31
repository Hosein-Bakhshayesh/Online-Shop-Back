﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityShopProjectModels.Context;
using UniversityShopProjectModels.Models;
using UniversityShopProjectRepository.GenericRepository;

namespace UniversityShopProjectRepository.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(UniversityShopProjectContext context) : base(context)
        {
        }
    }
}
