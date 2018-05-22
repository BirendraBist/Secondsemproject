using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using AirMaintenanceSystemMVVM.ViewModel;
using AirMaintenanceSystemMVVM.Persistency;
using AirMaintenanceSystemMVVM.View;
using AirMaintenanceSystemMVVM.Model;
using System.Windows.Input;
using Windows.UI.Popups;


namespace AirMaintenanceSystemMVVM.Handler
{
    public class LogInHandler
    {
        public LogInViewModel LogInViewM { get; set; }
        public PersistencyFadace Persistency { get; set; }
        public LogInHandler(LogInViewModel logInViewM)
        {
            
            LogInViewM = logInViewM;
            Persistency = new PersistencyFadace();
        }
        public void AccountCheck()
        {
            var LU = Persistency.GetLogin();
            var L = from login in LU select login.User_Email;
            foreach (var i in L)
            
            {
                if (i.Equals(LogInViewM.NewUser.User_Email))
                {
                    {
                        var lu = (User)LU.FirstOrDefault(x => x.User_Email == LogInViewM.NewUser.User_Email);
                        if (lu.User_Password.Equals(LogInViewM.NewUser.User_Password))
                        {



                            if (lu.User_Type == "Technician")
                            {
                                var newFrame = new Frame();
                                newFrame.Navigate(typeof(StationView));
                                Window.Current.Content = newFrame;
                                Windows.UI.Xaml.Window.Current.Activate();
                            }
                            //else if (lu.User_Type == "Researcher")
                            //{
                            //    var newFrame = new Frame();
                            //    newFrame.Navigate(typeof(StationForResearcher));
                            //    Windows.UI.Xaml.Window.Current.Content = newFrame;
                            //    Windows.UI.Xaml.Window.Current.Activate();
                            //}
                        }
                    }
                }
                //else
                {
                  

                }
                
            }
        }
    }
}
