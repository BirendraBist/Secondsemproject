using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using AirMaintenanceSystemMVVM.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Task = AirMaintenanceSystemMVVM.Model.Task;


namespace AirMaintenanceSystemMVVM.Persistency
{
    public class PersistencyFadace
    {
        
       
        const string ServerUrl = "http://localhost:50107/";
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
        
        public List<Station> GetStations()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Stations").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var stationlist = response.Content.ReadAsAsync<IEnumerable<Station>>().Result;
                        return stationlist.ToList();
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

                return null;

            }

        }
        public ObservableCollection<Monitor> om = new ObservableCollection<Monitor>();
        public ObservableCollection<Monitor> GetMonitors(int id)

        {
            
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Monitors").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var monitorlist = response.Content.ReadAsAsync<IEnumerable<Monitor>>().Result;

                        foreach (var m in monitorlist)
                        {
                           if(m.Station_ID==id) 
                               om.Add(m);
                        }
                        return om;
                      }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
                }
            }

        public ObservableCollection<int> omt = new ObservableCollection<int>();
        public ObservableCollection<Task> GetMonitorsTasks(int id)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/MonitorTasks").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var monitorlist = response.Content.ReadAsAsync<IEnumerable<MonitorTask>>().Result;

                        foreach (var u in monitorlist)
                        {
                            if (u.Monitor_ID == id)
                            omt.Add(u.Task_ID);
                        }
                        return ot;
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

                return null;
            }
        }

        public ObservableCollection<Task> ot = new ObservableCollection<Task>();
        public ObservableCollection<Task> GetTasks()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Tasks").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var tasklist = response.Content.ReadAsAsync<IEnumerable<Task>>().Result;

                        foreach (var u in tasklist)
                        {
                            foreach (var i in omt)
                            {
                                if (i == u.Task_ID)
                                ot.Add(u);
                            }
                            
                        }
                        return ot;
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
        

