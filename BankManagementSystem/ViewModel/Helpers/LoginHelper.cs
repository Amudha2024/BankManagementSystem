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
    public class LoginHelper
    {
        public const string BASE_URL = "http://localhost:5278/api/Authenticate/";

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

    }
}
