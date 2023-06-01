using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }
        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.UserNumber == id);
            return user.First();
        }
        public async Task Create(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.Namee))
            {
                throw new ArgumentException(nameof(model.Namee));
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new ArgumentException(nameof(model.LastName));
            }

            if (string.IsNullOrEmpty(model.Nickname))
            {
                throw new ArgumentException(nameof(model.Nickname));
            }

            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                throw new ArgumentException(nameof(model.PhoneNumber));
            }

            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(User model)
        {
            await _repositoryWrapper.User.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.UserNumber == id);
            await _repositoryWrapper.User.Delete(user.First());
            await _repositoryWrapper.Save();
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _repositoryWrapper.User.GetByEmailAndPassword(email, password);
            return user;
        }
    }
}