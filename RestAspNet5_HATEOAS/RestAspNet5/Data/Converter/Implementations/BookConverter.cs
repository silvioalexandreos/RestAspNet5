using RestAspNet5.Data.Converter.Contract;
using RestAspNet5.Data.VO;
using RestAspNet5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAspNet5.Data.Converter.Implementations
{
    public class BookConverter : IParse<BookVO, Book>, IParse<Book, BookVO>
    {
        public BookVO Parse(Book origem)
        {
            if (origem == null) return null;

            return new BookVO
            {
                Id = origem.Id,
                Author = origem.Author,
                LaunchDate = origem.LaunchDate,
                Price = origem.Price,
                Title = origem.Title
            };
        }

        public Book Parse(BookVO origem)
        {
            if (origem == null) return null;

            return new Book
            {
                Id = origem.Id,
                Author = origem.Author,
                LaunchDate = origem.LaunchDate,
                Price = origem.Price,
                Title = origem.Title
            };
        }

        public List<BookVO> Parse(List<Book> origem)
        {
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<Book> Parse(List<BookVO> origem)
        {
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
