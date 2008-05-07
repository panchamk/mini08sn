using System;
using System.Collections.Generic;
using System.Text;

namespace DocClass.Src.Preprocessing
{
    /// <summary>
    /// Zawiera sta�e zwi�zane z preprocessingiem.
    /// </summary>
    static class PreprocessingConsts
    {
        public const String CategoryFilePattern = "*.cat";
        public const String CategoryFileExtension = ".cat";
        public const String StopWordsPath = "Preprocessing\\stopwords.txt";
        public const String SummaryFileName = "summary.all";
        public const String StemmedFileExtension = ".stm";
        public const String StemmedFilePattern = "*.stm";
        public const String StemmedFolder = "stem";
    }
}
