using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAgencyIS.View.Interface
{
    public interface ILogin
    {
        public event EventHandler OpenRegistrationWindow; 
        public event EventHandler OpenMainWindow;

        string userLogin { get; }
        string userPassword { get; }
    }
}
