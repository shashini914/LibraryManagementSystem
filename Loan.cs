using System;
using System.Collections.Generic;
using System.Text;

namespace SDAM_assignment
{
  public class Loan
    {
        private const Double x = 1.00;

        private static int loanId = 1;
        

        public int Id { get; }
      
        public DateTime extendDate { get; private set; }
        public DateTime LoanDate { get; private set; }

       public DateTime returnDate { get; private set; }

        public Loan()
        {
   
            this.Id = loanId++;
         
            this.LoanDate = DateTime.Today;
           
            this.returnDate = LoanDate.AddDays(7);

            this.extendDate = returnDate.AddDays(7);
        }

       public void fine()
        {
            if (DateTime.Now <returnDate)
            {
                Console.WriteLine($"your fine ${x}");
            }
            else
            {
                Console.WriteLine("there is no fine");
            }
        }
    }
}
