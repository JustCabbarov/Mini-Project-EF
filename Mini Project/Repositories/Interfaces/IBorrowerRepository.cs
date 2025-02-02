using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Models;

namespace Mini_Project.Repositories.Interfaces
{
    public interface IBorrowerRepository : IGenericRepository<Borrower>
    {
        List<Borrower> GetAll();
        Borrower GetById(int id);
    }
}
