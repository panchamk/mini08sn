using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using DocClass.Src.Controller.Common;

namespace DocClass.Src.Controller.Workers
{
    public class LearningBackgroundWorker : BackgroundWorker
    {
        /// <summary>
        /// Typ klasyfikatora, ktory bedzie uczony.
        /// </summary>
        private TypeClassificator mClassificator = TypeClassificator.None;

        public LearningBackgroundWorker(TypeClassificator type) :
            base()
        {
            this.mClassificator = type;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
        }
    }
}
