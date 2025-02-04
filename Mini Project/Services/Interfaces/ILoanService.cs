using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.DTOs.BorrowerDTO;
using Mini_Project.DTOs.LoanDTO;

namespace Mini_Project.Services.Interfaces
{
    public interface ILoanService
    {
        void AddLoan(CreatedLoanDTO createdLoanDTO);
        List<GetAllLoanDTO> GetAllLoan();
        void RemoveLoan(int Id);
        void UpdateLoan(int Id, UpdateLoanDTO updateLoanDTO);
    }
}
