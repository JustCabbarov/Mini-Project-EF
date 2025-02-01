using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mini_Project.Models;

namespace Mini_Project.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<Book> Books {  get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Borrower> Borrowers { get; set; }
        DbSet<Loan> Loans { get; set; }
        DbSet<LoanItem> LoanItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-IHAK3020\\SQLEXPRESS;Database=LibraryMiniProject;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
