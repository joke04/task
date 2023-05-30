using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class OrderingService : IOrderingService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public OrderingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Ordering>> GetAll()
        {
            return await _repositoryWrapper.Ordering.FindAll();
        }
        public async Task<Ordering> GetById(int id)
        {
            var order = await _repositoryWrapper.Ordering
            .FindByCondition(x => x.OrderNumber == id);
            return order.First();
        }
        public async Task Create(Ordering model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }


            if (string.IsNullOrEmpty(model.Statuss))
            {
                throw new ArgumentException(nameof(model.Statuss));
            }
            await _repositoryWrapper.Ordering.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Ordering model)
        {
            await _repositoryWrapper.Ordering.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var order = await _repositoryWrapper.Ordering
            .FindByCondition(x => x.OrderNumber == id);
            await _repositoryWrapper.Ordering.Delete(order.First());
            await _repositoryWrapper.Save();
        }
    }
}
