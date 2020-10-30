using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MIN = 1;
        const double MIN_FARE = 5;

        public double FareCalculation(int time, int distance)
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
    }
}
