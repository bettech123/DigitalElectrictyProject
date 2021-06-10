using System;
using ElectricityDigitalSystem;

namespace EDSAgentPortal
{   
    public class TariffInformation
    {
        public static void ViewCustomerInformation()
        {
            AgentService agentServices = new AgentService();
            Console.WriteLine("Please Provide Your Meter Number");
            string meterNumber = Console.ReadLine();
            var customer = agentServices.GetCustomerPersonalTariffInformation(meterNumber);
            if(customer != null)
            {
                Console.WriteLine($"Full Name :  {customer.CustomerFirstName} {customer.CustomerLastName}");
                Console.WriteLine($"Meter Number : {customer.CustomerMeterNumber}");
                Console.WriteLine($"Tariff Name : {customer.TarrifName}");
                Console.WriteLine($"Amount Purchased: {customer.CustomerAmount}");
                Console.WriteLine($"Agent Name : {customer.AgentName}");
                Console.WriteLine($"Kilowatts Bought: {customer.KilowattsPurchased}");
                Console.WriteLine($"Purchased Date : {customer.PurchasedDate}");
            }
            else
            {
                Console.WriteLine("No such User Exist");
            }
        }
    }
}