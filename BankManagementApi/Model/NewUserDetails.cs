using Microsoft.AspNetCore.Identity;

namespace BankManagementApi.Model
{
    public class NewUserDetails : IdentityUser
    {
       
            public string Name { get; set; }
           
           
            //public string Token { get; set; }

            //public int Role { get; set; }
           
            public long ContactNumber { get; set; }
            public long PAN { get; set; }
            public string Address { get; set; }
            public string AccountType { get; set; }
            public DateTime Dob { get; set; }
            public string State { get; set; }
            public string Country { get; set; }

        }
}
