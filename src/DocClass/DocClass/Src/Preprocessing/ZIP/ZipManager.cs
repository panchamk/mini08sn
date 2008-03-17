using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;

namespace DocClass.Src.Preprocessing.ZIP
{
    /// <summary>
    /// Klasa odczytuje pliki z folderu skompresowanego.
    /// </summary>
    public static class ZipManager
    {
        /// <summary>
        /// Funkcja ogolnie nie uzyteczna. Pokazuje jednak jak uzyc 
        /// biblioteki.
        /// </summary>
        /// <param name="path">Scierzka do skompresowanego pliku.</param>
        /// <returns>Pierwszy wczytany plik.</returns>
        public static string Read(string path)
        {
            ZipInputStream zipStream = null;
            try
            {
                zipStream = new ZipInputStream(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read));
                ZipEntry entry = null;
                while ((entry = zipStream.GetNextEntry()) != null)
                {
                    if (entry.IsFile && zipStream.CanDecompressEntry)
                    {
                        byte[] array = new byte[entry.CompressedSize];
                        int size = zipStream.Read(array, 0, (int)entry.CompressedSize);
                        if (size > 0)
                            return (new ASCIIEncoding().GetString(array));
                        else
                            return "Nie udalo sie odczytac pliku !";
                    }
                    zipStream.CloseEntry();
                }
                return String.Empty;
            }
            catch (Exception)
            {
                return String.Empty;
            }
            finally
            {
                if (zipStream != null)
                    zipStream.Close();
            }
        }
    }
}
