using BankManagementSystem.Model;
using BankManagementSystem.Model.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.ViewModel.Helpers
{
    public class SignUpHelper 
    {

        public const string BASE_URL = "http://localhost:5278/api/Authenticate/";
        public const string BASE_URL_Loan = "http://localhost:5278/api/ApplyLoan/";
        public const string POST_URL = "Register";
        public const string GET_URL = "ApplyLoan/all/{0}";

        public async Task<string> CreateAccount(NewUserDetails userDetail)
        {
            string agent;
            string URL = BASE_URL + POST_URL;

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(URL, userDetail, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json.ToString();
            }
            return agent;
        }

        public async Task<string> LoginAgent(LoginDetail loginDetail)
        {
            string agent;
            string URL = BASE_URL + "Login";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(URL, loginDetail, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json.ToString();
            }
            return agent;
        }

        public async Task<bool> SaveLoanDetail(LoanDetail loan)
        {
            string agent;
            string URL = BASE_URL + "SaveLoanDetail";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(URL, loan, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json;
            }
            return true;
           // return agent;
        }


        public async Task<List<LoanDetail>> GetUserLoan(string user)
        {
            List<LoanDetail> agent = null;

            
            string URL = BASE_URL_Loan + "GetLoan/"+user ;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(URL);
                    var json = await response.Content.ReadAsStringAsync();
                    agent = JsonConvert.DeserializeObject<List<LoanDetail>>(json);

                }
            }
            catch(Exception ex)
            {

            }
            return agent;
        }

        public async Task<List<LoanDetail>> GetAllUserLoan()
        {
            List<LoanDetail> agent = null;
            /// string URL = BASE_URL_Loan + "GetAllLoan" + string.Format(GET_URL, user); ;
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
            catch(Exception ex) { }
            return agent;
        }

        public async Task<UpdateUserDetail> GetUserDetail(string userName)
        {
            UpdateUserDetail userDetail;

            string URL = BASE_URL + string.Format(GET_URL, userName);

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string json = await response.Content.ReadAsStringAsync();
                userDetail = JsonConvert.DeserializeObject<UpdateUserDetail>(json);
            };

            //string agent;
            //string URL = BASE_URL + POST_URL;

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    var response = await httpClient.PostAsJsonAsync(URL, userDetail, default);
            //    var json = await response.Content.ReadAsStringAsync();
            //    agent = json.ToString();
            //}
            //return agent;

            return userDetail;
        }
      

        public async Task<string> ApproveLoanStatus(LoanDetail loan)
        {
            string agent;
            string URL = BASE_URL_Loan + "UpdateLoanStatus";
            loan.Status = "Approved";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync(URL, loan,default);
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
