using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Contracts
{
    /*
    Hashing - sifrelenmish melumati deshifre ede bilmirik(meselene shifreler)
    Symmetric - bir acharimiz olur hemin acharnan datani shifreleyirik ve hemin acharlada datani acha bilirik
    Asymetric - burda iki achar var public ve private acharlar
     */
    public interface ICryptoService
    {
        #region Hashing
        string ToMd5(string value);
        string ToSha1(string value);
        #endregion

        #region Symmetric
        string Encrypt(string value, bool appliedUrlEncoding = false);
        byte[] Encrypt(byte[] buffer, byte[] key);
        string Decrypt(string value);
        byte[] Decrypt(byte[] buffer, byte[] key);
        #endregion


        #region Asymetric
        byte[] Encrypt(byte[] buffer, RSA key);
        byte[] Decrypt(byte[] buffer, RSA key);
        #endregion
    }
}
