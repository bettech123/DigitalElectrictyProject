using System;
using System.Collections.Generic;
using System.Threading;
using EDSCustomerPortal.AppData;
using EDSCustomerPortal.Services;
using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace EDSCustomerPortal
{
    public class Menu : CustomerModel
    {
        
            private static bool appIsRunning = true;
            private static bool inRegisterPage = false;
            private static bool inLoginPage = false;

            private static string id = null;
            
            
        public static void selection()
        {
            
            JsonFileService jsonFileService = new JsonFileService();
            jsonFileService.SaveChanges();
            


            while (appIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome To EDS CUSTOMER PORTAL.\n");

                Console.WriteLine("Choose an Option : 1. Login         2. Register");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        inLoginPage = true;
                        
                       break;
                    case "2":
                        inRegisterPage = true;
                        break;
                }

                while (inLoginPage)
                {
                    NavigateToLogInPage();
                    
                }
                while (inRegisterPage)
                {
                    NavigateToRegisterPage();
                }

                
            }
       

            static void NavigateToRegisterPage()
            {
                Dictionary<string, string> navItemDic = new Dictionary<string, string>();
                
                List<string> navigationItems = new List<string>
                {
                   "FirstName", "LastName" ,"Email" , "Password","Meter Number","Phone Number"
                };

                Console.Clear();
                Console.WriteLine("*** Register your Details ******* \n");
                CustomerModel customerModel = new CustomerModel();

                
                for(int index =0; index < navigationItems.Count; index++)
                {
                    Console.Write($"Enter your  {navigationItems[index]} : " );
                    string value = Console.ReadLine();
                    navItemDic.Add(navigationItems[index], value);
                }

                CustomerModel customerForm = new CustomerModel();
                string FirstName,LastName,EmailAddress , Password, MeterNumber,PhoneNumber;

                customerModel.Id =  "CUS-" + Guid.NewGuid().ToString();
                
                FirstName = navItemDic["FirstName"];
                LastName = navItemDic["LastName"];
                EmailAddress= navItemDic["Email"];
                Password = navItemDic["Password"];
                MeterNumber = navItemDic["Meter Number"];
                PhoneNumber = navItemDic["Phone Number"];

                customerForm.Id = customerModel.Id;
                customerForm.FirstName = FirstName;
                customerForm.LastName = LastName;
                customerForm.EmailAddress = EmailAddress;
                customerForm.Password = Password;
                customerForm.MeterNumber = MeterNumber;
                customerForm.PhoneNumber = PhoneNumber;
                
                string response = AuthenticationService.RegisterUser(customerForm);

                if (response == "Success")
                {
                    Console.WriteLine("Registered Successfully ---> Redirecting To Home Page");
                    Thread.Sleep(5000);
                }
                else
                {
                    Console.WriteLine("An Error Has Occured");
                } 

                inRegisterPage = false;

            }

            static  void NavigateToLogInPage()
            {
                Console.WriteLine("Welcome Please input your details");
                Console.WriteLine("Input Email");
                string Email = Console.ReadLine();
                Console.WriteLine("Input Password");
                string Password = Console.ReadLine();

                var customer = AuthenticationService.LoginUser(Email);
                if(customer == null)
                {
                    Console.WriteLine("No such user registered please check the details provided");
                }
                else
                {
                    if(customer.EmailAddress == Email && customer.Password != Password)
                    {
                        Console.WriteLine("Wrong Password Inputed");
                        while(customer.Password != Password)
                        {
                            Console.WriteLine("Input Password");
                            Password = Console.ReadLine();
                            break;
                        }
                    }
                    else if (customer.EmailAddress != Email && customer.Password == Password)
                    {
                         Console.WriteLine("Wrong Email Inputed");
                         while(customer.EmailAddress != Email)
                         {
                             Console.WriteLine("Input Email");
                            Email = Console.ReadLine();
                            break;   
                         }
                         
                    }
                    else
                    {
                        Console.WriteLine($"Welcome to the App {customer.FirstName} {customer.LastName}");
                        Console.WriteLine("Redircting to Next Page");
                        
                        id = customer.Id;
                        CustomerApplicationData.CurrentCustomerId = id;
                        Thread.Sleep(3000);
                        CustomersSecondScreen.UpdateAndSubcribeMenu();
                    
                    } 
                }
                
                inLoginPage = false;
            }

        
    }
    }
}