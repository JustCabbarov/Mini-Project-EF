using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Mini_Project.DTOs.LoanDTO
{
    public class GetAllLoanDTO
    {
        public int BorrowerId { get; set; }
        public List<int> LoanIthems { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime MustReturnDate { get; set; }
    }
}
