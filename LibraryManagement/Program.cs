using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Library Management");

            bool loop = true;
            List<Book> BooksInLibrary = new List<Book>();
            List<User> UsersinLibrary = new List<User>();
            while(loop)  
            {
                Console.WriteLine("Choose an option below");
                Console.WriteLine("1. Enter book details ");
                Console.WriteLine("6. Enter User details ");
                Console.WriteLine("2. Borrow a book ");
                Console.WriteLine("3. Return a book ");
                Console.WriteLine("4. Search for a book ");
                Console.WriteLine("7. Retrieve all book details ");
                Console.WriteLine("8. Retrieve all User details ");
                Console.WriteLine("5. Exit program");

                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    //we still need a "break" for these switch cases. 
                    case 1: 
                        {
                            Console.WriteLine("Enter book details");
                            Console.WriteLine("Enter book ID");
                            int tempId = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Enter book title");
                            string tempName = Console.ReadLine();

                            Console.WriteLine("Enter Author");
                            string tempAuthor = Console.ReadLine();

                            Console.WriteLine("Enter number of copies");
                            int tempNumCopies = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Enter book location");
                            string tempLocation = Console.ReadLine();

                            Book tempbook = new Book { BookId = tempId, BookName = tempName, Author = tempAuthor, NumOfCopies = tempNumCopies, Location = tempLocation };
                            //old
                            //book.enterBookDetails(tempId, tempName, tempAuthor, tempNumCopies, tempLocation);

                            # region LinQ method
                            //if (BooksInLibrary.Any(x => x.BookId == tempId))
                            //{
                            //    Console.WriteLine("Duplicate book details. Please try again.");
                            //    break;
                            //}
                            #endregion
                            #region foreach looping method
                            foreach (Book book in BooksInLibrary)
                            {
                                if (book.BookId == tempId)
                                {
                                    Console.WriteLine("Duplicate book details. Please try again.");
                                    break;
                                }
                            }
                            #endregion

                            BooksInLibrary.Add(tempbook);

                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("User selected to borrow a book");
                            Console.WriteLine("Enter details of book to be borrowed");
                            Console.WriteLine("Enter book ID");
                            int tempId = int.Parse(Console.ReadLine());
                            var validBook = SearchBook(tempId, BooksInLibrary);

                            if(validBook == null)
                            {
                                Console.WriteLine("Invalid Book Id. Try again");
                                break;
                            }
                            else if(validBook.NumOfCopies <= 0)
                            {
                                //book exist
                                //need to check count of book
                                Console.WriteLine("Curently not available in Library");
                            }
                            else
                            {
                                //issue the book
                                Console.WriteLine("Enter User ID");
                                int tempUserId = int.Parse(Console.ReadLine());
                                //check if user is valid
                                var user = UsersinLibrary.First(x => x.userId == tempUserId);
                                //this user borrowed this book
                                user.borrowedBook.Add(validBook);
                                validBook.NumOfCopies--;
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("User selected to return a book");

                            Console.WriteLine("Enter User ID");
                            int tempUsrId = int.Parse(Console.ReadLine());
                            var user = UsersinLibrary.First(x => x.userId == tempUsrId);
                            //the answer from C.ReadLine is just temp.
                            //need to find the user from the list

                            Console.WriteLine("Enter book ID to return");
                            int tempId = int.Parse(Console.ReadLine());
                            var validBook = SearchBook(tempId, BooksInLibrary);

                            if(validBook == null)
                            {
                                Console.WriteLine("Wrong book ID entered");
                                break;
                            }
                            user.borrowedBook.Remove(validBook);
                            validBook.NumOfCopies++;

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("User selected to search a book");
                            Console.WriteLine("Enter Book ID to search");
                            var tempBkId = Int32.Parse(Console.ReadLine());
                            var bookFound = SearchBook(tempBkId, BooksInLibrary);

                            if(bookFound == null)
                            {
                                Console.WriteLine("No book details found");
                            }
                            else
                            {
                                Console.WriteLine("Book details found as follow:");
                                bookFound.retriveBookDetails();
                            }
                            Console.WriteLine("No book details found");
                            break;
                        }
                    case 5:
                        {
                            loop = false;
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter User details");
                            Console.WriteLine("Enter User ID");
                            int tempId = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Enter User name");
                            string tempName = Console.ReadLine();

                            User usr = new User(tempId,tempName);
                            UsersinLibrary.Add(usr);

                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Showing all book details: ");
                            foreach(var bk in BooksInLibrary)
                            {
                                bk.retriveBookDetails();
                            }
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Showing all User details: ");
                            foreach (var usr in UsersinLibrary)
                            {
                                usr.retrieveUserDetails();
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("Invalide response!");
                        break;
                }
            }
        }

        private static Book SearchBook(int bookId, List<Book> BooksInLibrary)
            //returns a book Object
        {
            foreach (Book book in BooksInLibrary)
            {
                if (book.BookId == bookId)
                {
                    return book;
                }
            }
            return null;
        }
    }
}
