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
        public async Task<List<LoanDetail>> GetAllLoan()
        {
            return await appData.LoanDetails?.ToListAsync();
            //return await appData.LoanDetails?.Where(x => x.UserName == userName).ToListAsync();
        }



        [HttpGet("GetLoan/{userName}")]
        public async Task<List<LoanDetail>> GetLoan(string userName)
        {
            //return await appData.LoanDetails?.FirstOrDefaultAsync(x => x.LoanId == loanId);
            return await appData.LoanDetails?.Where(x => x.UserName == userName).ToListAsync();
        }

        [HttpPost("SaveLoanDetail")]
        public async Task<bool> SaveLoanDetail(LoanDeatailDto loanDeatailDto)
        {
            try
            {
                LoanDetail loan = new LoanDetail()
                {
                    LoanId = loanDeatailDto.LoanId,
                    LoanAmount = loanDeatailDto.LoanAmount,
                    LoanDate = loanDeatailDto.LoanDate,
                    LoanDuration = loanDeatailDto.LoanDuration,
                    LoanType = loanDeatailDto.LoanType,
                    RateOfInterst = loanDeatailDto.RateOfInterst,
                   Status= loanDeatailDto.Status,
                   Comment= loanDeatailDto.Comment,
                   UserName = loanDeatailDto.UserName,
                };

                await appData.LoanDetails.AddAsync(loan);
                await appData.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPut("UpdateLoanStatus")]
        public async Task<bool> UpdateLoanDetails(LoanDeatailDto loanDeatailDto)
        {
            try
            {
                LoanDetail loan = appData.LoanDetails.FirstOrDefault(s => s.LoanId == loanDeatailDto.LoanId);
                loan.LoanType = loanDeatailDto.LoanType;
                loan.Status= loanDeatailDto.Status;
                loan.LoanDuration = loanDeatailDto.LoanDuration;
                loan.Status = loanDeatailDto.Status;
                loan.LoanDate = loanDeatailDto.LoanDate;
                loan.UserName= loanDeatailDto.UserName;
                appData.LoanDetails.Update(loan);
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
