using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DocClass.Src.Tests;


namespace DocClass
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //test czytania zipa
            //RadialNetworkTest test = new RadialNetworkTest();
            //test.Tests();
            //end test

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}