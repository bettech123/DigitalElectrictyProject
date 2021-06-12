using System;
using System.Collections.Generic;
using EDSAgentPortal.AppData;
using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;


namespace EDSAgentPortal
{
    public class AgentUpdateInputs
    {
        public static void AgentInputingDetails()
        {
                Console.WriteLine("Welcome Please Update your records");
                AgentService agentService = new AgentService();
                JsonFileService jsonFileService = new JsonFileService();
                string id = AgentApplicationData.CurrentAgentId;
                var agent = agentService.GetAgentById(id);
                Console.WriteLine(agent.FirstName);
                Console.WriteLine("Which data would you like to update\n press 1 for FirstName\nPress 2 for LastName\nPress 3 for Email Address\nPress 4 for Phone Number\nPress 5 for Password\nPress 6 for Meter Number");
                var reply = Console.ReadLine();

                switch (reply)
                {
                    case "1":
                    Console.WriteLine("Enter your new First Name");
                    string firstName = Console.ReadLine();
                    agent.FirstName = firstName;
                    break;
                    case "2":
                    Console.WriteLine("Enter your new Last Name");
                    string lastName = Console.ReadLine();
                    agent.LastName = lastName;
                    break;
                    case "3":
                    Console.WriteLine("Enter your new Email Address");
                    string email = Console.ReadLine();
                    agent.EmailAddress = email;
                    break;
                    case "4":
                    Console.WriteLine("Enter your new Phone Number");
                    string phoneNumber = Console.ReadLine();
                    agent.PhoneNumber = phoneNumber;
                    break;
                    case "5":
                    Console.WriteLine("Enter your new password");
                    string password = Console.ReadLine();
                    agent.Password = password;
                    break;
                    case "6":
                    Console.WriteLine("Enter your new Meter Number");
                    string meterNumber = Console.ReadLine();
                    agent.MeterNumber = meterNumber;
                    break;
                }
            customer.ModifiedDateTime = DateTime.Now;
            jsonFileService.SaveChanges();
                agentService.UpdateAgentinfo(agent);
                Console.WriteLine("Redirecting ....");
                AgentSecondScreen.UpdateAndSubcribeMenu();             
   
        }
    }
}