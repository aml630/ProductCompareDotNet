using ProductCompareDotNet.Models;
using Xunit;

namespace ToDoList.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var product = new Product();

            //Act
            product.ProductName = "Test Product";
            var result = product.ProductName;

            //Assert
            Assert.Equal("Test Product", result);
        }

        [Fact]
        public void TestAjax()
        {
            //Arrange
            var product = new Product();

            //Act
            product.ProductName = "Test Product";
            var result = product.ProductName;

            //Assert
            Assert.Equal("Test Product", result);
        }
    }
}