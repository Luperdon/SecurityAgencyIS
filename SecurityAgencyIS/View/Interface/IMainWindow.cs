using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAgencyIS.View.Interface
{
    public interface IMainWindow
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
        public event EventHandler Documents;
        public event EventHandler UserManual;

        public event EventHandler AddButt;
        public event EventHandler ChangeButt;
        public event EventHandler DeleteButt;
        public event EventHandler FindButt;
        string deleteFindId { get; }
        

        DataGridView MainDataGridView { get; }
    }
}
