using System.Threading.Tasks;
using System.Windows.Forms;
using SecurityAgencyIS.View;
using SecurityAgencyIS;
using SecurityAgencyIS.Models;
using SecurityAgencyIS.Presenter;

namespace SecurityAgencyIS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            MainWindow mainView = new MainWindow();
            //LoginWindow loginView = new LoginWindow();
            Application.Run(mainView);
        }
    }
}