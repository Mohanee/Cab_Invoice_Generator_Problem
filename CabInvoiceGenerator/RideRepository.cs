using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
       public Dictionary<string, List<RideDetails>> rideRepoDict = new Dictionary<string, List<RideDetails>>();

        public void AddUser(string userID, List<RideDetails> rideList)
        {
            rideRepoDict.Add(userID, rideList);
        }

        public List<RideDetails> GetRideDetailsofUser(string userID)
        {
            List<RideDetails> rideOfUser = new List<RideDetails>();
            foreach(var kvp in rideRepoDict)
            {
                if(kvp.Key==userID)
                {
                    rideOfUser = kvp.Value;
                }
            }
               return rideOfUser;
        }

        
    }
}
