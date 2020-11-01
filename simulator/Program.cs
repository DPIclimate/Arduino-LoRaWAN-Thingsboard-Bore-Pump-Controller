using System;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;

namespace Pump_Sim {
    static class Program {
        // The docs say to only instatiate one instance of this class.
        public static HttpClient httpClient = new HttpClient();

                /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
    }
}
