﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Models;

namespace Mini_Project.Repositories.Interfaces
{
    public interface ILoanItemRepository :IGenericRepository<LoanItem>
    {
        List<LoanItem> GetAll();
        LoanItem GetById(int id);
    }
}
