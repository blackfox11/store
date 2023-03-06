using System;
using System.Collections.Generic;
using System.Linq;
using Store;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12312-31231", "D. Knuth", "Art Of Programming, Vol. 1", 
                "This volume begins with basic programming concepts and techniques, then focuses more particularly on information structures-the representation of information inside a computer, the structural relationships between data elements and how to deal with them efficiently.", 
                7.19m),
            new Book(2, "ISBN 12312-31232", "M. Fowler", "Refactoring", "", 12.45m),
            new Book(3, "ISBN 12312-31232", "B.Kernighan, D. Ritchie", "C Programming Language", "", 14.98m),
        };
        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.ToLower().Contains(query) || book.Author.ToLower().Contains(query)).ToArray();
        }
        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }
        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return foundBooks.ToArray();
        }
    }
}
