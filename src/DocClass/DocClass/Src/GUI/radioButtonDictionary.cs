using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using DocClass.Src.Classification;
using DocClass.Src.Dictionaries;
using DocClass.Src.DocumentRepresentation;

namespace DocClass
{
    class RadioButtonDictionary :RadioButton
    {
        private DictionaryType dictionaryType;

        public DictionaryType DictionaryType
        {
            get { return dictionaryType; }
            set 
            {
                this.Name = DictionaryTypeUtil.ToString(value);
                dictionaryType = value;
                
            }
        }

        protected override void  OnCheckedChanged(EventArgs e)
        {
 	         base.OnCheckedChanged(e);
             if (this.Checked)
             {
                 Properties.Settings.Default.dictionaryType = (int)dictionaryType;
                 //Console.Out.WriteLine(DictionaryTypeUtil.ToString((DictionaryType)Properties.Settings.Default.dictionaryType));
             }
             
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Text = DictionaryTypeUtil.ToString(dictionaryType);
            Checked = (Properties.Settings.Default.dictionaryType == (int)dictionaryType);
        }



        
    
            
    

        
    }
}
