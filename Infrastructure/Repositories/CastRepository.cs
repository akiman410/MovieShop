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
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public  async Task<Cast> GetCastDetailsById(int id)
        {
            var castDetails = await _dbContext.Casts.Include(m => m.MovieCasts).ThenInclude(m => m.Movie).FirstOrDefaultAsync(m => m.Id == id);
            return castDetails; ;
        }
    }
}
