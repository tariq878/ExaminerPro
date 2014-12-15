using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner_Pro
{
    public class WizardReturnEventArgs
    {
        WizardResult result;
        object data;

        public WizardReturnEventArgs(WizardResult result, object data)
        {
            this.result = result;
            this.data = data;
        }


        //test

        public WizardResult Result
        {
            get { return this.result; }
        }

        public object Data
        {
            get { return this.data; }
        }
    }
}
