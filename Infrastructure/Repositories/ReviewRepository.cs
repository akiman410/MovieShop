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
    public class ReviewRepository : EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Review> AddReview(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> DeleteReview(Review review)
        {
            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsByUser(int userId)
        {
            var reviews = await _dbContext.Reviews.Include(m => m.Movie).Where(p => p.User.Id == userId).ToListAsync();
            return reviews;
        }

        public async Task<Review> UpdateReview(Review review)
        {
            _dbContext.Reviews.Update(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
    }
}
