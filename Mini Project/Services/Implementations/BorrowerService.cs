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
            IBorrowerRepository repository = new BorrowerRepository();  

            Borrower borrower = new Borrower()
            {
                Name = createBorrower.Name,
                Email = createBorrower.Email,

            };
            repository.Add(borrower);
            repository.Commit();
        }

        public List<GetAllBorrower> GetAllBorrower()
        {
            IBorrowerRepository repository= new BorrowerRepository();
            var data = repository.GetAll();
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
            throw new NotImplementedException();
        }

        public void UpdateBorrower(int Id, UpdateBorrowerDTO AuthorDTO)
        {
            throw new NotImplementedException();
        }
    }
}
