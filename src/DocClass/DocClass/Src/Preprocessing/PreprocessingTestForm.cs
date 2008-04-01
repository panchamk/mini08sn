using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DocClass.Src.Dictionaries;

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
            Dictionary<int, String> stopWords = PreprocessingUtility.LoadStopWords("PreprocessingTest\\stopwords\\stopwords.txt");
            DateTime startTime = DateTime.Now;
            /*
            DirectoryInfo sourceDir = new DirectoryInfo(folderTextBox.Text);
            DirectoryInfo destDir = Directory.CreateDirectory(sourceDir.FullName + "\\stem");
            String destFile;
            DateTime startTime = DateTime.Now;
            foreach (FileInfo sourceFile in sourceDir.GetFiles())
            {
                Console.WriteLine("Processing file: " + sourceFile);
                destFile = sourceFile.Name + ".stm";
                FileConverter.StemFile(sourceFile.FullName,destDir.FullName + "\\" + destFile, stopWords);
            }
              */
            PreprocessingUtility.StemDir(folderTextBox.Text, stopWords);
            MessageBox.Show("All done in:" + (DateTime.Now.Subtract(startTime)).ToString() );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                folderTextBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            PreprocessingUtility.SumWords(folderTextBox.Text,folderTextBox.Text + "\\summary.sum");
            MessageBox.Show("All done in:" + (DateTime.Now.Subtract(startTime)).ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dictionary<int, String> stopWords = PreprocessingUtility.LoadStopWords("PreprocessingTest\\stopwords\\stopwords.txt");

            DirectoryInfo rootDirInfo = new DirectoryInfo(folderTextBox.Text);
            DateTime startTime = DateTime.Now;
            foreach (DirectoryInfo sourceDirInfo in rootDirInfo.GetDirectories())
            {
                PreprocessingUtility.StemDir(sourceDirInfo.FullName, stopWords);
                PreprocessingUtility.SumWords(sourceDirInfo.FullName + "\\stem\\", rootDirInfo + "\\" + sourceDirInfo.Name + ".sum");
            }
            
            MessageBox.Show("All done in:" + (DateTime.Now.Subtract(startTime)).ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FrequentDictionary dictionary = new FrequentDictionary(openFileDialog1.FileName, 10);
                Console.WriteLine("Dictionary:");
                Console.WriteLine(dictionary.ToString());
            }
        }
    }
}