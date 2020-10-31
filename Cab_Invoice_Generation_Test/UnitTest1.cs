using NUnit.Framework;
using CabInvoiceGenerator;
using System.Collections.Generic;

namespace Cab_Invoice_Generation_Test
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        RideRepository rideRepo;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
            rideRepo = new RideRepository();
        }

        /// <summary>
        /// To test whether MultipleTripFareCalculation method returns expected TotalFare for Multiple Rides
        /// Given an input of array of distance and array of time travelled
        /// </summary>
        [Test]
        public void Given_MultipleDistance_and_Time_Should_Return_Fare()
        {
            try
            {
                double[] distance = { 15, 10, 5 }; int[] time = { 20, 10, 5 };
                double actualFare = invoiceGenerator.MultipleTripFareCalculation(time, distance, InvoiceGenerator.RideType.NORMAL);

                Assert.AreEqual(335.0, actualFare);
            }
            catch (InvoiceException i)
            {
                Assert.AreEqual(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, i.type);
            }
        }


        /// <summary>
        /// To test whether the SingleTripFareCalculation method returns expected TotalFare
        /// </summary>
        [Test]
        public void Given_SingleDistance_and_Time_Should_Return_Fare()
        {
            try
            {
                double distance1 = 10; int time1 = 5;
                double actualFare = invoiceGenerator.SingleTripFareCalculation(time1, distance1, InvoiceGenerator.RideType.NORMAL);
                double actualFare2 = invoiceGenerator.SingleTripFareCalculation(2, 0.2, InvoiceGenerator.RideType.NORMAL);         //considering minimum fare criteria

                Assert.AreEqual(105, actualFare);
                Assert.AreEqual(5, actualFare2);
            }
            catch (InvoiceException i)
            {
                Assert.AreEqual(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, i.type);
            }
        }


        /// <summary>
        /// To test for correct invoice summary
        /// </summary>
        [Test]
        public void Given_MultipleDistance_and_Time_Should_Return_InvoiceSummary()
        {
            try
            {
                double[] distance = { 15, 10, 5, 10 };
                int[] time = { 20, 10, 5, 15 };

                invoiceGenerator.MultipleTripFareCalculation(time, distance, InvoiceGenerator.RideType.NORMAL);
                string actualInvoice = invoiceGenerator.GenerateInvoiceSummary();

                Assert.AreEqual("4,450,112.5", actualInvoice);
            }
            catch(InvoiceException i)
            {
                Assert.AreEqual(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, i.type);
            }
        }


        /// <summary>
        /// To test for correct invoice asper UserID
        /// </summary>
        [Test]
        public void Given_UserID_and_RideList_Should_Return_InvoiceSummary()
        {
            List<RideDetails> user1Details =  new List<RideDetails>();
                
            user1Details.Add( new RideDetails(20,15));
            user1Details.Add(new RideDetails(10, 10));
            user1Details.Add(new RideDetails(5, 5));
            user1Details.Add(new RideDetails(15, 10));
        
            rideRepo.AddUser("user1", user1Details);

            try
            {
                invoiceGenerator.MultipleTripFareCalculationList("user1", InvoiceGenerator.RideType.NORMAL);
                string actualInvoice = invoiceGenerator.GenerateInvoiceSummary();

                Assert.AreEqual("4,450,112.5", actualInvoice);
            }
            catch (InvoiceException e)
            {
                Assert.AreEqual(InvoiceException.ExceptionType.INVALID_USER_ID, e.type);
            }

        }


        /// <summary>
        /// To test invoice for premeir rides
        /// </summary>
        [Test]
        public void Given_RideType_Premier_Should_Return_InvoiceSummary()
        {
            double[] distance = { 15, 10, 5, 10 };
            int[] time = { 20, 10, 5, 15 };

            invoiceGenerator.MultipleTripFareCalculation(time, distance, InvoiceGenerator.RideType.PREMIER);
            string actualInvoice = invoiceGenerator.GenerateInvoiceSummary();

            Assert.AreEqual("4,700,175", actualInvoice);
        }
    }
}