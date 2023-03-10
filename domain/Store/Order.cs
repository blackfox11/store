﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class Order
    {
        public int Id { get; }
        private List<OrderItem> items;
        public IReadOnlyCollection<OrderItem> Items => items;
        public int TotalCount => items.Sum(item => item.Count);
        public decimal TotalPrice => items.Sum(item => item.Price * item.Count);
        public Order(int id, IEnumerable<OrderItem> items)
        {
            if(items == null)
                throw new ArgumentNullException(nameof(items));
            Id = id;
            this.items = new List<OrderItem>(items);
        }
        public OrderItem GetItem(int bookId)
        {
            int index = items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
                ThrowBookException("Book not found.", bookId);
            return items[index];
        }
        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            int index = items.FindIndex(item => item.BookId == book.Id);
            if (index == -1)
                items.Add(new OrderItem(book.Id, count, book.Price));
            else
                items[index].Count += count;
        }
        public void RemoveItem(int bookId)
        {
            int index = items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
                ThrowBookException("Order does not contain specified item.", bookId);

            items.RemoveAt(index);
        }
        //public void AddItem(Book book, int count)
        //{
        //    if(book == null)
        //    {
        //        throw new ArgumentNullException(nameof(book));
        //    }
        //    var item = items.SingleOrDefault(x => x.BookId == book.Id);
        //    if(item == null)
        //    {
        //        items.Add(new OrderItem(book.Id, count, book.Price));
        //    }
        //    else
        //    {
        //        //item.Count += count;
        //        items.Remove(item);
        //        items.Add(new OrderItem(book.Id, item.Count + count, book.Price));
        //    }
        //}

        private void ThrowBookException(string message, int bookId)
        {
            var exception = new InvalidOperationException(message);
            exception.Data["BookId"] = bookId;
            throw exception;
        }
    }
}
