using System;
using System.IO.Packaging;
using System.Windows;

namespace TP2_ST2TRD
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            var toDecrypt = ConvertCheckBox.IsChecked ?? false;
            var inputText = InputTextBox.Text;
            var inputKey = InputKeyBox.Text;
            var encryptionmethod = EncryptionComboBox.Text;

            try
            {
                OutputTextBox.Text = "";
                if (encryptionmethod == "Caesar")
                {

                    if (string.IsNullOrWhiteSpace(inputKey))
                    {
                        inputKey = "3";
                        OutputTextBox.Text += "The key was initialized to '3'.\n";
                    }
                    if (string.IsNullOrWhiteSpace(inputText))
                    {
                        inputText = "Default";
                        OutputTextBox.Text += "The text was initialized to 'Default'.\n";
                    }
                    OutputTextBox.Text += Caesar.Code(inputText, inputKey, toDecrypt);
                }
                if (encryptionmethod == "Binary")
                {
                    if (string.IsNullOrWhiteSpace(inputText))
                    {
                        if (toDecrypt)
                        {
                            inputText = "Default";
                            OutputTextBox.Text += "The text was initialized to 'Default'.\n";
                        }
                        else
                        {
                            inputText = "01000100011001010110011001100001011101010110110001110100";
                            OutputTextBox.Text += "The text was initialized to '01000100011001010110011001100001011101010110110001110100'.\n";
                        }
                    }
                    OutputTextBox.Text += Binary.Code(inputText, toDecrypt);
                }
                if (encryptionmethod == "Vigenere")
                {
                    if (string.IsNullOrWhiteSpace(inputKey))
                    {
                        inputKey = "key";
                        OutputTextBox.Text += "The text was initialized to 'key'.\n";
                    }
                    if (string.IsNullOrWhiteSpace(inputText))
                    {
                        inputText = "Default";
                        OutputTextBox.Text += "The text was initialized to 'Default'.\n";
                    }
                    OutputTextBox.Text += Vigenere.Code(inputText, inputKey, toDecrypt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            var inputText = InputTextBox.Text;
            var fileName = fileNameBox.Text;
            try
            {
                if (fileName.Contains(".txt"))
                {
                    InputTextBox.Text = Data.ReadTxt(fileName);
                }
                else if (fileName.Contains(".csv"))
                {
                    InputTextBox.Text = Data.ReadCsv(fileName);
                }
                else if (fileName.Contains(".docx"))
                {
                    InputTextBox.Text = Data.ReadDocx(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}