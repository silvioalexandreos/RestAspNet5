using RestAspNet5.Model;
using System.Collections.Generic;

namespace RestAspNet5.Repository
{
    public interface IPersonRepository
    {
        Person Created(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Existe(long id);
    }
}
