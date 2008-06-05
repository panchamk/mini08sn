namespace DocClass.Src.GUI
{
    partial class PreprocessingForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelMain = new System.Windows.Forms.Label();
            this.progressBarPreprocessing = new System.Windows.Forms.ProgressBar();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.progressBarPreprocessing, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.labelMain, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonEnd, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(409, 99);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMain.Location = new System.Drawing.Point(3, 0);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(403, 39);
            this.labelMain.TabIndex = 1;
            this.labelMain.Text = "Wykonywana jest operacja preprocessingu słow, w której są usuwane przedrostki ora" +
                "z przedrostki.";
            this.labelMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMain.Click += new System.EventHandler(this.labelMain_Click);
            // 
            // progressBarPreprocessing
            // 
            this.progressBarPreprocessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarPreprocessing.Location = new System.Drawing.Point(3, 42);
            this.progressBarPreprocessing.Name = "progressBarPreprocessing";
            this.progressBarPreprocessing.Size = new System.Drawing.Size(403, 23);
            this.progressBarPreprocessing.TabIndex = 2;
            // 
            // buttonEnd
            // 
            this.buttonEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonEnd.Location = new System.Drawing.Point(167, 71);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(75, 25);
            this.buttonEnd.TabIndex = 3;
            this.buttonEnd.Text = "Zakończ";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // PreprocessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 99);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreprocessingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analizowanie danych";
            this.Load += new System.EventHandler(this.PreprocessingForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreprocessingForm_FormClosed);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.ProgressBar progressBarPreprocessing;
        private System.Windows.Forms.Button buttonEnd;
    }
}