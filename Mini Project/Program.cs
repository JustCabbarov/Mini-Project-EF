using Mini_Project.DTOs.AuthorDTO;
using Mini_Project.DTOs.BookDtO;
using Mini_Project.Services.Implementations;
using Mini_Project.Services.Interfaces;

namespace Mini_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAuthorService authorService = new AuthorService();
            CreateAuthorDTO createAuthorDTO = new CreateAuthorDTO()
            {
                Name="Ruslan"
            };

           
            
            authorService.AddAuthor(createAuthorDTO);
        }
    }
}
