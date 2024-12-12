using SecurityAgencyIS.View.EditingWindows;
using SecurityAgencyIS.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAgencyIS.Presenter
{
    public class AddLinePresenter
    {
        IAddLine _addLine;

        public AddLinePresenter(IAddLine addLine)
        {
            _addLine = addLine;
        }

        public void AddButton(object args, EventArgs e)
        {

        }
    }
}
