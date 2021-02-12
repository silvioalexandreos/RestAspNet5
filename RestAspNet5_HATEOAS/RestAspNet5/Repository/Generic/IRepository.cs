using RestAspNet5.Model;
using RestAspNet5.Model.Base;
using System.Collections.Generic;

namespace RestAspNet5.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Created(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Existe(long id);
    }
}
