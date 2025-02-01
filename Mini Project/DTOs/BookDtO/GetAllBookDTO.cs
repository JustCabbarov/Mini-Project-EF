using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project.Models;

namespace Mini_Project.DTOs.BookDtO
{
    public class GetAllBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishedYear { get; set; }
        public List<string> Authors { get; set; }
        public bool IsBorrowed { get; set; }
    }
}
