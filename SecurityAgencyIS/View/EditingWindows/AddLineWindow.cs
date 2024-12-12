using SecurityAgencyIS.Presenter;
using SecurityAgencyIS.View.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityAgencyIS.View.EditingWindows
{
    public partial class AddLineWindow : Form, IAddLine
    {
        public event EventHandler AddButt;
        AddLinePresenter addLinePresenter;
        public AddLineWindow()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            addLinePresenter = new AddLinePresenter(this);
        }

        private void Add_Click(object sender, EventArgs e)
        {

        }
    }
}
