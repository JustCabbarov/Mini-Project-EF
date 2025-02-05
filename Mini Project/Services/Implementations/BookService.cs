using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public void AddBook(CreatedBookDTO createdBookDTO)
        {
            if (createdBookDTO == null) throw new InvalidImputException("Imput Can not Be Null");
            if (string.IsNullOrWhiteSpace(createdBookDTO.Title)) throw new InvalidImputException("Imput Can not Be Null");
            if (string.IsNullOrEmpty(createdBookDTO.Description)) throw new InvalidImputException("Wrong Imput");
            if (createdBookDTO.PublishedYear <= 0) throw new InvalidImputException("PublishedYear Must be bigger than 0 ");
            BookRepository bookRepository = new BookRepository();
          
            Book book1 = new Book()
            {
                Id = createdBookDTO.Id,
                Title = createdBookDTO.Title,
                Description = createdBookDTO.Description,
                PublishedYear = createdBookDTO.PublishedYear,
                Authors = new List<Author>(),
                CreateAt = DateTime.UtcNow.AddHours(4),
                UpdateAt = DateTime.UtcNow.AddHours(4),
               
            }; 
      
            IAuthorRepository authorRepository = new AuthorRepository();
            foreach (var item in createdBookDTO.AuthorID) 
            {
                var data = authorRepository.GetById(item);
                book1.Authors.Add(data);
            }
        }
              
                


         
        public List<GetAllBookDTO> GettAll()
        {
          IBookRepository bookRepository = new BookRepository();
            var data=bookRepository.GetAll();
            if (data == null) throw new InvalidDataException("Books Not Found");
            if (data.Count == 0) throw new InvalidDataException("There are 0 Book in Library");
            List<GetAllBookDTO> result = new List<GetAllBookDTO>();
            
            result = data.Select(x => new GetAllBookDTO()
            {
                Title = x.Title,
                Description = x.Description,
                PublishedYear = x.PublishedYear,
                Authors = x.Authors.Select(x=>x.Name).ToList(),
                

            }).ToList();
            return result;
        }

        public void RemoveBook(int Id)
        {
            if (Id < 1) throw new InvalidImputException("Id Must Be Bigger Than 1");
            IBookRepository bookRepository= new BookRepository();
            var data=  bookRepository.GetById(Id);
            if (data == null) throw new InvalidDataException("Book Dont Found");
           
            bookRepository.Remove(data);
            bookRepository.Commit();

        }

        public void UpdateBook(int Id, UpdateBookDTO updateBookDTO)
        {
            if (Id < 1) throw new InvalidImputException("Id Must Be Bigger Than 1");
            if (updateBookDTO == null) throw new InvalidImputException("Imput Can Not be Null");
            if (string.IsNullOrEmpty(updateBookDTO.Title)) throw new InvalidImputException("Wrong Imput");
            if (string.IsNullOrEmpty(updateBookDTO.Description)) throw new InvalidImputException("Wrong Imput");
            if (updateBookDTO.PublishedYear <= 0) throw new InvalidImputException("PublishedYear Must be bigger than 0 ");
            if (updateBookDTO.Authors == null) throw new InvalidImputException("Imput Can Not Be Null");
            IBookRepository bookRepository = new BookRepository();
            IAuthorRepository authorRepository = new AuthorRepository();
           
            var data= bookRepository.GetById(Id);
            data.Description = updateBookDTO.Description;
            data.Title = updateBookDTO.Title;
            data.PublishedYear = updateBookDTO.PublishedYear;
            data.UpdateAt = DateTime.UtcNow.AddHours(4);
            data.Authors = new List<Author>();

            foreach (var ithem in updateBookDTO.Authors) 
            {
                var data2 = authorRepository.GetById(ithem);
                data.Authors.Add(data2);
            }
            bookRepository.Commit();
            
        }
    }
}
