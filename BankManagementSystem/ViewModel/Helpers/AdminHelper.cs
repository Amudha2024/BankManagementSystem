using BankManagementSystem.Model.Service;
using BankManagementSystem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace BankManagementSystem.ViewModel.Helpers
{
    public static class AdminHelper
    {
        public static async Task<List<LoanDetail>> GetAllUserLoan()
        {
            List<LoanDetail> agent = null;
            string URL = Helper.BASE_URL_Loan + "GetAllLoan";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(URL);
                    var json = await response.Content.ReadAsStringAsync();
                    agent = JsonConvert.DeserializeObject<List<LoanDetail>>(json).ToList();
                }
            }
            catch (Exception ex) { }
            return agent;
        }

        public static async Task<string> ApproveLoanStatus(LoanDetail loan)
        {
            string agent = string.Empty;
            string URL = Helper.BASE_URL_Loan + "UpdateLoanStatus";
            loan.Status = "Approved";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.PutAsJsonAsync(URL, loan, default);
                    var json = await response.Content.ReadAsStringAsync();
                    agent = json;
                }
            }
            catch (Exception ex)
            {
                agent = null;
            }
            return agent;
        }

        public static async Task<string> RejectLoanStatus(LoanDetail loan)
        {
            string agent = string.Empty;
            string URL =  Helper.BASE_URL_Loan + "UpdateLoanStatus";
            loan.Status = "Rejected";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.PutAsJsonAsync(URL, loan, default);
                    var json = await response.Content.ReadAsStringAsync();
                    agent = json;
                }
            }
            catch(Exception ex)
            {

            }
            return agent;
        }
    }
}
