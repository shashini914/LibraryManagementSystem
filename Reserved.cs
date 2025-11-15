using System;
using System.Collections.Generic;
using System.Text;

namespace SDAM_assignment
{
   class Reserved
    {
        private static int resID = 1;
        

        public static readonly string RESERVED = "Reserved";
        public static readonly string AVAILABLE = "Available";
        public string Title { get;  }
       

        public  int ResID { get;  }
        public string Status { get; private set; }

        public Reserved(string title)
        {
            this.Title = title;
           
            this.ResID = resID++;
            this.Status = RESERVED;
            

        }

       
        public void SetReserved()
        {
            Status = RESERVED;
        }
        public void SetAvailable()
        {
            Status = AVAILABLE;
        }

      
    }
}
