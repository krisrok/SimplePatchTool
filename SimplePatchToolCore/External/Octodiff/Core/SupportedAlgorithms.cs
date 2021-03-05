using System;
using System.Security.Cryptography;
using FastRsync.Hash;

namespace FastRsync.Core
{
    public static class SupportedAlgorithms
    {
        public static class Hashing
        {
            public static IHashAlgorithm Sha1()
            {
                return new HashAlgorithmWrapper("SHA1", SHA1.Create());
            }

            public static IHashAlgorithm Md5()
            {
                return new HashAlgorithmWrapper("MD5", MD5.Create());
            }

            public static IHashAlgorithm XxHash()
            {
                return new XxHashAlgorithm();
            }

            public static IHashAlgorithm Default()
            {
                return XxHash();
            }

            public static IHashAlgorithm Create(string algorithm)
            {
                switch (algorithm)
                {
                    case "XXH64":
                        return XxHash();
                    case "MD5":
                        return Md5();
                    case "SHA1":
                        return Sha1();
                }

                throw new NotSupportedException($"The hash algorithm '{algorithm}' is not supported");
            }
        }

        public static class Checksum
        {
            public static IRollingChecksum Adler32Rolling() { return new Adler32RollingChecksum();  }
            public static IRollingChecksum Adler32RollingV2() { return new Adler32RollingChecksumV2(); }

            public static IRollingChecksum Default()
            {
                return Adler32Rolling();
            }

            public static IRollingChecksum Create(string algorithm)
            {
                if (algorithm == "Adler32")
                    return Adler32Rolling();
                if (algorithm == "Adler32V2")
                    return Adler32RollingV2();
                throw new NotSupportedException($"The rolling checksum algorithm '{algorithm}' is not supported");
            }
        }
    }
}