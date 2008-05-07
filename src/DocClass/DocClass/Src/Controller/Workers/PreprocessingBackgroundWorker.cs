using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace DocClass.Src.Controller.Workers
{
    class PreprocessingBackgroundWorker : BackgroundWorker
    {
        private Controller controller;

        public PreprocessingBackgroundWorker(Controller controller) :
            base()
        {
            this.controller = controller;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
            controller.PreprocessingDirProcess();
        }
    }
}
