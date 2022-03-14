﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Enities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        Task IPurchaseRepository.Add(Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}
