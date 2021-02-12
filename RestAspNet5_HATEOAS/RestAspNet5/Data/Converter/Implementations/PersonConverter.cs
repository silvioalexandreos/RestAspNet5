using RestAspNet5.Data.Converter.Contract;
using RestAspNet5.Data.VO;
using RestAspNet5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAspNet5.Data.Converter.Implementations
{
    public class PersonConverter : IParse<PersonVO, Person>, IParse<Person, PersonVO>
    {
        public PersonVO Parse(Person origem)
        {
            if (origem == null) return null;

            return new PersonVO
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public Person Parse(PersonVO origem)
        {
            if (origem == null) return null;

            return new Person
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public List<PersonVO> Parse(List<Person> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }

        public List<Person> Parse(List<PersonVO> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
