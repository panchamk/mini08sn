using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DocClass.Src.Dictionaries;
using DocClass.Src.DocumentRepresentation;
using DocClass.Src.Classification;

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
            Dictionary<int, String> stopWords = PreprocessingUtility.LoadStopWords("Preprocessing\\stopwords.txt");
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
            PreprocessingUtility.SumWords(folderTextBox.Text,PreprocessingConsts.CategoryFilePattern,folderTextBox.Text + "\\summary.all");
            MessageBox.Show("All done in:" + (DateTime.Now.Subtract(startTime)).ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            Dictionary<int, String> stopWords = PreprocessingUtility.LoadStopWords("Preprocessing\\stopwords.txt");

            DirectoryInfo rootDirInfo = new DirectoryInfo(folderTextBox.Text);
            DateTime startTime = DateTime.Now;
            foreach (DirectoryInfo sourceDirInfo in rootDirInfo.GetDirectories())
            {
                PreprocessingUtility.StemDir(sourceDirInfo.FullName, stopWords);
                PreprocessingUtility.SumWords(sourceDirInfo.FullName + "\\stem\\", rootDirInfo + "\\" + sourceDirInfo.Name + ".cat");
            }
            
            MessageBox.Show("All done in:" + (DateTime.Now.Subtract(startTime)).ToString());
             * */
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Dictionary dictionary = new FrequentDictionary(openFileDialog1.FileName, 100);
                Console.WriteLine("Dictionary:");
                Console.WriteLine(dictionary.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dictionary dictionary = new FrequentDictionary("Preprocessing\\" + PreprocessingConsts.SummaryFileName, 100);
            DirectoryInfo dirInfo = new DirectoryInfo(folderTextBox.Text);
            foreach (FileInfo fileInfo in dirInfo.GetFiles())
                Console.WriteLine(new OwnDocument(fileInfo.FullName, dictionary, null));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DocumentClass.LoadFromFiles(folderTextBox.Text,PreprocessingConsts.CategoryFilePattern);
            Console.Write(DocumentClass.ToString());
            CategoryList categoryList = new CategoryList(folderTextBox.Text, PreprocessingConsts.CategoryFilePattern);
            MessageBox.Show("Koniec");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PlainDocument pd = new PlainDocument(openFileDialog1.FileName);
                Console.WriteLine(pd.GetAllWordsCount());
                Console.WriteLine(pd.GetUniqueWordsCount());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                Dictionary<int, String> stopWords = PreprocessingUtility.LoadStopWords("Preprocessing\\stopwords.txt");

                DirectoryInfo rootDirInfo = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                DateTime startTime = DateTime.Now;
                foreach (DirectoryInfo sourceDirInfo in rootDirInfo.GetDirectories())
                {
                    PreprocessingUtility.StemDir(sourceDirInfo.FullName, stopWords);
                    PreprocessingUtility.SumWords(sourceDirInfo.FullName + "\\stem\\",PreprocessingConsts.StemmedFilePattern, rootDirInfo + "\\" + sourceDirInfo.Name + PreprocessingConsts.CategoryFileExtension);
                }
                //sumowanie kategorii
                PreprocessingUtility.SumWords(folderBrowserDialog1.SelectedPath,PreprocessingConsts.CategoryFilePattern, rootDirInfo + "\\" + PreprocessingConsts.SummaryFileName);                

                MessageBox.Show("All done in:" + (DateTime.Now.Subtract(startTime)).ToString());

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}