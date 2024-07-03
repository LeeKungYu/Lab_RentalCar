using System.Security.Cryptography;

namespace Common.RentalCar.Crypto
{
    public class StringEncryptor
    {
        
        //string originalText = "1qaz@WSX"; 加密前的字串。

        private static readonly string SALTFrom = "YourEncryptionKey"; // 16, 24, or 32 bytes key for AES
        private static byte[] SALT = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3d }; //System.Text.UTF8Encoding.UTF8.GetBytes(SALTFrom);
        public static string EncryptString(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = SALT; //Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16]; // Use a different IV for each encryption

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encryptedBytes = null;

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string DecryptString(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = SALT;
                aesAlg.IV = new byte[16]; // Use the same IV that was used for encryption

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                string plaintext = null;

                using (var msDecrypt = new System.IO.MemoryStream(cipherBytes))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

                return plaintext;
            }
        }
    }
}
