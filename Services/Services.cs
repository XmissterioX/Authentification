using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public  class  Services<T>:IServices<T> where T: class, IEntity
    {
        private readonly Context context;

        public Services()
        {
            this.context = new Context();
            
        }

        public void Add(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public List<T> getAll()
        {
            return context.Set<T>().ToList();
        }

        public T getById(int Id)
        {
            return context.Set<T>().Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
