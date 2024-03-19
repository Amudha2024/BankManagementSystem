using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BankManagementApi.Data;
using BankManagementApi.Model;

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
               //Role=model.Role,

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
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
           var user = appData.UserDetails.FirstOrDefault(d => d.UserName.ToLower() == model.UserName.ToLower());
            bool isValid = await userManager.CheckPasswordAsync(user, model.Password);
            if(user==null || !isValid)
            {
                return BadRequest("User name and Passwod is Incorrect");
            }
            return Ok(user);
        }


    }
}
