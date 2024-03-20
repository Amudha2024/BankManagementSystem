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
    public class AdminHelper
    {
        public const string BASE_URL = "http://localhost:5278/api/Authenticate/";
        public const string BASE_URL_Loan = "http://localhost:5278/api/ApplyLoan/";

        public async Task<List<LoanDetail>> GetAllUserLoan()
        {
            List<LoanDetail> agent = null;
            string URL = BASE_URL_Loan + "GetAllLoan";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(URL);
                    var json = await response.Content.ReadAsStringAsync();
                    agent = JsonConvert.DeserializeObject<List<LoanDetail>>(json);

                }
            }
            catch (Exception ex) { }
            return agent;
        }

        public async Task<string> ApproveLoanStatus(LoanDetail loan)
        {
            string agent;
            string URL = BASE_URL_Loan + "UpdateLoanStatus";
            loan.Status = "Approved";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync(URL, loan, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json;
            }
            return agent;
        }

        public async Task<string> RejectLoanStatus(LoanDetail loan)
        {
            string agent;
            string URL = BASE_URL_Loan + "UpdateLoanStatus";
            loan.Status = "Rejected";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync(URL, loan, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json;
            }
            return agent;
        }
    }
}
