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
    public class ProductServiceTest
    {
        private readonly ProductService service;
        private readonly Mock<IProductRepository> productRepositoryMoq;

        public ProductServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            productRepositoryMoq = new Mock<IProductRepository>();

            repositoryWrapperMoq.Setup(ex => ex.Product)
                .Returns(productRepositoryMoq.Object);

            service = new ProductService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectProduct()
        {
            return new List<object[]>
            {
                new object[] { new Product() },
                new object[] { new Product() { NumberProduct = 101 } },
                new object[] { new Product() { NumberProduct = 101, ProductDescription = "Text" } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            /* act */
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            /* assert */
            Assert.IsType<ArgumentNullException>(ex);
            productRepositoryMoq.Verify(meow => meow.Create(It.IsAny<Product>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectProduct))]
        public async Task CreateAsyncNewUser_ShouldNot(Product product)
        {
            /* arrange */
            var newProduct = product;

            /* act */
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newProduct));

            /* assert */
            productRepositoryMoq.Verify(meow => meow.Create(It.IsAny<Product>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            /* arrange */
            var newProd = new Product() { ProductPrice = 5.5m, NumberProduct = 101, Namee = "Text", IdCategories = 1, ProductDescription = "descr of text", Article = 10 };

            /* act */
            await service.Create(newProd);

            /* assert */
            productRepositoryMoq.Verify(meow => meow.Create(It.IsAny<Product>()), Times.Once);
        }
    }
}
