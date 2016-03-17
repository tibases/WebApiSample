using System;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public class Hash
    {
        private HashAlgorithm _algoritm;

        public Hash(HashAlgorithm algoritm)
        {
            _algoritm = algoritm;
        }


        public string Cryptograph(string passWord)
        {

            var encodedValue = Encoding.UTF8.GetBytes(passWord);
            var encryptedPassword = _algoritm.ComputeHash(encodedValue);
            var sb = new StringBuilder();

            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();

        }


        public bool PasswordValidate(string passwordInputed, string passwordSaved)
        {
            if (string.IsNullOrEmpty(passwordSaved)) throw new NullReferenceException("Cadastre uma senha.");

            var encryptedPassword = _algoritm.ComputeHash(Encoding.UTF8.GetBytes(passwordInputed));
            var sb = new StringBuilder();

            foreach (var character in encryptedPassword)
            {
                sb.Append(character.ToString("X2"));
            }

            return sb.ToString() == passwordSaved;
        }
    }


}

