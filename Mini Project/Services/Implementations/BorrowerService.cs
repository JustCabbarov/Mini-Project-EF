using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.DTOs.BorrowerDTO;
using Mini_Project.Exceptions;
using Mini_Project.Models;
using Mini_Project.Repositories.Implementations;
using Mini_Project.Repositories.Interfaces;
using Mini_Project.Services.Interfaces;

namespace Mini_Project.Services.Implementations
{
    public class BorrowerService : IBorrowerService
    {
        public void AddBorrower(CreateBorrowerDTO createBorrower)
        {
            if (createBorrower == null) throw new InvalidImputException("Imput Can Not BE NULL");
            if (string.IsNullOrEmpty(createBorrower.Name)) throw new InvalidImputException("Imput Can Not Be Empty");
            if (string.IsNullOrEmpty(createBorrower.Email)) throw new InvalidImputException("Imput Can Not Be Empty");
            IBorrowerRepository borroverRepository = new BorrowerRepository();

            Borrower borrower = new Borrower()
            {
                Name = createBorrower.Name,
                Email = createBorrower.Email,
                CreateAt = DateTime.UtcNow.AddHours(4),
                UpdateAt = DateTime.UtcNow.AddHours(4),
               

            };
            borroverRepository.Add(borrower);
            borroverRepository.Commit();
        }

        public List<GetAllBorrower> GetAllBorrower()
        {
            IBorrowerRepository borroverRepository = new BorrowerRepository();
            var data = borroverRepository.GetAll();
            if (data == null) throw new InvalidDataException("Borrowers Dont Found");
            List<GetAllBorrower> AllBorrowers = new List<GetAllBorrower>();
            AllBorrowers = data.Select(x => new GetAllBorrower()
            {
                Name = x.Name,
                Email = x.Email,
               
                
            }).ToList();
            
            return AllBorrowers;
        }

        public void RemoveBorrower(int Id)
        {
            if (Id < 1) throw new InvalidImputException("Id Can Not Be Null");
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            var data = borrowerRepository.GetById(1);
            if (data == null) throw new InvalidDataException("Borrower Not Found");
            data.IsDeleted = true;
            borrowerRepository.Commit();
        }

        public void UpdateBorrower(int Id, UpdateBorrowerDTO borrowerDTO)
        {
            if (Id < 1) throw new InvalidImputException("Id Can Not Be Null");
            if (borrowerDTO == null) throw new InvalidImputException("Borrower Can Not Be Null");
            if (string.IsNullOrEmpty(borrowerDTO.Name)) throw new InvalidImputException("Name Can Not Be Empty");
            if (string.IsNullOrEmpty(borrowerDTO.Email)) throw new InvalidImputException("Email CAn Not Be Empty");
            IBorrowerRepository borrowerRepository= new BorrowerRepository();
            var data=borrowerRepository.GetById(Id);
            data.Name = borrowerDTO.Name;
            data.Email = borrowerDTO.Email;
            data.UpdateAt = DateTime.UtcNow.AddHours(4);
            borrowerRepository.Commit();
        }
    }
}
