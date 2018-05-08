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

        public User(int userid,string username, string useremail,string userpassword,string usertype)
        {
            User_Id = userid;
            User_Name = username;
            User_Email = useremail;
            User_Type = usertype;
        }
        public User()
        {

        }
    }
}
