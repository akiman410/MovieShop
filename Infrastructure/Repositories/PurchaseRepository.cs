using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Enities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Purchase>> GetAllPurchasesForUser(int userId)
        {
            var purchases = await _dbContext.Purchases.Include(m => m.Movie).Where(p => p.UserId == userId).ToListAsync();
            return purchases;

        }
        
        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
            _dbContext.Purchases.Add(purchase);
            await _dbContext.SaveChangesAsync();
            return purchase;
        }
        public async Task<Purchase> GetUserPurchase(int userId, int movieId)
        {
            var purchaseDetail = await _dbContext.Purchases.Where(p => p.UserId == userId && p.MovieId == movieId).FirstOrDefaultAsync();
            return purchaseDetail;
        }
        public async Task<Purchase> DeletePurchase(Purchase purchase)
        {
            _dbContext.Purchases.Remove(purchase);
            await _dbContext.SaveChangesAsync();
            return purchase;
        }

        public async Task<Purchase> UpdatePurchase(Purchase purchase)
        {
            _dbContext.Purchases.Add(purchase);
             await _dbContext.SaveChangesAsync();
            return purchase;
        }
    }
}
