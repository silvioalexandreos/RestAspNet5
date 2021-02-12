using RestAspNet5.Data.VO;
using System.Collections.Generic;

namespace RestAspNet5.Business
{
    public interface IBookBusiness
    {
        List<BookVO> FindAll();
        BookVO FindById(long id);
        BookVO Created(BookVO book);
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
