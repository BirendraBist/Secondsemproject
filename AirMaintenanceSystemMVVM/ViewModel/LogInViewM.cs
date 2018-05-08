using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AirMaintenanceSystemMVVM.Model;
using AirMaintenanceSystemMVVM.Common;

namespace AirMaintenanceSystemMVVM.ViewModel
{
     public class LogInViewM : INotifyPropertyChanged
    {
        
        public Handler.LogInHandler LogInHandler { get; set; }
        public ICommand CheckCommand { get; set; }

        private User _newUser;
        public User NewUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }

        //property 
        private int _userId;
        public int User_ID
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }

        private int _userName;

        public int User_Name
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private int _userEmail;
        public int User_Email
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                OnPropertyChanged();
            }
        }
        private int _userPassword;
        public int User_Password
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                OnPropertyChanged();
            }
        }

        private int _userType;
        
        public int User_Type
        {
            get { return _userType; }
            set
            {
                _userType = value;
                OnPropertyChanged();
            }
        }

        public LogInViewM()
        {
            LogInHandler = new Handler.LogInHandler(this);
            NewUser = new User();
            
            CheckCommand = new RelayCommand(LogInHandler.AccountCheck);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
