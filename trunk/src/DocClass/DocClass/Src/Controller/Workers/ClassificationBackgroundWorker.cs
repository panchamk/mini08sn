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
        private Controller controller;

        

        public ClassificationBackgroundWorker(Controller controller)
            :base()
        {
            this.controller = controller;
        }

        /// <summary>
        /// Metoda bazowa. Wykonana przez watek.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
            controller.ClassificateProcess();
        }
    }
}
