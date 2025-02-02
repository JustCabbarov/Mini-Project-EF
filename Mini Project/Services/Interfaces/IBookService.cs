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
        void AddBook(CreatedBookDTO createdBookDTO);
        List<GetAllBookDTO> GettAll();
        void RemoveBook(int Id);
        void UpdateBook (int Id, UpdateBookDTO updateBookDTO);
    }
}
