using Data;
using Moq;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemUnitTests
{
    public class ItemRepositoryTests
    {
        private readonly Mock<ItemDbContext> _mockContext;
        private readonly ItemRepository _repository;

        public ItemRepositoryTests()
        {
            _mockContext = new Mock<ItemDbContext>();
            _repository = new ItemRepository(_mockContext.Object);
        }

        [Fact]
        public async Task Create_AddsItemToContext()
        {
            // Arrange
            var item = new Item { /* set item properties */ };

            // Act
            await _repository.Create(item);

            // Assert
            _mockContext.Verify(c => c.SaveChanges(item), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task Delete_RemovesItemFromContext()
        {
            // Arrange
            var item = new Item { Id = 1 };
            _mockContext.Setup(c => c.Delete<Item>(1)).ReturnsAsync(item);

            // Act
            await _repository.Delete(1);

            // Assert
            _mockContext.Verify(c => c.Remove(item), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task Update_ModifiesItemInContext()
        {
            // Arrange
            var item = new Item { /* set item properties */ };

            // Act
            await _repository.Update(item);

            // Assert
            _mockContext.Verify(c => c.Entry(item).State = EntityState.Modified, Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}
