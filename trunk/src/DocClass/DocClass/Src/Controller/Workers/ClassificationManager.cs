using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using DocClass.Src.Controller.Common;
using DocClass.Src.Controller.Workers;

namespace DocClass.Src.Controller.Workers
{
    /// <summary>
    /// Klasa implementujaca klasyfikacje.
    /// </summary>
    public class ClassificationManager //: IDisposable
    {
        /*#region Private Fields

        /// <summary>
        /// Typ klasyfikatora do nauki.
        /// </summary>
        private TypeClassificator mClassificator = TypeClassificator.None;

        /// <summary>
        /// Watek, ktory selekcjonuje pliki.
        /// </summary>
        private ClassificationBackgroundWorker mClassificationWorker;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Konstruktor jednoparametrowy.
        /// </summary>
        /// <param name="classificator">Typ klasyfikatora, ktory bedzie uzyty do 
        /// selekcjonowania plikow.</param>
        public ClassificationManager(TypeClassificator classificator)
        {
            this.mClassificator = classificator;
            this.mClassificationWorker = new ClassificationBackgroundWorker(classificator);
            this.mClassificationWorker.WorkerReportsProgress = true;
            this.mClassificationWorker.WorkerSupportsCancellation = true;
            this.mClassificationWorker.ProgressChanged += new ProgressChangedEventHandler(OnClassificationWorker_ProgressChanged);
            this.mClassificationWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnClassificationWorker_RunWorkerCompleted);
        }

        #endregion

        #region Background Events

        void OnClassificationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void OnClassificationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Zwraca typ klasyfikatora, uzytego do klasyfikacji plikow.
        /// </summary>
        public TypeClassificator Classificator
        {
            get { return this.mClassificator; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Rozpoczyna dzialanie procesu.
        /// </summary>
        public void Start()
        {
            if (this.mClassificationWorker == null || this.mClassificationWorker.IsBusy)
                throw new Exception("Worker is busy !");

            this.mClassificationWorker.RunWorkerAsync();
        }


        /// <summary>
        /// Rozpoczyna dzialanie procesu.
        /// </summary>
        /// <param name="argument">Argument wykorzystany przez watek do
        /// wykonania klasyfikacji.</param>
        public void Start(Object argument)
        {
            if (this.mClassificationWorker == null || this.mClassificationWorker.IsBusy)
                throw new InvalidOperationException("Worker is busy !");

            this.mClassificationWorker.RunWorkerAsync(argument);
        }

        /// <summary>
        /// Konczy dzialanie watku.
        /// </summary>
        public void Cancel()
        {
            if (this.mClassificationWorker != null && this.mClassificationWorker.IsBusy)
                this.mClassificationWorker.CancelAsync();
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Zwalnia zaalokowane zasoby.
        /// </summary>
        public void Dispose()
        {
            if (this.mClassificationWorker != null)
                this.mClassificationWorker.Dispose();
        }

        #endregion
         */
    }
}
