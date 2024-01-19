using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Marvel
{
    public class MarvelApiConfig
    {
        public static long TimeStamp => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        public static string PublicKey => "4d3de4314998e1285b426a3b3fd9fc66";
        public static string PrivateKey => "1362e5f4fd298c5baea26ea9d63c070d3739b36d";

        //MD5 cryptor = MD5.Create();
        //string stringToHash = $"{ts}{privatKey}{publicKey}";
        //byte[] bytes = cryptor.ComputeHash(Encoding.Default.GetBytes(stringToHash));
        //public static string hash = BitConverter.ToString(bytes).ToLower().Replace("-", "");

        public static string Hash => BitConverter.ToString(
                                                                MD5
                                                               .Create()
                                                               .ComputeHash(Encoding.Default.GetBytes($"{TimeStamp}{PrivateKey}{PublicKey}"))
                                                           )
                                                       .ToLower()
                                                       .Replace("-", "");
    }
}
