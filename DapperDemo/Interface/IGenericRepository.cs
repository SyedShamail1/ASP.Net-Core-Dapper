using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Interface
{
    public interface IGenericRepository<T>  where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Insert(T admin);
        T Update(T admin);
        void Delete(int id);
    }
}
