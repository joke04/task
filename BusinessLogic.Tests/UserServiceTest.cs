using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;
        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User).
                Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            /* act */
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            /* assert */
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>()
            {
                new object[] {new User() { Namee = "", LastName = "", Patronymic = "", Birthdate = DateTime.MaxValue, Nickname = "", Mail = "", PhoneNumber = ""} },
                new object[] {new User() { Namee = "test", LastName = "", Patronymic = "", Birthdate = DateTime.MaxValue, Nickname = "", Mail = "", PhoneNumber = ""} },
                new object[] {new User() { Namee = "test", LastName = "test", Patronymic = "", Birthdate = DateTime.MaxValue, Nickname = "", Mail = "", PhoneNumber = ""} },

            };
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(User user)
        {
            /* arrange */
            var newUser = user;

            /* act */
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            /* assert */
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new User()
            {
                Namee = "Test",
                LastName = "Test",
                Patronymic = "Test",
                Birthdate = DateTime.Now,
                Nickname = "Test",
                Mail = "test@test.com",
                PhoneNumber = ""
            };

            /* act */
            await service.Create(newUser);

            /* assert */
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }
    }
}
