using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DocClass
{
    public partial class FileInput : UserControl
    {

        public FileInput()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            Browse();
        }

        private void Browse()
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.InitialDirectory = ".\\";
            fileOpen.Filter = "All files (*.*)|*.*";
            fileOpen.FilterIndex = 0;
            fileOpen.RestoreDirectory = false;
            if(fileOpen.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = fileOpen.FileName;
            }
        }

    }
}
