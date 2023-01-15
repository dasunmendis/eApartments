using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using GlobeFa.DAL.Enums;

namespace GlobeFa.Infrastructure.Services.Common
{
    public class CommonService
    {
        //ToDo: check dependencies here
        public bool HaveDependencies(object obj)
        {
            return true;
        }

        public string ChangeStringCase(string inputText, TextConversionTypeEnum convertToType)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            switch (convertToType)
            {
                case TextConversionTypeEnum.LowerCase:
                    return textInfo.ToLower(inputText);
                case TextConversionTypeEnum.UpperCase:
                    return textInfo.ToUpper(inputText);
                case TextConversionTypeEnum.TitleCase:
                    return textInfo.ToTitleCase(inputText);
                default:
                    return inputText;
            }
        }
    }

    public class CryptographyService
    {
        private const string EncryptionKey = "@!&%#@?,";

        public string Encrypt(string text)
        {
            byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };

            try
            {
                byte[] bykey = System.Text.Encoding.UTF8.GetBytes(EncryptionKey);
                byte[] inputByteArray = System.Text.Encoding.UTF8.GetBytes(text);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(bykey, iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Decrypt(string text)
        {
            byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            var inputByteArray = new byte[text.Length];

            try
            {
                byte[] byKey = System.Text.Encoding.UTF8.GetBytes(EncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(text);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

    }

}
