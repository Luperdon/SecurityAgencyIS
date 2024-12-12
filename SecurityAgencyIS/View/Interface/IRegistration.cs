using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAgencyIS.View.Interface
{
    public interface IRegistration
    {
        public event EventHandler RegistrationButton;
        string userLogin { get; }
        string userPassword { get; }
        string userRole { get; }
        string adminPassword { get; }
    }
}
