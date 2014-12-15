using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner_Pro.DataLayer
{
    class Context
    {
        public class Context : DbContext
        {
            public Context()
                : base()
            {



            }
            public DbSet<Course> _Courses { get; set; }
        }
    }
}
