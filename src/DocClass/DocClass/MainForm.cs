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
using DocClass.Src.Controller;
using DocClass.Src.Preprocessing;
using System.Diagnostics;
using System.IO;



namespace DocClass
{
    /// <summary>
    /// Glowne okno aplikacji.
    /// </summary>
    public partial class MainForm : Form
    {
        private Controller controller = new Controller();

        public MainForm()
        {
            InitializeComponent();

        }

        #region EVENTS

        private void MainForm_Load(object sender, EventArgs e)
        {
            splitContainerMain.Panel1Collapsed = true;
            
            labelValuePathLearningDir.Text = Properties.Settings.Default.pathLearningDir;
            labelValueNumbersHiddenNerons.Text = Properties.Settings.Default.hiddenLayerInitNeuronCount.ToString();
            labelValueNumbersOutNerons.Text = Properties.Settings.Default.outputLayerNeuronCount.ToString();
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
            String pathTemp = ShowFolderBrowserDialogDateLoad();

            OperationType operationType =  (OperationType)Properties.Settings.Default.operationType;
            switch (operationType)
            {
                case OperationType.Learning:
                    String pathSummaryTemp = pathTemp + "\\" + PreprocessingConsts.SummaryFileName;
                    if (!System.IO.File.Exists(pathSummaryTemp))
                    {
                        MessageBox.Show("Dokonaj preprocessing'u dla danych ucz¹cych.");
                        return;
                    }

                    Properties.Settings.Default.pathLearningDir = pathTemp;
                    Properties.Settings.Default.pathSummaryFile = pathSummaryTemp;
                    Properties.Settings.Default.numberAllWordsInDictionary = new WordCountList(pathSummaryTemp).GetUniqueWordsCount();

                    labelValuePathLearningDir.Text = Properties.Settings.Default.pathLearningDir;
                    labelValueWordNumber.Text = Properties.Settings.Default.numberAllWordsInDictionary.ToString();
                    break;
                case OperationType.Classification:
                    Properties.Settings.Default.pathLearningDir = pathTemp;
                    AddItemsToClassificationResultFtomDir(Properties.Settings.Default.pathLearningDir);
                    break;
                default:
                    break;
            }



            



            /*

        */
        }

        private void dataGridViewClassificationResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                String path = (String)dataGridViewClassificationResults.Rows[e.RowIndex].Tag;
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
            this.controller.Classificate(null);
        }

        private void buttonLearningStop1_Click(object sender, EventArgs e)
        {
            this.buttonLearningStop1.Visible = false;
            this.buttonLearningStart1.Visible = true;
        }

        private void buttonLearningStart1_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(Properties.Settings.Default.pathLearningDir))
            {
                MessageBox.Show("Nie mo¿na odnaleœæ katalogu z danymi ucz¹cymi.");
                return;
            }

            this.buttonLearningStop1.Visible = true;
            this.buttonLearningStart1.Visible = false;
            this.controller.Learn();
        }

        /// <summary>
        /// Zdarzenie wywo³ywane na zmiane zak³adki.
        /// Ustawia ustawia zmienn¹ OperationType z Settingsów w zale¿noœci od tego co jest wybrane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTabControlUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.operationType = this.tabControlUse.SelectedIndex;
        }

        #endregion

        #region METHODES

        /// <summary>
        /// Dodaje elementy do tabelki z wynikami klasyfikacji.
        /// </summary>
        /// <param name="tab"></param>
        public void AddItemsToClassificationResults(String[] tab,String path)
        {
            DataGridViewRow dgv = new DataGridViewRow();
            dgv.CreateCells(dataGridViewClassificationResults, tab);
            dgv.Tag = path;
            dataGridViewClassificationResults.Rows.Add(dgv);
        }

        private void AddItemsToClassificationResultFtomDir(String pathDir)
        {
            DirectoryInfo sourceDirInfo = new DirectoryInfo(pathDir);
            foreach (FileInfo sourceFile in sourceDirInfo.GetFiles())
            {
                AddItemsToClassificationResults(new string[] { sourceFile.Name, "", "Podgl¹d"},sourceFile.FullName);
            }
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