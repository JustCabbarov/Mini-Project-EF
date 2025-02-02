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
    public class LoanItemRepository : GenericRepository<LoanItem>, ILoanItemRepository
    {

        AppDbContext _appDbContext;
        public LoanItemRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public List<LoanItem> GetAll()
        {
            return _appDbContext.LoanItems.Include(x=>x.Loan).Include(x=>x.Book).ToList();
        }

        public LoanItem GetById(int id)
        {
          return _appDbContext.LoanItems.Include(x=>x.Loan).Include(x=>x.Book).FirstOrDefault(x=>x.Id==id);
        }
    }
}
