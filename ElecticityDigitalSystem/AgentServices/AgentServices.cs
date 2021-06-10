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

    }
}