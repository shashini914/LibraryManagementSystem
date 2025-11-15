using System;
using System.Collections.Generic;
using System.Text;

namespace SDAM_assignment
{
 public class Member:Customer

    {
        public static readonly string MEMBERSHIP_ACTIVATE = "Active Membership";
        public static readonly string MEMBERSHIP_DEACTIVATED = "Deactivated Membership";

        private static int nextId = 1;
        
        

      
        public Member(string subscriptionlevel, string name, int noOfItemsBorrowed) : base(name)
        {
            this.Id = nextId++;
            this.Subscriptionlevel = subscriptionlevel;
            this.NoOfItemsBorrowed = noOfItemsBorrowed++;
            this.Status = MEMBERSHIP_ACTIVATE;

        }

        public int Id { get;  }
            
        public string Subscriptionlevel { get; }

        public int NoOfItemsBorrowed { get; set; }

        public string Status { get; private set; }

        public void IncreaseNoOfBorrowsA()
        {

            NoOfItemsBorrowed++;
            
        }
        public void IncreaseNoOfBorrowsB()
        {


            NoOfItemsBorrowed++;
        }
        public void  IncreaseNoOfBorrowsC()
        {

            NoOfItemsBorrowed++;
        }
      
        public void ActivateMembership()
        {
            Status = MEMBERSHIP_ACTIVATE;
        }
        public void DeactivateMembership()
        {
            Status = MEMBERSHIP_DEACTIVATED;
        }
       
    }

  



}



