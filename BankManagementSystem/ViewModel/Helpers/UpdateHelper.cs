﻿using BankManagementSystem.Model.Service;
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
    public static class UpdateHelper
    {
        public static async Task<UpdateUserDetail> GetUserDetail(string userName)
        {
            UpdateUserDetail userDetail;

            string URL = Helper.BASE_URL + "GetUserDetail/" + userName;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string json = await response.Content.ReadAsStringAsync();
                userDetail = JsonConvert.DeserializeObject<UpdateUserDetail>(json);
            };

            return userDetail;
        }

        public static async Task<string> UpdateUserDetail(UpdateUserDetail userDetail)
        {
            string agent=string.Empty;
            string URL = Helper.BASE_URL + "UpdateUserDetail";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.PutAsJsonAsync(URL, userDetail, default);
                    var json = await response.Content.ReadAsStringAsync();
                    agent = json.ToString();
                }
            }
            catch(Exception ex)
            {

            }
            return agent;
        }
    }
}
