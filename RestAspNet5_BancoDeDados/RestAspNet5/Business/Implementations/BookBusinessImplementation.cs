using MySql.Data.MySqlClient;
using RestAspNet5.Data.Converter.Implementations;
using RestAspNet5.Data.VO;
using RestAspNet5.Model;
using RestAspNet5.Repository;
using RestAspNet5.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAspNet5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Created(BookVO book)
        {
            var parseBook = _converter.Parse(book);
            parseBook = _repository.Created(parseBook);
            return _converter.Parse(parseBook);

        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse( _repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var parseBook = _converter.Parse(book);
            parseBook = _repository.Update(parseBook);
            return _converter.Parse(parseBook);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
