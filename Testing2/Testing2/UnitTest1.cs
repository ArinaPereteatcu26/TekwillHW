using Moq;
using ShoppingCartLib;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCartLib.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void AddToCart_ProductIsAdded()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var product = new Product { ProductId = 1, Name = "Test Product", Price = 10.0m };
            mockProductRepository.Setup(repo => repo.GetProductById(1)).Returns(product);

            var cart = new ShoppingCart(mockProductRepository.Object);

            // Act
            cart.AddToCart(1);

            // Assert
            var cartItems = cart.GetCartItems();
            Assert.Single(cartItems);
            Assert.Equal(product, cartItems.First());
        }

        [Fact]
        public void CalculateTotal_ReturnsCorrectTotal()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.GetProductById(It.IsAny<int>())).Returns((int id) => new Product { ProductId = id, Name = "Test Product", Price = 10.0m });

            var cart = new ShoppingCart(mockProductRepository.Object);
            cart.AddToCart(1);
            cart.AddToCart(2);

            // Act
            var total = cart.CalculateTotal();

            // Assert
            Assert.Equal(20.0m, total);
        }
    }
}