using ApplicationCore.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Contracts.Repositories.IRepositories;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<Review> GetAllReviewsByUser(int userId);
        Task DeleteReview(int userId, int movieId);
    }
}
