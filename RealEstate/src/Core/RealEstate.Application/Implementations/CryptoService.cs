using Microsoft.Extensions.Options;
using RealEstate.Application.Contracts;
using RealEstate.Domain.Configurations;
using System.Security.Cryptography;
using System.Text;

namespace RealEstate.Application.Implementations
{
    public class CryptoService : ICryptoService
    {
        private readonly MD5 md5;
        private readonly SHA1 sha1;
        private readonly CryptoServiceOptions options;
        private readonly TripleDES provider;
        public CryptoService(IOptions<CryptoServiceOptions> options)
        {
            this.md5 = MD5.Create();
            this.sha1 = SHA1.Create();
            this.options = options.Value;
            this.provider = TripleDES.Create();
        }
        public string ToMd5(string value)
        {
            var bufferSalt = Encoding.UTF8.GetBytes($"create_salt{this.options.Salt}@{value}2025");

            var buffer = Encoding.UTF8.GetBytes(value);

            var hashBuffer = md5.ComputeHash(buffer);
            return string.Join(string.Empty, hashBuffer.Select(b => b.ToString("x2")));
        }

        public string ToSha1(string value)
        {

            var bufferSalt = Encoding.UTF8.GetBytes($"create_salt{this.options.Salt}@{value}2025");

            var buffer = Encoding.UTF8.GetBytes(value);

            var sha1Buffer = sha1.ComputeHash(buffer);
            return string.Join(string.Empty, sha1Buffer.Select(x => x.ToString("x2")));
        }


        public string Encrypt(string value, bool appliedUrlEncoding = false)
        {
            throw new NotImplementedException();
        }

        public byte[] Encrypt(byte[] buffer, byte[] key)
        {
            var keyBuffer = md5.ComputeHash(key);
            var ivBuffer = sha1.ComputeHash(key);
            var keyBufferFinal = new byte[this.provider.Key.Length];
            var ivBufferFinal = new byte[this.provider.IV.Length];

            Array.Copy(keyBuffer, 0, ivBuffer, 0, Math.Min(keyBuffer.Length, keyBufferFinal.Length));
            Array.Copy(keyBuffer, 0, ivBuffer, 0, Math.Min(ivBuffer.Length, ivBufferFinal.Length));

            var transform = provider.CreateEncryptor(keyBufferFinal, ivBufferFinal);

            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
                cs.FlushFinalBlock();

                ms.Position = 0;
                ms.Seek(0, SeekOrigin.Begin);

                var dataBuffer = new byte[ms.Length];
                ms.Read(dataBuffer, 0, dataBuffer.Length);
                return dataBuffer;
            }

        }

        public string Decrypt(string value)
        {
            throw new NotImplementedException();
        }

        public byte[] Decrypt(byte[] buffer, byte[] key)
        {
            var keyBuffer = md5.ComputeHash(key);
            var ivBuffer = sha1.ComputeHash(key);
            var keyBufferFinal = new byte[this.provider.Key.Length];
            var ivBufferFinal = new byte[this.provider.IV.Length];

            Array.Copy(keyBuffer, 0, ivBuffer, 0, Math.Min(keyBuffer.Length, keyBufferFinal.Length));
            Array.Copy(keyBuffer, 0, ivBuffer, 0, Math.Min(ivBuffer.Length, ivBufferFinal.Length));

            var transform = provider.CreateDecryptor(keyBufferFinal, ivBufferFinal);

            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
                cs.FlushFinalBlock();

                ms.Position = 0;
                ms.Seek(0, SeekOrigin.Begin);

                var dataBuffer = new byte[ms.Length];
                ms.Read(dataBuffer, 0, dataBuffer.Length);
                return dataBuffer;
            }
        }


        public byte[] Encrypt(byte[] buffer, RSA key)
        {
            throw new NotImplementedException();
        }
        public byte[] Decrypt(byte[] buffer, RSA key)
        {
            throw new NotImplementedException();
        }


    }
}
