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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metodaKlasyfikacjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BayesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RadialNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxDictionary = new System.Windows.Forms.GroupBox();
            this.groupBoxDocumentRepresentation = new System.Windows.Forms.GroupBox();
            this.tabControlUse = new System.Windows.Forms.TabControl();
            this.tabPageLearning = new System.Windows.Forms.TabPage();
            this.mLearningTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLearningFile = new System.Windows.Forms.GroupBox();
            this.groupBoxLearningActions = new System.Windows.Forms.GroupBox();
            this.mStartStopTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLearningStop = new System.Windows.Forms.Button();
            this.buttonLearningStart = new System.Windows.Forms.Button();
            this.groupBoxLearningParameters = new System.Windows.Forms.GroupBox();
            this.splitContainerLearning = new System.Windows.Forms.SplitContainer();
            this.tabPageClasyfication = new System.Windows.Forms.TabPage();
            this.radioButtonDictionaryFrequance = new DocClass.RadioButtonDictionary();
            this.radioButtonDictionaryFixed = new DocClass.RadioButtonDictionary();
            this.radioButtonDictionaryCtfIdf = new DocClass.RadioButtonDictionary();
            this.radioButtonDocumentRepresentationBinary = new DocClass.RadioButtonDocumentRepresentation();
            this.radioButtonDocumentRepresentationOwn = new DocClass.RadioButtonDocumentRepresentation();
            this.radioButtonDocumentRepresentationTfIdf = new DocClass.RadioButtonDocumentRepresentation();
            this.fileInput1 = new DocClass.FileInput();
            this.splitContainerClasification = new System.Windows.Forms.SplitContainer();
            this.mClassificationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxClasificationFile = new System.Windows.Forms.GroupBox();
            this.fileInput3 = new DocClass.FileInput();
            this.groupBoxClasificationParameters = new System.Windows.Forms.GroupBox();
            this.groupBoxClassificationAction = new System.Windows.Forms.GroupBox();
            this.mClassStartStoptableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClassificationStop = new System.Windows.Forms.Button();
            this.buttonClassificationStart = new System.Windows.Forms.Button();
            this.fileInput2 = new DocClass.FileInput();
            this.menuStripMain.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxDictionary.SuspendLayout();
            this.groupBoxDocumentRepresentation.SuspendLayout();
            this.tabControlUse.SuspendLayout();
            this.tabPageLearning.SuspendLayout();
            this.mLearningTableLayoutPanel.SuspendLayout();
            this.groupBoxLearningFile.SuspendLayout();
            this.groupBoxLearningActions.SuspendLayout();
            this.mStartStopTableLayoutPanel.SuspendLayout();
            this.splitContainerLearning.SuspendLayout();
            this.tabPageClasyfication.SuspendLayout();
            this.splitContainerClasification.Panel1.SuspendLayout();
            this.splitContainerClasification.SuspendLayout();
            this.mClassificationTableLayoutPanel.SuspendLayout();
            this.groupBoxClasificationFile.SuspendLayout();
            this.groupBoxClassificationAction.SuspendLayout();
            this.mClassStartStoptableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItemProgram,
            this.metodaKlasyfikacjiToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(960, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // programToolStripMenuItemProgram
            // 
            this.programToolStripMenuItemProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.programToolStripMenuItemProgram.Name = "programToolStripMenuItemProgram";
            this.programToolStripMenuItemProgram.Size = new System.Drawing.Size(59, 20);
            this.programToolStripMenuItemProgram.Text = "Program";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.BayesToolStripMenuItem.Checked = true;
            this.BayesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BayesToolStripMenuItem.Name = "BayesToolStripMenuItem";
            this.BayesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.BayesToolStripMenuItem.Text = "Klasyfikator Bayes\'a";
            this.BayesToolStripMenuItem.Click += new System.EventHandler(this.OnBayesaToolStripMenuItem_Click);
            // 
            // RadialNetworkToolStripMenuItem
            // 
            this.RadialNetworkToolStripMenuItem.Name = "RadialNetworkToolStripMenuItem";
            this.RadialNetworkToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.RadialNetworkToolStripMenuItem.Text = "Siec Radialna";
            this.RadialNetworkToolStripMenuItem.Click += new System.EventHandler(this.RadialNetworkToolStripMenuItem_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxDictionary);
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxDocumentRepresentation);
            this.splitContainerMain.Panel1MinSize = 10;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlUse);
            this.splitContainerMain.Size = new System.Drawing.Size(960, 481);
            this.splitContainerMain.SplitterDistance = 129;
            this.splitContainerMain.TabIndex = 2;
            // 
            // groupBoxDictionary
            // 
            this.groupBoxDictionary.Controls.Add(this.radioButtonDictionaryFrequance);
            this.groupBoxDictionary.Controls.Add(this.radioButtonDictionaryFixed);
            this.groupBoxDictionary.Controls.Add(this.radioButtonDictionaryCtfIdf);
            this.groupBoxDictionary.Location = new System.Drawing.Point(232, 15);
            this.groupBoxDictionary.Name = "groupBoxDictionary";
            this.groupBoxDictionary.Size = new System.Drawing.Size(232, 100);
            this.groupBoxDictionary.TabIndex = 1;
            this.groupBoxDictionary.TabStop = false;
            this.groupBoxDictionary.Text = "Dobieranie s³ów do s³ownika";
            // 
            // groupBoxDocumentRepresentation
            // 
            this.groupBoxDocumentRepresentation.Controls.Add(this.radioButtonDocumentRepresentationBinary);
            this.groupBoxDocumentRepresentation.Controls.Add(this.radioButtonDocumentRepresentationOwn);
            this.groupBoxDocumentRepresentation.Controls.Add(this.radioButtonDocumentRepresentationTfIdf);
            this.groupBoxDocumentRepresentation.Location = new System.Drawing.Point(12, 15);
            this.groupBoxDocumentRepresentation.Name = "groupBoxDocumentRepresentation";
            this.groupBoxDocumentRepresentation.Size = new System.Drawing.Size(200, 100);
            this.groupBoxDocumentRepresentation.TabIndex = 0;
            this.groupBoxDocumentRepresentation.TabStop = false;
            this.groupBoxDocumentRepresentation.Text = "Reprezentacja dokumentu";
            // 
            // tabControlUse
            // 
            this.tabControlUse.Controls.Add(this.tabPageLearning);
            this.tabControlUse.Controls.Add(this.tabPageClasyfication);
            this.tabControlUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlUse.Location = new System.Drawing.Point(0, 0);
            this.tabControlUse.Name = "tabControlUse";
            this.tabControlUse.SelectedIndex = 0;
            this.tabControlUse.Size = new System.Drawing.Size(960, 348);
            this.tabControlUse.TabIndex = 0;
            // 
            // tabPageLearning
            // 
            this.tabPageLearning.Controls.Add(this.mLearningTableLayoutPanel);
            this.tabPageLearning.Controls.Add(this.splitContainerLearning);
            this.tabPageLearning.Location = new System.Drawing.Point(4, 22);
            this.tabPageLearning.Name = "tabPageLearning";
            this.tabPageLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLearning.Size = new System.Drawing.Size(952, 322);
            this.tabPageLearning.TabIndex = 0;
            this.tabPageLearning.Text = "Nauka";
            this.tabPageLearning.UseVisualStyleBackColor = true;
            // 
            // mLearningTableLayoutPanel
            // 
            this.mLearningTableLayoutPanel.ColumnCount = 3;
            this.mLearningTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mLearningTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mLearningTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mLearningTableLayoutPanel.Controls.Add(this.groupBoxLearningFile, 0, 0);
            this.mLearningTableLayoutPanel.Controls.Add(this.groupBoxLearningActions, 2, 0);
            this.mLearningTableLayoutPanel.Controls.Add(this.groupBoxLearningParameters, 1, 0);
            this.mLearningTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mLearningTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.mLearningTableLayoutPanel.Name = "mLearningTableLayoutPanel";
            this.mLearningTableLayoutPanel.RowCount = 1;
            this.mLearningTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mLearningTableLayoutPanel.Size = new System.Drawing.Size(946, 66);
            this.mLearningTableLayoutPanel.TabIndex = 3;
            // 
            // groupBoxLearningFile
            // 
            this.groupBoxLearningFile.Controls.Add(this.fileInput1);
            this.groupBoxLearningFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLearningFile.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLearningFile.Name = "groupBoxLearningFile";
            this.groupBoxLearningFile.Size = new System.Drawing.Size(277, 60);
            this.groupBoxLearningFile.TabIndex = 0;
            this.groupBoxLearningFile.TabStop = false;
            this.groupBoxLearningFile.Text = "Plik";
            // 
            // groupBoxLearningActions
            // 
            this.groupBoxLearningActions.Controls.Add(this.mStartStopTableLayoutPanel);
            this.groupBoxLearningActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLearningActions.Location = new System.Drawing.Point(759, 3);
            this.groupBoxLearningActions.Name = "groupBoxLearningActions";
            this.groupBoxLearningActions.Size = new System.Drawing.Size(184, 60);
            this.groupBoxLearningActions.TabIndex = 2;
            this.groupBoxLearningActions.TabStop = false;
            this.groupBoxLearningActions.Text = "Akcje";
            // 
            // mStartStopTableLayoutPanel
            // 
            this.mStartStopTableLayoutPanel.ColumnCount = 2;
            this.mStartStopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mStartStopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mStartStopTableLayoutPanel.Controls.Add(this.buttonLearningStop, 1, 0);
            this.mStartStopTableLayoutPanel.Controls.Add(this.buttonLearningStart, 0, 0);
            this.mStartStopTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mStartStopTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.mStartStopTableLayoutPanel.Name = "mStartStopTableLayoutPanel";
            this.mStartStopTableLayoutPanel.RowCount = 1;
            this.mStartStopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mStartStopTableLayoutPanel.Size = new System.Drawing.Size(178, 36);
            this.mStartStopTableLayoutPanel.TabIndex = 2;
            // 
            // buttonLearningStop
            // 
            this.buttonLearningStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLearningStop.Location = new System.Drawing.Point(92, 3);
            this.buttonLearningStop.Name = "buttonLearningStop";
            this.buttonLearningStop.Size = new System.Drawing.Size(83, 30);
            this.buttonLearningStop.TabIndex = 1;
            this.buttonLearningStop.Text = "Stop";
            this.buttonLearningStop.UseVisualStyleBackColor = true;
            this.buttonLearningStop.Click += new System.EventHandler(this.OnLearningStopButton_Click);
            // 
            // buttonLearningStart
            // 
            this.buttonLearningStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLearningStart.Location = new System.Drawing.Point(3, 3);
            this.buttonLearningStart.Name = "buttonLearningStart";
            this.buttonLearningStart.Size = new System.Drawing.Size(83, 30);
            this.buttonLearningStart.TabIndex = 0;
            this.buttonLearningStart.Text = "Start";
            this.buttonLearningStart.UseVisualStyleBackColor = true;
            this.buttonLearningStart.Click += new System.EventHandler(this.OnLearningStartButton_Click);
            // 
            // groupBoxLearningParameters
            // 
            this.groupBoxLearningParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLearningParameters.Location = new System.Drawing.Point(286, 3);
            this.groupBoxLearningParameters.Name = "groupBoxLearningParameters";
            this.groupBoxLearningParameters.Size = new System.Drawing.Size(467, 60);
            this.groupBoxLearningParameters.TabIndex = 1;
            this.groupBoxLearningParameters.TabStop = false;
            this.groupBoxLearningParameters.Text = "Parametry";
            // 
            // splitContainerLearning
            // 
            this.splitContainerLearning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLearning.Location = new System.Drawing.Point(3, 3);
            this.splitContainerLearning.Name = "splitContainerLearning";
            this.splitContainerLearning.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerLearning.Size = new System.Drawing.Size(946, 316);
            this.splitContainerLearning.SplitterDistance = 72;
            this.splitContainerLearning.TabIndex = 0;
            // 
            // tabPageClasyfication
            // 
            this.tabPageClasyfication.Controls.Add(this.splitContainerClasification);
            this.tabPageClasyfication.Location = new System.Drawing.Point(4, 22);
            this.tabPageClasyfication.Name = "tabPageClasyfication";
            this.tabPageClasyfication.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClasyfication.Size = new System.Drawing.Size(952, 322);
            this.tabPageClasyfication.TabIndex = 1;
            this.tabPageClasyfication.Text = "Klasyfikacja";
            this.tabPageClasyfication.UseVisualStyleBackColor = true;
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
            this.radioButtonDocumentRepresentationBinary.Location = new System.Drawing.Point(16, 44);
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
            this.radioButtonDocumentRepresentationOwn.Location = new System.Drawing.Point(18, 67);
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
            this.radioButtonDocumentRepresentationTfIdf.Location = new System.Drawing.Point(18, 21);
            this.radioButtonDocumentRepresentationTfIdf.Name = "radioButtonDocumentRepresentationTfIdf";
            this.radioButtonDocumentRepresentationTfIdf.Size = new System.Drawing.Size(47, 17);
            this.radioButtonDocumentRepresentationTfIdf.TabIndex = 0;
            this.radioButtonDocumentRepresentationTfIdf.TabStop = true;
            this.radioButtonDocumentRepresentationTfIdf.Text = "TfIdf";
            this.radioButtonDocumentRepresentationTfIdf.UseVisualStyleBackColor = true;
            // 
            // fileInput1
            // 
            this.fileInput1.Location = new System.Drawing.Point(-19, 19);
            this.fileInput1.Name = "fileInput1";
            this.fileInput1.Size = new System.Drawing.Size(294, 27);
            this.fileInput1.TabIndex = 0;
            // 
            // splitContainerClasification
            // 
            this.splitContainerClasification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerClasification.Location = new System.Drawing.Point(3, 3);
            this.splitContainerClasification.Name = "splitContainerClasification";
            this.splitContainerClasification.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerClasification.Panel1
            // 
            this.splitContainerClasification.Panel1.Controls.Add(this.mClassificationTableLayoutPanel);
            this.splitContainerClasification.Size = new System.Drawing.Size(946, 316);
            this.splitContainerClasification.SplitterDistance = 78;
            this.splitContainerClasification.TabIndex = 0;
            // 
            // mClassificationTableLayoutPanel
            // 
            this.mClassificationTableLayoutPanel.ColumnCount = 3;
            this.mClassificationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mClassificationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mClassificationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mClassificationTableLayoutPanel.Controls.Add(this.groupBoxClasificationFile, 0, 0);
            this.mClassificationTableLayoutPanel.Controls.Add(this.groupBoxClasificationParameters, 1, 0);
            this.mClassificationTableLayoutPanel.Controls.Add(this.groupBoxClassificationAction, 2, 0);
            this.mClassificationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mClassificationTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mClassificationTableLayoutPanel.Name = "mClassificationTableLayoutPanel";
            this.mClassificationTableLayoutPanel.RowCount = 1;
            this.mClassificationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mClassificationTableLayoutPanel.Size = new System.Drawing.Size(946, 66);
            this.mClassificationTableLayoutPanel.TabIndex = 3;
            // 
            // groupBoxClasificationFile
            // 
            this.groupBoxClasificationFile.Controls.Add(this.fileInput3);
            this.groupBoxClasificationFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxClasificationFile.Location = new System.Drawing.Point(3, 3);
            this.groupBoxClasificationFile.Name = "groupBoxClasificationFile";
            this.groupBoxClasificationFile.Size = new System.Drawing.Size(277, 60);
            this.groupBoxClasificationFile.TabIndex = 0;
            this.groupBoxClasificationFile.TabStop = false;
            this.groupBoxClasificationFile.Text = "Plik";
            // 
            // fileInput3
            // 
            this.fileInput3.Location = new System.Drawing.Point(-19, 19);
            this.fileInput3.Name = "fileInput3";
            this.fileInput3.Size = new System.Drawing.Size(294, 27);
            this.fileInput3.TabIndex = 0;
            // 
            // groupBoxClasificationParameters
            // 
            this.groupBoxClasificationParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxClasificationParameters.Location = new System.Drawing.Point(286, 3);
            this.groupBoxClasificationParameters.Name = "groupBoxClasificationParameters";
            this.groupBoxClasificationParameters.Size = new System.Drawing.Size(467, 60);
            this.groupBoxClasificationParameters.TabIndex = 1;
            this.groupBoxClasificationParameters.TabStop = false;
            this.groupBoxClasificationParameters.Text = "Parametry";
            // 
            // groupBoxClassificationAction
            // 
            this.groupBoxClassificationAction.Controls.Add(this.mClassStartStoptableLayoutPanel);
            this.groupBoxClassificationAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxClassificationAction.Location = new System.Drawing.Point(759, 3);
            this.groupBoxClassificationAction.Name = "groupBoxClassificationAction";
            this.groupBoxClassificationAction.Size = new System.Drawing.Size(184, 60);
            this.groupBoxClassificationAction.TabIndex = 2;
            this.groupBoxClassificationAction.TabStop = false;
            this.groupBoxClassificationAction.Text = "Akcje";
            // 
            // mClassStartStoptableLayoutPanel
            // 
            this.mClassStartStoptableLayoutPanel.ColumnCount = 2;
            this.mClassStartStoptableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mClassStartStoptableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mClassStartStoptableLayoutPanel.Controls.Add(this.buttonClassificationStop, 1, 0);
            this.mClassStartStoptableLayoutPanel.Controls.Add(this.buttonClassificationStart, 0, 0);
            this.mClassStartStoptableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mClassStartStoptableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.mClassStartStoptableLayoutPanel.Name = "mClassStartStoptableLayoutPanel";
            this.mClassStartStoptableLayoutPanel.RowCount = 1;
            this.mClassStartStoptableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mClassStartStoptableLayoutPanel.Size = new System.Drawing.Size(178, 42);
            this.mClassStartStoptableLayoutPanel.TabIndex = 2;
            // 
            // buttonClassificationStop
            // 
            this.buttonClassificationStop.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonClassificationStop.Location = new System.Drawing.Point(92, 3);
            this.buttonClassificationStop.Name = "buttonClassificationStop";
            this.buttonClassificationStop.Size = new System.Drawing.Size(83, 30);
            this.buttonClassificationStop.TabIndex = 1;
            this.buttonClassificationStop.Text = "Stop";
            this.buttonClassificationStop.UseVisualStyleBackColor = true;
            this.buttonClassificationStop.Click += new System.EventHandler(this.OnClassificationStopButton_Click);
            // 
            // buttonClassificationStart
            // 
            this.buttonClassificationStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonClassificationStart.Location = new System.Drawing.Point(3, 3);
            this.buttonClassificationStart.Name = "buttonClassificationStart";
            this.buttonClassificationStart.Size = new System.Drawing.Size(83, 30);
            this.buttonClassificationStart.TabIndex = 0;
            this.buttonClassificationStart.Text = "Start";
            this.buttonClassificationStart.UseVisualStyleBackColor = true;
            this.buttonClassificationStart.Click += new System.EventHandler(this.OnClassificationStartButton_Click);
            // 
            // fileInput2
            // 
            this.fileInput2.Location = new System.Drawing.Point(-16, 19);
            this.fileInput2.Name = "fileInput2";
            this.fileInput2.Size = new System.Drawing.Size(357, 27);
            this.fileInput2.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 505);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "Klasyfikator dokumentów";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.groupBoxDictionary.ResumeLayout(false);
            this.groupBoxDictionary.PerformLayout();
            this.groupBoxDocumentRepresentation.ResumeLayout(false);
            this.groupBoxDocumentRepresentation.PerformLayout();
            this.tabControlUse.ResumeLayout(false);
            this.tabPageLearning.ResumeLayout(false);
            this.mLearningTableLayoutPanel.ResumeLayout(false);
            this.groupBoxLearningFile.ResumeLayout(false);
            this.groupBoxLearningActions.ResumeLayout(false);
            this.mStartStopTableLayoutPanel.ResumeLayout(false);
            this.splitContainerLearning.ResumeLayout(false);
            this.tabPageClasyfication.ResumeLayout(false);
            this.splitContainerClasification.Panel1.ResumeLayout(false);
            this.splitContainerClasification.ResumeLayout(false);
            this.mClassificationTableLayoutPanel.ResumeLayout(false);
            this.groupBoxClasificationFile.ResumeLayout(false);
            this.groupBoxClassificationAction.ResumeLayout(false);
            this.mClassStartStoptableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBoxDictionary;
        private System.Windows.Forms.GroupBox groupBoxDocumentRepresentation;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItemProgram;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlUse;
        private System.Windows.Forms.TabPage tabPageLearning;
        private System.Windows.Forms.TabPage tabPageClasyfication;
        private System.Windows.Forms.SplitContainer splitContainerLearning;
        private System.Windows.Forms.GroupBox groupBoxLearningFile;
        private System.Windows.Forms.GroupBox groupBoxLearningParameters;
        private FileInput fileInput1;
        private System.Windows.Forms.SplitContainer splitContainerClasification;
        private System.Windows.Forms.GroupBox groupBoxClasificationFile;
        private FileInput fileInput2;
        private System.Windows.Forms.GroupBox groupBoxClasificationParameters;
        private FileInput fileInput3;
        private RadioButtonDictionary radioButtonDictionaryFixed;
        private RadioButtonDictionary radioButtonDictionaryCtfIdf;
        private RadioButtonDictionary radioButtonDictionaryFrequance;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationBinary;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationOwn;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationTfIdf;
        private System.Windows.Forms.GroupBox groupBoxLearningActions;
        private System.Windows.Forms.Button buttonLearningStop;
        private System.Windows.Forms.Button buttonLearningStart;
        private System.Windows.Forms.GroupBox groupBoxClassificationAction;
        private System.Windows.Forms.Button buttonClassificationStop;
        private System.Windows.Forms.Button buttonClassificationStart;
        private System.Windows.Forms.ToolStripMenuItem metodaKlasyfikacjiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BayesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RadialNetworkToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mLearningTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel mStartStopTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel mClassificationTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel mClassStartStoptableLayoutPanel;
    }
}

