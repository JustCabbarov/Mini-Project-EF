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
    public class BorrowerRepository : GenericRepository<Borrower>, IBorrowerRepository
    {

        AppDbContext _appDbContext;
        public BorrowerRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public List<Borrower> GetAll()
        {
           return _appDbContext.Borrowers.Include(x=>x.Loans).ToList();
        }

        public Borrower GetById(int id)
        {
          return _appDbContext.Borrowers.Include(x=>x.Loans).FirstOrDefault(x=>x.Id == id);
        }
    }
}
