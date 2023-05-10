using DataAccess.Wrapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class BasketService
    {
        IRepositoryWrapper _repositoryWrapper;
        public BasketService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Basket>> GetAll()
        {
            return await _repositoryWrapper.Basket.FindAll();
        }
        public async Task<Basket> GetById(int id)
        {
            var Basket = await _repositoryWrapper.Basket
            .FindByCondition(x => x.BasketNumber == id);
            return Basket.First();
        }
        public async Task Create(Basket model)
        {
            await _repositoryWrapper.Basket.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Basket model)
        {
            await _repositoryWrapper.Basket.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Basket = await _repositoryWrapper.Basket
            .FindByCondition(x => x.BasketNumber == id);
            await _repositoryWrapper.Basket.Delete(Basket.First());
            await _repositoryWrapper.Save();
        }
    }
}
