using System;
using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace ElectricityDigitalSystem
{
    public class AgentService : AgentServiceAPI
    {
          public string RegisterCustomerSubcription(AcceptAndProcessPaymentModel PaymentDetails)
        {
           
           JsonFileService jsonFileService = new JsonFileService();
            fileService.database.AcceptingPayment.Add(PaymentDetails);
            fileService.SaveChanges();
            return PaymentDetails.Id;
        
        }

        public AgentsModel GetAgentById(string AgentId)
        {
            
            AgentsModel foundAgents = fileService.database.Agents.Find(A => A.Id == AgentId);
            if (foundAgents != null)
            {
                return foundAgents;
            }
            return null;
        }
        public string SavePaymentDetails(AcceptAndProcessPaymentModel PaymentDetails)
        {
           
           JsonFileService jsonFileService = new JsonFileService();
            fileService.database.AcceptingPayment.Add(PaymentDetails);
            fileService.SaveChanges();
            return PaymentDetails.Id;
        }

        public string InputsValidation(string input)
        {
            bool status = false;
            do
            {   
                if(input != null)
                {
                    status = true;
                    return input;
                }
                
            } while (status);
            return input;
        }

         public AcceptAndProcessPaymentModel GetCustomerPersonalTariffInformation(string meterNumber)
        {
            
            AcceptAndProcessPaymentModel foundCustomer = fileService.database.AcceptingPayment.Find(A => A.Id == meterNumber);
            if (foundCustomer != null)
            {
                return foundCustomer;
            }
            return null;
        }

        public void UpdateAgentinfo(AgentsModel agent)
        {
            Console.WriteLine("\t\tWhat would like to update?\n\n");
            Console.WriteLine("\t\t1 : First Name \n\t\t2 : Last Name\n\t\t3 : Email Address\n\t\t4 : Phone Number");
            Console.Write($"\t\t  : ");
            string NewEntry = Console.ReadLine();
            switch (NewEntry)
            {
                case "1":
                    Console.Write("\t\tFirst Name : ");
                    string newFirstName = Console.ReadLine();
                    while (string.IsNullOrEmpty(newFirstName))
                    {
                        Console.WriteLine("\n\n\t\tFirst name cannot be left blank");
                        Console.Write("\t\tFirst Name : ");
                        newFirstName = Console.ReadLine();
                    }
                    agent.FirstName = newFirstName;
                    agent.ModifiedDateTime = DateTime.Now;
                    
            }
        }

        
    }
}