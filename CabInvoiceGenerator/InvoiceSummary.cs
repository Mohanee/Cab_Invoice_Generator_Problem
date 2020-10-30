using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class InvoiceSummary
    {
        int no_of_rides;
        double totalFare, averageFare_perRide;

        /// <summary>
        /// Constructor to set value of no_of_rides and totalFare variables
        /// </summary>
        /// <param name="no_of_rides">Total number of rides</param>
        /// <param name="totalFare">total fare for all rides</param>
        public InvoiceSummary(int no_of_rides, double totalFare)
        {
            this.no_of_rides = no_of_rides;
            this.totalFare = totalFare;
        }

        /// <summary>
        /// Calculating average fare from total rides and total fare
        /// </summary>
        public void CalculateAverageFare_perRide()
        {
            this.averageFare_perRide = (totalFare / no_of_rides);
        }

        /// <summary>
        /// Overriding ToString() method to return number of rides, total fare and average fare per ride all 
        /// into a single string
        /// </summary>
        /// <returns>single string with all values separated by comma</returns>
        public override string ToString() => this.no_of_rides+","+this.totalFare+","+this.averageFare_perRide;
       
    }
}
