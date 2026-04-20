using Xunit;
using NorthwindCatalog.Services.DTOs;

namespace NorthwindCatalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            // Arrange
            var product = new ProductDto
            {
                UnitPrice = 10,
                UnitsInStock = 5
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(50, result);
        }
    }
}