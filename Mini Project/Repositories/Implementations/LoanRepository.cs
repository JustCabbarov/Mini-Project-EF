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
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        AppDbContext _appDbContext;
        public LoanRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public List<Loan> GetAll()
        {
            return _appDbContext.Loans.Include(x=>x.LoanItems).ToList();
        }

        public Loan GetById(int id)
        {
          return _appDbContext.Loans.Include(x=>x.LoanItems).FirstOrDefault(x=>x.Id==id); 
        }
    }
}
