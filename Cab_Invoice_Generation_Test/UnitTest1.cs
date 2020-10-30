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

        [Test]
        public void Given_Distance_and_Time_Should_Return_Fare()
        {
            int distance = 15; int time = 20;
            double actualFare = invoiceGenerator.FareCalculation(distance, time);

            Assert.AreEqual(170, actualFare);
        }
    }
}