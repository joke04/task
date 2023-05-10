using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BasketRepository : RepositoriesBase<Basket>, IBasketRepository
    {
        public BasketRepository(shop_pharmacyContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
