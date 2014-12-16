using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner_Pro.DataLayer
{
    public class User
    {
        public int _id;
        public String _username;
        public String _password;

        List<Roles> _roles = new List<Roles>();


        public List<Roles> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        public int ID {
            get { return _id; }
            set { _id = value; }
        }

        public String UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        

    }
}
