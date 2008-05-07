using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DocClass.Src.GUI
{
    public partial class PreprocessingForm : Form
    {
        
        public PreprocessingForm(int max)
        {
            InitializeComponent();
            this.progressBarPreprocessing.Maximum = max;
        }

        public void IncreseProgress(int value)
        {
            this.progressBarPreprocessing.Increment(value);
        }

    }
}
