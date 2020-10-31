using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideDetails
    {
        public double distance { get; set; }
        public int time { get; set; }

        public RideDetails(int time, double distance)
        {
            this.time = time;
            this.distance = distance;
        }

        List<RideDetails> rideList = new List<RideDetails>();
        public void AddToRideList(int time, double distance)
        {
            RideDetails newRide = new RideDetails(time, distance);
            rideList.Add(newRide);
        }

    }
}
