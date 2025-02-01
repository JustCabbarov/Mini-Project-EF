using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.DTOs.BookDtO;
using Mini_Project.Models;

namespace Mini_Project.Services.Interfaces
{
    public interface IBookService
    {
        void Add(CreatedBookDTO createdBookDTO);
        List<GetAllBookDTO> GettAll();
        void Remove(int Id);
        void Update (int Id, UpdateBookDTO updateBookDTO);
    }
}
