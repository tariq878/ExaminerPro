using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminerProLib.DataLayer.Users
{
    public class Roles
    {
        int _id;
        String _desription;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Description
        {
            get { return _desription ; }
            set { _desription = value; }
        }

    }
}
