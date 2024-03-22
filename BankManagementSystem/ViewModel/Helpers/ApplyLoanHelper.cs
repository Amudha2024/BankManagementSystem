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
    public static class ApplyLoanHelper
    {
        public static async Task<bool> SaveLoanDetail(LoanDetail loan)
        {
            string agent;
            string URL = Helper.BASE_URL + "SaveLoanDetail";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(URL, loan, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json;
            }
            return true;
        }

        public static async Task<List<LoanDetail>> GetUserLoan(string user)
        {
            List<LoanDetail> agent = new List<LoanDetail>();
            string URL = Helper.BASE_URL_Loan + "GetLoan/" + user;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(URL);
                    var json = await response.Content.ReadAsStringAsync();
                    agent = JsonConvert.DeserializeObject<List<LoanDetail>>(json);
                }
            }
            catch (Exception ex)
            {

            }
            return agent;
        }
    }
}
