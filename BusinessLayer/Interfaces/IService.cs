using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IService<T> where T : class
    {
        T Create(T entity);

        IEnumerable<T> GetAll();

        T GetById(int id);

        T Delete(int id);

        T Update(T entity);
    }
}