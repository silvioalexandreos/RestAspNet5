using RestAspNet5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAspNet5.Business
{
    public interface IBookBusiness
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Created(Book book);
        Book Update(Book book);
        void Delete(long id);
    }
}
