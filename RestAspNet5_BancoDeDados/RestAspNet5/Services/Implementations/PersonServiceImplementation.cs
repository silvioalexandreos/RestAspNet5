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

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(x => x.Id.Equals(id));
        }

        public Person Created(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar o Person", ex);
            }

            return person;
        }

        public Person Update(Person person)
        {
            if (!Existe(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {

                    //ler sobre esse comando.
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception("Não possível atualizar", ex);
                }
            }
            return person;
        }

        

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool Existe(long id)
        {
            return _context.Persons.Any(x => x.Id.Equals(id));
        }
    }
}
