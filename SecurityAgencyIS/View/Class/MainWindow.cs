using SecurityAgencyIS.Models;
using SecurityAgencyIS.Presenter;
using SecurityAgencyIS.View.Interface;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SecurityAgencyIS
{
    public partial class MainWindow : Form, IMainWindow
    {
        public event EventHandler TableMenuEmployee;
        public event EventHandler TableMenuEvents;
        public event EventHandler TableMenuCities;
        public event EventHandler TableMenuStreets;
        public event EventHandler TableMenuContracts;
        public event EventHandler TableMenuIndividualEntity;
        public event EventHandler TableMenuLegalEntity;
        public event EventHandler TableMenuOwners;
        public event EventHandler TableMenuJobs;
        public event EventHandler TableMenuObjects;
        public event EventHandler TableMenuPayments;
        public event EventHandler TableMenuSchedule;
        public event EventHandler TableMenuSpecialMeans;
        public event EventHandler TableMenuWeapon;
        public event EventHandler TableMenuWeaponBrand;
        public event EventHandler TableMenuUsers;

        //public event EventHandler AddTableMenuEmployee;
        //public event EventHandler AddTableMenuEvents;
        //public event EventHandler AddTableMenuCities;
        //public event EventHandler AddTableMenuStreets;
        //public event EventHandler AddTableMenuContracts;
        //public event EventHandler AddTableMenuIndividualEntity;
        //public event EventHandler AddTableMenuLegalEntity;
        //public event EventHandler AddTableMenuOwners;
        //public event EventHandler AddTableMenuJobs;
        //public event EventHandler AddTableMenuObjects;
        //public event EventHandler AddTableMenuPayments;
        //public event EventHandler AddTableMenuSchedule;
        //public event EventHandler AddTableMenuSpecialMeans;
        //public event EventHandler AddTableMenuWeapon;
        //public event EventHandler AddTableMenuWeaponBrand;
        //public event EventHandler AddTableMenuUsers;

        public event EventHandler AboutTheProgram;

        public event EventHandler AddButt;
        public event EventHandler ChangeButt;
        public event EventHandler DeleteButt;
        public event EventHandler FindButt;
        public DataGridView MainDataGridView => dataGridView1;
        private string _userRole;
        private DBManage dataBase;
        public MainWindowPresenter mainWindowPresenter;

        string tableName = "";
        public MainWindow(string userRole)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            mainWindowPresenter = new MainWindowPresenter(this);
            _userRole = userRole;
            CustomizeUI();
        }

        private void CustomizeUI()
        {
                if (_userRole == "user")
                {
                    AddLineButton.Visible = false;
                    ChangeButton.Visible = false;
                    DeleteButton.Visible = false;
                    StripMenuUsers.Visible = false;
                }
                else if (_userRole == "admin" || _userRole == "manager")
                {
                    AddLineButton.Visible = true;
                    ChangeButton.Visible = true;
                    DeleteButton.Visible = true;
                }
        }

        public void ConnectionString(DataGridView dataGridView)
        {
            dataBase.SqlConnectionReader(dataGridView);
        }

        private void AddLineButton_Click(object sender, EventArgs e)
        {           
            AddButt?.Invoke(this, EventArgs.Empty);
        }
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            ChangeButt?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuEmployee_Click(object sender, EventArgs e)
        {
            TableMenuEmployee?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "employee";
        }

        private void StripMenuEvents_Click(object sender, EventArgs e)
        {
            TableMenuEvents?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "events";
        }

        private void StripMenuCities_Click(object sender, EventArgs e)
        {
            TableMenuCities?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "cities";
        }

        private void StripMenuStreets_Click(object sender, EventArgs e)
        {
            TableMenuStreets?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "streets";
        }

        private void StripMenuContracts_Click(object sender, EventArgs e)
        {
            TableMenuContracts?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "contracts";
        }

        private void StripMenuIndividualEntity_Click(object sender, EventArgs e)
        {
            TableMenuIndividualEntity?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "individualentity";
        }

        private void StripMenuLegalEntity_Click(object sender, EventArgs e)
        {
            TableMenuLegalEntity?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "legalentity";
        }

        private void StripMenuOwners_Click(object sender, EventArgs e)
        {
            TableMenuOwners?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "owners";
        }

        private void StripMenuJobs_Click(object sender, EventArgs e)
        {
            TableMenuJobs?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "job";
        }

        private void StripMenuObjects_Click(object sender, EventArgs e)
        {
            TableMenuObjects?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "objects";
        }

        private void StripMenuPayments_Click(object sender, EventArgs e)
        {
            TableMenuPayments?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "payment";
        }

        private void StripMenuSchedule_Click(object sender, EventArgs e)
        {
            TableMenuSchedule?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "schedule";
        }

        private void StripMenuSpecialMeans_Click(object sender, EventArgs e)
        {
            TableMenuSpecialMeans?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "specialmeans";
        }

        private void StripMenuWeapon_Click(object sender, EventArgs e)
        {
            TableMenuWeapon?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "weapon";
        }

        private void StripMenuWeaponBrand_Click(object sender, EventArgs e)
        {
            TableMenuWeaponBrand?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "weaponbrand";
        }

        private void StripMenuUsers_Click(object sender, EventArgs e)
        {
            TableMenuUsers?.Invoke(this, EventArgs.Empty);
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText);
            }
            tableName = "users";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AboutTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutTheProgram?.Invoke(this, EventArgs.Empty);
        }
        public string deleteFindId => textBox1.Text;
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteButt?.Invoke(this, EventArgs.Empty);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (tableName == "")
            {
                MessageBox.Show("Выберите сначала таблицу!");
            }
            else
            {
                if(string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox1.Text)) 
                {
                    MessageBox.Show("Эта строчка не может быть пустой при поиске чего-либо.", "Ошибка");
                }
                else
                {
                dataBase.Find(comboBox1.Text, tableName, textBox1.Text, dataGridView1);
                }
            }
        }
        private bool whiteTheme = false;
        private void тёмныйРежимToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (whiteTheme) 
            { 
            
                panel1.BackColor = Color.FromArgb(64, 64, 64);

                foreach (Control control in this.Controls)
                {
                    if (control is Label || control is Button)
                    {
                        control.ForeColor = Color.White;
                    }
                    else if (control is TextBox || control is ComboBox)
                    {
                        control.BackColor = Color.FromArgb(30, 30, 30);
                        control.ForeColor = Color.White;
                    }
                }
                whiteTheme = false;
            }
            else
            {
                panel1.BackColor = Color.FromArgb(200, 200, 200);

                foreach (Control control in this.Controls)
                {
                    if (control is Label || control is Button)
                    {
                        control.ForeColor = Color.FromArgb(64, 64, 64);
                    }
                    else if (control is TextBox || control is ComboBox)
                    {
                        control.BackColor = Color.FromArgb(255, 255, 255);
                        control.ForeColor = Color.FromArgb(64, 64, 64); ;
                    }
                }
                whiteTheme = true;
            }
        }
    }
}