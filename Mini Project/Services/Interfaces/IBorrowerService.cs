using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.DTOs.AuthorDTO;
using Mini_Project.DTOs.BorrowerDTO;

namespace Mini_Project.Services.Interfaces
{
    public interface IBorrowerService
    {

        void AddBorrower(CreateBorrowerDTO createBorrower);
        List<GetAllBorrowerDTO> GetAllBorrower();
        void RemoveBorrower(int Id);
        void UpdateBorrower(int Id, UpdateBorrowerDTO AuthorDTO);
    }
}
