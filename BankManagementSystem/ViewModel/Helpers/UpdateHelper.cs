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
    public  class UpdateHelper
    {
        public const string BASE_URL = "http://localhost:5278/api/Authenticate/";
        public const string BASE_URL_Loan = "http://localhost:5278/api/ApplyLoan/";

        public async Task<UpdateUserDetail> GetUserDetail(string userName)
        {
            UpdateUserDetail userDetail;

            string URL = BASE_URL + "GetUserDetail/" + userName;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string json = await response.Content.ReadAsStringAsync();
                userDetail = JsonConvert.DeserializeObject<UpdateUserDetail>(json);
            };

            return userDetail;
        }

        public async Task<string> UpdateUserDetail(UpdateUserDetail userDetail)
        {
            string agent;
            string URL = BASE_URL + "UpdateUserDetail";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync(URL, userDetail, default);
                var json = await response.Content.ReadAsStringAsync();
                agent = json.ToString();
            }
            return agent;
        }

    }
}
