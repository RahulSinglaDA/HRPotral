using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotralAPI.Repositories
{
    public interface IRepository<T>
    {
        public void Add(T e);
        public T Get(int ID);
        public void Update(int id, T e);
        public IEnumerable<T> GetAll();
        public void Delete(int id);
    }
}
