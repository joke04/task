using DataAccess.Wrapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SavedAddressService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public SavedAddressService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<SavedAddress>> GetAll()
        {
            return await _repositoryWrapper.SavedAddress.FindAll();
        }
        public async Task<SavedAddress> GetById(int id)
        {
            var adres = await _repositoryWrapper.SavedAddress
            .FindByCondition(x => x.AddressName == id);
            return adres.First();
        }
        public async Task Create(SavedAddress model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.City))
            {
                throw new ArgumentException(nameof(model.City));
            }
            if (string.IsNullOrEmpty(model.Street))
            {
                throw new ArgumentException(nameof(model.Street));
            }
            if (string.IsNullOrEmpty(model.AddressName))
            {
                throw new ArgumentException(nameof(model.AddressName));
            }
            await _repositoryWrapper.SavedAddress.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(SavedAddress model)
        {
            await _repositoryWrapper.SavedAddress.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var adres = await _repositoryWrapper.SavedAddress
            .FindByCondition(x => x.AddressName == id);
            await _repositoryWrapper.SavedAddress.Delete(adres.First());
            await _repositoryWrapper.Save();
        }
    }
}
