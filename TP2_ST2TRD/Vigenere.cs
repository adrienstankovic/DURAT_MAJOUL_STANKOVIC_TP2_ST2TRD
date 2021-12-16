using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_ST2TRD
{
	public class Vigenere
    {
        public static string Code(string inputText, string inputKey, bool toDecrypt)
        {
            return toDecrypt ? Decrypt(inputText, inputKey) : Encrypt(inputText, inputKey);
        }
		private static int Mod(int a, int b)
		{
			return (a % b + b) % b;
		}
		private static string Encrypt(string inputText, string inputKey)
        {
			foreach (char ch in inputKey)
			{
				if (!char.IsLetter(ch))
                {
					return null;
                }
			}
			string output = string.Empty;
			int nonAlphaCharCount = 0;
			for (int i = 0; i < inputText.Length; ++i)
			{
				if (char.IsLetter(inputText[i]))
				{
					bool cIsUpper = char.IsUpper(inputText[i]);
					char offset = cIsUpper ? 'A' : 'a';
					int keyIndex = (i - nonAlphaCharCount) % inputKey.Length;
					int k = (cIsUpper ? char.ToUpper(inputKey[keyIndex]) : char.ToLower(inputKey[keyIndex])) - offset;
					char ch = (char)((Mod(((inputText[i] + k) - offset), 26)) + offset);
					output += ch;
				}
				else
				{
					output += inputText[i];
					++nonAlphaCharCount;
				}
			}
			inputText = output;
			return $"{inputText} encrypted with Vigenere !";
        }
        private static string Decrypt(string inputText, string inputKey)
        {
			foreach (char ch in inputKey)
			{
				if (!char.IsLetter(ch))
				{
					return null;
				}
			}
			string output = string.Empty;
			int nonAlphaCharCount = 0;
			for (int i = 0; i < inputText.Length; ++i)
			{
				if (char.IsLetter(inputText[i]))
				{
					bool cIsUpper = char.IsUpper(inputText[i]);
					char offset = cIsUpper ? 'A' : 'a';
					int keyIndex = (i - nonAlphaCharCount) % inputKey.Length;
					int k = (cIsUpper ? char.ToUpper(inputKey[keyIndex]) : char.ToLower(inputKey[keyIndex])) - offset;
					char ch = (char)((Mod(((inputText[i] - k) - offset), 26)) + offset);
					output += ch;
				}
				else
				{
					output += inputText[i];
					++nonAlphaCharCount;
				}
			}
			inputText = output;
			return $"{inputText} was decrypted with Binary !";
        }
    }
}