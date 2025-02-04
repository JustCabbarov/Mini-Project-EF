using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.DTOs.AuthorDTO
{
    public class GetAllAuthorDTO
    {
        public int  Id { get; set; }    
        public string Name  { get; set; }
        public List<string> Books { get; set; }
    }
}
