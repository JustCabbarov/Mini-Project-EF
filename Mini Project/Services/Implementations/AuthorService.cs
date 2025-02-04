using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.DTOs.AuthorDTO;
using Mini_Project.DTOs.BookDtO;
using Mini_Project.Exceptions;
using Mini_Project.Models;
using Mini_Project.Repositories.Implementations;
using Mini_Project.Repositories.Interfaces;
using Mini_Project.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mini_Project.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        public void AddAuthor(CreateAuthorDTO AuthorDTO)
        {
            if (AuthorDTO == null) throw new InvalidImputException("Imput Can not Be Null");
            if (string.IsNullOrWhiteSpace(AuthorDTO.Name)) throw new InvalidImputException("Imput Can not Be Null");
            IAuthorRepository authorRepository = new AuthorRepository();

            Author author = new Author()
            {
                Name = AuthorDTO.Name,
                CreateAt = DateTime.UtcNow.AddHours(4),
                UpdateAt = DateTime.UtcNow.AddHours(4),
                IsDeleted=false,

            };

          authorRepository.Add(author);
           authorRepository.Commit();
        }

        public List<GetAllAuthorDTO> GetAllAuthors()
        {
            IAuthorRepository authorRepository = new AuthorRepository();
            var authors=authorRepository.GetAll().Where(x=>x.IsDeleted==false).ToList();
            if (authors.Count == 0) throw new InvalidDataException ("There are 0 Authors in Library");
            if (authors == null) throw new InvalidDataException("Books Not Found");
           
            List<GetAllAuthorDTO> authorDTO = new List<GetAllAuthorDTO>();
           
            authorDTO = authors.Select(x => new GetAllAuthorDTO()
            {
               Id = x.Id,
               Name=x.Name,
               Books=x.Books.Select(x=>x.Title).ToList()
               
               
               
            }).ToList();

            return authorDTO;
        }

        public void RemoveAuthor(int Id)
        {
            if (Id < 1) throw new InvalidImputException("Id Must Be Bigger Than 1");
            IAuthorRepository authorRepository= new AuthorRepository();
            var data =authorRepository.GetById(Id);
            if (data == null) throw new InvalidDataException("Author Dont Found");
             authorRepository.Remove(data);
            authorRepository.Commit();

        }

        public void UpdateAuthor(int Id, UpdateAuthorDTO AuthorDTO)
        {
            if (Id < 1) throw new InvalidImputException("Id Must Be Bigger Than 1");
            if (AuthorDTO == null) throw new InvalidImputException("Imput Can Not be Null");
            if (string.IsNullOrEmpty(AuthorDTO.Name)) throw new InvalidImputException("Name Can Not Be NUll");
            IAuthorRepository authorRepository = new AuthorRepository();
           
            var data= authorRepository.GetById(Id) ?? throw new InvalidDataException("Author Dont Found");
            
            data.Name = AuthorDTO.Name;
            data.UpdateAt = DateTime.UtcNow.AddHours(4);
            authorRepository.Commit();
        }
    }
}
