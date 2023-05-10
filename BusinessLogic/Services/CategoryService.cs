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
    public class CategoryService : ICategoryService
    {
        IRepositoryWrapper _repositoryWrapper;
        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll();
        }
        public async Task<Category> GetById(int id)
        {
            var Category = await _repositoryWrapper.Category
            .FindByCondition(x => x.IdCategories == id);
            return Category.First();
        }
        public async Task Create(Category model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.IdCategories == 0)
            {
                throw new ArgumentException(nameof(model.IdCategories));
            }

            if (string.IsNullOrEmpty(model.CategoryName))
            {
                throw new ArgumentException(nameof(model.CategoryName));
            }

            await _repositoryWrapper.Category.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Category model)
        {
            await _repositoryWrapper.Category.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Category = await _repositoryWrapper.Category
            .FindByCondition(x => x.IdCategories == id);
            await _repositoryWrapper.Category.Delete(Category.First());
            await _repositoryWrapper.Save();
        }
    }
}
