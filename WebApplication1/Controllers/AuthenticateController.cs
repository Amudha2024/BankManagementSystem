using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BankManagementApi.Data;
using BankManagementApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BankManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly AppDataContext appData;
        private readonly UserManager<NewUserDetails> userManager;
        public AuthenticateController(AppDataContext appData, UserManager<NewUserDetails> userManager)
        {
            this.appData = appData;
            this.userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<string> Register([FromBody] UserDetailsDto model)
        {
           NewUserDetails detail = new NewUserDetails()
           {
               Name=model.Name,
               Email=model.Email,
               UserName=model.UserName,
               Address=model.Address,
               State=model.State,
               AccountType=model.AccountType,
               PAN = model.PAN,
               Country=model.Country,
               Dob=model.Dob,
               ContactNumber=model.ContactNumber,

           };
            try
            {
                var result = await userManager.CreateAsync(detail, model.Password);
                if (result.Succeeded)
                {
                    return "Register Sucessfully";
                }
                else
                {
                    return "Register Failed";
                    //return result.Errors.FirstOrDefault().Description;
                }
            }
            catch 
            {

            }
            return "Register Failed";
        }

        [HttpPost("Login")]
        public async Task<string> Login([FromBody] LoginDto model)
        {
           var user = appData.UserDetails.FirstOrDefault(d => d.UserName.ToLower() == model.UserName.ToLower());
            bool isValid = await userManager.CheckPasswordAsync(user, model.Password);
            if(user==null || !isValid)
            {
                return "User name and Passwod is Incorrect";
            }
            return "Login Sucessfully";
        }

        [HttpPost("SaveLoanDetail")]
        public async Task<bool> SaveLoanDetail([FromBody] LoanDetail loanDeatailDto)
        {
            try
            {
                await appData.LoanDetails.AddAsync(loanDeatailDto);
                await appData.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet("GetUserDetail/{userName}")]
        public async Task<NewUserDetails> GetUserDetails(string userName)
        {
            return await appData.UserDetails.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        [HttpPost("UpdateUserDetail")]
        public async Task<bool> UpdateUserDetail([FromBody] UserDetailsDto model)
        {
            NewUserDetails detail = new NewUserDetails()
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.UserName,
                Address = model.Address,
                State = model.State,
                AccountType = model.AccountType,
                PAN = model.PAN,
                Country = model.Country,
                Dob = model.Dob,
                ContactNumber = model.ContactNumber,

            };
            try
            {
                var result = await userManager.UpdateAsync(detail);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

            }
            return false;
        }

    }
}
