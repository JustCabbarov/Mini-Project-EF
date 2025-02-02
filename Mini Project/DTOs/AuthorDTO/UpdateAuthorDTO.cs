using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.DTOs.AuthorDTO
{
    public class UpdateAuthorDTO
    {
        public string Name { get; set; }
        public List<string> Books { get; set; }
    }
}
