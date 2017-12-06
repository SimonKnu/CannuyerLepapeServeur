using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Net.Mail;

namespace CannuyerLepapeServeur.Models
{
    public static class Encrypt
    {
        //source -http://webman.developpez.com/articles/dotnet/aes-rijndael/#L2.1

        static readonly string PasswordHash = "FadDd52da9Mmdax2";
        static readonly string SaltKey = "Sa9c&dzdsqaqdfKEY";
        static readonly string VIKey = "@1B29ABDC555g7H8";

        public static string EncryptPassword(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }


        public static void sendMail(string mail, string nom, string prenom, string password)
        {
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("trackcityreset@gmail.com");
            Msg.To.Add(mail);
            Msg.Subject = "TrackCity - Réinitialisation de votre mot de passe";
            Msg.Body = "Bonjour "+nom+" "+prenom+".\n\nVous avez effectué une demande de réinitialisation de mot de passe pour votre compte TrackCity.\n\n" +
                "Nous vous avons généré un nouveau mot de passe aléatoire temporaire que nous vous invitons à aller modifier directement.\n\nVotre nouveau mot de passe est : "+password+".\n\n" +
                "Nous vous souhaitons une agréable journée ou nuit sur notre site TrackCity.\n\nSimon & Yorick.";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("trackcityreset@gmail.com", "vivilafolie");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
        }

        public static string random_string(int size)
        {
            string dico = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            char[] chars = new char[size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                chars[i] = dico[rand.Next(0, dico.Length)];
            }

            return new string(chars);
        }
    }
}