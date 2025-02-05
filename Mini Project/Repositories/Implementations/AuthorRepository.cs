using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mini_Project.Data;
using Mini_Project.Models;
using Mini_Project.Repositories.Interfaces;

namespace Mini_Project.Repositories.Implementations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        AppDbContext _appDbContext;
        public AuthorRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public List<Author> GetAll()
        {
          return _appDbContext.Authors.Where(x=>!x.IsDeleted).Include(x=>x.Books).ToList();
        }

        public Author GetById(int id)
        {
           return _appDbContext.Authors.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
        }
    }
}
