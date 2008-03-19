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
            this.radioButtonNeuralMethode = new System.Windows.Forms.RadioButton();
            this.radioButtonBayesMethode = new System.Windows.Forms.RadioButton();
            this.groupBoxDictionary = new System.Windows.Forms.GroupBox();
            this.radioButtonCtfidfDictionary = new System.Windows.Forms.RadioButton();
            this.radioButtonOwnDictionary = new System.Windows.Forms.RadioButton();
            this.radioButtonMostFrequanceDictionary = new System.Windows.Forms.RadioButton();
            this.groupBoxDocumentRepresentation = new System.Windows.Forms.GroupBox();
            this.radioButtonTfRepresentation = new System.Windows.Forms.RadioButton();
            this.radioButtonTfidfRepresentation = new System.Windows.Forms.RadioButton();
            this.radioButtonBinaryRepresentation = new System.Windows.Forms.RadioButton();
            this.tabControlUse = new System.Windows.Forms.TabControl();
            this.tabPageLearning = new System.Windows.Forms.TabPage();
            this.tabPageClasyfication = new System.Windows.Forms.TabPage();
            this.splitContainerLearning = new System.Windows.Forms.SplitContainer();
            this.groupBoxLearningFile = new System.Windows.Forms.GroupBox();
            this.groupBoxLearningParameters = new System.Windows.Forms.GroupBox();
            this.labelLearningResults = new System.Windows.Forms.Label();
            this.fileInput1 = new DocClass.FileInput();
            this.splitContainerClasification = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.fileInput2 = new DocClass.FileInput();
            this.groupBoxClasificationFile = new System.Windows.Forms.GroupBox();
            this.fileInput3 = new DocClass.FileInput();
            this.groupBoxClasificationParameters = new System.Windows.Forms.GroupBox();
            this.labeClasificationResults = new System.Windows.Forms.Label();
            this.menuStripMain.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBoxClasificationMethode.SuspendLayout();
            this.groupBoxDictionary.SuspendLayout();
            this.groupBoxDocumentRepresentation.SuspendLayout();
            this.tabControlUse.SuspendLayout();
            this.tabPageLearning.SuspendLayout();
            this.tabPageClasyfication.SuspendLayout();
            this.splitContainerLearning.Panel1.SuspendLayout();
            this.splitContainerLearning.Panel2.SuspendLayout();
            this.splitContainerLearning.SuspendLayout();
            this.groupBoxLearningFile.SuspendLayout();
            this.splitContainerClasification.Panel1.SuspendLayout();
            this.splitContainerClasification.Panel2.SuspendLayout();
            this.splitContainerClasification.SuspendLayout();
            this.groupBoxClasificationFile.SuspendLayout();
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
            this.groupBoxClasificationMethode.Controls.Add(this.radioButtonNeuralMethode);
            this.groupBoxClasificationMethode.Controls.Add(this.radioButtonBayesMethode);
            this.groupBoxClasificationMethode.Location = new System.Drawing.Point(496, 15);
            this.groupBoxClasificationMethode.Name = "groupBoxClasificationMethode";
            this.groupBoxClasificationMethode.Size = new System.Drawing.Size(203, 100);
            this.groupBoxClasificationMethode.TabIndex = 2;
            this.groupBoxClasificationMethode.TabStop = false;
            this.groupBoxClasificationMethode.Text = "Metoda klasyfikacji";
            // 
            // radioButtonNeuralMethode
            // 
            this.radioButtonNeuralMethode.AutoSize = true;
            this.radioButtonNeuralMethode.Location = new System.Drawing.Point(7, 44);
            this.radioButtonNeuralMethode.Name = "radioButtonNeuralMethode";
            this.radioButtonNeuralMethode.Size = new System.Drawing.Size(86, 17);
            this.radioButtonNeuralMethode.TabIndex = 1;
            this.radioButtonNeuralMethode.TabStop = true;
            this.radioButtonNeuralMethode.Text = "Sieæ radialna";
            this.radioButtonNeuralMethode.UseVisualStyleBackColor = true;
            // 
            // radioButtonBayesMethode
            // 
            this.radioButtonBayesMethode.AutoSize = true;
            this.radioButtonBayesMethode.Location = new System.Drawing.Point(7, 20);
            this.radioButtonBayesMethode.Name = "radioButtonBayesMethode";
            this.radioButtonBayesMethode.Size = new System.Drawing.Size(138, 17);
            this.radioButtonBayesMethode.TabIndex = 0;
            this.radioButtonBayesMethode.TabStop = true;
            this.radioButtonBayesMethode.Text = "Klasyfikator Bayesowski";
            this.radioButtonBayesMethode.UseVisualStyleBackColor = true;
            this.radioButtonBayesMethode.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // groupBoxDictionary
            // 
            this.groupBoxDictionary.Controls.Add(this.radioButtonCtfidfDictionary);
            this.groupBoxDictionary.Controls.Add(this.radioButtonOwnDictionary);
            this.groupBoxDictionary.Controls.Add(this.radioButtonMostFrequanceDictionary);
            this.groupBoxDictionary.Location = new System.Drawing.Point(232, 15);
            this.groupBoxDictionary.Name = "groupBoxDictionary";
            this.groupBoxDictionary.Size = new System.Drawing.Size(232, 100);
            this.groupBoxDictionary.TabIndex = 1;
            this.groupBoxDictionary.TabStop = false;
            this.groupBoxDictionary.Text = "Dobieranie s³ów do s³ownika";
            // 
            // radioButtonCtfidfDictionary
            // 
            this.radioButtonCtfidfDictionary.AutoSize = true;
            this.radioButtonCtfidfDictionary.Location = new System.Drawing.Point(20, 77);
            this.radioButtonCtfidfDictionary.Name = "radioButtonCtfidfDictionary";
            this.radioButtonCtfidfDictionary.Size = new System.Drawing.Size(65, 17);
            this.radioButtonCtfidfDictionary.TabIndex = 2;
            this.radioButtonCtfidfDictionary.TabStop = true;
            this.radioButtonCtfidfDictionary.Text = "CTF-IDF";
            this.radioButtonCtfidfDictionary.UseVisualStyleBackColor = true;
            // 
            // radioButtonOwnDictionary
            // 
            this.radioButtonOwnDictionary.AutoSize = true;
            this.radioButtonOwnDictionary.Location = new System.Drawing.Point(20, 44);
            this.radioButtonOwnDictionary.Name = "radioButtonOwnDictionary";
            this.radioButtonOwnDictionary.Size = new System.Drawing.Size(63, 17);
            this.radioButtonOwnDictionary.TabIndex = 1;
            this.radioButtonOwnDictionary.TabStop = true;
            this.radioButtonOwnDictionary.Text = "W³asna";
            this.radioButtonOwnDictionary.UseVisualStyleBackColor = true;
            // 
            // radioButtonMostFrequanceDictionary
            // 
            this.radioButtonMostFrequanceDictionary.AutoSize = true;
            this.radioButtonMostFrequanceDictionary.Location = new System.Drawing.Point(20, 20);
            this.radioButtonMostFrequanceDictionary.Name = "radioButtonMostFrequanceDictionary";
            this.radioButtonMostFrequanceDictionary.Size = new System.Drawing.Size(141, 17);
            this.radioButtonMostFrequanceDictionary.TabIndex = 0;
            this.radioButtonMostFrequanceDictionary.TabStop = true;
            this.radioButtonMostFrequanceDictionary.Text = "Najczêœciej wystêpuj¹ce";
            this.radioButtonMostFrequanceDictionary.UseVisualStyleBackColor = true;
            // 
            // groupBoxDocumentRepresentation
            // 
            this.groupBoxDocumentRepresentation.Controls.Add(this.radioButtonTfRepresentation);
            this.groupBoxDocumentRepresentation.Controls.Add(this.radioButtonTfidfRepresentation);
            this.groupBoxDocumentRepresentation.Controls.Add(this.radioButtonBinaryRepresentation);
            this.groupBoxDocumentRepresentation.Location = new System.Drawing.Point(12, 15);
            this.groupBoxDocumentRepresentation.Name = "groupBoxDocumentRepresentation";
            this.groupBoxDocumentRepresentation.Size = new System.Drawing.Size(200, 100);
            this.groupBoxDocumentRepresentation.TabIndex = 0;
            this.groupBoxDocumentRepresentation.TabStop = false;
            this.groupBoxDocumentRepresentation.Text = "Reprezentacja dokumentu";
            this.groupBoxDocumentRepresentation.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButtonTfRepresentation
            // 
            this.radioButtonTfRepresentation.AutoSize = true;
            this.radioButtonTfRepresentation.Location = new System.Drawing.Point(16, 68);
            this.radioButtonTfRepresentation.Name = "radioButtonTfRepresentation";
            this.radioButtonTfRepresentation.Size = new System.Drawing.Size(38, 17);
            this.radioButtonTfRepresentation.TabIndex = 2;
            this.radioButtonTfRepresentation.TabStop = true;
            this.radioButtonTfRepresentation.Text = "TF";
            this.radioButtonTfRepresentation.UseVisualStyleBackColor = true;
            // 
            // radioButtonTfidfRepresentation
            // 
            this.radioButtonTfidfRepresentation.AutoSize = true;
            this.radioButtonTfidfRepresentation.Location = new System.Drawing.Point(16, 44);
            this.radioButtonTfidfRepresentation.Name = "radioButtonTfidfRepresentation";
            this.radioButtonTfidfRepresentation.Size = new System.Drawing.Size(58, 17);
            this.radioButtonTfidfRepresentation.TabIndex = 1;
            this.radioButtonTfidfRepresentation.TabStop = true;
            this.radioButtonTfidfRepresentation.Text = "TF-IDF";
            this.radioButtonTfidfRepresentation.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinaryRepresentation
            // 
            this.radioButtonBinaryRepresentation.AutoSize = true;
            this.radioButtonBinaryRepresentation.Location = new System.Drawing.Point(16, 20);
            this.radioButtonBinaryRepresentation.Name = "radioButtonBinaryRepresentation";
            this.radioButtonBinaryRepresentation.Size = new System.Drawing.Size(61, 17);
            this.radioButtonBinaryRepresentation.TabIndex = 0;
            this.radioButtonBinaryRepresentation.TabStop = true;
            this.radioButtonBinaryRepresentation.Text = "Binarna";
            this.radioButtonBinaryRepresentation.UseVisualStyleBackColor = true;
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
            // splitContainerLearning
            // 
            this.splitContainerLearning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLearning.Location = new System.Drawing.Point(3, 3);
            this.splitContainerLearning.Name = "splitContainerLearning";
            this.splitContainerLearning.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLearning.Panel1
            // 
            this.splitContainerLearning.Panel1.Controls.Add(this.groupBoxLearningParameters);
            this.splitContainerLearning.Panel1.Controls.Add(this.groupBoxLearningFile);
            // 
            // 
            // 
            this.splitContainerLearning.Panel2.Controls.Add(this.labelLearningResults);
            this.splitContainerLearning.Panel2.Controls.Add(this.label1);
            this.splitContainerLearning.Size = new System.Drawing.Size(721, 285);
            this.splitContainerLearning.SplitterDistance = 70;
            this.splitContainerLearning.TabIndex = 0;
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
            this.groupBoxLearningFile.Enter += new System.EventHandler(this.groupBoxFile_Enter);
            // 
            // groupBoxLearningParameters
            // 
            this.groupBoxLearningParameters.Location = new System.Drawing.Point(379, 4);
            this.groupBoxLearningParameters.Name = "groupBoxLearningParameters";
            this.groupBoxLearningParameters.Size = new System.Drawing.Size(255, 63);
            this.groupBoxLearningParameters.TabIndex = 1;
            this.groupBoxLearningParameters.TabStop = false;
            this.groupBoxLearningParameters.Text = "Parametry";
            // 
            // labelLearningResults
            // 
            this.labelLearningResults.AutoSize = true;
            this.labelLearningResults.Location = new System.Drawing.Point(20, 10);
            this.labelLearningResults.Name = "labelLearningResults";
            this.labelLearningResults.Size = new System.Drawing.Size(39, 13);
            this.labelLearningResults.TabIndex = 0;
            this.labelLearningResults.Text = "Wyniki";
            // 
            // fileInput1
            // 
            this.fileInput1.Location = new System.Drawing.Point(-20, 19);
            this.fileInput1.Name = "fileInput1";
            this.fileInput1.Size = new System.Drawing.Size(357, 27);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wyniki";
            // 
            // fileInput2
            // 
            this.fileInput2.Location = new System.Drawing.Point(-16, 19);
            this.fileInput2.Name = "fileInput2";
            this.fileInput2.Size = new System.Drawing.Size(357, 27);
            this.fileInput2.TabIndex = 0;
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
            this.groupBoxClasificationFile.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // fileInput3
            // 
            this.fileInput3.Location = new System.Drawing.Point(-8, 19);
            this.fileInput3.Name = "fileInput3";
            this.fileInput3.Size = new System.Drawing.Size(357, 27);
            this.fileInput3.TabIndex = 0;
            // 
            // groupBoxClasificationParameters
            // 
            this.groupBoxClasificationParameters.Location = new System.Drawing.Point(361, 4);
            this.groupBoxClasificationParameters.Name = "groupBoxClasificationParameters";
            this.groupBoxClasificationParameters.Size = new System.Drawing.Size(273, 63);
            this.groupBoxClasificationParameters.TabIndex = 1;
            this.groupBoxClasificationParameters.TabStop = false;
            this.groupBoxClasificationParameters.Text = "Parametry";
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
            this.tabPageClasyfication.ResumeLayout(false);
            this.splitContainerLearning.Panel1.ResumeLayout(false);
            this.splitContainerLearning.Panel2.ResumeLayout(false);
            this.splitContainerLearning.Panel2.PerformLayout();
            this.splitContainerLearning.ResumeLayout(false);
            this.groupBoxLearningFile.ResumeLayout(false);
            this.splitContainerClasification.Panel1.ResumeLayout(false);
            this.splitContainerClasification.Panel2.ResumeLayout(false);
            this.splitContainerClasification.Panel2.PerformLayout();
            this.splitContainerClasification.ResumeLayout(false);
            this.groupBoxClasificationFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBoxClasificationMethode;
        private System.Windows.Forms.GroupBox groupBoxDictionary;
        private System.Windows.Forms.GroupBox groupBoxDocumentRepresentation;
        private System.Windows.Forms.RadioButton radioButtonTfRepresentation;
        private System.Windows.Forms.RadioButton radioButtonTfidfRepresentation;
        private System.Windows.Forms.RadioButton radioButtonBinaryRepresentation;
        private System.Windows.Forms.RadioButton radioButtonBayesMethode;
        private System.Windows.Forms.RadioButton radioButtonCtfidfDictionary;
        private System.Windows.Forms.RadioButton radioButtonOwnDictionary;
        private System.Windows.Forms.RadioButton radioButtonMostFrequanceDictionary;
        private System.Windows.Forms.RadioButton radioButtonNeuralMethode;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainerClasification;
        private System.Windows.Forms.GroupBox groupBoxClasificationFile;
        private FileInput fileInput2;
        private System.Windows.Forms.GroupBox groupBoxClasificationParameters;
        private FileInput fileInput3;
        private System.Windows.Forms.Label labeClasificationResults;
    }
}

