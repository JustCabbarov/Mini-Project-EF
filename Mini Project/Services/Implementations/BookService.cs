using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.DTOs.BookDtO;
using Mini_Project.Exceptions;
using Mini_Project.Models;
using Mini_Project.Repositories.Implementations;
using Mini_Project.Repositories.Interfaces;
using Mini_Project.Services.Interfaces;

namespace Mini_Project.Services.Implementations
{
    public class BookService : IBookService
    {
        public void Add(CreatedBookDTO createdBookDTO)
        {
            if (createdBookDTO == null) throw new InvalidImputException("Imput Can not Be Null");
            if (string.IsNullOrWhiteSpace(createdBookDTO.Title)) throw new InvalidImputException("Imput Can not Be Null");
            IBookRepository bookRepository = new BookRepository();
        
            Book book1 = new Book()
            {
                Title = createdBookDTO.Title,
                Description = createdBookDTO.Description,
                PublishedYear = createdBookDTO.PublishedYear,
                CreateAt = DateTime.UtcNow.AddHours(4),
                IsDeleted=false,
            };
            bookRepository.Add(book1);
            bookRepository.Commit();  
        }
              
                


         
        public List<GetAllBookDTO> GettAll()
        {
          IBookRepository bookRepository = new BookRepository();
            var data=bookRepository.GettAll();
            if (data == null) throw new InvalidDataException("Books Not Found");
            List<GetAllBookDTO> result = new List<GetAllBookDTO>();
           result =data.Select(x => new GetAllBookDTO()
            {
                Title = x.Title,
                Description = x.Description,
                PublishedYear = x.PublishedYear,
                

            }).ToList();
            return result;
        }

        public void Remove(int Id)
        {
            if (Id < 1) throw new InvalidImputException("Id Must Be Bigger Than 1");

        }

        public void Update(int Id, UpdateBookDTO updateBookDTO)
        {
            throw new NotImplementedException();
        }
    }
}
