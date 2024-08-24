using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Collections;
using System.Security.Cryptography;

namespace PortalLatihan.Domain.Entities
{
    public class Staff : BaseDomainEntity
    {
        public required string Name { get; set; }
        public string Password { get; private set; } = "";
        public required string Email { get; set; }
        public required string Role { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new InvalidDataException("Name is required");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new InvalidDataException("Password is required");
            }

            if (string.IsNullOrEmpty(Email))
            {
                throw new InvalidDataException("Email is required");
            }

            if (string.IsNullOrEmpty(Role))
            {
                throw new InvalidDataException("Role is required");
            }
        }

        public void SetPassword(string password)
        {
            Password = EncryptString(password);
        }

        public void CheckPassword(string password)
        {
            if (Password != EncryptString(password))
            {
                throw new InvalidDataException("Username or password is not valid");
            }
        }

        private static string EncryptString(string plainText)
        {
            string key = "MPOB#PortalLatihan#Net8#Token#2024";

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = DeriveKey(key, aesAlg.KeySize / 8);
            aesAlg.IV = new byte[16]; // Initialization Vector

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msEncrypt = new();
            using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using StreamWriter swEncrypt = new(csEncrypt);
                swEncrypt.Write(plainText);
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static byte[] DeriveKey(string key, int keyBytes)
        {
#pragma warning disable SYSLIB0041 // Type or member is obsolete
            using var pbkdf2 = new Rfc2898DeriveBytes(key, new byte[8], 10000);
            return pbkdf2.GetBytes(keyBytes);
#pragma warning restore SYSLIB0041 // Type or member is obsolete
        }

    }
}
