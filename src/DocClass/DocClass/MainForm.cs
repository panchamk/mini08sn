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
using DocClass.Properties;
using System.Diagnostics;
using System.IO;



namespace DocClass
{
    /// <summary>
    /// Glowne okno aplikacji.
    /// </summary>
    public partial class MainForm : Form
    {
        private static string documentFilePattern = "Wszystkie (*.*)|*.*|Tektowe (*.txt*)|*.txt*|Zip (*.zip*)|*.zip*";

        private static string bayesFilePattern = "Klasyfikator Bayes'a (*.bay*)|*.bay*";

        private static string radialNetworkFilePattern = "Sie� radialna (*.rnet*)|*.rnet*";

        private static string bayesFileExt = "bay";

        private static string radialNetworkFileExt = "rnet";

        private Controller controller;

        public ProgressBar ProgressBarClassification
        {
            get { return progressBarClassification; }
        }

        public ProgressBar ProgressBarLearn
        {
            get { return progressBarLearn; }
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
        /// ZA�ADOWANIE okna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMainForm_Load(object sender, EventArgs e)
        {
            SetLearningInfo();
            this.fileToolStripMenuItem.Enabled = (((OperationType)Settings.Default.operationType) == OperationType.Classification);
        }

        /// <summary>
        /// WYJ�CIE w MENU.
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
            Settings.Default.clasificatorType = (int)ClasyficatorType.Bayes;
            SetFormStateAfterChangeClassificationType();
            progressBarLearn.Style = ProgressBarStyle.Blocks;

        }

        /// <summary>
        /// SIE w MENU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRadialNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.clasificatorType = (int)ClasyficatorType.RadialNeural;
            SetFormStateAfterChangeClassificationType();
            progressBarLearn.Style = ProgressBarStyle.Marquee;
        }

        /// <summary>
        /// WCZYTANIE PLIKU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathTemp = ShowOpenFileDialog(documentFilePattern);
            if (pathTemp == null)
                return;

