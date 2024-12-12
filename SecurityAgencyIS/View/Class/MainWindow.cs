using SecurityAgencyIS.Models;
using SecurityAgencyIS.Presenter;
using SecurityAgencyIS.View.EditingWindows;
using SecurityAgencyIS.View.Interface;
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


        public event EventHandler AddLineButt;
        public DataGridView MainDataGridView => dataGridView1;
        DBManage dataBase;
        public MainWindowPresenter mainWindowPresenter;
        public MainWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            mainWindowPresenter = new MainWindowPresenter(this);
        }
        public void ConnectionString(DataGridView dataGridView)
        {
            dataBase.SqlConnectionReader(dataGridView);
        }

        private void AddLineButton_Click(object sender, EventArgs e)
        {
            AddLineButt?.Invoke(this, e);
        }

        private void StripMenuEmployee_Click(object sender, EventArgs e)
        {
            TableMenuEmployee?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuEvents_Click(object sender, EventArgs e)
        {
            TableMenuEvents?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuCities_Click(object sender, EventArgs e)
        {
            TableMenuCities?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuStreets_Click(object sender, EventArgs e)
        {
            TableMenuStreets?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuContracts_Click(object sender, EventArgs e)
        {
            TableMenuContracts?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuIndividualEntity_Click(object sender, EventArgs e)
        {
            TableMenuIndividualEntity?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuLegalEntity_Click(object sender, EventArgs e)
        {
            TableMenuLegalEntity?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuOwners_Click(object sender, EventArgs e)
        {
            TableMenuOwners?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuJobs_Click(object sender, EventArgs e)
        {
            TableMenuJobs?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuObjects_Click(object sender, EventArgs e)
        {
            TableMenuObjects?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuPayments_Click(object sender, EventArgs e)
        {
            TableMenuPayments?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuSchedule_Click(object sender, EventArgs e)
        {
            TableMenuSchedule?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuSpecialMeans_Click(object sender, EventArgs e)
        {
            TableMenuSpecialMeans?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuWeapon_Click(object sender, EventArgs e)
        {
            TableMenuWeapon?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuWeaponBrand_Click(object sender, EventArgs e)
        {
            TableMenuWeaponBrand?.Invoke(this, EventArgs.Empty);
        }

        private void StripMenuUsers_Click(object sender, EventArgs e)
        {
            TableMenuUsers?.Invoke(this, EventArgs.Empty);
        }
    }
}