using NUnit.Framework;
using CabInvoiceGenerator;

namespace Cab_Invoice_Generation_Test
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
        }

        /// <summary>
        /// To test whether MultipleTripFareCalculation method returns expected TotalFare for Multiple Rides
        /// Given an input of array of distance and array of time travelled
        /// </summary>
        [Test]
        public void Given_MultipleDistance_and_Time_Should_Return_Fare()
        {
            double[] distance = { 15, 10, 5 }; int[] time = { 20, 10, 5 };
            double actualFare = invoiceGenerator.MultipleTripFareCalculation(time, distance);

            Assert.AreEqual(335.0, actualFare);
        }


        /// <summary>
        /// To test whether the SingleTripFareCalculation method returns expected TotalFare
        /// </summary>
        [Test]
        public void Given_SingleDistance_and_Time_Should_Return_Fare()
        {
            double distance1 = 10; int  time1 = 5;
            double actualFare = invoiceGenerator.SingleTripFareCalculation(time1, distance1);
            double actualFare2 = invoiceGenerator.SingleTripFareCalculation(2,0.2);         //considering minimum fare criteria

            Assert.AreEqual(105, actualFare);
            Assert.AreEqual(5, actualFare2);
        }
    }
}