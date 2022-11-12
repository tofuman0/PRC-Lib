using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.PRC
{
    public class PRC
    {
        public static byte[] CipherBuffer(byte[] inBuf, UInt32 decompressedSize, UInt32 seedOverride = 0)
        {
            try
            {
                byte[] buffer = (byte[])inBuf.Clone();
                UInt32 seed;
                if (seedOverride > 0)
                    seed = seedOverride;
                else
                    seed = Cipher.GenerateSeed();
                if (Cipher.InitKey(seed) == false) return null;
                buffer = Cipher.CipherBuffer(buffer, buffer.Length);
                if (buffer == null) return null;
                byte[] result = new byte[buffer.Length + 8];
                Buffer.BlockCopy(buffer, 0, result, 8, buffer.Length);
                Buffer.BlockCopy(BitConverter.GetBytes(decompressedSize), 0, result, 0, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(seed), 0, result, 4, 4);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static byte[] DecipherBuffer(byte[] inBuf, ref UInt32 decompressedSize, UInt32 seedOverride = 0)
        {
            try
            {
                byte[] buffer = (byte[])inBuf.Clone();
                decompressedSize = BitConverter.ToUInt32(buffer, 0);
                UInt32 seed;
                if (seedOverride > 0)
                    seed = seedOverride;
                else
                    seed = BitConverter.ToUInt32(buffer, 4);
                if (Cipher.InitKey(seed) == false) return null;
                byte[] CipherBuffer = new byte[buffer.Length - 8];
                Buffer.BlockCopy(buffer, 8, CipherBuffer, 0, buffer.Length - 8);
                byte[] result = Cipher.CipherBuffer(CipherBuffer, CipherBuffer.Length);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
