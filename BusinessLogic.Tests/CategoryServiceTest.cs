using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Moq;

namespace BusinessLogic.Tests
{
    public class CategoryServiceTest
    {
        private readonly CategoryService service;
        private readonly Mock<ICategoryRepository> categoryRepositoryMoq;

        public CategoryServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            categoryRepositoryMoq = new Mock<ICategoryRepository>();

            repositoryWrapperMoq.Setup(ex => ex.Category)
                .Returns(categoryRepositoryMoq.Object);

            service = new CategoryService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCategory()
        {
            return new List<object[]>
            {
                new object[] { new Category() },
                new object[] { new Category() { IdCategories = 101 } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            /* act */
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            /* assert */
            Assert.IsType<ArgumentNullException>(ex);
            categoryRepositoryMoq.Verify(ex => ex.Create(It.IsAny<Category>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCategory))]
        public async Task CreateAsyncNewUser_ShouldNot(Category category)
        {
            /* arrange */ 
            var newCustomer = category;

            /* act */
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newCustomer));

            /* assert */
            categoryRepositoryMoq.Verify(ex => ex.Create(It.IsAny<Category>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            /* arrange */
            var newCustomer = new Category() { IdCategories = 102, CategoryName = "Text" };

            /* act */
            await service.Create(newCustomer);

            /* assert */
            categoryRepositoryMoq.Verify(ex => ex.Create(It.IsAny<Category>()), Times.Once);
        }
    }
}
