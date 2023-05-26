using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class FilterRepository : RepositoriesBase<Filter>, IFilterRepository
    {
        public FilterRepository(shop_pharmacyContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
