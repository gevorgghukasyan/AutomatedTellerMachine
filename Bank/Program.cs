using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using DAL;


namespace Bank
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
            var form = new Bank();
            var menager = new Core.CardManager(new Repository(),new UserRepository());
            var presenter = new BuisnessLogic(form,new Repository(),new UserRepository(),new NotificationService(), menager);
            Application.Run(form );
        }
    }
}
