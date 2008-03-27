using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DocClass.Src.Preprocessing
{
    public partial class PreprocessingTestForm : Form
    {
        public PreprocessingTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo("proba1.stm");
            
            MessageBox.Show(fi.FullName.Substring(0,fi.FullName.LastIndexOf('.')));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<int, String> stopWords = FileConverter.LoadStopWords("PreprocessingTest\\stopwords\\stopwords.txt");

            DirectoryInfo sourceDir = new DirectoryInfo("PreprocessingTest");
            DirectoryInfo destDir = Directory.CreateDirectory(sourceDir.FullName + "\\stem");
            String destFile;
            DateTime startTime = DateTime.Now;
            foreach (FileInfo sourceFile in sourceDir.GetFiles())
            {
                Console.WriteLine("Processing file: " + sourceFile);
                destFile = sourceFile.Name + ".stm";
                FileConverter.StemFile(sourceFile.FullName,destDir.FullName + "\\" + destFile, stopWords);
            }
            MessageBox.Show("All done in:" + (DateTime.Now.Subtract(startTime)).ToString() );
        }
    }
}