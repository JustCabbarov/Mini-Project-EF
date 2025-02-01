using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Models;

namespace Mini_Project.Repositories.Interfaces
{
   public interface IGenericRepository <T> where T : BaseEntity , new() 
    {
        void Add(T entity);
        List<T> GettAll();
        void Remove(T entity);
        void Commit();
    }
}
