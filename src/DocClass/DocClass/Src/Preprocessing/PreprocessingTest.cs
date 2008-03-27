using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DocClass.Src.Preprocessing
{
    class PreprocessingTest
    {

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PreprocessingTestForm());
        }
    }
}
