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
using System.Diagnostics;


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

        }

        #region EVENTS

        private void MainForm_Load(object sender, EventArgs e)
        {
            splitContainerMain.Panel1Collapsed = true;
            AddItemsToClassificationResults(new string[] { "testName", "testKategoria", "C:\\kapitanie.txt" });
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

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOpenFileDialogDateLoad("Tektowe (*.txt*)|*.txt*|Wszystkie (*.*)|*.*|Zip (*.zip*)|*.zip*");
        }

        private void directoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFolderBrowserDialogDateLoad();
        }

        private void dataGridViewClassificationResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                String path = dataGridViewClassificationResults.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                ShowFile(path);
            }
        }

        private void buttonClassificationStop_Click(object sender, EventArgs e)
        {
            this.buttonClassificationStop.Visible = false;
            this.buttonClassificationStart.Visible = true;
        }

        private void buttonClassificationStart_Click(object sender, EventArgs e)
        {
            this.buttonClassificationStop.Visible = true;
            this.buttonClassificationStart.Visible = false;
        }

        private void buttonLearningStop1_Click(object sender, EventArgs e)
        {
            this.buttonLearningStop1.Visible = false;
            this.buttonLearningStart1.Visible = true;
        }

        private void buttonLearningStart1_Click(object sender, EventArgs e)
        {
            this.buttonLearningStop1.Visible = true;
            this.buttonLearningStart1.Visible = false;
        }

        #endregion

        #region METHODES

        /// <summary>
        /// Dodaje elementy do tabelki z wynikami klasyfikacji.
        /// </summary>
        /// <param name="tab"></param>
        public void AddItemsToClassificationResults(String[] tab)
        {
            DataGridViewRow dgv = new DataGridViewRow();
            dgv.CreateCells(dataGridViewClassificationResults, tab);
            dataGridViewClassificationResults.Rows.Add(dgv);
        }

        /// <summary>
        /// Wyœwetla zawartoœæ dokumentu a podanej scie¿ce.
        /// </summary>
        /// <param name="path"></param>
        public void ShowFile(String path)
        {
            Process process = new Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = "notepad";
            process.StartInfo.Arguments = path;
            process.Start();
            process.WaitForExit();
        }

        /// <summary>
        /// Ustawia parametru nauki programu w g³ównym oknie aplikacji.
        /// </summary>
        public void SetLearningParameters()
        {
            labelValueAllNumbersCategories.Text = "3";
            labelValueAllNumbersParameters.Text = "3";

            labelValueTestNumbersCategories.Text = "3";
            labelValueTestNumbersDocuments.Text = "3";
            
            labelValueNumbersHiddenNerons.Text = "3";
            labelValueWordNumber.Text = "3";
        }

        /// <summary>
        /// Wyœwietla okno dialogowe do przegl¹dania folderów.
        /// </summary>
        /// <returns></returns>
        public String ShowFolderBrowserDialogDateLoad()
        {
            if (folderBrowserDialogDateLoad.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialogDateLoad.SelectedPath;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Wyœwietla okno dialogowe do wyboru pliku.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public String ShowOpenFileDialogDateLoad(String filter)
        {
            openFileDialogDateLoad.Filter = filter;
            if (openFileDialogDateLoad.ShowDialog() == DialogResult.OK)
            {
                return openFileDialogDateLoad.FileName;
            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}