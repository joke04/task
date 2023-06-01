using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoriesBase<User>, IUserRepository
    {
        public UserRepository(shop_pharmacyContext repositoryContext)
            : base(repositoryContext)
        { }
        public async Task<User?> GetByEmailAndPassword(string email, string password)
        {
            var result = await base.FindByCondition(x => x.Mail == email && x.PhoneNumber == password);
            if (result == null || result.Count == 0)
            {
                return null;
            }
            return result[0];
        }
    }
}
