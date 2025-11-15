using System;
using System.Collections.Generic;
using System.Text;

namespace SDAM_assignment
{
   public class Notfication
    {
        public Notfication(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }

        public void displayNotification()
        {
            Console.WriteLine(Message);
        }
    }
}
