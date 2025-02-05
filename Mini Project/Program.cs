using System.Linq.Expressions;
using Microsoft.Identity.Client;
using Mini_Project.DTOs.AuthorDTO;
using Mini_Project.DTOs.BookDtO;
using Mini_Project.DTOs.BorrowerDTO;
using Mini_Project.DTOs.LoanDTO;
using Mini_Project.Exceptions;
using Mini_Project.Models;
using Mini_Project.Repositories.Implementations;
using Mini_Project.Repositories.Interfaces;
using Mini_Project.Services.Implementations;
using Mini_Project.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mini_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            Console.WriteLine("Library Menegment Siystem");
        MainMenyu:
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\nSelect Operation");
            Console.WriteLine("  1 - Author actions");
            Console.WriteLine("  2 - Book actions");
            Console.WriteLine("  3 - Borrower actions");
            Console.WriteLine("  4 - BorrowBook ");
            Console.WriteLine("  5 - ReturnBook");
            Console.WriteLine("  6 - Most borrowed book ");
            Console.WriteLine("  7 - GetOverdueBorrowers ");
            Console.WriteLine("  8 - GetBorrowerHistory ");
            Console.WriteLine("  9 - FilterBooksByTitle");
            Console.WriteLine("  0 - Exit");
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (input < 0 || input > 10)
                {
                    throw new InvalidImputException("Select Number From 1 To 10");
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong Format Enter Number");
                Thread.Sleep(800);
                goto MainMenyu;
            }
            catch (InvalidImputException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(800);
                goto MainMenyu;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Another Exception {ex.Message}");
                Thread.Sleep(800);
                goto MainMenyu;
            }

            switch (input)
            {
                case 1:
                AuthorMenu:
                    int input2;
                    Console.Clear();
                    Console.WriteLine("1 - Author Actions\n");
                    Console.WriteLine("1 - List all authors");
                    Console.WriteLine("2 - Create an author");
                    Console.WriteLine("3 - Edit an author");
                    Console.WriteLine("4 - Delete an author");
                    Console.WriteLine("0 - Exit");
                    Console.Write("\nSelect an option: ");

                    try
                    {
                        input2 = Convert.ToInt32(Console.ReadLine());
                        if (input2 < 0 || input2 > 5)
                        {
                            throw new InvalidImputException("Select Number From 0 To 4");
                        }

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong Format Enter Number");

                        Thread.Sleep(800);
                        goto AuthorMenu;

                    }
                    catch (InvalidImputException)
                    {
                        Console.WriteLine("Select Number From 1 To 4");
                        Thread.Sleep(800);
                        goto AuthorMenu;


                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Another Exception {ex.Message}");
                        Thread.Sleep(1000);
                        goto AuthorMenu;

                    }
                    switch (input2)
                    {
                        case 1:
                            try
                            {
                                AuthorService authorService = new AuthorService();

                                foreach (var ithem in authorService.GetAllAuthors())
                                {
                                    Console.WriteLine(ithem.Id + "-" + ithem.Name);
                                }
                            }
                            catch (InvalidDataException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(700);
                                goto AuthorMenu;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Enother Exception");
                                Thread.Sleep(700);
                                goto CreateAuthor;
                            }
                            Thread.Sleep(2200);
                            goto AuthorMenu;
                            break;
                        case 2:
                            string inputAuthorName;
                        CreateAuthor:
                            AuthorService authorService1 = new AuthorService();
                            try
                            {
                                Console.WriteLine("Enter Author Name");
                                inputAuthorName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputAuthorName) || !inputAuthorName.All(char.IsLetter)) throw new InvalidImputException("Author Name Must Be Only Lettter");


                            }

                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(700);
                                goto CreateAuthor;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Another Exception");
                                Thread.Sleep(700);
                                goto CreateAuthor;
                            }
                            CreateAuthorDTO create = new CreateAuthorDTO { Name = inputAuthorName };
                            authorService1.AddAuthor(create);
                            Console.WriteLine("Author Created Successfuly");
                            Thread.Sleep(1000);
                            goto AuthorMenu;
                            break;
                        case 3:
                            AuthorService authorService2 = new AuthorService();
                            int authorId = 0;
                            string inputAuthorName2 = null;
                        EditMenyu:
                            try
                            {
                                Console.WriteLine("Enter  Author Id");
                                authorId = Convert.ToInt32(Console.ReadLine());
                                AuthorRepository authorRepository1 = new AuthorRepository();
                                var data = authorRepository1.GetById(authorId);
                                if (data == null) throw new InvalidDataException("Author Dont Found");
                                if (authorId < 0) throw new InvalidImputException("Id Can Not Be Null");
                                if (authorId is string) throw new FormatException("Id Must Be Number");
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                goto EditMenyu;
                            }
                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                goto EditMenyu;
                            }
                            catch (InvalidDataException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                goto EditMenyu;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Another Exception");
                                Thread.Sleep(1000);
                                goto EditMenyu;
                            }
                        EditAuthorName:
                            try
                            {
                                Console.WriteLine("Enter New Author Name");
                                inputAuthorName2 = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputAuthorName2) || !inputAuthorName2.All(char.IsLetter)) throw new InvalidImputException("Author Name Must Be Only Lettter");
                            }
                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                goto EditAuthorName;
                            }


                            catch (Exception)
                            {

                                Console.WriteLine("Enother Exception");
                                Thread.Sleep(1000);
                                goto EditAuthorName;
                            }

                            UpdateAuthorDTO update = new UpdateAuthorDTO { Name = inputAuthorName2 };
                            authorService2.UpdateAuthor(authorId, update);
                            Console.WriteLine("Author Update Successfuly");
                            Thread.Sleep(1000);
                            goto AuthorMenu;
                            break;
                        case 4:
                            int deletedAuthor = 0;
                            AuthorService authorService3 = new AuthorService();
                            AuthorRepository authorRepository4 = new AuthorRepository();
                        InputRemoveId:
                            Console.WriteLine("Enter the ID of the author to be deleted.");
                            try
                            {
                                deletedAuthor = Convert.ToInt32(Console.ReadLine());
                                var data = authorRepository4.GetById(deletedAuthor);
                                if (deletedAuthor < 0) throw new InvalidImputException("Id Can Not Be Negativ");
                                if (deletedAuthor is string) throw new FormatException("Id Must Be Number");
                                if (data is null) throw new InvalidDataException("Author Dont Found");
                            }
                            catch (InvalidDataException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(700);
                                goto InputRemoveId;
                            }
                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(700);
                                goto InputRemoveId;

                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(700);
                                goto InputRemoveId;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Another Exception");
                                Thread.Sleep(700);
                                goto InputRemoveId;
                            }
                            authorService3.RemoveAuthor(deletedAuthor);
                            Console.WriteLine("Author Deleted Successfuly");
                            Thread.Sleep(700);
                            goto AuthorMenu;
                            break;

                        case 0:
                            goto MainMenyu;
                            break;
                    }
                    break;

                case 2:
                    int input3;
                BookMenyu:
                    Console.Clear();
                    Console.WriteLine("1 - Book Actions\n");
                    Console.WriteLine("1 - List all books");
                    Console.WriteLine("2 - Create a book");
                    Console.WriteLine("3 - Edit a book");
                    Console.WriteLine("4 - Delete a book");
                    Console.WriteLine("0 - Exit");
                    Console.Write("\nSelect an option: ");
                    try
                    {
                        input3 = Convert.ToInt32(Console.ReadLine());
                        if (input3 < 0 || input3 > 5)
                        {
                            throw new InvalidImputException("Select Number From 0 To 4");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong Format Enter Number");

                        Thread.Sleep(800);
                        goto BookMenyu;


                    }
                    catch (InvalidImputException)
                    {
                        Console.WriteLine("Select Number From 1 To 4");
                        Thread.Sleep(800);
                        goto BookMenyu;



                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Another Exception {ex.Message}");
                        Thread.Sleep(800);
                        goto BookMenyu;


                    }
                    switch (input3)
                    {
                        case 1:
                            try
                            {
                                BookService bookService = new BookService();
                                foreach (var item in bookService.GettAll())
                                {
                                    Console.WriteLine($"Id: {item.Id}   Title: {item.Title}   Description: {item.Description}  PublishedYear: {item.PublishedYear}  IsBorrowed: {item.IsBorrowed}  Authors: {string.Join(", ", item.Authors)}");

                                }
                            }
                            catch (InvalidDataException ex)
                            {

                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto BookMenyu;
                            }


                            catch (Exception ex)
                            {
                                Console.WriteLine($"Enother Exception {ex.Message}");
                                Thread.Sleep(800);
                                goto BookMenyu;
                            }
                            Thread.Sleep(2500);
                            goto BookMenyu;
                            break;
                        case 2:

                            string inputBookTitle = null;
                            string inputBookDescription = null;
                            int publishedYear = 0;

                            List<int> authors = new List<int>();
                            BookService bookService1 = new BookService();
                        EnterBookTit:
                            try
                            {
                                Console.WriteLine("Enter Book Title");
                                inputBookTitle = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputBookTitle)) throw new InvalidImputException("Author Name Must Be Only Lettter");

                            }

                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto EnterBookTit;
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto EnterBookTit;
                            }
                        EnterBookDesc:
                            try
                            {

                                Console.Clear();
                                Console.WriteLine("Enter Book Description");
                                inputBookDescription = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputBookDescription) || !inputBookDescription.All(char.IsLetter)) throw new InvalidImputException("Book Description Must Be Only Lettter");
                            }

                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto EnterBookDesc;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Another Exception {ex.Message}");
                                Thread.Sleep(800);
                                goto EnterBookDesc;

                            }
                        EnterPublised:
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Book Published Year");
                                publishedYear = Convert.ToInt32(Console.ReadLine());
                                if (publishedYear < 0) throw new InvalidImputException("Published Year Can Not Be Less Than 0");
                                if (publishedYear is string) throw new FormatException("Id Must Be Number");
                                if (publishedYear > DateTime.Now.Year) throw new InvalidTimeException("Published Year Can Not Be Bigger Than Today");

                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto EnterPublised;
                            }
                            catch (InvalidTimeException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto EnterPublised;
                            }
                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto EnterPublised;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Another exception {ex.Message}");
                                Thread.Sleep(800);
                                goto EnterPublised;
                            }

                            Console.Clear();
                            Console.WriteLine("Enter Book Authors Id With Comma");
                            Console.WriteLine("\nAuthor List");
                            AuthorService authorService = new AuthorService();

                            foreach (var ithem in authorService.GetAllAuthors())
                            {
                                Console.WriteLine(ithem.Id + "-" + ithem.Name);
                            }

                            try
                            {
                                var data = (Console.ReadLine());
                                authors = data.Split(",").Select(int.Parse).ToList();
                                if (data is null) throw new InvalidImputException("Input Must Not Be NULL ");

                            }
                            catch (InvalidImputException ex) { Console.WriteLine(ex.Message); }
                            catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); }




                            CreatedBookDTO bookDTO = new CreatedBookDTO()
                            {
                                Title = inputBookTitle,
                                Description = inputBookDescription,
                                PublishedYear = publishedYear,
                                AuthorID = authors


                            };

                            bookService1.AddBook(bookDTO);
                            Console.WriteLine("Book Ceated Successfuly");
                            Thread.Sleep(1000);
                            goto BookMenyu;
                            break;
                        case 3:
                            string inputUpdatedTitle = null;
                            string inputUpdatedDescription = null;
                            int inputUpdatedPublisY = 0;
                            int inputUpdatedBookId = 0;
                            IBookService bookService2 = new BookService();
                            IBookRepository bookRepository2 = new BookRepository();

                        inputUpdatedBookId:
                            Console.Clear();
                            Console.WriteLine("Enter the ID of the Book for Update.");
                            try
                            {
                                inputUpdatedBookId = Convert.ToInt32(Console.ReadLine());
                                if (inputUpdatedBookId < 0) throw new InvalidImputException("Id Can Not Be Negativ");
                                if (inputUpdatedBookId is string) throw new FormatException("Id Must Be Number");
                                var data1 = bookRepository2.GetById(inputUpdatedBookId);
                                if (data1 is null) throw new InvalidDataException("Author Dont Found");
                            }
                            catch (InvalidDataException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                goto inputUpdatedBookId;
                            }
                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                goto inputUpdatedBookId;

                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(1000);
                                goto inputUpdatedBookId;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Another Exception");
                                Thread.Sleep(1000);
                                goto inputUpdatedBookId;
                            }

                        BookTitUpdate:
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Book Title for Update");
                                inputUpdatedTitle = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputUpdatedTitle)) throw new InvalidImputException("Author Name Must Be Only Lettter");
                            }
                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto BookTitUpdate;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto BookTitUpdate;
                            }
                        BookDescUpdate:
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Book Description for Update");
                                inputUpdatedDescription = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputUpdatedDescription) || !inputUpdatedDescription.All(char.IsLetter)) throw new InvalidImputException("Book Description Must Be Only Lettter");
                            }

                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto BookDescUpdate;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Another Exception {ex.Message}");
                                Thread.Sleep(800);
                                goto BookDescUpdate;

                            }
                        BookPublishUpdate:
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Book Published Year for Update");
                                int.TryParse(Console.ReadLine(), out inputUpdatedPublisY);
                                if (inputUpdatedBookId is string) throw new FormatException("Id Must Be Number");
                                if (inputUpdatedPublisY < 0) throw new InvalidImputException("Published Year Can Not Be Less Than 0");
                                if (inputUpdatedPublisY > DateTime.Now.Year) throw new InvalidTimeException("Published Year Can Not Be Bigger Than Today");
                            }
                            catch (InvalidTimeException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto BookPublishUpdate;
                            }
                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(800);
                                goto BookPublishUpdate;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Another exception {ex.Message}");
                                Thread.Sleep(800);
                                goto BookPublishUpdate;
                            }
                            Console.Clear();
                            Console.WriteLine("Enter Book  Authors Id With Comma for Update");
                            Console.WriteLine("\nAuthor List");
                            AuthorService authorService1 = new AuthorService();

                            foreach (var ithem in authorService1.GetAllAuthors())
                            {
                                Console.WriteLine(ithem.Id + "-" + ithem.Name);
                            }
                            var data2 = (Console.ReadLine());




                            UpdateBookDTO update = new UpdateBookDTO()
                            {
                                Title = inputUpdatedTitle,
                                Description = inputUpdatedDescription,
                                PublishedYear = inputUpdatedPublisY,

                            };

                            break;
                        case 4:
                            int deletedBook = 0;
                            BookService bookService3 = new BookService();
                            BookRepository bookRepository = new BookRepository();
                        InputRemoveIdBook:
                            Console.WriteLine("Enter the ID of the author to be deleted.");
                            try
                            {
                                deletedBook = Convert.ToInt32(Console.ReadLine());
                                var data4 = bookRepository.GetById(deletedBook);

                                if (deletedBook is string) throw new FormatException("Id Must Be Number");
                                if (data4 is null) throw new InvalidDataException("Book Dont Found");
                            }
                            catch (InvalidDataException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(700);
                                goto InputRemoveIdBook;
                            }
                            catch (InvalidImputException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(700);
                                goto InputRemoveIdBook;

                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(700);
                                goto InputRemoveIdBook;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Another Exception");
                                Thread.Sleep(700);
                                goto InputRemoveIdBook;
                            }
                            bookService3.RemoveBook(deletedBook);
                            Console.WriteLine("Book Deleted Successfuly");
                            Thread.Sleep(700);
                            goto BookMenyu;
                            break;
                        case 0:
                            goto MainMenyu;
                            break;
                    }
                    break;
                case 3:


                    int input4;
                BorrowerMenyu:
                    Console.Clear();
                    Console.WriteLine("1 - Borrower Actions\n");
                    Console.WriteLine("1 - List all Borrowers");
                    Console.WriteLine("2 - Create a Borrower");
                    Console.WriteLine("3 - Edit a Borrower");
                    Console.WriteLine("4 - Delete a Borrower");
                    Console.WriteLine("0 - Exit");
                    Console.Write("\nSelect an option: ");
                    try
                    {
                        input4 = Convert.ToInt32(Console.ReadLine());
                        if (input4 < 0 || input4 > 5)
                        {
                            throw new InvalidImputException("Select Number From 0 To 4");
                        }
                    }
                    catch (FormatException) { Console.WriteLine("Wrong Format Enter Number"); Thread.Sleep(800); goto BorrowerMenyu; }
                    catch (InvalidImputException) {Console.WriteLine("Select Number From 1 To 4"); Thread.Sleep(800); goto BorrowerMenyu; }
                    catch (Exception ex) {Console.WriteLine($"Another Exception {ex.Message}");Thread.Sleep(800);goto BorrowerMenyu;}
                    switch (input4)
                    {
                        case 1:
                            try
                            {
                                BorrowerService borrowerService = new BorrowerService();

                                foreach (var item in borrowerService.GetAllBorrower())
                                {
                                    Console.WriteLine($"Id:{item.Id} --   Name:{item.Name} --  Email:{item.Email}");
                                }
                            }
                            catch (InvalidDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerMenyu; }

                            catch (Exception ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerMenyu; }
                            Thread.Sleep(2500);
                            goto BorrowerMenyu;
                            break;
                        case 2:
                            string inputBorrowerName;
                            string inputBorrowerEmail;
                            BorrowerService borrowerService6 = new BorrowerService();
                            IBorrowerRepository borrowerRepository= new BorrowerRepository();
                        BorrowerName:
                            try
                            {
                                Console.WriteLine("Enter Borrower Name");
                                inputBorrowerName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputBorrowerName)) throw new InvalidImputException("Name Can Not Be Null");
                                var data1 = borrowerRepository.GetAll();
                                foreach (var item in data1)
                                {
                                    if (item.Name == inputBorrowerName) throw new SameDataException("Borrower Name Already Exist Pleace Enter Another Name");
                                }
                            }
                            catch (SameDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerName; }

                            catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerName; }

                            catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); Thread.Sleep(800); goto BorrowerName; }
                        inputBorrowerEmail:
                            try
                            {
                                Console.WriteLine("Enter Borrower Email");
                                inputBorrowerEmail = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputBorrowerEmail)) throw new InvalidImputException("Name Can Not Be Null");
                                var data2 = borrowerRepository.GetAll();
                                foreach (var item in data2)
                                {
                                    if (item.Email == inputBorrowerEmail) throw new SameDataException("Borrower Email Already Exist Pleace Enter Another Email");
                                }

                            }
                            catch (SameDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto inputBorrowerEmail; }

                            catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto inputBorrowerEmail; }

                            catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); Thread.Sleep(800); goto inputBorrowerEmail; }

                            CreateBorrowerDTO create = new CreateBorrowerDTO()
                            {
                                Name = inputBorrowerName,
                                Email = inputBorrowerEmail,

                            };
                            borrowerService6.AddBorrower(create);
                            Console.WriteLine("Borrower Created Succesfuly");
                            Thread.Sleep(1000);
                            goto BorrowerMenyu;
                            break;
                        case 3:
                        UpdatedBorrowerId:
                            //string inputUpdatedTitle = null;
                            string inputUpdatedName = null;
                            string inputUpdatedEmail = null;
                            int inputUpdatedBorrowerId = 0;
                            IBorrowerRepository borrower = new BorrowerRepository();
                            BorrowerService borrowerService2 = new BorrowerService();
                            Console.Clear();
                            try
                            {
                                Console.WriteLine("Enter the ID of the Book for Update.");
                                inputUpdatedBorrowerId = Convert.ToInt32(Console.ReadLine());
                                if (inputUpdatedBorrowerId is string) throw new FormatException("Id Must Be Number");
                                if (inputUpdatedBorrowerId < 0) throw new InvalidImputException("Id Can Not Be Negativ");
                                var data1 = borrower.GetById(inputUpdatedBorrowerId);
                                if (data1 == null) throw new InvalidDataException("Borrower Dont Found");

                            }
                            catch (InvalidDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto UpdatedBorrowerId; }

                            catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto UpdatedBorrowerId; }

                            catch (FormatException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto UpdatedBorrowerId; }

                            catch (Exception) { Console.WriteLine("Another Exception"); Thread.Sleep(1000); goto UpdatedBorrowerId; }
                        UpdateBorrowerName:
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Name For Update");
                                inputUpdatedName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputUpdatedName)) throw new InvalidImputException("Name Can Not Be Null");
                                var data1 = borrower.GetAll();
                                foreach (var item in data1)
                                {
                                    if (item.Name == inputUpdatedName) throw new SameDataException("Borrower Name Already Exist Pleace Enter Another Name");
                                }

                            }
                            catch (SameDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto UpdateBorrowerName; }

                            catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto UpdateBorrowerName; }

                            catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); Thread.Sleep(800); goto UpdateBorrowerName; }
                        UpdateBorrowerEmail:
                            try
                            {
                                Console.WriteLine("Enter Borrower Email");
                                inputUpdatedEmail = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(inputUpdatedEmail)) throw new InvalidImputException("Name Can Not Be Null");
                                var data2 = borrower.GetAll();
                                foreach (var item in data2)
                                {
                                    if (item.Email == inputUpdatedEmail) throw new SameDataException("Borrower Email Already Exist Pleace Enter Another Email");
                                }

                            }
                            catch (SameDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto UpdateBorrowerEmail; }

                            catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto UpdateBorrowerEmail; }

                            catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); Thread.Sleep(800); goto UpdateBorrowerEmail; }


                            UpdateBorrowerDTO update = new UpdateBorrowerDTO()
                            {
                                Email = inputUpdatedEmail,
                                Name = inputUpdatedEmail,
                            };
                            borrowerService2.UpdateBorrower(inputUpdatedBorrowerId, update);
                            Console.WriteLine("Borrower Updated Successfuly");
                            Thread.Sleep(800);
                            goto BorrowerMenyu;
                            break;
                        case 4:
                        DeleteBorrowerId:
                            int inputDeleteBorrowerId = 0;
                            IBorrowerRepository repository = new BorrowerRepository();
                            BorrowerService service = new BorrowerService();
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Enter the ID of the Book for Delete.");
                                inputDeleteBorrowerId = Convert.ToInt32(Console.ReadLine());
                                if (inputDeleteBorrowerId is string) throw new FormatException("Id Must Be Number");
                                if (inputDeleteBorrowerId < 0) throw new InvalidImputException("Id Can Not Be Negativ");
                                var data1 = repository.GetById(inputDeleteBorrowerId);
                                if (data1 == null) throw new InvalidDataException("Borrower Dont Found");

                            }
                            catch (InvalidDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto DeleteBorrowerId; }

                            catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto DeleteBorrowerId; }

                            catch (FormatException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto DeleteBorrowerId; }

                            catch (Exception) { Console.WriteLine("Another Exception"); Thread.Sleep(1000); goto DeleteBorrowerId; }


                            service.RemoveBorrower(inputDeleteBorrowerId);
                            Console.WriteLine("Borrower Deleted Successfuly");
                            Thread.Sleep(1000);
                            goto BorrowerMenyu;

                            break;
                        case 0:
                            goto MainMenyu;
                            break;
                    }
                    break;
                case 4:

                    string BorrowerName1;
                    string BorrowerEmail;
                    BorrowerService borrowerService1 = new BorrowerService();
                   IBorrowerRepository Repository = new BorrowerRepository();
                BorrowerNameForBorrow:
                    try
                    {
                        Console.WriteLine("Enter Borrower Name (Press 'q' For Exit)");
                        BorrowerName1 = Console.ReadLine();
                        if (BorrowerName1=="q") goto MainMenyu;
                        if (string.IsNullOrWhiteSpace(BorrowerName1)) throw new InvalidImputException("Name Can Not Be Null");
                        var data1 = Repository.GetAll();
                        var isExist = data1.Any(x=>x.Name==BorrowerName1);
                        if (!isExist) throw new SameDataException("Wrong Borrower Name Enter Another One Or Create ");
                        
                      
                    }
                    catch (SameDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerNameForBorrow; }

                    catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerNameForBorrow; }

                    catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); Thread.Sleep(800); goto BorrowerNameForBorrow; }

                BorrowerEmailForBorrow:
                    try
                    {
                        Console.WriteLine("Enter Borrower Email");
                       var BorrowerEmail1 = Console.ReadLine();
                        if (BorrowerEmail1 == "q") goto MainMenyu;
                        if (string.IsNullOrWhiteSpace(BorrowerEmail1)) throw new InvalidImputException("Name Can Not Be Null");
                        var data2 = Repository.GetAll();
                       
                        var isExist2 = data2.Any(x => x.Email == BorrowerEmail1);
                        if (!isExist2) { throw new SameDataException("Wrong Borrower Email Enter Another One"); }
                        
                        
                    }
                    catch (SameDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerEmailForBorrow; }

                    catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerEmailForBorrow; }

                    catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); Thread.Sleep(800); goto BorrowerEmailForBorrow; }


                    BorrowAnother:
                    Console.Clear();    
                    BookService bookService4 = new BookService();
                    BookRepository bookRepository4 = new BookRepository();
                    foreach (var item in bookService4.GettAll())
                    {
                        Console.WriteLine($"Id: {item.Id}   Title: {item.Title}   Description: {item.Description}  PublishedYear: {item.PublishedYear}  Availability: {(item.IsBorrowed ? "Not available" : "Available")}  Authors: {string.Join(", ", item.Authors)}");
                    }
                    BorrowBook:
                    try
                    {
                        Console.WriteLine("Enter Book Id For Borrow");
                        int borrowedBook = Convert.ToInt32(Console.ReadLine());
                        if (borrowedBook is string) throw new FormatException("Id Must Be Number");
                        if (borrowedBook < 0) throw new InvalidImputException("Id Can Not Be Negativ");
                        var data= bookService4.GettAll().FirstOrDefault(x=>x.Id==borrowedBook);
                        if (data == null) throw new InvalidDataException("Book Dont Found");
                        if (data.IsBorrowed = true) throw new ISBorrowedException("The Book is Currently Rented, Please Check Back Later.");
                        if(data.IsBorrowed= false) { data.IsBorrowed = true; Console.WriteLine("The book was successfully lent"); }
                        
                    }  
                    catch(ISBorrowedException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto BorrowBook; }

                    catch (InvalidDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto BorrowBook; }

                    catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto BorrowBook; }

                    catch (FormatException ex) { Console.WriteLine(ex.Message); Thread.Sleep(1000); goto BorrowBook; }

                    catch (Exception ex) { Console.WriteLine($"Another Exception:{ex.Message}"); Thread.Sleep(1000); goto BorrowBook; }

                    var borrowerid = Repository.GetAll().FirstOrDefault(x => x.Name == BorrowerName1);
                    CreatedLoanDTO created = new CreatedLoanDTO()
                    {
                        BorrowerId= borrowerid.Id,
                        LoanDate = DateTime.UtcNow.AddHours(4),
                        MustReturnDate= DateTime.UtcNow.AddHours(4).AddDays(15),
                    };
                    LoanService loanService = new LoanService();
                    loanService.AddLoan(created);
                    try
                    {
                        Console.WriteLine("\nAnother Operation");
                        Console.WriteLine("1- Borrow Another Book");
                        Console.WriteLine("2- Add Borrower");
                        input4 = Convert.ToInt32(Console.ReadLine());
                        if (input4 != 1 || input4 != 2){throw new InvalidImputException("Select Number 1 or 2");  }
                    }
                    catch (FormatException) { Console.WriteLine("Wrong Format Enter Number"); Thread.Sleep(800); goto BorrowerMenyu; }
                    catch (InvalidImputException) { Console.WriteLine("Select Number From 1 To 4"); Thread.Sleep(800); goto BorrowerMenyu; }
                    catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); Thread.Sleep(800); goto BorrowerMenyu; }
                    if (input4 == 1) { goto BorrowAnother; }
                    if ((input4 == 2)) 
                    {
                        string inputBorrowerName;
                        string inputBorrowerEmail;
                        BorrowerService borrowerService6 = new BorrowerService();
                        IBorrowerRepository borrowerRepository = new BorrowerRepository();
                    BorrowerName:
                        try
                        {
                            Console.WriteLine("Enter Borrower Name");
                            inputBorrowerName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(inputBorrowerName)) throw new InvalidImputException("Name Can Not Be Null");
                            var data1 = borrowerRepository.GetAll();
                            foreach (var item in data1)
                            {
                                if (item.Name == inputBorrowerName) throw new SameDataException("Borrower Name Already Exist Pleace Enter Another Name");
                            }
                        }
                        catch (SameDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerName; }

                        catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto BorrowerName; }

                        catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); Thread.Sleep(800); goto BorrowerName; }
                    inputBorrowerEmail:
                        try
                        {
                            Console.WriteLine("Enter Borrower Email");
                            inputBorrowerEmail = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(inputBorrowerEmail)) throw new InvalidImputException("Name Can Not Be Null");
                            var data2 = borrowerRepository.GetAll();
                            foreach (var item in data2)
                            {
                                if (item.Email == inputBorrowerEmail) throw new SameDataException("Borrower Email Already Exist Pleace Enter Another Email");
                            }

                        }
                        catch (SameDataException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto inputBorrowerEmail; }

                        catch (InvalidImputException ex) { Console.WriteLine(ex.Message); Thread.Sleep(800); goto inputBorrowerEmail; }

                        catch (Exception ex) { Console.WriteLine($"Another Exception {ex.Message}"); Thread.Sleep(800); goto inputBorrowerEmail; }

                        CreateBorrowerDTO create = new CreateBorrowerDTO()
                        {
                            Name = inputBorrowerName,
                            Email = inputBorrowerEmail,

                        };
                        borrowerService6.AddBorrower(create);
                        Console.WriteLine("Borrower Created Succesfuly");
                        Thread.Sleep(1000);
                        goto BorrowerMenyu;
                    }



















                    break;




































            }












        }




    }
}
