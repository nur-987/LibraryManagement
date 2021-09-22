using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class User
    {
        //private int userId { get; set; }
        private string userName;
        //private List<Book> borrowedBook;
        private float finePaid;


        public int userId { get; set; }
        public List<Book> borrowedBook
        {
            get;
            set;
        }

        //list of book in private
        //but needs to be accesed in Main
        //either change to public or create indexer

        //public Book this[int i]
        //{
        //    get { return borrowedBook[i]; }
        //    set { borrowedBook.Add(value); }
        //}
        public User(int Id, string name)        //constructor
        {
            userId = Id;
            userName = name;
            finePaid = 0;
            borrowedBook = new List<Book>();
        }

        public void retrieveUserDetails()
        {
            Console.WriteLine("User id = " + userId);
            Console.WriteLine("User name = " + userName);
            Console.WriteLine("Books borrowed = " + borrowedBook);

        }
    }
}
