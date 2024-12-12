using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Windows.Forms;
using SecurityAgencyIS.Models;
using SecurityAgencyIS.View.Interface;
using SecurityAgencyIS.Presenter;

namespace SecurityAgencyIS
{
    public partial class RegistrationWindow : Form, IRegistration
    {
        public IRegistration registration;
        public event EventHandler RegistrationButton;
        public RegistrationPresenter registrationPresenter;

        public RegistrationWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            registrationPresenter = new RegistrationPresenter(this);
        }

        private void ButtonHashPassword_Click(object sender, EventArgs e)
        {
            RegistrationButton?.Invoke(this, EventArgs.Empty);
        }
        public string userLogin => textBox1.Text;
        public string userPassword => textBox2.Text;
        public string adminPassword => textBox3.Text;
        public string userRole => comboBox1.Text;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
