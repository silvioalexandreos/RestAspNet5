using RestAspNet5.Model;
using System.Collections.Generic;

namespace RestAspNet5.Services
{
    public interface IPersonService
    {
        Person Created(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
