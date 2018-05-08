using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using AirMaintenanceSystemMVVM.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using AirMaintenanceSystemMVVM.Model;


namespace AirMaintenanceSystemMVVM.Persistency
{
    public class PersistencyFadace
    {
        const string ServerUrl = "http://localhost:63341/";
        HttpClientHandler handler;
        public PersistencyFadace()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

        }


        public User GetLogin(User login)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Users/" + login.User_Email).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var login1 = response.Content.ReadAsAsync<User>().Result;
                        return login1;
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        public List<User> GetLogin()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Users").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var loginlist = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                        return loginlist.ToList();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;

            }
        }
    }
}

