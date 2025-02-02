using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Data;
using Mini_Project.Models;
using Mini_Project.Repositories.Interfaces;

namespace Mini_Project.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _appDbContext;
        public GenericRepository()
        =>_appDbContext = new AppDbContext();
        public void Add(T entity)
        => _appDbContext.Set<T>().Add(entity);

        public void Commit()
        => _appDbContext.SaveChanges();

       
        public void Remove(T entity)
       => _appDbContext.Set<T>().Remove(entity);












    }
}
