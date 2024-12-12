using SecurityAgencyIS.View.Interface;
using SecurityAgencyIS.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityAgencyIS
{
    public partial class LoginWindow : Form, ILogin
    {
        public ILogin _login { get; set; }
        public event EventHandler OpenRegistrationWindow;
        public event EventHandler OpenMainWindow;
        public LoginPresenter loginPresenter;
        public LoginWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            loginPresenter = new LoginPresenter(this);
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            OpenRegistrationWindow?.Invoke(this, EventArgs.Empty);
        }

        public string userLogin => textBox1.Text;
        public string userPassword => textBox2.Text;
        private void LoginButton_Click(object sender, EventArgs e)
        {
            OpenMainWindow?.Invoke(this, EventArgs.Empty);
        }
    }
}
