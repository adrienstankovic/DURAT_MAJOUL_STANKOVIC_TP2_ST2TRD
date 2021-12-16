using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_ST2TRD
{
    public class Binary
    {
        public static string Code(string inputText, bool toDecrypt)
        {
            return toDecrypt ? Decrypt(inputText) : Encrypt(inputText);
        }

        private static string Encrypt(string inputText)
        {
            byte[] binaryArr = Encoding.ASCII.GetBytes(inputText);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in binaryArr)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            inputText = sb.ToString();
            return $"{inputText} encrypted with Binary !";
        }

        private static string Decrypt(string inputText)
        {
            List<Byte> binaryList = new List<Byte>();
            for (int i = 0; i < inputText.Length; i += 8)
            {
                binaryList.Add(Convert.ToByte(inputText.Substring(i, 8), 2));
            }
            inputText = Encoding.ASCII.GetString(binaryList.ToArray());
            return $"{inputText} was decrypted with Binary !";
        }
    }
}
