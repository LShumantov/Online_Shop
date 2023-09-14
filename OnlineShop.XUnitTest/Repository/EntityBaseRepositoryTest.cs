using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Data.Base;
using OnlineShop.XUnitTest.MemoryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.XUnitTest.Repository
{
    public class EntityBaseRepositoryTest
    {
        private readonly MemoryDataContex _contex;
        public EntityBaseRepositoryTest()
        {
            _contex = new MemoryDataContex();
        }

        public async void EntityRepository_GetEntity_ReturnEntity()
        {
            // arrange
            var mockRepo = new Mock<EntityBaseRepository>();
            mockRepo.Setup(m => m.GetAll()).Returns(SiteToSiteMockData.GetSiteToSites());
            var emptyDbContext = new PharmacyDBContext();   //won't test the AJAX calls
            var controller = new SiteToSiteController(emptyDbContext, mockRepo.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.True(viewResult.ViewData.Count > 0, "viewResult does not have any records, as it should");
            var viewResultSites = Assert.IsAssignableFrom<List<SiteToSite>>(viewResult.ViewData.Model);
            if (viewResultSites.Count > 0)
            {
                // NOTE: I do not like this; it violates unit testing.
                Assert.Equal(2, viewResultSites.Count);
                Assert.Equal("John Doe", viewResultSites[0]?.OrderedByName);
                ////Arrange
                //var id = 1;
                //var dbContext = await _contex.GetDatabaseContext();
                //var EntityRepository = new EntityBaseRepository(dbContext);
                ////Act
                //var result = await EntityRepository.GetAuthor(id);
                ////Assert
                //result.Should().NotBeNull();
                //result.Should().BeOfType<entity>();
            }
        [Fact]
        public async void EntityRepository_GetEntitys_ReturnEntitys()
        {
            //Arrange           
            var dbContext = await _contex.GetDatabaseContext();
            var authorRepository = new AuthorRepository(dbContext);
            //Act
            var result = await authorRepository.GetAuthors();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Author>>();
        }
    }
}
