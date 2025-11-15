using System;
using System.Collections.Generic;
using System.Text;

namespace SDAM_assignment
{
    class Library
    {
        List<Item> itemsinthestore = new List<Item>();
        List<Member> membersofthestore = new List<Member>();
        List<Invoice> invoices = new List<Invoice>();
        List<Loan> loans = new List<Loan>();

        List<Reserved> reservedItems = new List<Reserved>();

        public Library()
        {


            itemsinthestore.Add(new Item("title 1", 22.3,100,"Lending item"));
            itemsinthestore.Add(new Item("title 2", 4.5,100, "Lending item"));
            itemsinthestore.Add(new Item("title 3", 34.3,40, "Lending item"));
            itemsinthestore.Add(new Item("title 4", 22.3,80, "PR item"));
            itemsinthestore.Add(new Item("title 5", 4.5,10, "PR item"));
            itemsinthestore.Add(new Item("title 6", 34.3,30, "Lending item"));

            membersofthestore.Add(new Member("A", "Sanadhi", 1));//subsription level, name, no of borrowed items
            membersofthestore.Add(new Member("C", "Kamal", 1));
            membersofthestore.Add(new Member("B", "Nila", 2));
            membersofthestore.Add(new Member("A", "millie", 3));//subsription level, name, no of borrowed items
            membersofthestore.Add(new Member("C", "namal", 0));
            membersofthestore.Add(new Member("B", "sarath", 2));


            loans.Add(new Loan());
            loans.Add(new Loan());
            loans.Add(new Loan());

            reservedItems.Add(new Reserved("title4"));
            reservedItems.Add(new Reserved("title5"));
            reservedItems.Add(new Reserved("title6"));


        }
        public void DisplayItems()
        {

            for (int i = 0; i < itemsinthestore.Count; i++)
            {
                Console.WriteLine($"          {itemsinthestore[i].ItemId }           {itemsinthestore[i].Title}       {itemsinthestore[i].Price}        {itemsinthestore[i].Status}       {itemsinthestore[i].NumofCopies}      {itemsinthestore[i].Type} ");
            }
            
        }
        public void DisplayMembers()
        {

            foreach (Member member in membersofthestore)
            {            
                Console.WriteLine($"  {member.Id}     { member.Name}       {member.Subscriptionlevel}    {member.NoOfItemsBorrowed}      {member.Status}   ");
            }
        }
        public void Register()
        {
            Console.WriteLine("whats your name:");
            string name = Console.ReadLine();
            Console.WriteLine("what is the preferred aubscription level?");
            string sublevel = Console.ReadLine();
            string sublevel1 = sublevel.ToUpper();

            membersofthestore.Add(new Member(sublevel1, name, 0));
            foreach (Member member in membersofthestore)
            {
                Console.WriteLine("\n");
                Console.WriteLine(" Member ID: " + member.Id + "      Name: " + member.Name + "         Subscription level " + member.Subscriptionlevel + "       No of items borrowed:  " + member.NoOfItemsBorrowed+"          "+member.Status);
                Console.WriteLine("\n");
            }
        }

        public void returnItem()
        {
            Console.WriteLine("enter the item id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Thank you for returning "+itemsinthestore[id].ItemId+"  "+ itemsinthestore[id].Title+" . ");
            itemsinthestore[id].IncreaseCopies();

        }

