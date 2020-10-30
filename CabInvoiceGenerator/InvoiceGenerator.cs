using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        /// <summary>
        /// Initialising constant values to variable for cost and min fare
        /// </summary>
        const int COST_PER_KM = 10;
        const int COST_PER_MIN = 1;
        const double MIN_FARE = 5;


        /// <summary>
        /// Method to calculate total fare for a single ride
        /// </summary>
        /// <param name="time">total time travelled</param>
        /// <param name="distance">total distance travelled</param>
        /// <returns>Total Fare for single ride</returns>
        public double SingleTripFareCalculation(int time, double distance)
        {
            if (distance <= 0 && time <= 0)
            {
                Console.WriteLine("Enter valid diatnce and time");
                return (-1);
            }

            else
            {
                double totalAmt = distance * COST_PER_KM + time * COST_PER_MIN;
                return (Math.Max(MIN_FARE, totalAmt));
            }
        }


        /// <summary>
        /// Method to calculate Total Fare for Multiple Rides
        /// </summary>
        /// <param name="time">Array of distance travelled per ride</param>
        /// <param name="distance">Array of time taken per ride</param>
        /// <returns>Sum total Fare of all the rides</returns>
        public double MultipleTripFareCalculation(int[] time, double[] distance)
        {
            double totalAmt = 0;
            if (distance.Length != time.Length && distance.Length==0)
            {
                Console.WriteLine("Some values are missing");
                return (-1);
            }

            else
            {
                for (int i = 0; i < distance.Length; i++)
                {
                   totalAmt += distance[i] * COST_PER_KM + time[i] * COST_PER_MIN;
                }
                return (Math.Max(MIN_FARE, totalAmt));
            }
        }
    }
}
