using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderingService
    {
        Task<List<Ordering>> GetAll();
        Task<Ordering> GetById(int id);
        Task Create(Ordering model);
        Task Update(Ordering model);
        Task Delete(int id);
    }
}
