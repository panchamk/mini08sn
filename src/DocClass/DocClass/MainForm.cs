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
using DocClass.Src.GUI;
using System.Diagnostics;
using System.IO;



namespace DocClass
{
    /// <summary>
    /// Glowne okno aplikacji.
    /// </summary>
    public partial class MainForm : Form
    {
        private Controller controller;

        public ProgressBar ProgressBarClassification
        {
            get { return progressBarClassification; }
        }

        #region CONSTRUKTOR

        public MainForm()
        {
            InitializeComponent();
            controller = new Controller(this);

        }

        #endregion

        #region EVENTS

        /// <summary>
        /// ZA£ADOWANIE okna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMainForm_Load(object sender, EventArgs e)
        {            
            labelLearningValuePathDir.Text = Properties.Settings.Default.pathLearningDir;
            labelLearningValueNumbersHiddenNerons.Text = Properties.Settings.Default.hiddenLayerInitNeuronCount.ToString();
            labelLearningValueNumberOutNerons.Text = Properties.Settings.Default.outputLayerNeuronCount.ToString();
            labelLearningValueNumbersCategoriesAll.Text = Properties.Settings.Default.numberAllCategories.ToString();
        }

        /// <summary>
        /// WYJŒCIE w MENU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// BAYES w MENU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBayesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RadialNetworkToolStripMenuItem.Checked = false;
            this.BayesToolStripMenuItem.Checked = true;
            this.splitContainerMain.Panel1Collapsed = true;

            Properties.Settings.Default.clasificatorType = (int)ClasyficatorType.Bayes;
        }

        /// <summary>
        /// SIE w MENU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRadialNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BayesToolStripMenuItem.Checked = false;
            this.RadialNetworkToolStripMenuItem.Checked = true;
            this.splitContainerMain.Panel1Collapsed = false;

            Properties.Settings.Default.clasificatorType = (int)ClasyficatorType.RadialNeural;
        }

        /// <summary>
        /// WCZYTANIE PLIKU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOpenFileDialogDateLoad("Tektowe (*.txt*)|*.txt*|Wszystkie (*.*)|*.*|Zip (*.zip*)|*.zip*");
        }

        /// <summary>
        /// WCZYTANIE KATALOGU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathTemp = ShowFolderBrowserDialogDateLoad();

            OperationType operationType =  (OperationType)Properties.Settings.Default.operationType;
            switch (operationType)
            {
                case OperationType.Learning:
                    String pathSummaryTemp = pathTemp + "\\" + PreprocessingConsts.SummaryFileName;
                    if (!IsPrepocessingDone(pathTemp))
                    {
                        MessageBox.Show("Dokonaj preprocessing'u dla danych ucz¹cych.");
                        return;
                    }

                    Properties.Settings.Default.pathLearningDir = pathTemp;
                    Properties.Settings.Default.pathSummaryFile = pathSummaryTemp;
                    Properties.Settings.Default.numberAllWordsInDictionary = new WordCountList(pathSummaryTemp).GetUniqueWordsCount();
                    Properties.Settings.Default.numberLearningCategories = new DirectoryInfo(pathTemp).GetDirectories().Length;

                    labelLearningValueNumbersCategoriesInLearning.Text = Properties.Settings.Default.numberLearningCategories.ToString();
                    labelLearningValuePathDir.Text = Properties.Settings.Default.pathLearningDir;
                    labelLearningValueNumberAllWords.Text = Properties.Settings.Default.numberAllWordsInDictionary.ToString();
                    buttonLearningStart1.Enabled = true;
                    break;
                case OperationType.Classification:
                    Properties.Settings.Default.pathClassificationDir = pathTemp;
                    AddItemsToClassificationResultFtomDir(Properties.Settings.Default.pathClassificationDir);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// WYŒWIETLENIE ZAWARTOSCI PLIKU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataGridViewClassificationResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                String path = (String)dataGridViewClassificationResults.Rows[e.RowIndex].Tag;
                ShowFile(path);
            }
        }

        /// <summary>
        /// Naciœniêcie STOP dla UCZENIA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClassificationStop_Click(object sender, EventArgs e)
        {
            this.buttonClassificationStop.Visible = false;
            this.buttonClassificationStart.Visible = true;

            progressBarClassification.Value = 0;
            progressBarClassification.Visible = false;
            controller.CancelClassification();
            
        }

        /// <summary>
        /// Naciœniêcie START dla KLASYFIKACJI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClassificationStart_Click(object sender, EventArgs e)
        {
            this.buttonClassificationStop.Visible = true;
            this.buttonClassificationStart.Visible = false;
            progressBarClassification.Visible = true;
            this.controller.Classificate();
        }

        /// <summary>
        /// Naciœniêcie STOP dla UCZENIA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonLearningStop1_Click(object sender, EventArgs e)
        {
            this.buttonLearningStop1.Visible = false;
            this.buttonLearningStart1.Visible = true;
        }

        /// <summary>
        /// Nacisniêcie START dla UCZENIA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonLearningStart1_Click(object sender, EventArgs e)
        {
            String s = Properties.Settings.Default.pathLearningDir;
            if (!System.IO.Directory.Exists(Properties.Settings.Default.pathLearningDir))
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

        /// <summary>
        /// Zdarzenie wywo³ywane gdy ma byæ wykonywany preprocessing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPreproccesingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathTemp = ShowFolderBrowserDialogDateLoad();
            if (IsPrepocessingDone(pathTemp))
            {
                MessageBox.Show("Preproccesing ju¿ jest zrobiony w tym katalogu.");
                return;
            }
            controller.PreprocessingDir(pathTemp);
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
            controller.AddFileToClassification(path);
            dataGridViewClassificationResults.Rows.Add(dgv);
        }

        /// <summary>
        /// Dodaje do tabelki z plikami do klasyfikacji z ca³ego folderu.
        /// </summary>
        /// <param name="pathDir"></param>
        private void AddItemsToClassificationResultFtomDir(String pathDir)
        {
            controller.ClearFileToClassification();
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
            labelLearningValueNumbersCategoriesAll.Text = "3";
            labelValueAllNumbersParameters.Text = "3";

            labelLearningValueNumbersCategoriesInLearning.Text = "3";
            labelLearningValueNumbersDocumentsInLearning.Text = "3";
            
            labelLearningValueNumbersHiddenNerons.Text = "3";
            labelLearningValueNumberAllWords.Text = "3";
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

        /// <summary>
        /// Metoda sprawdzaj¹ca czy preprocesing by³ wykonany dla tego katalogu.
        /// UWAGA! Sprawdza tylko czy istnieje tam plik summary.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool IsPrepocessingDone(String path)
        {
            return System.IO.File.Exists(path+"\\"+PreprocessingConsts.SummaryFileName);
        }

        #endregion

    }
}