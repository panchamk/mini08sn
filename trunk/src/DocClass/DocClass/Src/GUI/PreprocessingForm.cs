using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DocClass.Src.Controller;

namespace DocClass.Src.GUI
{
    public partial class PreprocessingForm : Form
    {
        private DocClass.Src.Controller.Controller controller;


        public PreprocessingForm(DocClass.Src.Controller.Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        public void IncreseProgress(int value)
        {
            this.progressBarPreprocessing.Increment(value);
        }

        public void PreprocessingEnd()
        {
            labelMain.Text = "Preprocessing został zakończony.";
        }

        public int MaxProgress
        {
            get { return this.progressBarPreprocessing.Maximum; }
            set { this.progressBarPreprocessing.Maximum = value; }
        }

        private void PreprocessingForm_Load(object sender, EventArgs e)
        {

        }

        private void labelMain_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            controller.StopPreprocessing();
        }

        private void PreprocessingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.StopPreprocessing();
        }
    }
}
