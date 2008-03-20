using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using DocClass.Src.Classification;

namespace DocClass
{
    class RadioButtonClassification : RadioButton
    {
        private ClasyficatorType classificationType;

        public ClasyficatorType ClassificationType
        {
            get { return classificationType; }
            set {
                this.Text = ClassyficatorTypeUtil.ToString(value);
                classificationType = value; 
            }
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if (this.Checked)
            {
                Properties.Settings.Default.clasificatorType = (int)classificationType;
                //Console.Out.WriteLine(ClassyficatorTypeUtil.ToString((ClasyficatorType)Properties.Settings.Default.clasificatorType));
            }

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Checked = (Properties.Settings.Default.clasificatorType == (int)classificationType);
        }


    }
}


