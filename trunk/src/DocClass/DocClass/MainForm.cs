using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using DocClass.Src.Dictionaries;
using DocClass.Src.Classification;
using DocClass.Src.DocumentRepresentation;

namespace DocClass
{
    /// <summary>
    /// Glowne okno aplikacji.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.splitContainerMain.Panel1Collapsed = true;
            this.buttonLearningStop.Visible = false;
            this.buttonClassificationStop.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnBayesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RadialNetworkToolStripMenuItem.Checked = false;
            this.BayesToolStripMenuItem.Checked = true;
            this.splitContainerMain.Panel1Collapsed = true;
        }

        private void RadialNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BayesToolStripMenuItem.Checked = false;
            this.RadialNetworkToolStripMenuItem.Checked = true;
            this.splitContainerMain.Panel1Collapsed = false;
        }

        private void OnClassificationStartButton_Click(object sender, EventArgs e)
        {
            this.buttonClassificationStop.Visible = true;
        }

        private void OnLearningStartButton_Click(object sender, EventArgs e)
        {
            this.buttonLearningStop.Visible = true;
        }

        private void OnLearningStopButton_Click(object sender, EventArgs e)
        {
            this.buttonLearningStop.Visible = false;
        }

        private void OnClassificationStopButton_Click(object sender, EventArgs e)
        {
            this.buttonClassificationStop.Visible = false;
        }

        private void buttonClassificationStop_Click(object sender, EventArgs e)
        {

        }

    }
}