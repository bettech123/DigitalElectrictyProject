using System;

namespace EDSAgentPortal
{
    public class MenuSecondScreen
    {
        public static void AccessSecondScreen()
        {
            //Accept And Process Payments from a Customer For a 
            //particular Electricity Tariff subscription and 
            //Store that Information on the Customer in their
            // Database

            Console.WriteLine("Press 1 to Process a payment from a customer.");
            string reply = Console.ReadLine();
            switch (reply)
            {
                case "1":
                    AcceptPayment.AcceptUserDetailsForPayment();
                break;
                default:
                Console.WriteLine("Wrong input");
                break;
            }

        }
    }
}