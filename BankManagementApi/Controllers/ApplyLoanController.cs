using BankManagementApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankManagementApi.Data;

namespace BankManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyLoanController : ControllerBase
    {
        private readonly AppDataContext appData;


        public ApplyLoanController(AppDataContext appData)
        {
            this.appData = appData;
        }


        [HttpGet("GetAllLoan")]
        public async Task<List<LoanDetail>> GetAllLoan(string userName)
        {
            return await appData.LoanDetails?.Where(x => x.UserName == userName).ToListAsync();
        }

        [HttpGet("GetLoan")]
        public async Task<LoanDetail> GetLoan(int loanId)
        {
            return await appData.LoanDetails?.FirstOrDefaultAsync(x => x.LoanId == loanId);
        }

        [HttpPost("SaveLoanDetail")]
        public async Task<bool> SaveLoanDetail([FromBody]LoanDetail loanDetail)
        {
            try
            {
                await appData.LoanDetails.AddAsync(loanDetail);
                await appData.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
