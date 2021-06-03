using System;

namespace EDSCustomerPortal
{
    public class CustomersSecondScreen
    {
        public static void UpdateAndSubcribeMenu()
        {
            //UpdateProfileDetails updateProfileDetails = new UpdateProfileDetails();
            Menu menu = new Menu();
            Console.WriteLine("Welcome");
            Console.WriteLine("Press 1 to Update your Records\nPress 2 to Subcribe To A Tariff plan\nPress 3 to Unsubcribe from your Tariff Plan");
            string reply = Console.ReadLine();
            switch (reply)
            {
                case "1":
                CustomerUpdateInputs.CustomerInputingDetails();
                break;
                case "2":
                Console.WriteLine("Subcribing...");
                break;
                case "3":
                Console.WriteLine("Unsubscribing...");
                break;
            }
        }
    }
}