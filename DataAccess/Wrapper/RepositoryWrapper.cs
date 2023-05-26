using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        shop_pharmacyContext _repoContext;
        IUserRepository _user;
        IProductRepository _product;
        ICategoryRepository _category;
        IBasketRepository _basket;
        IFilterRepository _filter;
        IOrderingRepository _ordering;
        ISavedAddressRepository _savedAddress;

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_repoContext);
                return _user;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (_product == null) _product = new ProductRepository(_repoContext);
                return _product;
            }
        }
        public ICategoryRepository Category
        {
            get
            {
                if (_category == null) _category = new CategoryRepository(_repoContext);
                return _category;
            }
        }
        public IBasketRepository Basket
        {
            get
            {
                if (_basket == null) _basket = new BasketRepository(_repoContext);
                return _basket;
            }
        }
        public IFilterRepository Filter
        {
            get
            {
                if (_filter == null) _filter = new FilterRepository(_repoContext);
                return _user;
            }
        }

        public RepositoryWrapper(shop_pharmacyContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}