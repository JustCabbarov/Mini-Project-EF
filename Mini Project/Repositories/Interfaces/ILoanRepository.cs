﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Models;

namespace Mini_Project.Repositories.Interfaces
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        List<Loan> GetAll();
        Loan GetById(int id);
    }
}
