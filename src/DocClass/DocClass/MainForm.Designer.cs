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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metodaKlasyfikacjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BayesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RadialNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogDateLoad = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogDateLoad = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxDictionary = new System.Windows.Forms.GroupBox();
            this.groupBoxDocumentRepresentation = new System.Windows.Forms.GroupBox();
            this.tabControlUse = new System.Windows.Forms.TabControl();
            this.tabPageClasyfication = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewClassificationResults = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Podgl¹d = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClassificationStop = new System.Windows.Forms.Button();
            this.buttonClassificationStart = new System.Windows.Forms.Button();
            this.tabPageLearning = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLearningParameters = new System.Windows.Forms.GroupBox();
            this.labelValueNumbersOutNerons = new System.Windows.Forms.Label();
            this.labelNameNumberOutNerons = new System.Windows.Forms.Label();
            this.labelValuePathLearningDir = new System.Windows.Forms.Label();
            this.labelNamePathLearningDir = new System.Windows.Forms.Label();
            this.labelValueWordNumber = new System.Windows.Forms.Label();
            this.labelValueNumbersHiddenNerons = new System.Windows.Forms.Label();
            this.labelValueTestNumbersDocuments = new System.Windows.Forms.Label();
            this.labelValueTestNumbersCategories = new System.Windows.Forms.Label();
            this.labelValueAllNumbersParameters = new System.Windows.Forms.Label();
            this.labelValueAllNumbersCategories = new System.Windows.Forms.Label();
            this.labelNameNumbersHiddenNerons = new System.Windows.Forms.Label();
            this.labelNameWordNumber = new System.Windows.Forms.Label();
            this.labelNameTestNumbersCategories = new System.Windows.Forms.Label();
            this.labelNameAllNumbersCategories = new System.Windows.Forms.Label();
            this.labelNameTestNumbersDocuments = new System.Windows.Forms.Label();
            this.labelNameAllNumbersParameters = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLearningStop1 = new System.Windows.Forms.Button();
            this.buttonLearningStart1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLearningStart = new System.Windows.Forms.Button();
            this.buttonLearningStop = new System.Windows.Forms.Button();
            this.radioButtonDictionaryFrequance = new DocClass.RadioButtonDictionary();
            this.radioButtonDictionaryFixed = new DocClass.RadioButtonDictionary();
            this.radioButtonDictionaryCtfIdf = new DocClass.RadioButtonDictionary();
            this.radioButtonDocumentRepresentationBinary = new DocClass.RadioButtonDocumentRepresentation();
            this.radioButtonDocumentRepresentationOwn = new DocClass.RadioButtonDocumentRepresentation();
            this.radioButtonDocumentRepresentationTfIdf = new DocClass.RadioButtonDocumentRepresentation();
            this.fileInput2 = new DocClass.FileInput();
            this.menuStripMain.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxDictionary.SuspendLayout();
            this.groupBoxDocumentRepresentation.SuspendLayout();
            this.tabControlUse.SuspendLayout();
            this.tabPageClasyfication.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassificationResults)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPageLearning.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxLearningParameters.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.menuStripMain.Size = new System.Drawing.Size(962, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // programToolStripMenuItemProgram
            // 
            this.programToolStripMenuItemProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
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
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.loadToolStripMenuItem.Text = "Wczytaj";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.fileToolStripMenuItem.Text = "Plik";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.directoryToolStripMenuItem.Text = "Folder";
            this.directoryToolStripMenuItem.Click += new System.EventHandler(this.directoryToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
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
            this.splitContainerMain.Size = new System.Drawing.Size(962, 544);
            this.splitContainerMain.SplitterDistance = 145;
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
            this.tabControlUse.Size = new System.Drawing.Size(962, 395);
            this.tabControlUse.TabIndex = 0;
            this.tabControlUse.SelectedIndexChanged += new System.EventHandler(this.OnTabControlUse_SelectedIndexChanged);
            // 
            // tabPageClasyfication
            // 
            this.tabPageClasyfication.Controls.Add(this.tableLayoutPanel2);
            this.tabPageClasyfication.Location = new System.Drawing.Point(4, 22);
            this.tabPageClasyfication.Name = "tabPageClasyfication";
            this.tabPageClasyfication.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClasyfication.Size = new System.Drawing.Size(954, 369);
            this.tabPageClasyfication.TabIndex = 1;
            this.tabPageClasyfication.Text = "Klasyfikacja";
            this.tabPageClasyfication.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.11392F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.88608F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(948, 363);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewClassificationResults);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 357);
            this.panel2.TabIndex = 6;
            // 
            // dataGridViewClassificationResults
            // 
            this.dataGridViewClassificationResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewClassificationResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassificationResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnCategory,
            this.Podgl¹d});
            this.dataGridViewClassificationResults.Location = new System.Drawing.Point(0, 8);
            this.dataGridViewClassificationResults.Name = "dataGridViewClassificationResults";
            this.dataGridViewClassificationResults.Size = new System.Drawing.Size(1423, 364);
            this.dataGridViewClassificationResults.TabIndex = 5;
            this.dataGridViewClassificationResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClassificationResults_CellClick);
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Nazwa";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 250;
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.HeaderText = "Kategoria";
            this.ColumnCategory.Name = "ColumnCategory";
            this.ColumnCategory.ReadOnly = true;
            this.ColumnCategory.Width = 200;
            // 
            // Podgl¹d
            // 
            this.Podgl¹d.HeaderText = "ColumnPath";
            this.Podgl¹d.Name = "Podgl¹d";
            this.Podgl¹d.ReadOnly = true;
            this.Podgl¹d.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Podgl¹d.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Podgl¹d.Width = 250;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Location = new System.Drawing.Point(752, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(193, 357);
            this.panel3.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.buttonClassificationStop, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonClassificationStart, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(180, 37);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // buttonClassificationStop
            // 
            this.buttonClassificationStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClassificationStop.Location = new System.Drawing.Point(3, 3);
            this.buttonClassificationStop.Name = "buttonClassificationStop";
            this.buttonClassificationStop.Size = new System.Drawing.Size(90, 31);
            this.buttonClassificationStop.TabIndex = 0;
            this.buttonClassificationStop.Text = "Stop";
            this.buttonClassificationStop.UseVisualStyleBackColor = true;
            this.buttonClassificationStop.Visible = false;
            this.buttonClassificationStop.Click += new System.EventHandler(this.buttonClassificationStop_Click);
            // 
            // buttonClassificationStart
            // 
            this.buttonClassificationStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClassificationStart.Location = new System.Drawing.Point(99, 3);
            this.buttonClassificationStart.Name = "buttonClassificationStart";
            this.buttonClassificationStart.Size = new System.Drawing.Size(78, 31);
            this.buttonClassificationStart.TabIndex = 1;
            this.buttonClassificationStart.Text = "Start";
            this.buttonClassificationStart.UseVisualStyleBackColor = true;
            this.buttonClassificationStart.Click += new System.EventHandler(this.buttonClassificationStart_Click);
            // 
            // tabPageLearning
            // 
            this.tabPageLearning.Controls.Add(this.tableLayoutPanel1);
            this.tabPageLearning.Location = new System.Drawing.Point(4, 22);
            this.tabPageLearning.Name = "tabPageLearning";
            this.tabPageLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLearning.Size = new System.Drawing.Size(954, 369);
            this.tabPageLearning.TabIndex = 0;
            this.tabPageLearning.Text = "Nauka";
            this.tabPageLearning.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.11F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.89F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxLearningParameters, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(948, 363);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxLearningParameters
            // 
            this.groupBoxLearningParameters.Controls.Add(this.labelValueNumbersOutNerons);
            this.groupBoxLearningParameters.Controls.Add(this.labelNameNumberOutNerons);
            this.groupBoxLearningParameters.Controls.Add(this.labelValuePathLearningDir);
            this.groupBoxLearningParameters.Controls.Add(this.labelNamePathLearningDir);
            this.groupBoxLearningParameters.Controls.Add(this.labelValueWordNumber);
            this.groupBoxLearningParameters.Controls.Add(this.labelValueNumbersHiddenNerons);
            this.groupBoxLearningParameters.Controls.Add(this.labelValueTestNumbersDocuments);
            this.groupBoxLearningParameters.Controls.Add(this.labelValueTestNumbersCategories);
            this.groupBoxLearningParameters.Controls.Add(this.labelValueAllNumbersParameters);
            this.groupBoxLearningParameters.Controls.Add(this.labelValueAllNumbersCategories);
            this.groupBoxLearningParameters.Controls.Add(this.labelNameNumbersHiddenNerons);
            this.groupBoxLearningParameters.Controls.Add(this.labelNameWordNumber);
            this.groupBoxLearningParameters.Controls.Add(this.labelNameTestNumbersCategories);
            this.groupBoxLearningParameters.Controls.Add(this.labelNameAllNumbersCategories);
            this.groupBoxLearningParameters.Controls.Add(this.labelNameTestNumbersDocuments);
            this.groupBoxLearningParameters.Controls.Add(this.labelNameAllNumbersParameters);
            this.groupBoxLearningParameters.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLearningParameters.Name = "groupBoxLearningParameters";
            this.groupBoxLearningParameters.Size = new System.Drawing.Size(743, 285);
            this.groupBoxLearningParameters.TabIndex = 2;
            this.groupBoxLearningParameters.TabStop = false;
            this.groupBoxLearningParameters.Text = "Parametry";
            // 
            // labelValueNumbersOutNerons
            // 
            this.labelValueNumbersOutNerons.AutoSize = true;
            this.labelValueNumbersOutNerons.Location = new System.Drawing.Point(222, 220);
            this.labelValueNumbersOutNerons.Name = "labelValueNumbersOutNerons";
            this.labelValueNumbersOutNerons.Size = new System.Drawing.Size(0, 13);
            this.labelValueNumbersOutNerons.TabIndex = 15;
            // 
            // labelNameNumberOutNerons
            // 
            this.labelNameNumberOutNerons.AutoSize = true;
            this.labelNameNumberOutNerons.Location = new System.Drawing.Point(17, 220);
            this.labelNameNumberOutNerons.Name = "labelNameNumberOutNerons";
            this.labelNameNumberOutNerons.Size = new System.Drawing.Size(153, 13);
            this.labelNameNumberOutNerons.TabIndex = 14;
            this.labelNameNumberOutNerons.Text = "Liczba neuronów wyjœciowych:";
            // 
            // labelValuePathLearningDir
            // 
            this.labelValuePathLearningDir.AutoSize = true;
            this.labelValuePathLearningDir.Location = new System.Drawing.Point(222, 253);
            this.labelValuePathLearningDir.Name = "labelValuePathLearningDir";
            this.labelValuePathLearningDir.Size = new System.Drawing.Size(0, 13);
            this.labelValuePathLearningDir.TabIndex = 13;
            // 
            // labelNamePathLearningDir
            // 
            this.labelNamePathLearningDir.AutoSize = true;
            this.labelNamePathLearningDir.Location = new System.Drawing.Point(17, 253);
            this.labelNamePathLearningDir.Name = "labelNamePathLearningDir";
            this.labelNamePathLearningDir.Size = new System.Drawing.Size(130, 13);
            this.labelNamePathLearningDir.TabIndex = 12;
            this.labelNamePathLearningDir.Text = "Folder z danymi ucz¹cymi:";
            // 
            // labelValueWordNumber
            // 
            this.labelValueWordNumber.AutoSize = true;
            this.labelValueWordNumber.Location = new System.Drawing.Point(222, 152);
            this.labelValueWordNumber.Name = "labelValueWordNumber";
            this.labelValueWordNumber.Size = new System.Drawing.Size(0, 13);
            this.labelValueWordNumber.TabIndex = 11;
            // 
            // labelValueNumbersHiddenNerons
            // 
            this.labelValueNumbersHiddenNerons.AutoSize = true;
            this.labelValueNumbersHiddenNerons.Location = new System.Drawing.Point(222, 184);
            this.labelValueNumbersHiddenNerons.Name = "labelValueNumbersHiddenNerons";
            this.labelValueNumbersHiddenNerons.Size = new System.Drawing.Size(0, 13);
            this.labelValueNumbersHiddenNerons.TabIndex = 10;
            // 
            // labelValueTestNumbersDocuments
            // 
            this.labelValueTestNumbersDocuments.AutoSize = true;
            this.labelValueTestNumbersDocuments.Location = new System.Drawing.Point(222, 118);
            this.labelValueTestNumbersDocuments.Name = "labelValueTestNumbersDocuments";
            this.labelValueTestNumbersDocuments.Size = new System.Drawing.Size(0, 13);
            this.labelValueTestNumbersDocuments.TabIndex = 9;
            // 
            // labelValueTestNumbersCategories
            // 
            this.labelValueTestNumbersCategories.AutoSize = true;
            this.labelValueTestNumbersCategories.Location = new System.Drawing.Point(222, 89);
            this.labelValueTestNumbersCategories.Name = "labelValueTestNumbersCategories";
            this.labelValueTestNumbersCategories.Size = new System.Drawing.Size(0, 13);
            this.labelValueTestNumbersCategories.TabIndex = 8;
            // 
            // labelValueAllNumbersParameters
            // 
            this.labelValueAllNumbersParameters.AutoSize = true;
            this.labelValueAllNumbersParameters.Location = new System.Drawing.Point(222, 61);
            this.labelValueAllNumbersParameters.Name = "labelValueAllNumbersParameters";
            this.labelValueAllNumbersParameters.Size = new System.Drawing.Size(0, 13);
            this.labelValueAllNumbersParameters.TabIndex = 7;
            // 
            // labelValueAllNumbersCategories
            // 
            this.labelValueAllNumbersCategories.AutoSize = true;
            this.labelValueAllNumbersCategories.Location = new System.Drawing.Point(222, 37);
            this.labelValueAllNumbersCategories.Name = "labelValueAllNumbersCategories";
            this.labelValueAllNumbersCategories.Size = new System.Drawing.Size(0, 13);
            this.labelValueAllNumbersCategories.TabIndex = 6;
            // 
            // labelNameNumbersHiddenNerons
            // 
            this.labelNameNumbersHiddenNerons.AutoSize = true;
            this.labelNameNumbersHiddenNerons.Location = new System.Drawing.Point(17, 184);
            this.labelNameNumbersHiddenNerons.Name = "labelNameNumbersHiddenNerons";
            this.labelNameNumbersHiddenNerons.Size = new System.Drawing.Size(180, 13);
            this.labelNameNumbersHiddenNerons.TabIndex = 5;
            this.labelNameNumbersHiddenNerons.Text = "Liczba neuronów w warstwie ukrytej:";
            // 
            // labelNameWordNumber
            // 
            this.labelNameWordNumber.AutoSize = true;
            this.labelNameWordNumber.Location = new System.Drawing.Point(17, 152);
            this.labelNameWordNumber.Name = "labelNameWordNumber";
            this.labelNameWordNumber.Size = new System.Drawing.Size(121, 13);
            this.labelNameWordNumber.TabIndex = 4;
            this.labelNameWordNumber.Text = "Liczba wszystkich s³ów:";
            // 
            // labelNameTestNumbersCategories
            // 
            this.labelNameTestNumbersCategories.AutoSize = true;
            this.labelNameTestNumbersCategories.Location = new System.Drawing.Point(17, 118);
            this.labelNameTestNumbersCategories.Name = "labelNameTestNumbersCategories";
            this.labelNameTestNumbersCategories.Size = new System.Drawing.Size(153, 13);
            this.labelNameTestNumbersCategories.TabIndex = 3;
            this.labelNameTestNumbersCategories.Text = "Liczba przekazanych kategorii:";
            // 
            // labelNameAllNumbersCategories
            // 
            this.labelNameAllNumbersCategories.AutoSize = true;
            this.labelNameAllNumbersCategories.Location = new System.Drawing.Point(17, 89);
            this.labelNameAllNumbersCategories.Name = "labelNameAllNumbersCategories";
            this.labelNameAllNumbersCategories.Size = new System.Drawing.Size(138, 13);
            this.labelNameAllNumbersCategories.TabIndex = 2;
            this.labelNameAllNumbersCategories.Text = "Liczba wszystkich kategorii:";
            // 
            // labelNameTestNumbersDocuments
            // 
            this.labelNameTestNumbersDocuments.AutoSize = true;
            this.labelNameTestNumbersDocuments.Location = new System.Drawing.Point(17, 61);
            this.labelNameTestNumbersDocuments.Name = "labelNameTestNumbersDocuments";
            this.labelNameTestNumbersDocuments.Size = new System.Drawing.Size(174, 13);
            this.labelNameTestNumbersDocuments.TabIndex = 1;
            this.labelNameTestNumbersDocuments.Text = "Liczba przekazanych dokumentów:";
            // 
            // labelNameAllNumbersParameters
            // 
            this.labelNameAllNumbersParameters.AutoSize = true;
            this.labelNameAllNumbersParameters.Location = new System.Drawing.Point(17, 37);
            this.labelNameAllNumbersParameters.Name = "labelNameAllNumbersParameters";
            this.labelNameAllNumbersParameters.Size = new System.Drawing.Size(153, 13);
            this.labelNameAllNumbersParameters.TabIndex = 0;
            this.labelNameAllNumbersParameters.Text = "Liczba wszystkich parametrów:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(752, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 357);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.buttonLearningStop1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonLearningStart1, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(180, 37);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // buttonLearningStop1
            // 
            this.buttonLearningStop1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLearningStop1.Location = new System.Drawing.Point(102, 3);
            this.buttonLearningStop1.Name = "buttonLearningStop1";
            this.buttonLearningStop1.Size = new System.Drawing.Size(75, 31);
            this.buttonLearningStop1.TabIndex = 0;
            this.buttonLearningStop1.Text = "Stop";
            this.buttonLearningStop1.UseVisualStyleBackColor = true;
            this.buttonLearningStop1.Visible = false;
            this.buttonLearningStop1.Click += new System.EventHandler(this.buttonLearningStop1_Click);
            // 
            // buttonLearningStart1
            // 
            this.buttonLearningStart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLearningStart1.Location = new System.Drawing.Point(3, 3);
            this.buttonLearningStart1.Name = "buttonLearningStart1";
            this.buttonLearningStart1.Size = new System.Drawing.Size(93, 31);
            this.buttonLearningStart1.TabIndex = 1;
            this.buttonLearningStart1.Text = "Start";
            this.buttonLearningStart1.UseVisualStyleBackColor = true;
            this.buttonLearningStart1.Click += new System.EventHandler(this.buttonLearningStart1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 546);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(962, 22);
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
            this.ClientSize = new System.Drawing.Size(962, 568);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "Klasyfikator dokumentów";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
            this.tabPageClasyfication.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassificationResults)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabPageLearning.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxLearningParameters.ResumeLayout(false);
            this.groupBoxLearningParameters.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
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
        private FileInput fileInput2;
        private RadioButtonDictionary radioButtonDictionaryFixed;
        private RadioButtonDictionary radioButtonDictionaryCtfIdf;
        private RadioButtonDictionary radioButtonDictionaryFrequance;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationBinary;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationOwn;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationTfIdf;
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
        private System.Windows.Forms.GroupBox groupBoxLearningParameters;
        private System.Windows.Forms.Label labelValueWordNumber;
        private System.Windows.Forms.Label labelValueNumbersHiddenNerons;
        private System.Windows.Forms.Label labelValueTestNumbersDocuments;
        private System.Windows.Forms.Label labelValueTestNumbersCategories;
        private System.Windows.Forms.Label labelValueAllNumbersParameters;
        private System.Windows.Forms.Label labelValueAllNumbersCategories;
        private System.Windows.Forms.Label labelNameNumbersHiddenNerons;
        private System.Windows.Forms.Label labelNameWordNumber;
        private System.Windows.Forms.Label labelNameTestNumbersCategories;
        private System.Windows.Forms.Label labelNameAllNumbersCategories;
        private System.Windows.Forms.Label labelNameTestNumbersDocuments;
        private System.Windows.Forms.Label labelNameAllNumbersParameters;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonLearningStart;
        private System.Windows.Forms.Button buttonLearningStop;
        private System.Windows.Forms.TabControl tabControlUse;
        private System.Windows.Forms.TabPage tabPageClasyfication;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewClassificationResults;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonClassificationStop;
        private System.Windows.Forms.Button buttonClassificationStart;
        private System.Windows.Forms.TabPage tabPageLearning;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button buttonLearningStop1;
        private System.Windows.Forms.Button buttonLearningStart1;
        private System.Windows.Forms.Label labelValuePathLearningDir;
        private System.Windows.Forms.Label labelNamePathLearningDir;
        private System.Windows.Forms.Label labelValueNumbersOutNerons;
        private System.Windows.Forms.Label labelNameNumberOutNerons;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory;
        private System.Windows.Forms.DataGridViewLinkColumn Podgl¹d;
    }
}

