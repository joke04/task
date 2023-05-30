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
    public class FilterService : IFilterService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public FilterService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Filter>> GetAll()
        {
            return await _repositoryWrapper.Filter.FindAll();
        }
        public async Task<Filter> GetById(int id)
        {
            var filter = await _repositoryWrapper.Filter
            .FindByCondition(x => x.IdCategories == id);
            return filter.First();
        }
        public async Task Create(Filter model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.ReleaseForm))
            {
                throw new ArgumentException(nameof(model.ReleaseForm));
            }
            if (string.IsNullOrEmpty(model.VacationFromThePharmacy))
            {
                throw new ArgumentException(nameof(model.VacationFromThePharmacy));
            }
            if (string.IsNullOrEmpty(model.Indications))
            {
                throw new ArgumentException(nameof(model.Indications));
            }
            if (string.IsNullOrEmpty(model.Producer))
            {
                throw new ArgumentException(nameof(model.Producer));
            }
            if (string.IsNullOrEmpty(model.ExpirationDate))
            {
                throw new ArgumentException(nameof(model.ExpirationDate));
            }
            if (string.IsNullOrEmpty(model.BrandName))
            {
                throw new ArgumentException(nameof(model.BrandName));
            }

            await _repositoryWrapper.Filter.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Filter model)
        {
            await _repositoryWrapper.Filter.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var filter = await _repositoryWrapper.Filter
            .FindByCondition(x => x.IdCategories == id);
            await _repositoryWrapper.Filter.Delete(filter.First());
            await _repositoryWrapper.Save();
        }
    }
}
