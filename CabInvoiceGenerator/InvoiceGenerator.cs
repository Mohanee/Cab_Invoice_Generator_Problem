//using Cab_Invoice_Generation_Test;
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
        int NO_OF_RIDES = 1;
        double totalAmt = 0;

        /// <summary>
        /// Method to calculate total fare for a single ride
        /// </summary>
        /// <param name="time">total time travelled</param>
        /// <param name="distance">total distance travelled</param>
        /// <returns>Total Fare for single ride</returns>
        public double SingleTripFareCalculation(int time, double distance)
        {
            if (distance == 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Distance cannot be null");
            }
            else if (time == 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Time cannot be null");
            }
            else
            {
                totalAmt = distance * COST_PER_KM + time * COST_PER_MIN;
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
            if (distance.Length==0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Distance cannot be null");
            }
            else if(time.Length==0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Time cannot be null");
            }

            else
            {
                NO_OF_RIDES = distance.Length;
                for (int i = 0; i < distance.Length; i++)
                {
                   totalAmt += distance[i] * COST_PER_KM + time[i] * COST_PER_MIN;
                }
                return (Math.Max(MIN_FARE, totalAmt));
            }
        }


        /// <summary>
        /// Method to calculate total fare of all the rides
        /// </summary>
        /// <param name="rideList">List of ride details</param>
        /// <returns>Total fare</returns>
        public double MultipleTripFareCalculationList(string userID)
        {
            RideRepository rideRepo = new RideRepository();
            if (rideRepo.rideRepoDict.ContainsKey(userID))
            {
                List<RideDetails> rideList = rideRepo.GetRideDetailsofUser(userID);
                if (rideList.Count != 0)
                {
                    foreach (var rides in rideList)
                    {
                        totalAmt += rides.distance * COST_PER_KM + rides.time * COST_PER_MIN;
                    }
                }
                return (Math.Max(MIN_FARE, totalAmt));
            }
            else
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "UserID not found");
            }
        }



        /// <summary>
        /// Generates Invoice in string format
        /// </summary>
        /// <returns>string containing no_ofrides,totalFare,averageFare_perRide</returns>
        public string GenerateInvoiceSummary()
        {
            InvoiceSummary ic = new InvoiceSummary(NO_OF_RIDES, totalAmt);
            ic.CalculateAverageFare_perRide();
            string invoice = ic.ToString();
            return (invoice);
        }


        /// <summary>
        /// Creates rideList and add it to the ride Repository per User
        /// </summary>
        /// <param name="userID">userID if the user</param>
        public void CreateRideRepository(string userID)
        {
            List<RideDetails> rideList = new List<RideDetails>();
            Console.WriteLine("Enter the number of rides");
            NO_OF_RIDES = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < NO_OF_RIDES; i++)
            {
                Console.WriteLine("Enter the time and distance separated by space for ride " + (i + 1));
                int time = Convert.ToInt32(Console.ReadLine());
                double distance = Convert.ToInt32(Console.ReadLine());
                RideDetails newRide = new RideDetails(time, distance);
                rideList.Add(newRide);
            }

             RideRepository rideReop = new RideRepository();
            rideReop.AddUser(userID, rideList);
        }
    }
    
}
