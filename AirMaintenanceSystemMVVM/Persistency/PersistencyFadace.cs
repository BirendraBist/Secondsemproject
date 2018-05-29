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
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using Task = AirMaintenanceSystemMVVM.Model.Task;


namespace AirMaintenanceSystemMVVM.Persistency
{
    public class PersistencyFadace
    {


        const string ServerUrl = "http://localhost:50618/";
        HttpClientHandler handler;

        public PersistencyFadace()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            om = new ObservableCollection<Monitor>();
            omt = new ObservableCollection<int>();


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

        public ObservableCollection<Monitor> om;

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
                            if (m.Station_ID == id)
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

        
        public ObservableCollection<int> omt;

        public ObservableCollection<Task> GetMonitorsTasks(int Mid)
        {
            IEnumerable<MonitorTask> monitortasklist = new List<MonitorTask>();

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
                        monitortasklist = response.Content.ReadAsAsync<IEnumerable<MonitorTask>>().Result.ToList();



                        foreach (var u in monitortasklist)
                        {
                            if (u.Monitor_ID == Mid)
                                omt.Add(u.Task_ID);
                        }
                        var tasks = GetTasks();
                        return tasks;
                    }
                    
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

                return null; //return new ObservableCollection<MonitorTask>(monitorlist);
            }
        }

        public ObservableCollection<int> ot = new ObservableCollection<int>();

        public  ObservableCollection<Task> GetTasks()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var taskstoreturn = new ObservableCollection<Task>();
                try
                {
                    var response = client.GetAsync("api/Tasks").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var tasklist = response.Content.ReadAsAsync<IEnumerable<Task>>().Result;
                       foreach (var i in tasklist)
                        {
                            if (omt.Contains(i.Task_ID))
                            {
                                taskstoreturn.Add(i);
                            }
                        }
                       
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }

                return taskstoreturn;

            }
        }

        public void UpdateTask(Task TaskToUpdate)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                   
                    string jsonResidentToUpdate = JsonConvert.SerializeObject(TaskToUpdate);

                    
                    StringContent content = new StringContent(jsonResidentToUpdate, Encoding.UTF8, "Application/json");

                   
                    var updateResponse = client.PutAsync("api/Tasks/" + TaskToUpdate.Name, content).Result;
                    var result = updateResponse.StatusCode;

                    }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }


    }
}
        
    



        