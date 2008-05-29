namespace DocClass
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItemProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preproccesingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveBayesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBayesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metodaKlasyfikacjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BayesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RadialNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogDateLoad = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogDateLoad = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabControlUse = new System.Windows.Forms.TabControl();
            this.tabPageLearning = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLearningParameters = new System.Windows.Forms.GroupBox();
            this.groupBoxDictionary = new System.Windows.Forms.GroupBox();
            this.labelLearningValueNumberOutNerons = new System.Windows.Forms.Label();
            this.groupBoxDocumentRepresentation = new System.Windows.Forms.GroupBox();
            this.labelLearningNameNumberOutNerons = new System.Windows.Forms.Label();
            this.labelLearningValuePathDir = new System.Windows.Forms.Label();
            this.labelLearningNamePathDir = new System.Windows.Forms.Label();
            this.labelLearningValueNumberAllWords = new System.Windows.Forms.Label();
            this.labelLearningValueNumbersHiddenNerons = new System.Windows.Forms.Label();
            this.labelLearningValueNumbersDocumentsInLearning = new System.Windows.Forms.Label();
            this.labelLearningValueNumbersCategoriesInLearning = new System.Windows.Forms.Label();
            this.labelLearningValueNumbersCategoriesAll = new System.Windows.Forms.Label();
            this.labelLearningNameNumbersHiddenNerons = new System.Windows.Forms.Label();
            this.labelLearningNameNumberAllWords = new System.Windows.Forms.Label();
            this.labelLearningNameNumbersCategoriesInLearning = new System.Windows.Forms.Label();
            this.labelLearningNameNumbersCategoriesAll = new System.Windows.Forms.Label();
            this.labelLearningNameNumbersDocumentsInLearning = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.progressBarLearn = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLearningStart1 = new System.Windows.Forms.Button();
            this.buttonLearningStop1 = new System.Windows.Forms.Button();
            this.tabPageClasyfication = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewClassificationResults = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelClassificationValueDirectory = new System.Windows.Forms.Label();
            this.labelClassificationNameDirectory = new System.Windows.Forms.Label();
            this.labelClassificationValueDocument = new System.Windows.Forms.Label();
            this.labelClassificationNameDocument = new System.Windows.Forms.Label();
            this.labelClassificationValueClassificatorState = new System.Windows.Forms.Label();
            this.labelClassificationNameClassificatorState = new System.Windows.Forms.Label();
            this.labelClassificationValueEfficiency = new System.Windows.Forms.Label();
            this.labelClassificationNameEfficiency = new System.Windows.Forms.Label();
            this.labelClassificationValueNumberGoodDocuments = new System.Windows.Forms.Label();
            this.labelClassificationNameNumberGoodDocuments = new System.Windows.Forms.Label();
            this.labelClassificationValueNumberAllDocuments = new System.Windows.Forms.Label();
            this.labelClassificationNameNumberAllDocuments = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClassificationStop = new System.Windows.Forms.Button();
            this.buttonClassificationStart = new System.Windows.Forms.Button();
            this.progressBarClassification = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLearningStart = new System.Windows.Forms.Button();
            this.buttonLearningStop = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.radioButtonDictionaryFrequance = new DocClass.RadioButtonDictionary();
            this.radioButtonDictionaryFixed = new DocClass.RadioButtonDictionary();
            this.radioButtonDictionaryCtfIdf = new DocClass.RadioButtonDictionary();
            this.radioButtonDocumentRepresentationBinary = new DocClass.RadioButtonDocumentRepresentation();
            this.radioButtonDocumentRepresentationOwn = new DocClass.RadioButtonDocumentRepresentation();
            this.radioButtonDocumentRepresentationTfIdf = new DocClass.RadioButtonDocumentRepresentation();
            this.fileInput2 = new DocClass.FileInput();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategoryFind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShow = new System.Windows.Forms.DataGridViewLinkColumn();
            this.menuStripMain.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControlUse.SuspendLayout();
            this.tabPageLearning.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxLearningParameters.SuspendLayout();
            this.groupBoxDictionary.SuspendLayout();
            this.groupBoxDocumentRepresentation.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPageClasyfication.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassificationResults)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItemProgram,
            this.metodaKlasyfikacjiToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(959, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // programToolStripMenuItemProgram
            // 
            this.programToolStripMenuItemProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.preproccesingToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveNetworkToolStripMenuItem,
            this.loadNetworkToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveBayesToolStripMenuItem,
            this.loadBayesToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItemProgram.Name = "programToolStripMenuItemProgram";
            this.programToolStripMenuItemProgram.Size = new System.Drawing.Size(59, 20);
            this.programToolStripMenuItemProgram.Text = "Program";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.directoryToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.loadToolStripMenuItem.Text = "Wczytaj";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Image = global::DocClass.Properties.Resources.Generic_Document;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.fileToolStripMenuItem.Text = "Plik";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.OnFileToolStripMenuItem_Click);
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.Image = global::DocClass.Properties.Resources.Folder_Open;
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.directoryToolStripMenuItem.Text = "Folder";
            this.directoryToolStripMenuItem.Click += new System.EventHandler(this.OnDirectoryToolStripMenuItem_Click);
            // 
            // preproccesingToolStripMenuItem
            // 
            this.preproccesingToolStripMenuItem.Name = "preproccesingToolStripMenuItem";
            this.preproccesingToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.preproccesingToolStripMenuItem.Text = "Preproccesing";
            this.preproccesingToolStripMenuItem.Click += new System.EventHandler(this.OnPreproccesingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // saveNetworkToolStripMenuItem
            // 
            this.saveNetworkToolStripMenuItem.Enabled = false;
            this.saveNetworkToolStripMenuItem.Name = "saveNetworkToolStripMenuItem";
            this.saveNetworkToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.saveNetworkToolStripMenuItem.Text = "Zapisz sieæ";
            this.saveNetworkToolStripMenuItem.Click += new System.EventHandler(this.OnSaveNetworkToolStripMenuItem_Click);
            // 
            // loadNetworkToolStripMenuItem
            // 
            this.loadNetworkToolStripMenuItem.Name = "loadNetworkToolStripMenuItem";
            this.loadNetworkToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.loadNetworkToolStripMenuItem.Text = "Wczytaj sieæ";
            this.loadNetworkToolStripMenuItem.Click += new System.EventHandler(this.OnLoadNetworkToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // saveBayesToolStripMenuItem
            // 
            this.saveBayesToolStripMenuItem.Enabled = false;
            this.saveBayesToolStripMenuItem.Name = "saveBayesToolStripMenuItem";
            this.saveBayesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.saveBayesToolStripMenuItem.Text = "Zapisz klasyfikator Bayes\'a";
            this.saveBayesToolStripMenuItem.Click += new System.EventHandler(this.OnSaveBayesToolStripMenuItem_Click);
            // 
            // loadBayesToolStripMenuItem
            // 
            this.loadBayesToolStripMenuItem.Name = "loadBayesToolStripMenuItem";
            this.loadBayesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.loadBayesToolStripMenuItem.Text = "Wczytak klasyfikator Bayes\'a";
            this.loadBayesToolStripMenuItem.Click += new System.EventHandler(this.OnLoadBayesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::DocClass.Properties.Resources.delete;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItem_Click);
            // 
            // metodaKlasyfikacjiToolStripMenuItem
            // 
            this.metodaKlasyfikacjiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BayesToolStripMenuItem,
            this.RadialNetworkToolStripMenuItem});
            this.metodaKlasyfikacjiToolStripMenuItem.Name = "metodaKlasyfikacjiToolStripMenuItem";
            this.metodaKlasyfikacjiToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.metodaKlasyfikacjiToolStripMenuItem.Text = "Metoda Klasyfikacji";
            // 
            // BayesToolStripMenuItem
            // 
            this.BayesToolStripMenuItem.Name = "BayesToolStripMenuItem";
            this.BayesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.BayesToolStripMenuItem.Text = "Klasyfikator Bayes\'a";
            this.BayesToolStripMenuItem.Click += new System.EventHandler(this.OnBayesaToolStripMenuItem_Click);
            // 
            // RadialNetworkToolStripMenuItem
            // 
            this.RadialNetworkToolStripMenuItem.Checked = true;
            this.RadialNetworkToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadialNetworkToolStripMenuItem.Name = "RadialNetworkToolStripMenuItem";
            this.RadialNetworkToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.RadialNetworkToolStripMenuItem.Text = "Siec Radialna";
            this.RadialNetworkToolStripMenuItem.Click += new System.EventHandler(this.OnRadialNetworkToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descriptionToolStripMenuItem});
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.AboutToolStripMenuItem.Text = "O programie";
            // 
            // descriptionToolStripMenuItem
            // 
            this.descriptionToolStripMenuItem.Name = "descriptionToolStripMenuItem";
            this.descriptionToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.descriptionToolStripMenuItem.Text = "Opis";
            // 
            // openFileDialogDateLoad
            // 
            this.openFileDialogDateLoad.FileName = "openFileDialog";
            this.openFileDialogDateLoad.InitialDirectory = ".";
            // 
            // folderBrowserDialogDateLoad
            // 
            this.folderBrowserDialogDateLoad.SelectedPath = ".";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerMain.Panel1Collapsed = true;
            this.splitContainerMain.Panel1MinSize = 10;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlUse);
            this.splitContainerMain.Size = new System.Drawing.Size(959, 423);
            this.splitContainerMain.SplitterDistance = 145;
            this.splitContainerMain.TabIndex = 2;
            // 
            // tabControlUse
            // 
            this.tabControlUse.Controls.Add(this.tabPageLearning);
            this.tabControlUse.Controls.Add(this.tabPageClasyfication);
            this.tabControlUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlUse.Location = new System.Drawing.Point(0, 0);
            this.tabControlUse.Name = "tabControlUse";
            this.tabControlUse.SelectedIndex = 0;
            this.tabControlUse.Size = new System.Drawing.Size(959, 423);
            this.tabControlUse.TabIndex = 0;
            this.tabControlUse.SelectedIndexChanged += new System.EventHandler(this.OnTabControlUse_SelectedIndexChanged);
            // 
            // tabPageLearning
            // 
            this.tabPageLearning.Controls.Add(this.tableLayoutPanel1);
            this.tabPageLearning.Location = new System.Drawing.Point(4, 22);
            this.tabPageLearning.Name = "tabPageLearning";
            this.tabPageLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLearning.Size = new System.Drawing.Size(951, 397);
            this.tabPageLearning.TabIndex = 0;
            this.tabPageLearning.Text = "Nauka";
            this.tabPageLearning.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.06329F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.93671F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxLearningParameters, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 391F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(945, 391);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // groupBoxLearningParameters
            // 
            this.groupBoxLearningParameters.Controls.Add(this.groupBoxDictionary);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningValueNumberOutNerons);
            this.groupBoxLearningParameters.Controls.Add(this.groupBoxDocumentRepresentation);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningNameNumberOutNerons);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningValuePathDir);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningNamePathDir);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningValueNumberAllWords);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningValueNumbersHiddenNerons);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningValueNumbersDocumentsInLearning);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningValueNumbersCategoriesInLearning);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningValueNumbersCategoriesAll);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningNameNumbersHiddenNerons);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningNameNumberAllWords);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningNameNumbersCategoriesInLearning);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningNameNumbersCategoriesAll);
            this.groupBoxLearningParameters.Controls.Add(this.labelLearningNameNumbersDocumentsInLearning);
            this.groupBoxLearningParameters.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLearningParameters.Name = "groupBoxLearningParameters";
            this.groupBoxLearningParameters.Size = new System.Drawing.Size(735, 370);
            this.groupBoxLearningParameters.TabIndex = 2;
            this.groupBoxLearningParameters.TabStop = false;
            this.groupBoxLearningParameters.Text = "Parametry";
            // 
            // groupBoxDictionary
            // 
            this.groupBoxDictionary.Controls.Add(this.radioButtonDictionaryFrequance);
            this.groupBoxDictionary.Controls.Add(this.radioButtonDictionaryFixed);
            this.groupBoxDictionary.Controls.Add(this.radioButtonDictionaryCtfIdf);
            this.groupBoxDictionary.Location = new System.Drawing.Point(249, 248);
            this.groupBoxDictionary.Name = "groupBoxDictionary";
            this.groupBoxDictionary.Size = new System.Drawing.Size(232, 100);
            this.groupBoxDictionary.TabIndex = 1;
            this.groupBoxDictionary.TabStop = false;
            this.groupBoxDictionary.Text = "Dobieranie s³ów do s³ownika";
            // 
            // labelLearningValueNumberOutNerons
            // 
            this.labelLearningValueNumberOutNerons.AutoSize = true;
            this.labelLearningValueNumberOutNerons.Location = new System.Drawing.Point(230, 209);
            this.labelLearningValueNumberOutNerons.Name = "labelLearningValueNumberOutNerons";
            this.labelLearningValueNumberOutNerons.Size = new System.Drawing.Size(0, 13);
            this.labelLearningValueNumberOutNerons.TabIndex = 15;
            // 
            // groupBoxDocumentRepresentation
            // 
            this.groupBoxDocumentRepresentation.Controls.Add(this.radioButtonDocumentRepresentationBinary);
            this.groupBoxDocumentRepresentation.Controls.Add(this.radioButtonDocumentRepresentationOwn);
            this.groupBoxDocumentRepresentation.Controls.Add(this.radioButtonDocumentRepresentationTfIdf);
            this.groupBoxDocumentRepresentation.Location = new System.Drawing.Point(29, 248);
            this.groupBoxDocumentRepresentation.Name = "groupBoxDocumentRepresentation";
            this.groupBoxDocumentRepresentation.Size = new System.Drawing.Size(200, 100);
            this.groupBoxDocumentRepresentation.TabIndex = 0;
            this.groupBoxDocumentRepresentation.TabStop = false;
            this.groupBoxDocumentRepresentation.Text = "Reprezentacja dokumentu";
            // 
            // labelLearningNameNumberOutNerons
            // 
            this.labelLearningNameNumberOutNerons.AutoSize = true;
            this.labelLearningNameNumberOutNerons.Location = new System.Drawing.Point(25, 209);
            this.labelLearningNameNumberOutNerons.Name = "labelLearningNameNumberOutNerons";
            this.labelLearningNameNumberOutNerons.Size = new System.Drawing.Size(153, 13);
            this.labelLearningNameNumberOutNerons.TabIndex = 14;
            this.labelLearningNameNumberOutNerons.Text = "Liczba neuronów wyjœciowych:";
            // 
            // labelLearningValuePathDir
            // 
            this.labelLearningValuePathDir.AutoSize = true;
            this.labelLearningValuePathDir.Location = new System.Drawing.Point(227, 25);
            this.labelLearningValuePathDir.Name = "labelLearningValuePathDir";
            this.labelLearningValuePathDir.Size = new System.Drawing.Size(0, 13);
            this.labelLearningValuePathDir.TabIndex = 13;
            // 
            // labelLearningNamePathDir
            // 
            this.labelLearningNamePathDir.AutoSize = true;
            this.labelLearningNamePathDir.Location = new System.Drawing.Point(23, 25);
            this.labelLearningNamePathDir.Name = "labelLearningNamePathDir";
            this.labelLearningNamePathDir.Size = new System.Drawing.Size(130, 13);
            this.labelLearningNamePathDir.TabIndex = 12;
            this.labelLearningNamePathDir.Text = "Folder z danymi ucz¹cymi:";
            // 
            // labelLearningValueNumberAllWords
            // 
            this.labelLearningValueNumberAllWords.AutoSize = true;
            this.labelLearningValueNumberAllWords.Location = new System.Drawing.Point(230, 141);
            this.labelLearningValueNumberAllWords.Name = "labelLearningValueNumberAllWords";
            this.labelLearningValueNumberAllWords.Size = new System.Drawing.Size(0, 13);
            this.labelLearningValueNumberAllWords.TabIndex = 11;
            // 
            // labelLearningValueNumbersHiddenNerons
            // 
            this.labelLearningValueNumbersHiddenNerons.AutoSize = true;
            this.labelLearningValueNumbersHiddenNerons.Location = new System.Drawing.Point(230, 173);
            this.labelLearningValueNumbersHiddenNerons.Name = "labelLearningValueNumbersHiddenNerons";
            this.labelLearningValueNumbersHiddenNerons.Size = new System.Drawing.Size(0, 13);
            this.labelLearningValueNumbersHiddenNerons.TabIndex = 10;
            // 
            // labelLearningValueNumbersDocumentsInLearning
            // 
            this.labelLearningValueNumbersDocumentsInLearning.AutoSize = true;
            this.labelLearningValueNumbersDocumentsInLearning.Location = new System.Drawing.Point(227, 50);
            this.labelLearningValueNumbersDocumentsInLearning.Name = "labelLearningValueNumbersDocumentsInLearning";
            this.labelLearningValueNumbersDocumentsInLearning.Size = new System.Drawing.Size(0, 13);
            this.labelLearningValueNumbersDocumentsInLearning.TabIndex = 9;
            // 
            // labelLearningValueNumbersCategoriesInLearning
            // 
            this.labelLearningValueNumbersCategoriesInLearning.AutoSize = true;
            this.labelLearningValueNumbersCategoriesInLearning.Location = new System.Drawing.Point(227, 107);
            this.labelLearningValueNumbersCategoriesInLearning.Name = "labelLearningValueNumbersCategoriesInLearning";
            this.labelLearningValueNumbersCategoriesInLearning.Size = new System.Drawing.Size(0, 13);
            this.labelLearningValueNumbersCategoriesInLearning.TabIndex = 8;
            // 
            // labelLearningValueNumbersCategoriesAll
            // 
            this.labelLearningValueNumbersCategoriesAll.AutoSize = true;
            this.labelLearningValueNumbersCategoriesAll.Location = new System.Drawing.Point(227, 78);
            this.labelLearningValueNumbersCategoriesAll.Name = "labelLearningValueNumbersCategoriesAll";
            this.labelLearningValueNumbersCategoriesAll.Size = new System.Drawing.Size(0, 13);
            this.labelLearningValueNumbersCategoriesAll.TabIndex = 6;
            // 
            // labelLearningNameNumbersHiddenNerons
            // 
            this.labelLearningNameNumbersHiddenNerons.AutoSize = true;
            this.labelLearningNameNumbersHiddenNerons.Location = new System.Drawing.Point(25, 173);
            this.labelLearningNameNumbersHiddenNerons.Name = "labelLearningNameNumbersHiddenNerons";
            this.labelLearningNameNumbersHiddenNerons.Size = new System.Drawing.Size(185, 13);
            this.labelLearningNameNumbersHiddenNerons.TabIndex = 5;
            this.labelLearningNameNumbersHiddenNerons.Text = "Liczba neuronów warstwy wyjœciowej:";
            // 
            // labelLearningNameNumberAllWords
            // 
            this.labelLearningNameNumberAllWords.AutoSize = true;
            this.labelLearningNameNumberAllWords.Location = new System.Drawing.Point(25, 141);
            this.labelLearningNameNumberAllWords.Name = "labelLearningNameNumberAllWords";
            this.labelLearningNameNumberAllWords.Size = new System.Drawing.Size(121, 13);
            this.labelLearningNameNumberAllWords.TabIndex = 4;
            this.labelLearningNameNumberAllWords.Text = "Liczba wszystkich s³ów:";
            // 
            // labelLearningNameNumbersCategoriesInLearning
            // 
            this.labelLearningNameNumbersCategoriesInLearning.AutoSize = true;
            this.labelLearningNameNumbersCategoriesInLearning.Location = new System.Drawing.Point(25, 107);
            this.labelLearningNameNumbersCategoriesInLearning.Name = "labelLearningNameNumbersCategoriesInLearning";
            this.labelLearningNameNumbersCategoriesInLearning.Size = new System.Drawing.Size(153, 13);
            this.labelLearningNameNumbersCategoriesInLearning.TabIndex = 3;
            this.labelLearningNameNumbersCategoriesInLearning.Text = "Liczba przekazanych kategorii:";
            // 
            // labelLearningNameNumbersCategoriesAll
            // 
            this.labelLearningNameNumbersCategoriesAll.AutoSize = true;
            this.labelLearningNameNumbersCategoriesAll.Location = new System.Drawing.Point(25, 78);
            this.labelLearningNameNumbersCategoriesAll.Name = "labelLearningNameNumbersCategoriesAll";
            this.labelLearningNameNumbersCategoriesAll.Size = new System.Drawing.Size(138, 13);
            this.labelLearningNameNumbersCategoriesAll.TabIndex = 2;
            this.labelLearningNameNumbersCategoriesAll.Text = "Liczba wszystkich kategorii:";
            // 
            // labelLearningNameNumbersDocumentsInLearning
            // 
            this.labelLearningNameNumbersDocumentsInLearning.AutoSize = true;
            this.labelLearningNameNumbersDocumentsInLearning.Location = new System.Drawing.Point(25, 50);
            this.labelLearningNameNumbersDocumentsInLearning.Name = "labelLearningNameNumbersDocumentsInLearning";
            this.labelLearningNameNumbersDocumentsInLearning.Size = new System.Drawing.Size(174, 13);
            this.labelLearningNameNumbersDocumentsInLearning.TabIndex = 1;
            this.labelLearningNameNumbersDocumentsInLearning.Text = "Liczba przekazanych dokumentów:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.progressBarLearn);
            this.panel4.Controls.Add(this.tableLayoutPanel4);
            this.panel4.Location = new System.Drawing.Point(759, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(183, 385);
            this.panel4.TabIndex = 2;
            // 
            // progressBarLearn
            // 
            this.progressBarLearn.Location = new System.Drawing.Point(3, 50);
            this.progressBarLearn.Name = "progressBarLearn";
            this.progressBarLearn.Size = new System.Drawing.Size(180, 23);
            this.progressBarLearn.TabIndex = 1;
            this.progressBarLearn.Visible = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.buttonLearningStart1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonLearningStop1, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(186, 37);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // buttonLearningStart1
            // 
            this.buttonLearningStart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLearningStart1.Location = new System.Drawing.Point(84, 3);
            this.buttonLearningStart1.Name = "buttonLearningStart1";
            this.buttonLearningStart1.Size = new System.Drawing.Size(99, 31);
            this.buttonLearningStart1.TabIndex = 1;
            this.buttonLearningStart1.Text = "Start";
            this.buttonLearningStart1.UseVisualStyleBackColor = true;
            this.buttonLearningStart1.Click += new System.EventHandler(this.OnButtonLearningStart1_Click);
            // 
            // buttonLearningStop1
            // 
            this.buttonLearningStop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLearningStop1.Location = new System.Drawing.Point(3, 3);
            this.buttonLearningStop1.Name = "buttonLearningStop1";
            this.buttonLearningStop1.Size = new System.Drawing.Size(75, 31);
            this.buttonLearningStop1.TabIndex = 0;
            this.buttonLearningStop1.Text = "Stop";
            this.buttonLearningStop1.UseVisualStyleBackColor = true;
            this.buttonLearningStop1.Visible = false;
            this.buttonLearningStop1.Click += new System.EventHandler(this.OnButtonLearningStop1_Click);
            // 
            // tabPageClasyfication
            // 
            this.tabPageClasyfication.Controls.Add(this.tableLayoutPanel2);
            this.tabPageClasyfication.Location = new System.Drawing.Point(4, 22);
            this.tabPageClasyfication.Name = "tabPageClasyfication";
            this.tabPageClasyfication.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClasyfication.Size = new System.Drawing.Size(951, 397);
            this.tabPageClasyfication.TabIndex = 1;
            this.tabPageClasyfication.Text = "Klasyfikacja";
            this.tabPageClasyfication.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.27004F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.72996F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(945, 391);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewClassificationResults);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(733, 385);
            this.panel2.TabIndex = 6;
            // 
            // dataGridViewClassificationResults
            // 
            this.dataGridViewClassificationResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClassificationResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassificationResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnCategory,
            this.ColumnCategoryFind,
            this.ColumnShow});
            this.dataGridViewClassificationResults.Location = new System.Drawing.Point(3, 6);
            this.dataGridViewClassificationResults.Name = "dataGridViewClassificationResults";
            this.dataGridViewClassificationResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewClassificationResults.Size = new System.Drawing.Size(727, 364);
            this.dataGridViewClassificationResults.TabIndex = 5;
            this.dataGridViewClassificationResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnDataGridViewClassificationResults_CellClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.labelClassificationValueDirectory);
            this.panel3.Controls.Add(this.labelClassificationNameDirectory);
            this.panel3.Controls.Add(this.labelClassificationValueDocument);
            this.panel3.Controls.Add(this.labelClassificationNameDocument);
            this.panel3.Controls.Add(this.labelClassificationValueClassificatorState);
            this.panel3.Controls.Add(this.labelClassificationNameClassificatorState);
            this.panel3.Controls.Add(this.labelClassificationValueEfficiency);
            this.panel3.Controls.Add(this.labelClassificationNameEfficiency);
            this.panel3.Controls.Add(this.labelClassificationValueNumberGoodDocuments);
            this.panel3.Controls.Add(this.labelClassificationNameNumberGoodDocuments);
            this.panel3.Controls.Add(this.labelClassificationValueNumberAllDocuments);
            this.panel3.Controls.Add(this.labelClassificationNameNumberAllDocuments);
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Controls.Add(this.progressBarClassification);
            this.panel3.Location = new System.Drawing.Point(753, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 385);
            this.panel3.TabIndex = 7;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // labelClassificationValueDirectory
            // 
            this.labelClassificationValueDirectory.AutoSize = true;
            this.labelClassificationValueDirectory.Location = new System.Drawing.Point(155, 271);
            this.labelClassificationValueDirectory.Name = "labelClassificationValueDirectory";
            this.labelClassificationValueDirectory.Size = new System.Drawing.Size(0, 13);
            this.labelClassificationValueDirectory.TabIndex = 20;
            // 
            // labelClassificationNameDirectory
            // 
            this.labelClassificationNameDirectory.AutoSize = true;
            this.labelClassificationNameDirectory.Location = new System.Drawing.Point(-1, 271);
            this.labelClassificationNameDirectory.Name = "labelClassificationNameDirectory";
            this.labelClassificationNameDirectory.Size = new System.Drawing.Size(125, 13);
            this.labelClassificationNameDirectory.TabIndex = 19;
            this.labelClassificationNameDirectory.Text = "Reprezentacja s³ownika:";
            // 
            // labelClassificationValueDocument
            // 
            this.labelClassificationValueDocument.AutoSize = true;
            this.labelClassificationValueDocument.Location = new System.Drawing.Point(155, 243);
            this.labelClassificationValueDocument.Name = "labelClassificationValueDocument";
            this.labelClassificationValueDocument.Size = new System.Drawing.Size(0, 13);
            this.labelClassificationValueDocument.TabIndex = 18;
            // 
            // labelClassificationNameDocument
            // 
            this.labelClassificationNameDocument.AutoSize = true;
            this.labelClassificationNameDocument.Location = new System.Drawing.Point(0, 243);
            this.labelClassificationNameDocument.Name = "labelClassificationNameDocument";
            this.labelClassificationNameDocument.Size = new System.Drawing.Size(143, 13);
            this.labelClassificationNameDocument.TabIndex = 17;
            this.labelClassificationNameDocument.Text = "Reprezentacja dokumentów:";
            // 
            // labelClassificationValueClassificatorState
            // 
            this.labelClassificationValueClassificatorState.AutoSize = true;
            this.labelClassificationValueClassificatorState.Location = new System.Drawing.Point(107, 213);
            this.labelClassificationValueClassificatorState.Name = "labelClassificationValueClassificatorState";
            this.labelClassificationValueClassificatorState.Size = new System.Drawing.Size(73, 13);
            this.labelClassificationValueClassificatorState.TabIndex = 16;
            this.labelClassificationValueClassificatorState.Text = "Nie nauczona";
            // 
            // labelClassificationNameClassificatorState
            // 
            this.labelClassificationNameClassificatorState.AutoSize = true;
            this.labelClassificationNameClassificatorState.Location = new System.Drawing.Point(4, 191);
            this.labelClassificationNameClassificatorState.Name = "labelClassificationNameClassificatorState";
            this.labelClassificationNameClassificatorState.Size = new System.Drawing.Size(56, 13);
            this.labelClassificationNameClassificatorState.TabIndex = 15;
            this.labelClassificationNameClassificatorState.Text = "Stan sieci:";
            // 
            // labelClassificationValueEfficiency
            // 
            this.labelClassificationValueEfficiency.AutoSize = true;
            this.labelClassificationValueEfficiency.Location = new System.Drawing.Point(159, 164);
            this.labelClassificationValueEfficiency.Name = "labelClassificationValueEfficiency";
            this.labelClassificationValueEfficiency.Size = new System.Drawing.Size(21, 13);
            this.labelClassificationValueEfficiency.TabIndex = 14;
            this.labelClassificationValueEfficiency.Text = "0%";
            // 
            // labelClassificationNameEfficiency
            // 
            this.labelClassificationNameEfficiency.AutoSize = true;
            this.labelClassificationNameEfficiency.Location = new System.Drawing.Point(3, 164);
            this.labelClassificationNameEfficiency.Name = "labelClassificationNameEfficiency";
            this.labelClassificationNameEfficiency.Size = new System.Drawing.Size(72, 13);
            this.labelClassificationNameEfficiency.TabIndex = 13;
            this.labelClassificationNameEfficiency.Text = "Skutecznoœæ:";
            // 
            // labelClassificationValueNumberGoodDocuments
            // 
            this.labelClassificationValueNumberGoodDocuments.AutoSize = true;
            this.labelClassificationValueNumberGoodDocuments.Location = new System.Drawing.Point(161, 135);
            this.labelClassificationValueNumberGoodDocuments.Name = "labelClassificationValueNumberGoodDocuments";
            this.labelClassificationValueNumberGoodDocuments.Size = new System.Drawing.Size(13, 13);
            this.labelClassificationValueNumberGoodDocuments.TabIndex = 12;
            this.labelClassificationValueNumberGoodDocuments.Text = "0";
            // 
            // labelClassificationNameNumberGoodDocuments
            // 
            this.labelClassificationNameNumberGoodDocuments.AutoSize = true;
            this.labelClassificationNameNumberGoodDocuments.Location = new System.Drawing.Point(4, 135);
            this.labelClassificationNameNumberGoodDocuments.Name = "labelClassificationNameNumberGoodDocuments";
            this.labelClassificationNameNumberGoodDocuments.Size = new System.Drawing.Size(151, 13);
            this.labelClassificationNameNumberGoodDocuments.TabIndex = 11;
            this.labelClassificationNameNumberGoodDocuments.Text = "Iloœæ rozpoznanych artyku³ów:";
            // 
            // labelClassificationValueNumberAllDocuments
            // 
            this.labelClassificationValueNumberAllDocuments.AutoSize = true;
            this.labelClassificationValueNumberAllDocuments.Location = new System.Drawing.Point(161, 106);
            this.labelClassificationValueNumberAllDocuments.Name = "labelClassificationValueNumberAllDocuments";
            this.labelClassificationValueNumberAllDocuments.Size = new System.Drawing.Size(13, 13);
            this.labelClassificationValueNumberAllDocuments.TabIndex = 10;
            this.labelClassificationValueNumberAllDocuments.Text = "0";
            // 
            // labelClassificationNameNumberAllDocuments
            // 
            this.labelClassificationNameNumberAllDocuments.AutoSize = true;
            this.labelClassificationNameNumberAllDocuments.Location = new System.Drawing.Point(3, 106);
            this.labelClassificationNameNumberAllDocuments.Name = "labelClassificationNameNumberAllDocuments";
            this.labelClassificationNameNumberAllDocuments.Size = new System.Drawing.Size(136, 13);
            this.labelClassificationNameNumberAllDocuments.TabIndex = 9;
            this.labelClassificationNameNumberAllDocuments.Text = "Iloœæ wszystkich artyku³ów:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.buttonClassificationStop, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonClassificationStart, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(187, 37);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // buttonClassificationStop
            // 
            this.buttonClassificationStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClassificationStop.Location = new System.Drawing.Point(3, 3);
            this.buttonClassificationStop.Name = "buttonClassificationStop";
            this.buttonClassificationStop.Size = new System.Drawing.Size(89, 31);
            this.buttonClassificationStop.TabIndex = 0;
            this.buttonClassificationStop.Text = "Stop";
            this.buttonClassificationStop.UseVisualStyleBackColor = true;
            this.buttonClassificationStop.Visible = false;
            this.buttonClassificationStop.Click += new System.EventHandler(this.OnButtonClassificationStop_Click);
            // 
            // buttonClassificationStart
            // 
            this.buttonClassificationStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClassificationStart.Location = new System.Drawing.Point(98, 3);
            this.buttonClassificationStart.Name = "buttonClassificationStart";
            this.buttonClassificationStart.Size = new System.Drawing.Size(86, 31);
            this.buttonClassificationStart.TabIndex = 1;
            this.buttonClassificationStart.Text = "Start";
            this.buttonClassificationStart.UseVisualStyleBackColor = true;
            this.buttonClassificationStart.Click += new System.EventHandler(this.OnButtonClassificationStart_Click);
            // 
            // progressBarClassification
            // 
            this.progressBarClassification.Location = new System.Drawing.Point(6, 58);
            this.progressBarClassification.Name = "progressBarClassification";
            this.progressBarClassification.Size = new System.Drawing.Size(183, 26);
            this.progressBarClassification.TabIndex = 4;
            this.progressBarClassification.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(959, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.buttonLearningStart, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // buttonLearningStart
            // 
            this.buttonLearningStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLearningStart.Location = new System.Drawing.Point(3, 3);
            this.buttonLearningStart.Name = "buttonLearningStart";
            this.buttonLearningStart.Size = new System.Drawing.Size(75, 94);
            this.buttonLearningStart.TabIndex = 0;
            this.buttonLearningStart.Text = "Start";
            this.buttonLearningStart.UseVisualStyleBackColor = true;
            // 
            // buttonLearningStop
            // 
            this.buttonLearningStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLearningStop.Location = new System.Drawing.Point(84, 3);
            this.buttonLearningStop.Name = "buttonLearningStop";
            this.buttonLearningStop.Size = new System.Drawing.Size(113, 8);
            this.buttonLearningStop.TabIndex = 1;
            this.buttonLearningStop.Text = "Stop";
            this.buttonLearningStop.UseVisualStyleBackColor = true;
            // 
            // radioButtonDictionaryFrequance
            // 
            this.radioButtonDictionaryFrequance.AutoSize = true;
            this.radioButtonDictionaryFrequance.DictionaryType = DocClass.Src.Dictionaries.DictionaryType.Frequent;
            this.radioButtonDictionaryFrequance.Location = new System.Drawing.Point(25, 67);
            this.radioButtonDictionaryFrequance.Name = "radioButtonDictionaryFrequance";
            this.radioButtonDictionaryFrequance.Size = new System.Drawing.Size(67, 17);
            this.radioButtonDictionaryFrequance.TabIndex = 3;
            this.radioButtonDictionaryFrequance.Text = "Frequent";
            this.radioButtonDictionaryFrequance.UseVisualStyleBackColor = true;
            // 
            // radioButtonDictionaryFixed
            // 
            this.radioButtonDictionaryFixed.AutoSize = true;
            this.radioButtonDictionaryFixed.Checked = true;
            this.radioButtonDictionaryFixed.DictionaryType = DocClass.Src.Dictionaries.DictionaryType.CtfIdf;
            this.radioButtonDictionaryFixed.Location = new System.Drawing.Point(25, 21);
            this.radioButtonDictionaryFixed.Name = "radioButtonDictionaryFixed";
            this.radioButtonDictionaryFixed.Size = new System.Drawing.Size(50, 17);
            this.radioButtonDictionaryFixed.TabIndex = 1;
            this.radioButtonDictionaryFixed.TabStop = true;
            this.radioButtonDictionaryFixed.Text = "CtfIdf";
            this.radioButtonDictionaryFixed.UseVisualStyleBackColor = true;
            // 
            // radioButtonDictionaryCtfIdf
            // 
            this.radioButtonDictionaryCtfIdf.AutoSize = true;
            this.radioButtonDictionaryCtfIdf.DictionaryType = DocClass.Src.Dictionaries.DictionaryType.Fixed;
            this.radioButtonDictionaryCtfIdf.Location = new System.Drawing.Point(25, 44);
            this.radioButtonDictionaryCtfIdf.Name = "radioButtonDictionaryCtfIdf";
            this.radioButtonDictionaryCtfIdf.Size = new System.Drawing.Size(50, 17);
            this.radioButtonDictionaryCtfIdf.TabIndex = 2;
            this.radioButtonDictionaryCtfIdf.Text = "Fixed";
            this.radioButtonDictionaryCtfIdf.UseVisualStyleBackColor = true;
            // 
            // radioButtonDocumentRepresentationBinary
            // 
            this.radioButtonDocumentRepresentationBinary.AutoSize = true;
            this.radioButtonDocumentRepresentationBinary.DocumentRepresentationType = DocClass.Src.DocumentRepresentation.DocumentRepresentationType.Binary;
            this.radioButtonDocumentRepresentationBinary.Location = new System.Drawing.Point(31, 44);
            this.radioButtonDocumentRepresentationBinary.Name = "radioButtonDocumentRepresentationBinary";
            this.radioButtonDocumentRepresentationBinary.Size = new System.Drawing.Size(54, 17);
            this.radioButtonDocumentRepresentationBinary.TabIndex = 2;
            this.radioButtonDocumentRepresentationBinary.Text = "Binary";
            this.radioButtonDocumentRepresentationBinary.UseVisualStyleBackColor = true;
            // 
            // radioButtonDocumentRepresentationOwn
            // 
            this.radioButtonDocumentRepresentationOwn.AutoSize = true;
            this.radioButtonDocumentRepresentationOwn.DocumentRepresentationType = DocClass.Src.DocumentRepresentation.DocumentRepresentationType.Own;
            this.radioButtonDocumentRepresentationOwn.Location = new System.Drawing.Point(33, 67);
            this.radioButtonDocumentRepresentationOwn.Name = "radioButtonDocumentRepresentationOwn";
            this.radioButtonDocumentRepresentationOwn.Size = new System.Drawing.Size(47, 17);
            this.radioButtonDocumentRepresentationOwn.TabIndex = 1;
            this.radioButtonDocumentRepresentationOwn.Text = "Own";
            this.radioButtonDocumentRepresentationOwn.UseVisualStyleBackColor = true;
            // 
            // radioButtonDocumentRepresentationTfIdf
            // 
            this.radioButtonDocumentRepresentationTfIdf.AutoSize = true;
            this.radioButtonDocumentRepresentationTfIdf.Checked = true;
            this.radioButtonDocumentRepresentationTfIdf.DocumentRepresentationType = DocClass.Src.DocumentRepresentation.DocumentRepresentationType.TfIdf;
            this.radioButtonDocumentRepresentationTfIdf.Location = new System.Drawing.Point(33, 21);
            this.radioButtonDocumentRepresentationTfIdf.Name = "radioButtonDocumentRepresentationTfIdf";
            this.radioButtonDocumentRepresentationTfIdf.Size = new System.Drawing.Size(47, 17);
            this.radioButtonDocumentRepresentationTfIdf.TabIndex = 0;
            this.radioButtonDocumentRepresentationTfIdf.TabStop = true;
            this.radioButtonDocumentRepresentationTfIdf.Text = "TfIdf";
            this.radioButtonDocumentRepresentationTfIdf.UseVisualStyleBackColor = true;
            // 
            // fileInput2
            // 
            this.fileInput2.Location = new System.Drawing.Point(-16, 19);
            this.fileInput2.Name = "fileInput2";
            this.fileInput2.Size = new System.Drawing.Size(357, 27);
            this.fileInput2.TabIndex = 0;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Nazwa";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 175;
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.HeaderText = "Kategoria";
            this.ColumnCategory.Name = "ColumnCategory";
            this.ColumnCategory.Width = 175;
            // 
            // ColumnCategoryFind
            // 
            this.ColumnCategoryFind.HeaderText = "Kategoria znaleziona";
            this.ColumnCategoryFind.Name = "ColumnCategoryFind";
            this.ColumnCategoryFind.ReadOnly = true;
            this.ColumnCategoryFind.Width = 175;
            // 
            // ColumnShow
            // 
            this.ColumnShow.HeaderText = "Podgl¹d";
            this.ColumnShow.Name = "ColumnShow";
            this.ColumnShow.ReadOnly = true;
            this.ColumnShow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnShow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnShow.Width = 175;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 447);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Klasyfikator dokumentów";
            this.Load += new System.EventHandler(this.OnMainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.tabControlUse.ResumeLayout(false);
            this.tabPageLearning.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxLearningParameters.ResumeLayout(false);
            this.groupBoxLearningParameters.PerformLayout();
            this.groupBoxDictionary.ResumeLayout(false);
            this.groupBoxDictionary.PerformLayout();
            this.groupBoxDocumentRepresentation.ResumeLayout(false);
            this.groupBoxDocumentRepresentation.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabPageClasyfication.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassificationResults)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItemProgram;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private FileInput fileInput2;
        private System.Windows.Forms.ToolStripMenuItem metodaKlasyfikacjiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BayesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RadialNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descriptionToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogDateLoad;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDateLoad;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonLearningStart;
        private System.Windows.Forms.Button buttonLearningStop;
        private System.Windows.Forms.ToolStripMenuItem preproccesingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNetworkToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveBayesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBayesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabControl tabControlUse;
        private System.Windows.Forms.TabPage tabPageLearning;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxLearningParameters;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ProgressBar progressBarLearn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button buttonLearningStart1;
        private System.Windows.Forms.Button buttonLearningStop1;
        private System.Windows.Forms.GroupBox groupBoxDictionary;
        private RadioButtonDictionary radioButtonDictionaryFrequance;
        private RadioButtonDictionary radioButtonDictionaryFixed;
        private RadioButtonDictionary radioButtonDictionaryCtfIdf;
        private System.Windows.Forms.Label labelLearningValueNumberOutNerons;
        private System.Windows.Forms.GroupBox groupBoxDocumentRepresentation;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationBinary;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationOwn;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationTfIdf;
        private System.Windows.Forms.Label labelLearningNameNumberOutNerons;
        private System.Windows.Forms.Label labelLearningValuePathDir;
        private System.Windows.Forms.Label labelLearningNamePathDir;
        private System.Windows.Forms.Label labelLearningValueNumberAllWords;
        private System.Windows.Forms.Label labelLearningValueNumbersHiddenNerons;
        private System.Windows.Forms.Label labelLearningValueNumbersDocumentsInLearning;
        private System.Windows.Forms.Label labelLearningValueNumbersCategoriesInLearning;
        private System.Windows.Forms.Label labelLearningValueNumbersCategoriesAll;
        private System.Windows.Forms.Label labelLearningNameNumbersHiddenNerons;
        private System.Windows.Forms.Label labelLearningNameNumberAllWords;
        private System.Windows.Forms.Label labelLearningNameNumbersCategoriesInLearning;
        private System.Windows.Forms.Label labelLearningNameNumbersCategoriesAll;
        private System.Windows.Forms.Label labelLearningNameNumbersDocumentsInLearning;
        private System.Windows.Forms.TabPage tabPageClasyfication;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewClassificationResults;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelClassificationValueDirectory;
        private System.Windows.Forms.Label labelClassificationNameDirectory;
        private System.Windows.Forms.Label labelClassificationValueDocument;
        private System.Windows.Forms.Label labelClassificationNameDocument;
        private System.Windows.Forms.Label labelClassificationValueClassificatorState;
        private System.Windows.Forms.Label labelClassificationNameClassificatorState;
        private System.Windows.Forms.Label labelClassificationValueEfficiency;
        private System.Windows.Forms.Label labelClassificationNameEfficiency;
        private System.Windows.Forms.Label labelClassificationValueNumberGoodDocuments;
        private System.Windows.Forms.Label labelClassificationNameNumberGoodDocuments;
        private System.Windows.Forms.Label labelClassificationValueNumberAllDocuments;
        private System.Windows.Forms.Label labelClassificationNameNumberAllDocuments;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonClassificationStop;
        private System.Windows.Forms.Button buttonClassificationStart;
        private System.Windows.Forms.ProgressBar progressBarClassification;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategoryFind;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnShow;
    }
}

