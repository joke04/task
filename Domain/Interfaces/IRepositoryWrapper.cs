using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IBasketRepository Basket { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IFilterRepository Filter { get; }
        IOrderingRepository Ordering { get; }
        ISavedAddressRepository SavedAddress { get; }
        Task Save();
    }
}
