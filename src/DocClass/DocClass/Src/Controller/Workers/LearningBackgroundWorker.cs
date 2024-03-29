﻿using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using DocClass.Src.Controller.Common;
using DocClass.Src.Controller;

namespace DocClass.Src.Controller.Workers
{
    public class LearningBackgroundWorker : BackgroundWorker
    {
        private Controller controller;

        public LearningBackgroundWorker(Controller controller) :
            base()
        {
            this.controller = controller;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
            controller.LearnProcess();
        }

    }
}
