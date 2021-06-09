using System;
using System.Threading;
using ElectricityDigitalSystem;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace EDSAgentPortal
{
    public class AcceptPayment
    {
        public static void AcceptUserDetailsForPayment()
        {   
            //Creating Objects  
            JsonFileService jsonFileService = new JsonFileService();
            TarriffModel tarriffModel = new TarriffModel();
            AgentService agentService = new AgentService();
            var Agent = agentService.GetAgentById(AgentApplicationData.CurrentAgentId);
            AcceptAndProcessPaymentModel acceptAndProcessPaymentModel = new AcceptAndProcessPaymentModel();
            
            
            
            Console.WriteLine("tWelcome to the Payment Portal\ntFill in the required details to process a payment");
           
            acceptAndProcessPaymentModel.Id = Guid.NewGuid().ToString();
            Console.WriteLine("Input Your FullName : ");
            acceptAndProcessPaymentModel.AgentName = agentService.InputsValidation(Console.ReadLine());
            
            Console.WriteLine("Input Your Meter Number : ");
            acceptAndProcessPaymentModel.CustomerMeterNumber = agentService.InputsValidation(Console.ReadLine());
            Console.WriteLine("Current Tariff Classes Are \nS1 = #16/KWH\nA3 = #25/KWH\nD1 = #23/KWH\nR3 = #18/KWH");
            Console.WriteLine("What Tariff Class Are You Subcribing To ?\nPress 1 for S1\nPress 2 for A3\nPress 3 for D1\nPress 4 for R3");
            int tariffName = Convert.ToInt32(Console.ReadLine());
            switch (tariffName)
            {
                case 1:
                acceptAndProcessPaymentModel.TarrifName = "S1";
                acceptAndProcessPaymentModel.PricePerUnit = Convert.ToDecimal(TariffName.S1);
                break;
                case 2:
                tarriffModel.Name = "A3";
                tarriffModel.PricePerUnit = Convert.ToDecimal(TariffName.A3);
                break;
                case 3:
                tarriffModel.Name = "D1";
                tarriffModel.PricePerUnit = Convert.ToDecimal(TariffName.D1);
                break;
                case 4:
                tarriffModel.Name = "R3";
                tarriffModel.PricePerUnit = Convert.ToDecimal(TariffName.R3);
                break;
                default:
                Console.WriteLine("Wrong selection");
                break;

            }

            Console.WriteLine("Amount : ");
            acceptAndProcessPaymentModel.CustomerAmount = Convert.ToDecimal(Console.ReadLine());
            acceptAndProcessPaymentModel.AgentId = AgentApplicationData.CurrentAgentId;
            acceptAndProcessPaymentModel.AgentName = $"{Agent.FirstName}  {Agent.LastName}";

            jsonFileService.SaveChanges();
            agentService.SavePaymentDetails(acceptAndProcessPaymentModel);
            Console.WriteLine("Redirecting ....");
            Thread.Sleep(3000);
            MenuSecondScreen.AccessSecondScreen(); 
        }
    }
}