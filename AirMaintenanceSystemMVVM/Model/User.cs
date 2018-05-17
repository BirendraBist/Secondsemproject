using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMaintenanceSystemMVVM.Model
{
    public class User
    {
        public int User_Id { get; set; }

        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public string User_Type { get; set; }

        public User(int user_id,string user_name, string user_email,string user_password,string user_type)
        {
            User_Id = user_id;
            User_Name = user_name;
            User_Email = user_email;
            User_Type = user_type;
        }
        public User()
        {

        }
    }
}
