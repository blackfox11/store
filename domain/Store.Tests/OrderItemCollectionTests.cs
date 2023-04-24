using System;
using Xunit;

namespace Store.Tests
{
    public class OrderItemCollectionTests
    {
        [Fact]
        public void Get_WithExistingItem_ReturnItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            var orderItem = order.Items.Get(1);
            Assert.Equal(3, orderItem.Count);
        }
        [Fact]
        public void Get_WithNonExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            Assert.Throws<InvalidOperationException>(() => order.Items.Get(3));
        }
        [Fact]
        public void Add_WithExistingItem_ThrowInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            //var book = new Book(1, null, null, null, null, 10m);
            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Add(1, 3, 10m);
            });
        }
        [Fact]
        public void Add_WithNonExistingItem_AddsCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            order.Items.Add(4, 10, 30m);
            //Assert.Equal(10, order.Items.Get(4).Count);
        }
        [Fact]
        public void Add_WithNewItem_SetsCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            order.Items.Add(4, 10, 30m);
            Assert.Equal(10, order.Items.Get(4).Count);
        }
        [Fact]
        public void Remove_WithExistingItem_RemovesItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            order.Items.Remove(1);
            Assert.Single(order.Items);
        }
        [Fact]
        public void Remove_WithNonExistingItem_RemovesItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            Assert.Throws<InvalidOperationException>(() => order.Items.Remove(3));
        }
    }
}
