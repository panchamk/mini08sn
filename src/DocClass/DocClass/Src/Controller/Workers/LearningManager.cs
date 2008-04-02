using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using DocClass.Src.Controller.Common;

namespace DocClass.Src.Controller.Workers
{
    /// <summary>
    /// Klasa implementujaca uczenie.
    /// Zarzadza operacja uczenia w innym watku.
    /// </summary>
    public class LearningManager : IDisposable
    {
        #region Private Fields

        /// <summary>
        /// Uzywany klasyfikator.
        /// </summary>
        private TypeClassificator mClassificator = TypeClassificator.None;

        /// <summary>
        /// Watek uczacy.
        /// </summary>
        private LearningBackgroundWorker mLearningWorker;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Konstruktor jednoparametrowy.
        /// </summary>
        /// <param name="classificator">Typ klasyfikatora.</param>
        public LearningManager(TypeClassificator classificator)
        {
            this.mClassificator = classificator;
            this.mLearningWorker = new LearningBackgroundWorker(classificator);
            this.mLearningWorker.WorkerReportsProgress = true;
            this.mLearningWorker.WorkerSupportsCancellation = true;
            this.mLearningWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLearningWorker_RunWorkerCompleted);
            this.mLearningWorker.ProgressChanged += new ProgressChangedEventHandler(OnLearningWorker_ProgressChanged);
        }

        #endregion

        #region Background Events

        void OnLearningWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void OnLearningWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Rozpoczyna uczenie.
        /// </summary>
        public void Start()
        {
            if (this.mLearningWorker == null || this.mLearningWorker.IsBusy)
                throw new InvalidOperationException("Worker is busy !");
            
            this.mLearningWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Rozpoczyna uczenie.
        /// </summary>
        /// <param name="argument">Argument wykorzystany przez watek do
        /// wykonania uczenia.</param>
        public void Start(Object argument)
        {
            if (this.mLearningWorker == null || this.mLearningWorker.IsBusy)
                throw new InvalidOperationException("Worker is busy !");

            this.mLearningWorker.RunWorkerAsync(argument);
        }

        /// <summary>
        /// Konczy dzialanie uczenia.
        /// </summary>
        public void Cancel()
        {
            if (this.mLearningWorker != null)
                this.mLearningWorker.CancelAsync();
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Zwalania zaalokowane zasoby.
        /// </summary>
        public void Dispose()
        {
            if (this.mLearningWorker != null)
                this.mLearningWorker.Dispose();
        }

        #endregion
    }
}
