using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using DocClass.Src.Controller.Common;

namespace DocClass.Src.Controller.Workers
{
    /// <summary>
    /// Implementuje watek klasyfikujacy.
    /// </summary>
    public class ClassificationBackgroundWorker : BackgroundWorker
    {
        /// <summary>
        /// Typ klasyfikatora.
        /// </summary>
        private TypeClassificator mClassificator = TypeClassificator.None;

        /// <summary>
        /// Konstruktor jednoparametrowy.
        /// </summary>
        /// <param name="type">Typ wykorzystywanego clasyfikatora.</param>
        public ClassificationBackgroundWorker(TypeClassificator type)
            :base()
        {
            this.mClassificator = type;
        }

        /// <summary>
        /// Metoda bazowa. Wykonana przez watek.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
        }
    }
}
