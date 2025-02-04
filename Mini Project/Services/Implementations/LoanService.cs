using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.DTOs.BookDtO;
using Mini_Project.DTOs.LoanDTO;
using Mini_Project.Exceptions;
using Mini_Project.Models;
using Mini_Project.Repositories.Implementations;
using Mini_Project.Repositories.Interfaces;
using Mini_Project.Services.Interfaces;

namespace Mini_Project.Services.Implementations
{
    public class LoanService : ILoanService
    {
        public void AddLoan(CreatedLoanDTO createdLoanDTO)
        {
            if (createdLoanDTO == null) throw new InvalidImputException("Imput Can not Be Null");
            if (createdLoanDTO.LoanDate > DateTime.UtcNow.AddHours(4)) throw new InvalidImputException("LoanDate Can Not Be Later Than Today");
            if (createdLoanDTO.MustReturnDate > DateTime.UtcNow.AddHours(4)) throw new InvalidImputException("MustReturnDate Can Not Be Later Than Today");
            ILoanRepository loanRepository = new LoanRepository();
            Loan loan = new Loan()
            {
                BorrowerId = createdLoanDTO.BorrowerId,
                LoanDate = createdLoanDTO.LoanDate,
                MustReturnDate = createdLoanDTO.MustReturnDate,


            };

            loanRepository.Add(loan);
            loanRepository.Commit();
        }

        public List<GetAllLoanDTO> GetAllLoan()
        {
            ILoanRepository loanRepository = new LoanRepository();
            var data = loanRepository.GetAll();
            if (data == null) throw new InvalidDataException("Loans Dont Found");
            List<GetAllLoanDTO> getAlls = new List<GetAllLoanDTO>();

            getAlls = data.Select(data => new GetAllLoanDTO
            {
                LoanIthems = data.LoanItems.Select(x => x.BookId).ToList(),


                LoanDate = data.LoanDate,
                MustReturnDate = data.MustReturnDate,
                BorrowerId = data.BorrowerId


            }).ToList();
            return getAlls;
        }

        public void RemoveLoan(int Id)
        {
            if (Id < 1) throw new InvalidImputException("Id Must Be Bigger Than 1");
            ILoanRepository loanRepository = new LoanRepository();
            var data = loanRepository.GetById(Id);
            if (data == null) throw new InvalidDataException("Loan Dont Found");
            data.IsDeleted = true;
            loanRepository.Commit();
        }

        public void UpdateLoan(int Id, UpdateLoanDTO updateLoanDTO)
        {
            if (Id < 1) throw new InvalidImputException("Id Must Be Bigger Than 1");
            if (updateLoanDTO == null) throw new InvalidImputException("Imput Can not Be Null");
            if (updateLoanDTO.LoanDate > DateTime.UtcNow.AddHours(4)) throw new InvalidImputException("LoanDate Can Not Be Later Than Today");
            if (updateLoanDTO.MustReturnDate > DateTime.UtcNow.AddHours(4)) throw new InvalidImputException("LoanDate Can Not Be Later Than Today");
            ILoanRepository loanRepository = new LoanRepository();
            var data = loanRepository.GetById(Id);
            data.MustReturnDate = updateLoanDTO.MustReturnDate;
            data.LoanDate = updateLoanDTO.LoanDate;
           
            data.UpdateAt = DateTime.UtcNow.AddHours(4);
            loanRepository.Commit();

        }
    }
}
