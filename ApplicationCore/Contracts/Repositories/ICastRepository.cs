using ApplicationCore.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface ICastRepository: IRepositories
    {
        Task<Cast> GetCastDetailsById(int id);
    }
}
