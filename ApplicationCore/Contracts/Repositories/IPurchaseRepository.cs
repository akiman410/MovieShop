using ApplicationCore.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Contracts.Repositories.IRepositories;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository: IRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetAllPurchasesForUser(int movieId);
        Task<Purchase> GetUserPurchase(int userId, int movieId);
        Task<Purchase> AddPurchase(Purchase purchase);

        Task<Purchase> DeletePurchase(Purchase purchase);
        Task<Purchase> UpdatePurchase(Purchase purchase);
    }
}
