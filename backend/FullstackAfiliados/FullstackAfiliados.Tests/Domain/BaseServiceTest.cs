using System.Linq.Expressions;
using FullstackAfiliados.Domain.Entities.Base;
using FullstackAfiliados.Domain.Services.Implemented;
using FullstackAfiliados.Tests.Factory;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FullstackAfiliados.Tests.Domain
{
    public class BaseServiceTests
    {
        #region Setup

        private readonly Mock<DbContext> _dbContextMock;
        private readonly Mock<DbSet<Entity>> _dbSetMock;
        private readonly BaseService<Entity> _service;

        public BaseServiceTests()
        {
            _dbContextMock = new Mock<DbContext>();
            _dbSetMock = new Mock<DbSet<Entity>>();
            _dbContextMock.Setup(ctx => ctx.Set<Entity>()).Returns(_dbSetMock.Object);
            _service = new BaseService<Entity>(_dbContextMock.Object);
        }

        #endregion

        #region GetByIdAsync Tests

        [Fact]
        public async Task GetByIdAsyncSuccessfully()
        {
            #region Arrange

            var entity = EntityFactory.GetGenericMockedEntity;
            var entityId = entity.Id;
            _dbSetMock.Setup(ds => ds.FindAsync(entityId)).ReturnsAsync(entity);

            #endregion

            #region Act

            var result = await _service.GetByIdAsync(entityId);

            #endregion

            #region Assert

            Assert.Equal(entityId, result.Id);

            #endregion
        }

        #endregion

        #region CreateAsync Tests

        [Fact]
        public async Task CreateAsyncSuccessfully()
        {
            #region Arrange

            var entity = EntityFactory.GetGenericMockedEntity;

            #endregion

            #region Act

            await _service.CreateAsync(entity);

            #endregion

            #region Assert

            _dbSetMock.Verify(ds => ds.Add(entity), Times.Once);

            #endregion
        }

        #endregion

        #region DeleteAsync Tests

        [Fact]
        public async Task DeleteAsyncSuccessfully()
        {
            #region Arrange

            var entity = EntityFactory.GetGenericMockedEntity;
            var entityId = entity.Id;

            _dbSetMock.Setup(ds => ds.FindAsync(entityId)).ReturnsAsync(entity);

            #endregion

            #region Act

            var result = await _service.DeleteAsync(entityId);

            #endregion

            #region Assert

            Assert.True(result.IsDeleted);

            #endregion
        }

        #endregion

        #region UpdateAsync Tests

        [Fact]
        public async Task UpdateAsyncSuccessfully()
        {
            #region Arrange

            var entity = EntityFactory.GetGenericMockedEntity;
            var entityId = entity.Id;
            var originalDate = entity.ModifyAt;

            _dbSetMock.Setup(ds => ds.FindAsync(entityId)).ReturnsAsync(entity);

            #endregion

            #region Act

            var result = await _service.UpdateAsync(entityId, entity);

            #endregion

            #region Assert

            Assert.NotEqual(originalDate, result.ModifyAt);

            #endregion
        }

        #endregion
    }
}
