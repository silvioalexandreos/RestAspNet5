using RestAspNet5.Model;
using RestAspNet5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAspNet5.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private readonly MySqlContext _context;

        public BookRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(x => x.Id.Equals(id));
        }

        public Book Creat(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public Book Update(Book book)
        {
            if (!Exist(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(x => x.Id.Equals(book.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possivel atualizar", ex); ;
                }  
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(x => x.Id.Equals(id));

            if (result != null)
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool Exist(long id)
        {
            return _context.Books.Any(x => x.Id.Equals(id));
        }
    }
}
