using System.Linq.Expressions;
using Microsoft.Identity.Client;
using Mini_Project.DTOs.AuthorDTO;
using Mini_Project.DTOs.BookDtO;
using Mini_Project.Exceptions;
using Mini_Project.Models;
using Mini_Project.Repositories.Implementations;
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

                goto MainMenyu;
            }
            catch (InvalidImputException ex)
            {
                Console.WriteLine(ex.Message);
                goto MainMenyu;
            }
            catch (Exception)
            {

                Console.WriteLine("Another Exception");
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
                             authorId= Convert.ToInt32(Console.ReadLine());
                            AuthorRepository authorRepository1 = new AuthorRepository();
                            var data=authorRepository1.GetById(authorId);
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
                            catch (InvalidDataException ex )
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
                            authorService2.UpdateAuthor(authorId,update);
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
                               deletedAuthor = Convert.ToInt32 (Console.ReadLine());
                               var data= authorRepository4.GetById( deletedAuthor);
                                if (deletedAuthor < 0) throw new InvalidImputException("Id Can Not Be Negativ");
                                if (deletedAuthor is string) throw new FormatException("Id Must Be Number");
                                if ( data is null) throw new InvalidDataException("Author Dont Found");
                            }catch (InvalidDataException ex)
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

                    break;




            }



        }
    }
}
