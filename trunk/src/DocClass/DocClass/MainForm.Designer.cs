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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBoxClasificationMethode = new System.Windows.Forms.GroupBox();
            this.groupBoxDictionary = new System.Windows.Forms.GroupBox();
            this.groupBoxDocumentRepresentation = new System.Windows.Forms.GroupBox();
            this.tabControlUse = new System.Windows.Forms.TabControl();
            this.tabPageLearning = new System.Windows.Forms.TabPage();
            this.splitContainerLearning = new System.Windows.Forms.SplitContainer();
            this.groupBoxLearningParameters = new System.Windows.Forms.GroupBox();
            this.groupBoxLearningFile = new System.Windows.Forms.GroupBox();
            this.labelLearningResults = new System.Windows.Forms.Label();
            this.tabPageClasyfication = new System.Windows.Forms.TabPage();
            this.splitContainerClasification = new System.Windows.Forms.SplitContainer();
            this.groupBoxClasificationParameters = new System.Windows.Forms.GroupBox();
            this.groupBoxClasificationFile = new System.Windows.Forms.GroupBox();
            this.labeClasificationResults = new System.Windows.Forms.Label();
            this.radioButtonClassificationRadialNeural = new DocClass.RadioButtonClassification();
            this.radioButtonClassificationBayes = new DocClass.RadioButtonClassification();
            this.radioButtonDictionaryFrequance = new DocClass.RadioButtonDictionary();
            this.radioButtonDictionaryFixed = new DocClass.RadioButtonDictionary();
            this.radioButtonDictionaryCtfIdf = new DocClass.RadioButtonDictionary();
            this.radioButtonDocumentRepresentationBinary = new DocClass.RadioButtonDocumentRepresentation();
            this.radioButtonDocumentRepresentationOwn = new DocClass.RadioButtonDocumentRepresentation();
            this.radioButtonDocumentRepresentationTfIdf = new DocClass.RadioButtonDocumentRepresentation();
            this.fileInput1 = new DocClass.FileInput();
            this.fileInput3 = new DocClass.FileInput();
            this.fileInput2 = new DocClass.FileInput();
            this.groupBoxLearningActions = new System.Windows.Forms.GroupBox();
            this.groupBoxClassificationAction = new System.Windows.Forms.GroupBox();
            this.buttonClassificationStart = new System.Windows.Forms.Button();
            this.buttonClassificationStop = new System.Windows.Forms.Button();
            this.buttonLearningStart = new System.Windows.Forms.Button();
            this.buttonLearningStop = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxClasificationMethode.SuspendLayout();
            this.groupBoxDictionary.SuspendLayout();
            this.groupBoxDocumentRepresentation.SuspendLayout();
            this.tabControlUse.SuspendLayout();
            this.tabPageLearning.SuspendLayout();
            this.splitContainerLearning.Panel1.SuspendLayout();
            this.splitContainerLearning.Panel2.SuspendLayout();
            this.splitContainerLearning.SuspendLayout();
            this.groupBoxLearningFile.SuspendLayout();
            this.tabPageClasyfication.SuspendLayout();
            this.splitContainerClasification.Panel1.SuspendLayout();
            this.splitContainerClasification.Panel2.SuspendLayout();
            this.splitContainerClasification.SuspendLayout();
            this.groupBoxClasificationFile.SuspendLayout();
            this.groupBoxLearningActions.SuspendLayout();
            this.groupBoxClassificationAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItemProgram});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(735, 24);
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxClasificationMethode);
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxDictionary);
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxDocumentRepresentation);
            this.splitContainerMain.Panel1MinSize = 10;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlUse);
            this.splitContainerMain.Size = new System.Drawing.Size(735, 439);
            this.splitContainerMain.SplitterDistance = 118;
            this.splitContainerMain.TabIndex = 2;
            // 
            // groupBoxClasificationMethode
            // 
            this.groupBoxClasificationMethode.Controls.Add(this.radioButtonClassificationRadialNeural);
            this.groupBoxClasificationMethode.Controls.Add(this.radioButtonClassificationBayes);
            this.groupBoxClasificationMethode.Location = new System.Drawing.Point(496, 15);
            this.groupBoxClasificationMethode.Name = "groupBoxClasificationMethode";
            this.groupBoxClasificationMethode.Size = new System.Drawing.Size(203, 100);
            this.groupBoxClasificationMethode.TabIndex = 2;
            this.groupBoxClasificationMethode.TabStop = false;
            this.groupBoxClasificationMethode.Text = "Metoda klasyfikacji";
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
            this.tabControlUse.Size = new System.Drawing.Size(735, 317);
            this.tabControlUse.TabIndex = 0;
            // 
            // tabPageLearning
            // 
            this.tabPageLearning.Controls.Add(this.splitContainerLearning);
            this.tabPageLearning.Location = new System.Drawing.Point(4, 22);
            this.tabPageLearning.Name = "tabPageLearning";
            this.tabPageLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLearning.Size = new System.Drawing.Size(727, 291);
            this.tabPageLearning.TabIndex = 0;
            this.tabPageLearning.Text = "Nauka";
            this.tabPageLearning.UseVisualStyleBackColor = true;
            // 
            // splitContainerLearning
            // 
            this.splitContainerLearning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLearning.Location = new System.Drawing.Point(3, 3);
            this.splitContainerLearning.Name = "splitContainerLearning";
            this.splitContainerLearning.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLearning.Panel1
            // 
            this.splitContainerLearning.Panel1.Controls.Add(this.groupBoxLearningActions);
            this.splitContainerLearning.Panel1.Controls.Add(this.groupBoxLearningParameters);
            this.splitContainerLearning.Panel1.Controls.Add(this.groupBoxLearningFile);
            // 
            // splitContainerLearning.Panel2
            // 
            this.splitContainerLearning.Panel2.Controls.Add(this.labelLearningResults);
            this.splitContainerLearning.Size = new System.Drawing.Size(721, 285);
            this.splitContainerLearning.SplitterDistance = 70;
            this.splitContainerLearning.TabIndex = 0;
            // 
            // groupBoxLearningParameters
            // 
            this.groupBoxLearningParameters.Location = new System.Drawing.Point(379, 4);
            this.groupBoxLearningParameters.Name = "groupBoxLearningParameters";
            this.groupBoxLearningParameters.Size = new System.Drawing.Size(169, 63);
            this.groupBoxLearningParameters.TabIndex = 1;
            this.groupBoxLearningParameters.TabStop = false;
            this.groupBoxLearningParameters.Text = "Parametry";
            // 
            // groupBoxLearningFile
            // 
            this.groupBoxLearningFile.Controls.Add(this.fileInput1);
            this.groupBoxLearningFile.Location = new System.Drawing.Point(21, 3);
            this.groupBoxLearningFile.Name = "groupBoxLearningFile";
            this.groupBoxLearningFile.Size = new System.Drawing.Size(337, 64);
            this.groupBoxLearningFile.TabIndex = 0;
            this.groupBoxLearningFile.TabStop = false;
            this.groupBoxLearningFile.Text = "Plik";
            // 
            // labelLearningResults
            // 
            this.labelLearningResults.AutoSize = true;
            this.labelLearningResults.Location = new System.Drawing.Point(18, 0);
            this.labelLearningResults.Name = "labelLearningResults";
            this.labelLearningResults.Size = new System.Drawing.Size(39, 13);
            this.labelLearningResults.TabIndex = 0;
            this.labelLearningResults.Text = "Wyniki";
            // 
            // tabPageClasyfication
            // 
            this.tabPageClasyfication.Controls.Add(this.splitContainerClasification);
            this.tabPageClasyfication.Location = new System.Drawing.Point(4, 22);
            this.tabPageClasyfication.Name = "tabPageClasyfication";
            this.tabPageClasyfication.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClasyfication.Size = new System.Drawing.Size(727, 291);
            this.tabPageClasyfication.TabIndex = 1;
            this.tabPageClasyfication.Text = "Klasyfikacja";
            this.tabPageClasyfication.UseVisualStyleBackColor = true;
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
            this.splitContainerClasification.Panel1.Controls.Add(this.groupBoxClassificationAction);
            this.splitContainerClasification.Panel1.Controls.Add(this.groupBoxClasificationParameters);
            this.splitContainerClasification.Panel1.Controls.Add(this.groupBoxClasificationFile);
            // 
            // splitContainerClasification.Panel2
            // 
            this.splitContainerClasification.Panel2.Controls.Add(this.labeClasificationResults);
            this.splitContainerClasification.Size = new System.Drawing.Size(721, 285);
            this.splitContainerClasification.SplitterDistance = 70;
            this.splitContainerClasification.TabIndex = 0;
            // 
            // groupBoxClasificationParameters
            // 
            this.groupBoxClasificationParameters.Location = new System.Drawing.Point(361, 4);
            this.groupBoxClasificationParameters.Name = "groupBoxClasificationParameters";
            this.groupBoxClasificationParameters.Size = new System.Drawing.Size(180, 63);
            this.groupBoxClasificationParameters.TabIndex = 1;
            this.groupBoxClasificationParameters.TabStop = false;
            this.groupBoxClasificationParameters.Text = "Parametry";
            // 
            // groupBoxClasificationFile
            // 
            this.groupBoxClasificationFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxClasificationFile.Controls.Add(this.fileInput3);
            this.groupBoxClasificationFile.Location = new System.Drawing.Point(5, 3);
            this.groupBoxClasificationFile.Name = "groupBoxClasificationFile";
            this.groupBoxClasificationFile.Size = new System.Drawing.Size(348, 64);
            this.groupBoxClasificationFile.TabIndex = 0;
            this.groupBoxClasificationFile.TabStop = false;
            this.groupBoxClasificationFile.Text = "Plik";
            // 
            // labeClasificationResults
            // 
            this.labeClasificationResults.AutoSize = true;
            this.labeClasificationResults.Location = new System.Drawing.Point(5, 0);
            this.labeClasificationResults.Name = "labeClasificationResults";
            this.labeClasificationResults.Size = new System.Drawing.Size(39, 13);
            this.labeClasificationResults.TabIndex = 0;
            this.labeClasificationResults.Text = "Wyniki";
            // 
            // radioButtonClassificationRadialNeural
            // 
            this.radioButtonClassificationRadialNeural.AutoSize = true;
            this.radioButtonClassificationRadialNeural.ClassificationType = DocClass.Src.Classification.ClasyficatorType.RadialNeural;
            this.radioButtonClassificationRadialNeural.Location = new System.Drawing.Point(24, 67);
            this.radioButtonClassificationRadialNeural.Name = "radioButtonClassificationRadialNeural";
            this.radioButtonClassificationRadialNeural.Size = new System.Drawing.Size(86, 17);
            this.radioButtonClassificationRadialNeural.TabIndex = 1;
            this.radioButtonClassificationRadialNeural.Text = "RadialNeural";
            this.radioButtonClassificationRadialNeural.UseVisualStyleBackColor = true;
            // 
            // radioButtonClassificationBayes
            // 
            this.radioButtonClassificationBayes.AutoSize = true;
            this.radioButtonClassificationBayes.Checked = true;
            this.radioButtonClassificationBayes.ClassificationType = DocClass.Src.Classification.ClasyficatorType.Bayes;
            this.radioButtonClassificationBayes.Location = new System.Drawing.Point(24, 31);
            this.radioButtonClassificationBayes.Name = "radioButtonClassificationBayes";
            this.radioButtonClassificationBayes.Size = new System.Drawing.Size(54, 17);
            this.radioButtonClassificationBayes.TabIndex = 0;
            this.radioButtonClassificationBayes.TabStop = true;
            this.radioButtonClassificationBayes.Text = "Bayes";
            this.radioButtonClassificationBayes.UseVisualStyleBackColor = true;
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
            this.radioButtonDictionaryFixed.Text = "Fixed";
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
            this.radioButtonDictionaryCtfIdf.Text = "CtfIdf";
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
            this.fileInput1.Location = new System.Drawing.Point(-20, 19);
            this.fileInput1.Name = "fileInput1";
            this.fileInput1.Size = new System.Drawing.Size(357, 27);
            this.fileInput1.TabIndex = 0;
            // 
            // fileInput3
            // 
            this.fileInput3.Location = new System.Drawing.Point(-8, 19);
            this.fileInput3.Name = "fileInput3";
            this.fileInput3.Size = new System.Drawing.Size(357, 27);
            this.fileInput3.TabIndex = 0;
            // 
            // fileInput2
            // 
            this.fileInput2.Location = new System.Drawing.Point(-16, 19);
            this.fileInput2.Name = "fileInput2";
            this.fileInput2.Size = new System.Drawing.Size(357, 27);
            this.fileInput2.TabIndex = 0;
            // 
            // groupBoxLearningActions
            // 
            this.groupBoxLearningActions.Controls.Add(this.buttonLearningStop);
            this.groupBoxLearningActions.Controls.Add(this.buttonLearningStart);
            this.groupBoxLearningActions.Location = new System.Drawing.Point(554, 4);
            this.groupBoxLearningActions.Name = "groupBoxLearningActions";
            this.groupBoxLearningActions.Size = new System.Drawing.Size(164, 63);
            this.groupBoxLearningActions.TabIndex = 2;
            this.groupBoxLearningActions.TabStop = false;
            this.groupBoxLearningActions.Text = "Akcje";
            // 
            // groupBoxClassificationAction
            // 
            this.groupBoxClassificationAction.Controls.Add(this.buttonClassificationStop);
            this.groupBoxClassificationAction.Controls.Add(this.buttonClassificationStart);
            this.groupBoxClassificationAction.Location = new System.Drawing.Point(547, 4);
            this.groupBoxClassificationAction.Name = "groupBoxClassificationAction";
            this.groupBoxClassificationAction.Size = new System.Drawing.Size(169, 63);
            this.groupBoxClassificationAction.TabIndex = 2;
            this.groupBoxClassificationAction.TabStop = false;
            this.groupBoxClassificationAction.Text = "Akcje";
            // 
            // buttonClassificationStart
            // 
            this.buttonClassificationStart.Location = new System.Drawing.Point(7, 18);
            this.buttonClassificationStart.Name = "buttonClassificationStart";
            this.buttonClassificationStart.Size = new System.Drawing.Size(75, 23);
            this.buttonClassificationStart.TabIndex = 0;
            this.buttonClassificationStart.Text = "Start";
            this.buttonClassificationStart.UseVisualStyleBackColor = true;
            // 
            // buttonClassificationStop
            // 
            this.buttonClassificationStop.Location = new System.Drawing.Point(88, 18);
            this.buttonClassificationStop.Name = "buttonClassificationStop";
            this.buttonClassificationStop.Size = new System.Drawing.Size(75, 23);
            this.buttonClassificationStop.TabIndex = 1;
            this.buttonClassificationStop.Text = "Stop";
            this.buttonClassificationStop.UseVisualStyleBackColor = true;
            // 
            // buttonLearningStart
            // 
            this.buttonLearningStart.Location = new System.Drawing.Point(0, 20);
            this.buttonLearningStart.Name = "buttonLearningStart";
            this.buttonLearningStart.Size = new System.Drawing.Size(75, 23);
            this.buttonLearningStart.TabIndex = 0;
            this.buttonLearningStart.Text = "Start";
            this.buttonLearningStart.UseVisualStyleBackColor = true;
            // 
            // buttonLearningStop
            // 
            this.buttonLearningStop.Location = new System.Drawing.Point(81, 18);
            this.buttonLearningStop.Name = "buttonLearningStop";
            this.buttonLearningStop.Size = new System.Drawing.Size(75, 23);
            this.buttonLearningStop.TabIndex = 1;
            this.buttonLearningStop.Text = "Stop";
            this.buttonLearningStop.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 463);
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
            this.groupBoxClasificationMethode.ResumeLayout(false);
            this.groupBoxClasificationMethode.PerformLayout();
            this.groupBoxDictionary.ResumeLayout(false);
            this.groupBoxDictionary.PerformLayout();
            this.groupBoxDocumentRepresentation.ResumeLayout(false);
            this.groupBoxDocumentRepresentation.PerformLayout();
            this.tabControlUse.ResumeLayout(false);
            this.tabPageLearning.ResumeLayout(false);
            this.splitContainerLearning.Panel1.ResumeLayout(false);
            this.splitContainerLearning.Panel2.ResumeLayout(false);
            this.splitContainerLearning.Panel2.PerformLayout();
            this.splitContainerLearning.ResumeLayout(false);
            this.groupBoxLearningFile.ResumeLayout(false);
            this.tabPageClasyfication.ResumeLayout(false);
            this.splitContainerClasification.Panel1.ResumeLayout(false);
            this.splitContainerClasification.Panel2.ResumeLayout(false);
            this.splitContainerClasification.Panel2.PerformLayout();
            this.splitContainerClasification.ResumeLayout(false);
            this.groupBoxClasificationFile.ResumeLayout(false);
            this.groupBoxLearningActions.ResumeLayout(false);
            this.groupBoxClassificationAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBoxClasificationMethode;
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
        private System.Windows.Forms.Label labelLearningResults;
        private FileInput fileInput1;
        private System.Windows.Forms.SplitContainer splitContainerClasification;
        private System.Windows.Forms.GroupBox groupBoxClasificationFile;
        private FileInput fileInput2;
        private System.Windows.Forms.GroupBox groupBoxClasificationParameters;
        private FileInput fileInput3;
        private System.Windows.Forms.Label labeClasificationResults;
        private RadioButtonDictionary radioButtonDictionaryFixed;
        private RadioButtonDictionary radioButtonDictionaryCtfIdf;
        private RadioButtonDictionary radioButtonDictionaryFrequance;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationBinary;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationOwn;
        private RadioButtonDocumentRepresentation radioButtonDocumentRepresentationTfIdf;
        private RadioButtonClassification radioButtonClassificationRadialNeural;
        private RadioButtonClassification radioButtonClassificationBayes;
        private System.Windows.Forms.GroupBox groupBoxLearningActions;
        private System.Windows.Forms.Button buttonLearningStop;
        private System.Windows.Forms.Button buttonLearningStart;
        private System.Windows.Forms.GroupBox groupBoxClassificationAction;
        private System.Windows.Forms.Button buttonClassificationStop;
        private System.Windows.Forms.Button buttonClassificationStart;
    }
}

