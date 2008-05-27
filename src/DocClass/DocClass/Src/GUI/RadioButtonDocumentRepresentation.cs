using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using DocClass.Src.DocumentRepresentation;

namespace DocClass
{
    class RadioButtonDocumentRepresentation : RadioButton
    {
        private DocumentRepresentationType documentRepresentationType;

        public DocumentRepresentationType DocumentRepresentationType
        {
            get { return documentRepresentationType; }
            set
            {
                Text = DocumentRepresentationTypeUtil.ToString(value);
                documentRepresentationType = value;
            }
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if (this.Checked)
            {
                Properties.Settings.Default.documentRepresentationType = (int)documentRepresentationType;
                //Console.Out.WriteLine(DocumentRepresentationTypeUtil.ToString((DocumentRepresentationType)Properties.Settings.Default.documentRepresentationType));
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Text = DocumentRepresentationTypeUtil.ToString(documentRepresentationType);
            Checked = (Properties.Settings.Default.documentRepresentationType == (int)documentRepresentationType);
        }

        public void BindWithSettings()
        {
            this.Checked = (Properties.Settings.Default.documentRepresentationType == (int)this.documentRepresentationType);
        }
    }
}
