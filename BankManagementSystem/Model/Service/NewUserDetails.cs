﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Model.Service
{
    public  class NewUserDetails
    {

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }

        public int Role { get; set; }
        public string Password { get; set; }
        public long ContactNumber { get; set; }
        public string PAN { get; set; }
        public string Address { get; set; }
        public string AccountType { get; set; }
        public DateTime Dob { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}
