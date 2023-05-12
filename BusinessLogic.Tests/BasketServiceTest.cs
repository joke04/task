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
    public class BasketServiceTest
    {
        private readonly BasketService service;
        private readonly Mock<IBasketRepository> basketRepositoryMoq;

        public BasketServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            basketRepositoryMoq = new Mock<IBasketRepository>();

            repositoryWrapperMoq.Setup(meow => meow.Basket)
                .Returns(basketRepositoryMoq.Object);

            service = new BasketService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectBasket()
        {
            return new List<object[]>
            {
                new object[] { new Basket() },
                new object[] { new Basket() { BasketNumber = 101 } },
                new object[] { new Basket() { BasketNumber = 101, QuantityOfGoods = 10 } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            /* act */
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            /* assert */
            Assert.IsType<ArgumentNullException>(ex);
            basketRepositoryMoq.Verify(meow => meow.Create(It.IsAny<Basket>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectBasket))]
        public async Task CreateAsyncNewUser_ShouldNot(Basket manufacturer)
        {
            /* arrange */
            var newCustomer = manufacturer;

            /* act */
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newCustomer));

            /* assert */
            basketRepositoryMoq.Verify(meow => meow.Create(It.IsAny<Basket>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            /* arrange */
            var newCustomer = new Basket() { BasketNumber = 102, QuantityOfGoods = 10, UserIdd = 1 };

            /* act */
            await service.Create(newCustomer);

            /* assert */
            basketRepositoryMoq.Verify(meow => meow.Create(It.IsAny<Basket>()), Times.Once);
        }
    }
}