            OperationType operationType =  (OperationType)Settings.Default.operationType;
            switch (operationType)
            {
                case OperationType.Learning:
                    break;
                case OperationType.Classification:
                    AddItemsToClassificationResultFromFile(pathTemp);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// WCZYTANIE KATALOGU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathTemp = ShowFolderBrowserDialog();
            if (pathTemp == null)
                return;

            OperationType operationType =  (OperationType)Settings.Default.operationType;
            switch (operationType)
            {
                case OperationType.Learning:
                    String pathSummaryTemp = pathTemp + "\\" + PreprocessingConsts.SummaryFileName;
                    if (!IsPrepocessingDone(pathTemp))
                    {
                        MessageBox.Show("Dokonaj preprocessing'u dla danych ucz�cych.","Preprocessing",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }

                    Settings.Default.pathLearningDir = pathTemp;
                    Settings.Default.pathSummaryFile = pathSummaryTemp;
                    Settings.Default.numberAllWordsInDictionary = new WordCountList(pathSummaryTemp).GetUniqueWordsCount();
                    Settings.Default.numberLearningCategories = PreprocessingUtility.GetCategoryNumber(pathTemp);
                    Settings.Default.numberLearningDocuments = PreprocessingUtility.GetDocumentsNumber(pathTemp);
                    
                    SetFormStateAfterLoadLearningData();
                    break;
                case OperationType.Classification:
                    Settings.Default.pathClassificationDir = pathTemp;
                    AddItemsToClassificationResultFtomDir(Settings.Default.pathClassificationDir);
                    SetFormStateAfterLoadClassificateData();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// WY�WIETLENIE ZAWARTOSCI PLIKU.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataGridViewClassificationResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewClassificationResults.Columns["ColumnShow"].Index)
            {
                String path = (String)dataGridViewClassificationResults.Rows[e.RowIndex].Tag;
                ShowFile(path);
            }
        }

        /// <summary>
        /// Naci�ni�cie STOP dla UCZENIA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClassificationStop_Click(object sender, EventArgs e)
        {
            changeClassificationButtons(false);
            progressBarClassification.Value = 0;
            progressBarClassification.Visible = false;
            controller.CancelClassification();
            
        }

        /// <summary>
        /// Naci�ni�cie START dla KLASYFIKACJI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClassificationStart_Click(object sender, EventArgs e)
        {
            

            if (!this.controller.IsAfterLearn())
            {
                switch ((ClasyficatorType)Settings.Default.clasificatorType)
                {
                    case ClasyficatorType.Bayes:
                        MessageBox.Show("Klasyfikator Bayes'a nie zosta� nauczony.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    case ClasyficatorType.RadialNeural:
                        MessageBox.Show("Sie� nie zosta�a nauczona.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    default:
                        break;
                }
            }
            changeClassificationButtons(true);
            SetFormStateBeforeClassification();
            this.controller.Classificate();
        }

        /// <summary>
        /// Naci�ni�cie STOP dla UCZENIA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonLearningStop1_Click(object sender, EventArgs e)
        {
            changeLearningButtons(false);

            this.controller.StopLearning();
        }

        /// <summary>
        /// Nacisni�cie START dla UCZENIA.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonLearningStart1_Click(object sender, EventArgs e)
        {
            String s = Settings.Default.pathLearningDir;
            if (!System.IO.Directory.Exists(Settings.Default.pathLearningDir))
            {
                MessageBox.Show("Nie mo�na odnale�� katalogu z danymi ucz�cymi.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            changeLearningButtons(true);
            this.SetFormStateBeforeLearn();
            this.controller.Learn();
        }

        private void changeLearningButtons(bool isShowStart)
        {
            if ((ClasyficatorType)Settings.Default.clasificatorType == ClasyficatorType.RadialNeural)
            {
                this.buttonLearningStop1.Enabled = !isShowStart;
            }
            this.buttonLearningStop1.Visible = isShowStart;
            this.buttonLearningStart1.Visible = !isShowStart;
            this.tableLayoutPanel4.ColumnStyles[0].SizeType = SizeType.Percent;
            this.tableLayoutPanel4.ColumnStyles[0].Width = (isShowStart)?100:0;
            this.tableLayoutPanel4.ColumnStyles[1].SizeType = SizeType.Percent;
            this.tableLayoutPanel4.ColumnStyles[1].Width = (isShowStart)?0:100;
        }

        private void changeClassificationButtons(bool isShowStart)
        {
            this.buttonClassificationStop.Visible = isShowStart;
            this.buttonClassificationStart.Visible = !isShowStart;
            this.tableLayoutPanel3.ColumnStyles[0].SizeType = SizeType.Percent;
            this.tableLayoutPanel3.ColumnStyles[0].Width = (isShowStart) ? 100 : 0;
            this.tableLayoutPanel3.ColumnStyles[1].SizeType = SizeType.Percent;
            this.tableLayoutPanel3.ColumnStyles[1].Width = (isShowStart) ? 0 : 100;

        }

        /// <summary>
        /// Zdarzenie wywo�ywane na zmiane zak�adki.
        /// Ustawia ustawia zmienn� OperationType z Settings�w w zale�no�ci od tego co jest wybrane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTabControlUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.operationType = this.tabControlUse.SelectedIndex;
            this.fileToolStripMenuItem.Enabled = (((OperationType)Settings.Default.operationType)==OperationType.Classification);
        }

        /// <summary>
        /// Zdarzenie wywo�ywane gdy ma by� wykonywany preprocessing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPreproccesingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathTemp = ShowFolderBrowserDialog();
            if (pathTemp == null)
                return;

            if (IsPrepocessingDone(pathTemp))
            {
                MessageBox.Show("Preproccesing ju� jest zrobiony w tym katalogu.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            controller.PreprocessingDir(pathTemp);
        }

        /// <summary>
        /// Odczyt sieci z pliku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void OnLoadNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathTemp = ShowOpenFileDialog(radialNetworkFilePattern);
            if (pathTemp != null)
            {
                try
                {
                    controller.LoadRadialNetwork(pathTemp);
                    MessageBox.Show("Sie� zosta�a odczytana.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie mo�na odczyta� sieci.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        /// <summary>
        /// Zapis sieci do pliku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathTemp = ShowSaveFileDialog(radialNetworkFilePattern,radialNetworkFileExt);
            if (pathTemp != null)
            {
                try
                {
                    controller.SaveRadialNetwork(pathTemp);
                    MessageBox.Show("Sie� zosta�a zapisana.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie mo�na zapisa� sieci.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        /// <summary>
        /// Zapis klasyfikato Bayes'a do pliku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveBayesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathTemp = ShowSaveFileDialog(bayesFilePattern,bayesFileExt);
            if (pathTemp != null)
            {
                try
                {
                    controller.SaveBayes(pathTemp);
                    MessageBox.Show("Klasyfikator Bayes'a zosta� zapisany.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie mo�na zapis� klasyfikatora.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        /// <summary>
        /// Odczytuje klasyfikato Bayes'a z pliku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadBayesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathTemp = ShowOpenFileDialog(bayesFilePattern);
            if (pathTemp != null)
            {
                try
                {
                    controller.LoadBayes(pathTemp);
                    MessageBox.Show("Klasyfikator Bayes'a zosta� odczytany.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie mo�na odczyta� klasyfikatora.", "Preprocessing", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        #endregion

        #region METHODES

        //SHOW DIALOGS

        /// <summary>
        /// Wy�wietla okno dialogowe do przegl�dania folder�w.
        /// </summary>
        /// <returns></returns>
        public String ShowFolderBrowserDialog()
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
        /// Wy�wietla okno dialogowe do wyboru pliku.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public String ShowOpenFileDialog(String filter)
        {
            String workDirPath = Directory.GetCurrentDirectory();
            openFileDialogDateLoad.Filter = filter;
            if (openFileDialogDateLoad.ShowDialog() == DialogResult.OK)
            {
                Directory.SetCurrentDirectory(workDirPath);
                return openFileDialogDateLoad.FileName;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Wy�wietla okno dialogowe do zapisu pliku.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public String ShowSaveFileDialog(String filter,String ext)
        {
            String workDirPath = Directory.GetCurrentDirectory();
            saveFileDialog.Filter = filter;
            saveFileDialog.DefaultExt = ext;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Directory.SetCurrentDirectory(workDirPath);
                return saveFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }

        //PREPROCESSING

        /// <summary>
        /// Metoda sprawdzaj�ca czy preprocesing by� wykonany dla tego katalogu.
        /// UWAGA! Sprawdza tylko czy istnieje tam plik summary.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool IsPrepocessingDone(String path)
        {
            return System.IO.File.Exists(path+"\\"+PreprocessingConsts.SummaryFileName);
        }

        //LOAD CLASSIFICATOR

        public void LoadClassificatorEnd(ClasyficatorType classificationType)
        {
            this.SetFormStateArferLoadClassificator(classificationType);
        }

        //LOAD LEARNING DATA

        public void SetLearningInfo()
        {
            //ilo�� przekazanych kategorii
            try
            {
                labelLearningValueNumbersCategoriesInLearning.Text = Settings.Default.numberLearningCategories.ToString();
            }
            catch (NullReferenceException)
            {
                labelLearningValueNumbersCategoriesInLearning.Text = "";
            }
            //ilo�� przekazanych dokument�w
            try
            {
                labelLearningValueNumbersDocumentsInLearning.Text = Settings.Default.numberLearningDocuments.ToString();
            }
            catch (NullReferenceException)
            {
                labelLearningValueNumbersDocumentsInLearning.Text = "";
            }
            //folder danych ucz�cych
            try
            {
                labelLearningValuePathDir.Text = Settings.Default.pathLearningDir;
            }
            catch (NullReferenceException)
            {
                labelLearningValuePathDir.Text = "";
            }
            //ilos� wszystkich s��w
            try
            {
                labelLearningValueNumberAllWords.Text = Settings.Default.numberAllWordsInDictionary.ToString();
            }
            catch (NullReferenceException)
            {
                labelLearningValueNumberAllWords.Text = "";
            }
            //ilos� neuron�w warstwy ukrytej
            try
            {
                labelLearningValueNumbersHiddenNerons.Text = Settings.Default.numberNeuronsHidden.ToString();
            }
            catch (NullReferenceException)
            {
                labelLearningValueNumbersHiddenNerons.Text = "";
            }
            //ilo�c neuron�w wyj�ciowych
            try
            {
                labelLearningValueNumberOutNerons.Text = Settings.Default.numberNeuronsOut.ToString();
            }
            catch (NullReferenceException)
            {
                labelLearningValueNumberOutNerons.Text = "";
            }
            //ilo�� wszystkich kategorii
            try
            {
                labelLearningValueNumbersCategoriesAll.Text = Settings.Default.numberAllCategories.ToString();
            }
            catch (NullReferenceException)
            {
                labelLearningValueNumbersCategoriesAll.Text = "";
            }
            SetRadioButtonsDictionary();
            SetRadioButtonsDocumentRepresentation();
        }

        private void SetRadioButtonsDictionary()
        {
            this.radioButtonDictionaryCtfIdf.BindWithSettings();
            this.radioButtonDictionaryFixed.BindWithSettings();
            this.radioButtonDictionaryFrequance.BindWithSettings();
        }

        private void SetRadioButtonsDocumentRepresentation()
        {
            this.radioButtonDocumentRepresentationBinary.BindWithSettings();
            this.radioButtonDocumentRepresentationOwn.BindWithSettings();
            this.radioButtonDocumentRepresentationTfIdf.BindWithSettings();
        }

        //LOAD CLASSIFICATION DATA

        private void SetMenuSaveClassificatorState()
        {
            if (controller.IsAfterLearn(ClasyficatorType.RadialNeural))
            {
                saveNetworkToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveNetworkToolStripMenuItem.Enabled = false;
            }
            if (controller.IsAfterLearn(ClasyficatorType.Bayes))
            {
                saveBayesToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveBayesToolStripMenuItem.Enabled = false;
            }
        }

        //LEARNING

        public void LearnEnd()
        {
            SetFormStateAfterLearn((ClasyficatorType)Settings.Default.clasificatorType);
            MessageBox.Show("Nauka zosta�a zako�czona pomy�lnie.","Nauka",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            
        }

        private void SetEnableRadioButtonRepresentation(bool flag)
        {
            //wyb�r reprzezntacji
            this.radioButtonDictionaryCtfIdf.Enabled = flag;
            this.radioButtonDictionaryFixed.Enabled = flag;
            this.radioButtonDictionaryFrequance.Enabled = flag;
            this.radioButtonDocumentRepresentationBinary.Enabled = flag;
            this.radioButtonDocumentRepresentationOwn.Enabled = flag;
            this.radioButtonDocumentRepresentationTfIdf.Enabled = flag;
        }

        //CLASSIFICATION

        /// <summary>
        /// Wy�wietla wyniki clasyfikacji.
        /// </summary>
        /// <param name="classificationResult"></param>
        public void ClassificationEnd(List<string> classificationResult)
        {
            SetClassificationResult(classificationResult);
            SetClassificationInfoAfterClassification();
            SetFormStateAfterClassification();
        }

        public int GetGoodRecognizeNumberDocuments()
        {
            int count = 0;
            for (int i=0;i<dataGridViewClassificationResults.Rows.Count;i++)
            {
                if (i != dataGridViewClassificationResults.Rows.Count - 1)
                {
                    DataGridViewRow row = dataGridViewClassificationResults.Rows[i];
                    String realCategory = (String)row.Cells["ColumnCategory"].Value;
                    String recognizeCategory = (String)row.Cells["ColumnCategoryFind"].Value;
                    if (realCategory.Equals(recognizeCategory))
                    {
                        count++;
                    }
                }
            }
            return count;

            
        }

        private void SetClassificationInfoAfterClassification()
        {
            int numberGood = GetGoodRecognizeNumberDocuments();
            int numberAll = dataGridViewClassificationResults.Rows.Count-1;

            labelClassificationValueNumberAllDocuments.Text = numberAll.ToString();
            labelClassificationValueNumberGoodDocuments.Text = numberGood.ToString();
            labelClassificationValueEfficiency.Text = ((int)(((double)numberGood) / ((double)numberAll) * 100.0)).ToString() + "%";
        }

        private void SetClassificationInfoAfterLearn(ClasyficatorType classificationType)
        {
            if (classificationType == ClasyficatorType.RadialNeural && this.controller.IsAfterLearn(ClasyficatorType.RadialNeural))
            {
                labelClassificationValueDirectory.Text = DictionaryTypeUtil.ToString(controller.LearnDictionaryType);
                labelClassificationValueDocument.Text = DocumentRepresentationTypeUtil.ToString(controller.LearnDocumentRepresentationType);
            }
        }

        private void SetClassificationResult(List<string> classificationResult)
        {
            for (int i = 0; i < classificationResult.Count; i++)
            {
                dataGridViewClassificationResults.Rows[i].Cells["ColumnCategoryFind"].Value = classificationResult[i];
            }
        }

        /// <summary>
        /// Dodaje elementy do tabelki z wynikami klasyfikacji.
        /// </summary>
        /// <param name="tab"></param>
        private void AddItemsToClassificationResults(String[] tab, String path)
        {
            DataGridViewRow dgv = new DataGridViewRow();
            dgv.CreateCells(dataGridViewClassificationResults, tab);
            dgv.Tag = path;
            controller.AddFileToClassification(path);
            dataGridViewClassificationResults.Rows.Add(dgv);
        }

        /// <summary>
        /// Dodaje do tabelki z plikami do klasyfikacji z ca�ego folderu.
        /// Czyci stare.
        /// </summary>
        /// <param name="pathDir">Scie�ka do folderu</param>
        private void AddItemsToClassificationResultFtomDir(String pathDir)
        {
            dataGridViewClassificationResults.Rows.Clear();
            controller.ClearFileToClassification();
            DirectoryInfo sourceDirInfo = new DirectoryInfo(pathDir);
            foreach (DirectoryInfo categoryDirInfo in sourceDirInfo.GetDirectories())
            {
                foreach (FileInfo sourceFile in categoryDirInfo.GetFiles())
                {
                    AddItemsToClassificationResults(new string[] { sourceFile.Name, categoryDirInfo.Name, "", "Podglad" }, sourceFile.FullName);
                }
            }

        }

        /// <summary>
        /// Dodaje do tabelki z plikami do klasyfikacji z jednego pliku.
        /// Czyci stare.
        /// </summary>
        /// <param name="path">Scie�ka do pliku.</param>
        private void AddItemsToClassificationResultFromFile(String path)
        {
            dataGridViewClassificationResults.Rows.Clear();
            controller.ClearFileToClassification();
            FileInfo f = new FileInfo(path);
            AddItemsToClassificationResults(new string[] { f.Name,f.Directory.Name ,"", "Podglad" }, f.FullName);
        }

        /// <summary>
        /// Czy�ci kolumne ze znalezion� kategori�
        /// </summary>
        private void ClearCategoryFindColumn()
        {
            foreach (DataGridViewRow row in this.dataGridViewClassificationResults.Rows)
            {
                row.Cells["ColumnCategoryFind"].Value = String.Empty;
            }
        }

        /// <summary>
        /// Wy�wetla zawarto�� dokumentu a podanej scie�ce.
        /// </summary>
        /// <param name="path"></param>
        public void ShowFile(String path)
        {
            try
            {
                Process p = new Process();
                p.EnableRaisingEvents = false;
                p.StartInfo.FileName = "wordpad.exe";
                p.StartInfo.Arguments = "\"" + path + "\"";
                p.Start();
                p.WaitForExit();
            }
            catch (Exception)
            {
                try
                {
                    Process p = new Process();
                    p.EnableRaisingEvents = false;
                    p.StartInfo.FileName = "notepad";
                    p.StartInfo.Arguments = "\"" + path + "\"";
                    p.Start();
                    p.WaitForExit();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie mo�na otworzy� dokumentu.","Otwieranie dokumentu",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void SetClassificatorState()
        {
            ClasyficatorType classificationType = (ClasyficatorType)Settings.Default.clasificatorType;
            switch (classificationType)
            {
                case ClasyficatorType.Bayes:
                    labelClassificationNameClassificatorState.Text = "Stan klasyfikatora Bayes'a:";
                    if (controller.IsAfterLearn())
                    {
                        labelClassificationValueClassificatorState.Text = "Nauczony";
                    }
                    else
                    {
                        labelClassificationValueClassificatorState.Text = "Nie nauczony";
                    }
                    break;
                case ClasyficatorType.RadialNeural:
                    labelClassificationNameClassificatorState.Text = "Stan sieci:";
                    if (controller.IsAfterLearn())
                    {
                        labelClassificationValueClassificatorState.Text = "Nauczona";
                    }
                    else
                    {
                        labelClassificationValueClassificatorState.Text = "Nie nauczona";
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        public void  SetFormStateArferLoadClassificator(ClasyficatorType classificateType)
        {
            //labele nauki
            this.SetLearningInfo();   
            
            //label m�wi�cy o stanie klasyfikatora
            SetClassificatorState();
            SetClassificationInfoAfterLearn(classificateType);

            //stan menu zapisu klasyfikator�w
            SetMenuSaveClassificatorState();
        }

        private void SetFormStateAfterLoadLearningData()
        {
            //labele nauki
            SetLearningInfo();
        }

        private void SetFormStateAfterLoadClassificateData()
        {
            this.SetClassificationInfoAfterClassification();

        }

        private void SetFormStateBeforeLearn()
        {
            this.buttonLearningStop1.Visible = true;
            this.buttonLearningStart1.Visible = false;
            this.progressBarLearn.Visible = true;
            this.progressBarLearn.Value = ProgressBarClassification.Minimum;

            //wyb�r reprzentacji s�ownik�w i dokument�w
            SetEnableRadioButtonRepresentation(false);

            //zmiana operacji (nauka/klasyfikacjia)
            this.RadialNetworkToolStripMenuItem.Enabled = false;
            this.BayesToolStripMenuItem.Enabled = false;

            //menu
            this.preproccesingToolStripMenuItem.Enabled = false;
            this.saveBayesToolStripMenuItem.Enabled = false;
            this.saveNetworkToolStripMenuItem.Enabled = false;
            this.loadBayesToolStripMenuItem.Enabled = false;
            this.loadNetworkToolStripMenuItem.Enabled = false;
            this.loadToolStripMenuItem.Enabled = false;

            this.buttonLearningStart1.Enabled = false;
            this.buttonClassificationStart.Enabled = false;

            //this.tableLayoutPanel4.ColumnStyles[0].SizeType = SizeType.Percent;
            //this.tableLayoutPanel4.ColumnStyles[0].Width = 100;
            //this.tableLayoutPanel4.ColumnStyles[1].SizeType = SizeType.Percent;
            //this.tableLayoutPanel4.ColumnStyles[1].Width = 0;
        }

        private void SetFormStateBeforeClassification()
        {
            this.buttonClassificationStop.Visible = true;
            this.buttonClassificationStart.Visible = false;
            progressBarClassification.Visible = true;
            ProgressBarClassification.Value = ProgressBarClassification.Minimum;
            this.ClearCategoryFindColumn();
            

            //wyb�r reprzentacji s�ownik�w i dokument�w
            SetEnableRadioButtonRepresentation(false);

            //zmiana operacji (nauka/klasyfikacjia)
            this.RadialNetworkToolStripMenuItem.Enabled = false;
            this.BayesToolStripMenuItem.Enabled = false;

            //menu
            this.preproccesingToolStripMenuItem.Enabled = false;
            this.saveBayesToolStripMenuItem.Enabled = false;
            this.saveNetworkToolStripMenuItem.Enabled = false;
            this.loadBayesToolStripMenuItem.Enabled = false;
            this.loadNetworkToolStripMenuItem.Enabled = false;
            this.loadToolStripMenuItem.Enabled = false;

            this.buttonLearningStart1.Enabled = false;
            this.buttonClassificationStart.Enabled = false;

            //this.tableLayoutPanel3.ColumnStyles[0].SizeType = SizeType.Percent;
            //this.tableLayoutPanel3.ColumnStyles[0].Width = 100;
            //this.tableLayoutPanel3.ColumnStyles[1].SizeType = SizeType.Percent;
            //this.tableLayoutPanel3.ColumnStyles[1].Width = 0;

        }

        private void SetFormStateAfterLearn(ClasyficatorType classificationType)
        {
            //buttons and progress bar
            changeLearningButtons(false);
            this.progressBarLearn.Visible = false;
            this.progressBarLearn.Value = ProgressBarClassification.Minimum;

            //label stanu klasyfikacji
            SetClassificatorState();
            SetClassificationInfoAfterLearn(classificationType);

            //wyb�r reprzentacji s�ownik�w i dokument�w
            SetEnableRadioButtonRepresentation(true);

            //zmiana operacji (nauka/klasyfikacjia)
            this.RadialNetworkToolStripMenuItem.Enabled = true;
            this.BayesToolStripMenuItem.Enabled = true;

            //menu
            this.preproccesingToolStripMenuItem.Enabled = true;
            this.saveBayesToolStripMenuItem.Enabled = true;
            this.saveNetworkToolStripMenuItem.Enabled = true;
            this.loadBayesToolStripMenuItem.Enabled = true;
            this.loadNetworkToolStripMenuItem.Enabled = true;
            this.loadToolStripMenuItem.Enabled = true;

            this.buttonLearningStart1.Enabled = true;
            this.buttonClassificationStart.Enabled = true;

            //menu (NA KONCU)
            SetMenuSaveClassificatorState();
        }

        private void SetFormStateAfterClassification()
        {
            changeClassificationButtons(false);
            this.progressBarClassification.Visible = false;


            //wyb�r reprzentacji s�ownik�w i dokument�w
            SetEnableRadioButtonRepresentation(true);

            //zmiana operacji (nauka/klasyfikacjia)
            this.RadialNetworkToolStripMenuItem.Enabled = true;
            this.BayesToolStripMenuItem.Enabled = true;

            //menu
            this.preproccesingToolStripMenuItem.Enabled = true;
            this.saveBayesToolStripMenuItem.Enabled = true;
            this.saveNetworkToolStripMenuItem.Enabled = true;
            this.loadBayesToolStripMenuItem.Enabled = true;
            this.loadNetworkToolStripMenuItem.Enabled = true;
            this.loadToolStripMenuItem.Enabled = true;
            this.SetMenuSaveClassificatorState();

            this.buttonLearningStart1.Enabled = true;
            this.buttonClassificationStart.Enabled = true;
        }

        private void SetFormStateAfterChangeClassificationType()
        {            
            //stan klasyfikator�w
            SetClassificatorState();

            switch ((ClasyficatorType)Settings.Default.clasificatorType)
            {
                case ClasyficatorType.Bayes:
                    this.RadialNetworkToolStripMenuItem.Checked = false;
                    this.BayesToolStripMenuItem.Checked = true;
                    //this.splitContainerMain.Panel1Collapsed = true;

                    this.labelLearningValueNumbersHiddenNerons.Visible = false;
                    this.labelLearningValueNumberOutNerons.Visible = false;
                    this.labelLearningNameNumbersHiddenNerons.Visible = false;
                    this.labelLearningNameNumberOutNerons.Visible = false;

                    //reprzenetacja dokument�w i s�ownik�w
                    this.labelClassificationNameDocument.Visible = false;
                    this.labelClassificationValueDocument.Visible = false;
                    this.labelClassificationNameDirectory.Visible = false;
                    this.labelClassificationValueDirectory.Visible = false;

                    //wyb�r s�ownika i dokument�w
                    this.groupBoxDictionary.Visible = false;
                    this.groupBoxDocumentRepresentation.Visible = false;
                    break;
                case ClasyficatorType.RadialNeural:
                    this.BayesToolStripMenuItem.Checked = false;
                    this.RadialNetworkToolStripMenuItem.Checked = true;
                    //this.splitContainerMain.Panel1Collapsed = false;

                    this.labelLearningValueNumbersHiddenNerons.Visible = true;
                    this.labelLearningValueNumberOutNerons.Visible = true;
                    this.labelLearningNameNumbersHiddenNerons.Visible = true;
                    this.labelLearningNameNumberOutNerons.Visible = true;

                    //reprzenetacja dokument�w i s�ownik�w
                    this.labelClassificationNameDocument.Visible = true;
                    this.labelClassificationValueDocument.Visible = true;
                    this.labelClassificationNameDirectory.Visible = true;
                    this.labelClassificationValueDirectory.Visible = true;

                    //wyb�r s�ownika i dokument�w
                    this.groupBoxDictionary.Visible = true;
                    this.groupBoxDocumentRepresentation.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelLearningNameNumberAllWords_Click(object sender, EventArgs e)
        {

        }

        private void descriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }


    }
}