using RestAspNet5.Model;
using RestAspNet5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAspNet5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

        private readonly MySqlContext _context;

        public PersonServiceImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Person Created(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Silvio",
                LastName = "Alexandre",
                Address = "Cocalzinho de Goiás - Goiás",
                Gender = "Masculino"
            };
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
