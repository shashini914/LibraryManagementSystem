using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SDAM_assignment
{
    class Program

    {
        private const int REGISTER = 1;
        private const int BUY_BOOK = 2;
        private const int BORROW_ITEM = 3;
        private const int EXTEND_ITEM = 4;
        private const int RETURN_ITEM = 5;
        //private const int VIEW_BORROWED_ITEMS = 6;
        private const int VIEW_MEMBERS = 6;
        private const int VIEW_ALL_ITEMS = 7;
        private const int VIEW_ALL_LOANS = 8;
        private const int EXIT = 9;

        private static Library library = new Library();
       
        static void Main(string[] args)
        {
            mainMenu();
            int choice = GetMenuChoice(); //Convert.ToInt32(Console.ReadLine());
            while (choice != EXIT)
            {
                switch (choice)
                {
                    case REGISTER:
                        Register();
                        break;
                    case BUY_BOOK:
                        Buy_Item();
                        break;
                    case BORROW_ITEM:
                        Borrow_book();
                        break;
                    case EXTEND_ITEM:
                        Extend_book();
                        break;
                    case RETURN_ITEM:
                        Return_Item();
                        break;
                    case VIEW_ALL_ITEMS:
                        View_all_Items();
                        break;

                    case VIEW_MEMBERS:
                        view_members();
                        break;
                    case VIEW_ALL_LOANS:
                        view_loans();
                        break;

                        // case EXIT:
                        //  break;


                }
               
                mainMenu();
                choice = GetMenuChoice();
            }

        }


        private static void mainMenu()
        {

            Console.WriteLine("choose an option:");
            Console.WriteLine(REGISTER + " Register");
            Console.WriteLine(BUY_BOOK + " Buy Book");
            Console.WriteLine(BORROW_ITEM + " Borrow item ");
            Console.WriteLine(EXTEND_ITEM + " Extend item");
            Console.WriteLine(RETURN_ITEM + " Return Items");
            Console.WriteLine(VIEW_MEMBERS + " View members");
            Console.WriteLine(VIEW_ALL_ITEMS + " View all items");
            Console.WriteLine(VIEW_ALL_LOANS + " View all loans");

            Console.WriteLine(EXIT + " Exit");
            Console.Write("\r\nSelect an option:");
            ;

        }
        private static int GetMenuChoice()
        {
            int option = ReadInteger("\nOption");
            while (option < 1 || option > 8)
            {
                Console.WriteLine("\nChoice not recognised. Please try again");
                option = ReadInteger("\nOption");
            }
            return option;
        }
        private static int ReadInteger(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }
        private static void Register()
        {
            
           
                library.Register();
            
        }
        private static void Buy_Item()
        {
            try
            {
                library.DisplayItems();
                library.BuyItems();
            }
            catch(Exception e )
            {
                Console.WriteLine("something went wrong. maybe the index was out of range");
            }
        }


        public static void Borrow_book()
        {
           
            library.DisplayMembers();
            library.DisplayItems();
            try
            {
                library.borrowBook();
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong. maybe the index was out of range");
            }

        }
        private static void Extend_book()
        {
            try
            {
                library.extendItem();
            }
            catch(Exception e)
            {
                Console.WriteLine("something went wrong. maybe the index was out of range went");
            }
        }
        public static void Return_Item()
        {
            library.displayLoans();
            try
            {
                library.returnLoan();
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong. maybe the index was out range");
            }

        }

        private static void view_members()
        {

            library.DisplayMembers();
           
        }
        private static void View_all_Items()
        {

            library.DisplayItems();

        }

        private static void view_loans()
        {
            library.displayLoans();

        }
    }
}
