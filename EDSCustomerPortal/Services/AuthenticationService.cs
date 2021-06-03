using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSCustomerPortal.Services
{
    public class AuthenticationService
    {
        public static string RegisterUser(CustomerModel model)
        {
            // if(model == null)
            // {
            //     throw new ArgumentNullException(nameof(model));
            // }
            // else
            // {
                CustomerService service = new CustomerService();
                string id = service.RegisterCustomer(model);
                return id == null ? "Failed" : "Success";
            //}
        }

        //Get User By Email.
        public static CustomerModel LoginUser(string email)
        {
            CustomerService service = new CustomerService();
            var customerfound = service.GetCustomerByEmail(email);
            return customerfound;
        }
        // public static CustomerModel updateUserDetails(string id)
        // {
        //     CustomerService customerService = new CustomerService();
        //     var customer = customerService.GetCustomerById(id);
        //     return customer;
        // }
    }
}
