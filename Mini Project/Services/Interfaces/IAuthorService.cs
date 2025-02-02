using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.DTOs.AuthorDTO;
using Mini_Project.DTOs.BookDtO;

namespace Mini_Project.Services.Interfaces
{
    public interface IAuthorService
    {

        void AddAuthor(CreateAuthorDTO AuthorDTO);
        List<GetAllAuthorDTO> GetAllAuthors();
        void RemoveAuthor(int Id);
        void UpdateAuthor(int Id, UpdateAuthorDTO  AuthorDTO);
    }
}
