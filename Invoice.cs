using System;
using System.Collections.Generic;
using System.Text;

namespace SDAM_assignment
{
   public class Invoice
    {
        private static int invoiceId = 1;
        public const int x = 1;

        public int InvoiceID { get; }
        public string ItemsBought { get; set; }
        public double Total { get; set; }
      

       

        public Invoice( string itemsBought, double total)
        {
            this.InvoiceID = invoiceId++;
           
            this.ItemsBought = itemsBought;
            this.Total = total;
            
        }
    }
}
