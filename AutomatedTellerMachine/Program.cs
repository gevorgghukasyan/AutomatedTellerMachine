using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using DAL;
using Core;

namespace AutomatedTellerMachine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new ATM();
            var presenter = new BusinessLogic(new Repository(), form,new UserRepository(),new NotificationService(),new Core.CardManager(new Repository(), new UserRepository()));
            Application.Run(form);
        }
    }
}
