using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_ST2TRD
{
    public class Caesar
    {
        public static string Code(string inputText, string inputKey, bool toDecrypt)
        {
            return toDecrypt ? Decrypt(inputText, inputKey) : Encrypt(inputText, inputKey);
        }

        private static string Encrypt(string inputText, string inputKey)
        {
            char[] buffer = inputText.ToCharArray();
            string temp = "";
            foreach (char ch in buffer)
            {
                char letter = ch;
                letter = (char)(letter + (int.Parse(inputKey) % 26));
                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }
                temp += letter;
            }
            inputText = temp;
            return $"{inputText} encrypted with Caesar !";
        }

        private static string Decrypt(string inputText, string inputKey)
        {
            char[] buffer = inputText.ToCharArray();
            string temp = "";
            foreach (char ch in buffer)
            {
                char letter = ch;
                letter = (char)(letter - (int.Parse(inputKey) % 26));
                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }
                temp += letter;
            }
            inputText = temp;
            return $"{inputText} was decrypted with Caesar !";
        }
    }
}
