using System;
using System.Collections.Generic;
using System.Text;

namespace SDAM_assignment
{
 class Item
    {
        public static readonly string AVAILABLE = "Available";
        public static readonly string BORROWED = "  Borrowed";

        private static int itemId = 0;

       

        public Item(string title, double price, int numofCopies, string type)
        {
            this.ItemId = itemId++;
            this.Title = title;

            this.Price = price;
            this.Status = AVAILABLE;
            this.NumofCopies = numofCopies;
            this.Type = type;
        }

        public int ItemId { get; }
        public string Title { get; }

        public double Price { get; }
        public string Status { get; private set; }
        public int NumofCopies { get; private set; }
        public string Type { get;  }

        public void SetAvailble()
        {
            Status = AVAILABLE;
        }
      
        public void SetBorrowed()
        {
            Status =BORROWED;
        }

        public void IncreaseCopies()
        {
            NumofCopies++;
        }
        public void DecreaseCopies()
        {
            NumofCopies--;

        }



    }
}
