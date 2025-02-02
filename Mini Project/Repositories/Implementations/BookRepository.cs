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
    public class BookRepository : GenericRepository<Book>,IBookRepository 
    {
        AppDbContext _appDbContext;
        public BookRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public List<Book> GetAll()
        {
            return _appDbContext.Books.Include(x=>x.Authors).ToList();
        }

        public Book GetById(int id)
        {
            return _appDbContext.Books.Include(x=>x.Authors).FirstOrDefault(x => x.Id == id);
        }
    }
}

