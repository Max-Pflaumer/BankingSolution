using BankingDomain;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Inversion of control container
            //A piece of software that knows how to contstruct our object for us
            //It is a super factory. We will train it, then say you make the "Form1"
            var container = Bootstrap();
            Application.Run(container.GetInstance<Form1>()); // This is the new "new"
        }

        public static Container Bootstrap()
        {
            //This is known as the "Composition Root"
            var container = new Container(); // This will be about our only us of teh "new" keyword for a whie
                                             // If we are trying to avoid coupling, "new is glue"
                                             //If these interfaces are needed in our project, use the container
            container.Options.EnableAutoVerification = false;
            container.Register<ISystemTime, SystemTime>();
            container.Register<ICalculateBankAccountBonuses, StandardBonusCalculator>();
            container.Register<IProvideTheCutoffClock, StandardCutoffClock >();
            container.Register<INotifyTheFeds, WindowsFormsFedNotifier>();
            container.Register<BankAccount>(); //These two (this and below) are saying "be prepared to make these, too"
            container.Register<Form1>();

            return container;
        }
    }
}
