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


        public event EventHandler AddLineButt;

        DataGridView MainDataGridView { get; }
    }
}
