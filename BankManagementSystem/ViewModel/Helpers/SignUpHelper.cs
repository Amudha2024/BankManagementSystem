using BankManagementSystem.Model;
using BankManagementSystem.Model.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.ViewModel.Helpers
{
    public  class SignUpHelper 
    {
        public  async Task<string> CreateAccount(NewUserDetails userDetail)
        {
            string agent = string.Empty;
            string URL = Helper.BASE_URL + Helper.POST_URL;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsJsonAsync(URL, userDetail, default);
                    var json = await response.Content.ReadAsStringAsync();
                    agent = json.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            return agent;
        }
    }
}
