using DataAccess.Wrapper;
using Domain.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        IRepositoryWrapper _repositoryWrapper;
        public ProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _repositoryWrapper.Product.FindAll();
        }
        public async Task<Product> GetById(int id)
        {
            var Product = await _repositoryWrapper.Product
            .FindByCondition(x => x.NumberProduct == id);
            return Product.First();
        }
        public async Task Create(Product model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.NumberProduct == 0)
            {
                throw new ArgumentException(nameof(model.NumberProduct));
            }

            if (string.IsNullOrEmpty(model.Namee))
            {
                throw new ArgumentException(nameof(model.Namee));
            }

            await _repositoryWrapper.Product.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Product model)
        {
            await _repositoryWrapper.Product.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Product = await _repositoryWrapper.Product
            .FindByCondition(x => x.NumberProduct == id);
            await _repositoryWrapper.Product.Delete(Product.First());
            await _repositoryWrapper.Save();
        }
    }
}
