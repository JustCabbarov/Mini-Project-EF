using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.DTOs.BookDtO
{
    public class UpdateBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishedYear { get; set; }
        public DateTime UpdateTime { get; set; }
        public List<string> Authors { get; set; }
    }
}
