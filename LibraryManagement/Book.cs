using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    /// <summary>
    /// A new way to set and get
    /// </summary>
    /// 
    ///Now using the properties method. 
    class Book
    {
        #region old
        //private int bookId;
        //private string bookName;
        //private string Author;
        //private int numberOfCopies;
        //private string location;
        #endregion

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int NumOfCopies { get; set; }
        public string Location { get; set; }

        #region Method 1
        //public int BookId 
        //{   
        //    get => bookId;
        //    set { bookId = value; }
        //}
        #endregion


        #region Old

        //public void enterBookDetails(int id, string name, string author, int noOfCopies, string location)
        //{
        //    bookId = id;
        //    bookName = name;
        //    this.Author = author;
        //    numberOfCopies = noOfCopies;
        //    this.location = location;
        //}
        //public void retrieveBookDetails()
        //{
        //    Console.WriteLine("UserId: " + bookId);
        //    Console.WriteLine("Book Name: " + bookName);
        //    Console.WriteLine("Author" + Author);


        //}

        //public int getBookId()
        //{
        //    return bookId;
        //}
        //public void setBookId(int id)
        //{
        //    bookId = id;
        //}
        #endregion

        public void retriveBookDetails()
        {
            Console.WriteLine("Book id = " + BookId);
            Console.WriteLine("Book name = " + BookName);
            Console.WriteLine("Author = " + Author);
            Console.WriteLine("Number of Copies = " + NumOfCopies);
            Console.WriteLine("Location = " + Location);



        }
    }
}
