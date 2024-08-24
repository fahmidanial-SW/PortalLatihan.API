using Newtonsoft.Json;
using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain;
using PortalLatihan.Domain.Entities;
using System.Security.Cryptography;

namespace PortalLatihan.Application.Services
{
    public class StaffService(IUnitOfWork unitOfWork) : IStaffService
    {
        private readonly string key = "MPOB#PortalLatihan#Net8#Token#2024";

        public async Task Add(StaffAddRequest staffInsertRequest, string user)
        {
            try
            {
                Staff staff = new()
                {
                    Name = staffInsertRequest.Username,
                    Email = staffInsertRequest.Email,
                    Role = staffInsertRequest.Role
                };

                staff.SetPassword(staffInsertRequest.Password);

                await unitOfWork.Staff_Add(staff, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> GetUserToken(StaffLoginRequest staffLoginRequest)
        {
            try
            {
                Staff staff = await unitOfWork.Staff_ByUsername(staffLoginRequest.Username);

                staff.CheckPassword(staffLoginRequest.Password);

                var tokenObject = new TokenDataVM
                {
                    Email = staff.Email,
                    Role = staff.Role,
                    Expired = DateTime.Now.AddDays(1)
                };

                string tokenOutput = JsonConvert.SerializeObject(tokenObject);
                return EncryptString(tokenOutput);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TokenDataVM CheckToken(string token)
        {
            try
            {
                string tokenOutput = DecryptString(token);
                var tokenData = JsonConvert.DeserializeObject<TokenDataVM>(tokenOutput) ?? throw new Exception("Token Not Valid");
                
                if (tokenData.Expired < DateTime.Now)
                {
                    throw new Exception("Token Expired");
                }

                return tokenData;
            }
            catch
            {
                throw new Exception("Token Not Valid");
            }
        }

        private string EncryptString(string plainText)
        {
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

        private string DecryptString(string cipherText)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = DeriveKey(key, aesAlg.KeySize / 8);
            aesAlg.IV = new byte[16]; // Initialization Vector

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msDecrypt = new(Convert.FromBase64String(cipherText));
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
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
