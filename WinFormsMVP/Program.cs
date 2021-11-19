using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMVP
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var repository = new Model.CustomerXmlRepository(Application.StartupPath);
            var view = new View.CustomerForm();
            var presenter = new Presenter.CustomerPresenter(view,repository);
            Application.Run(view);
        }
    }
}
