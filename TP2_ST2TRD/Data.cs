using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace TP2_ST2TRD
{
    public class Data
    {
        public static string ReadTxt(string fileName)
        {
            string text = "";
            try
            {
                text = File.ReadAllText(fileName, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return text;
        }
        public static string ReadCsv(string fileName)
        {
            try
            {
                string[] contents = File.ReadAllText(fileName).Split(';');
                string text = "";
                foreach (string line in contents)
                {
                    text += line+" ";
                }
                return text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
        public static string ReadDocx(string fileName)
        {
            try
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(fileName, false))
                {
                    Body body = wordDocument.MainDocumentPart.Document.Body;
                    return body.InnerText.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
    }
}
