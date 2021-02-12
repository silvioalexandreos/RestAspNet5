using RestAspNet5.Data.VO;
using System.Collections.Generic;

namespace RestAspNet5.Business
{
    public interface IPersonBusiness
    {
        PersonVO Created(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
