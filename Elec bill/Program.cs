using System;

class EnergyTechBilling
{
    static void Main()
    {
        Console.Write("Enter number of consumers: ");
        int N = int.Parse(Console.ReadLine());

        double totalRevenue = 0;
        double highestBill = 0;
        string highestBillConsumerID = "";
        int domesticCount = 0;
        int commercialCount = 0;

        Console.WriteLine("\n--- Consumer Bills ---");

        for (int i = 0; i < N; i++)
        {
            Console.Write("\nEnter ConsumerID: ");
            string consumerID = Console.ReadLine();

            Console.Write("Enter Units Consumed: ");
            int units = int.Parse(Console.ReadLine());

            Console.Write("Enter Connection Type (1 = Domestic, 2 = Commercial): ");
            int type = int.Parse(Console.ReadLine());

            string typeName = type == 1 ? "Domestic" : "Commercial";

            if (type == 1) domesticCount++;
            else commercialCount++;

            double baseCharge = 0;

            if (type == 1)
            {
                if (units <= 100)
                    baseCharge = units * 1.50;
                else if (units <= 300)
                    baseCharge = units * 2.50;
                else
                    baseCharge = units * 4.00;
            }
            else
            {
                if (units <= 200)
                    baseCharge = units * 5.00;
                else if (units <= 500)
                    baseCharge = units * 6.50;
                else
                    baseCharge = units * 8.00;
            }

            double surcharge = baseCharge * 0.03;
            double penalty = units > 500 ? 200 : 0;
            double total = baseCharge + surcharge + penalty;
            double discount = total > 2000 ? total * 0.05 : 0;
            double finalBill = total - discount;

            if (finalBill > highestBill)
            {
                highestBill = finalBill;
                highestBillConsumerID = consumerID;
            }

            totalRevenue += finalBill;

            Console.WriteLine("\n" + consumerID + " " + typeName + " Units:" + units);
            Console.WriteLine("BaseCharge: ₹" + baseCharge.ToString("F2"));
            Console.WriteLine("Surcharge (3%): ₹" + surcharge.ToString("F2"));
            Console.WriteLine("Penalty: ₹" + penalty.ToString("F2"));
            Console.WriteLine("Discount: ₹" + discount.ToString("F2"));
            Console.WriteLine("Final Bill: ₹" + finalBill.ToString("F2"));
        }

        Console.WriteLine("\n--- Summary ---");
        Console.WriteLine("Total Consumers: " + N);
        Console.WriteLine("Total Revenue: ₹" + totalRevenue.ToString("F2"));
        Console.WriteLine("Highest Bill: " + highestBillConsumerID + " ₹" + highestBill.ToString("F2"));
        Console.WriteLine("Domestic: " + domesticCount + "   Commercial: " + commercialCount);
    }
}

