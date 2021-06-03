using System;
using System.Collections.Generic;
using EDSCustomerPortal.AppData;
using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Models;

namespace EDSCustomerPortal
{
    public class CustomerUpdateInputs
    {
        public static void CustomerInputingDetails()
        {
           Console.WriteLine("Welcome Please Update your records");
                CustomerService customerService = new CustomerService();
                string id = CustomerApplicationData.CurrentCustomerId;
                var customer = customerService.GetCustomerById(id);
                Console.WriteLine(customer.FirstName);
                Console.WriteLine("Which data would you like to update\n1. FirstName\n2.LastName\n3.Email Address\n4. Phone Number");
                var reply = Console.ReadLine();

                switch (reply)
                {
                    case "1":
                    Console.WriteLine("Enter your First Name");
                    string firstName = Console.ReadLine();
                    customer.FirstName = firstName;
                    break;
                    case "2":
                    Console.WriteLine("Enter your Last Name");
                    string lastName = Console.ReadLine();
                    customer.LastName = lastName;
                    break;
                    case "3":
                    Console.WriteLine("Enter your Email Address");
                    string email = Console.ReadLine();
                    customer.EmailAddress = email;
                    break;
                    case "4":
                    Console.WriteLine("Enter your Phone Number");
                    string phoneNumber = Console.ReadLine();
                    customer.PhoneNumber = phoneNumber;
                    break;
                }

                customerService.UpdateCustomer(customer);
   
        }
    }
}