        public void buyItem()
        {
            Console.WriteLine("enter the item id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(itemsinthestore[id].ItemId + "  " + itemsinthestore[id].Title);
            itemsinthestore[id].DecreaseCopies();

        }
        public void borrowBook()
        {
            Console.WriteLine("enter the item id:");
            int id = Convert.ToInt32(Console.ReadLine());
            if(itemsinthestore[id].Type=="PR item")
            {
                Console.WriteLine("this item is a PR item. PR items cannot be borrowed.");
            }
            else
            {
                itemsinthestore[id].SetBorrowed();
                Console.WriteLine(itemsinthestore[id].Status);
                Console.WriteLine("Member ID?");
                int m = Convert.ToInt32(Console.ReadLine());
                var mem = membersofthestore.Find(membersofthestore => membersofthestore.Id == m);
                if (mem != null)
                {
                    switch (mem.Subscriptionlevel)
                    {
                        case "A":
                            if (mem.NoOfItemsBorrowed < 3 && mem.Subscriptionlevel == "A")
                            {
                                mem.IncreaseNoOfBorrowsA();
                                Console.WriteLine(mem.Id + "  " + mem.Subscriptionlevel + "  " + mem.Name + "    " + mem.NoOfItemsBorrowed);
                                itemsinthestore[id].DecreaseCopies();
                                loans.Add(new Loan());
                                foreach (Loan loan in loans)
                                {
                                    Console.WriteLine("loan ID   " + loan.Id + " loan date" + loan.LoanDate + "    return date  " + loan.returnDate);
                                }
                            }
                            else
                            {
                                Console.WriteLine("you have reached borrowing limit");
                            }

                            break;
                        case "B":
                            if (mem.NoOfItemsBorrowed < 2)
                            {
                                mem.IncreaseNoOfBorrowsB();
                                Console.WriteLine(mem.Id + "  " + mem.Subscriptionlevel + "  " + mem.Name + "    " + mem.NoOfItemsBorrowed);

                                itemsinthestore[id].DecreaseCopies();

                                loans.Add(new Loan());
                                foreach (Loan loan in loans)
                                {
                                    Console.WriteLine("loan ID   " + loan.Id + " loan date" + loan.LoanDate + "    return date  " + loan.returnDate);
                                }
                            }
                            else
                            {
                                Console.WriteLine("you have reached borrowing limit");

                            }

                            break;
                        case "C":
                            if (mem.NoOfItemsBorrowed < 1)
                            {
                                mem.IncreaseNoOfBorrowsC();
                                Console.WriteLine(mem.Id + "  " + mem.Subscriptionlevel + "  " + mem.Name + "    " + mem.NoOfItemsBorrowed);
                                itemsinthestore[id].DecreaseCopies();

                                loans.Add(new Loan());
                                foreach (Loan loan in loans)
                                {
                                    Console.WriteLine("loan ID   " + loan.Id + " loan date" + loan.LoanDate + "    return date  " + loan.returnDate);
                                }
                            }
                            else
                            {
                                Console.WriteLine("you have reached borrowing limit");

                            }

                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Please register to borrow");
                }

            }


        }
        public void displayLoans()
        {
            foreach (Loan loan in loans)
            {
                Console.WriteLine("loan ID   " + loan.Id + " loan date" + loan.LoanDate + "    return date  " + loan.returnDate);
            }
        }
        public void returnLoan()
        {
            
                Console.WriteLine("enter the loan id");
                int loanID = Convert.ToInt32(Console.ReadLine());
                var isloan = loans.Find(loans => loans.Id == loanID);
                if (isloan != null)
                {
                    loans.Remove(isloan); ;
                    Console.WriteLine("Member ID?");
                    int memid = Convert.ToInt32(Console.ReadLine());

                    var mem = membersofthestore.Find(membersofthestore => membersofthestore.Id == memid);
                    if (mem != null)
                    {

                        mem.DeactivateMembership();

                        Console.WriteLine("  " + mem.Id + "    " + mem.Status + "\t PLEASE PAY THE FINE FINE TO ACTIVATE YOUR MEMBERSHIP");
                        returnItem();
                    }
                    else
                    {
                        Console.WriteLine("invalid member ID");
                    }
                    Loan loan = new Loan();
                    loan.fine();
                }
                else
                {
                    Console.WriteLine("there is no loan");
                }
            
        }
       

        public void BuyItems()
        {
            Console.WriteLine("enter the item id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(itemsinthestore[id].ItemId + "  " + itemsinthestore[id].Title);
            itemsinthestore[id].DecreaseCopies();
           
            Console.WriteLine("Cost " + itemsinthestore[id].Price);
            var total = itemsinthestore[id].Price;
            string itemBought = itemsinthestore[id].Title;

            Console.WriteLine("buy another item? (yes/no)");  //make this loop
            string answer = Console.ReadLine();
            string answer1 = answer.ToLower();
            bool isBuy = (answer1 == "yes");
            if (isBuy)
            {
                Console.WriteLine("select item :");
                int index1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Cost " + itemsinthestore[index1].Price);
                total = total + itemsinthestore[index1].Price;
                Console.WriteLine("the total to be paid : $" + total);
                string itemBought2 = itemsinthestore[index1].Title;
            }
            else
            {
                Console.WriteLine("proceed to payment");
            }

            Console.WriteLine("enter member id");
            int memid = Convert.ToInt32(Console.ReadLine());

            var mem = membersofthestore.Find(membersofthestore => membersofthestore.Id == memid);
            if (mem != null)
            {
                Console.WriteLine($"{membersofthestore[memid].Name}   is a member\t you get a membership discount of ${Invoice.x} ");
                total = total - Invoice.x;
                invoices.Add(new Invoice(itemBought, total));
                foreach (Invoice invoice in invoices)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(invoice.InvoiceID + "           Items bought   " + invoice.ItemsBought + " total   $ " + invoice.Total + " discount $" + Invoice.x);
                }
            }
            else
            {
                Console.WriteLine("not a member");
                Console.WriteLine("Enter your name:");
                string name = Console.ReadLine();
                Customer customer = new Customer(name);
                invoices.Add(new Invoice(itemBought, total));
                foreach (Invoice invoice in invoices)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{customer.Name}  Invoice ID  {invoice.InvoiceID}    Items bought   {invoice.ItemsBought}  total :  $ { invoice.Total}");
                }
            }
        }

        public void extendItem()
        {   
                Console.WriteLine("would you like to extend the book? (yes/no)");
            string answer = Console.ReadLine();
            string answer1 = answer.ToLower();
            if (answer1 == "yes")
            {
                Console.WriteLine("enter the ID:");
                int resId = Convert.ToInt32(Console.ReadLine());
                var extend = reservedItems.Find(reservedItems => reservedItems.ResID == resId);
                if (extend != null)
                {
                    Console.WriteLine("you cannot extend because this item is reserved");
                    Notfication notif = new Notfication("your reserved book is available");
                    notif.displayNotification();
                    reservedItems[resId].SetAvailable();
                    Console.WriteLine(reservedItems[resId].ResID+"  "+reservedItems[resId].Title+" "+ reservedItems[resId].Status);
                }
                else
                {
                    Console.WriteLine("extended for another week");
                    List<Loan> loans = new List<Loan>();
                    loans.Add(new Loan());
                    foreach (Loan loan in loans)
                    {
                        Console.WriteLine("loan ID   " + loan.Id + " loan date" + loan.LoanDate +  "  extend date  " + loan.extendDate);
                    }
                    
                }
            }

        }
    }
}