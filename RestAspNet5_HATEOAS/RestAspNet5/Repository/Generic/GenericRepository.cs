using Microsoft.EntityFrameworkCore;
using RestAspNet5.Model.Base;
using RestAspNet5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAspNet5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySqlContext _context;
        private DbSet<T> dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T Created(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar o Person", ex);
            }
        }

        public T FindById(long id)
        {
            return dataSet.SingleOrDefault(x => x.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = dataSet.SingleOrDefault(x => x.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível salvar o Person", ex);
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(x => x.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível salvar o Person", ex);
                }
            }
        }

        public bool Existe(long id)
        {
            return dataSet.Any(x => x.Id.Equals(id));
        }
    }
}
