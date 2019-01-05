using Models;
using System.Collections.Generic;


namespace Services
{
   public interface IServices<T> where T:class, IEntity
    {
        T getById(int Id);
        List<T> getAll();
        void Add(T t);
    }
}
