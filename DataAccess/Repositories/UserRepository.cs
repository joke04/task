using DataAccess.Interfaces;
using DataAccess.Models;
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
    }
}
