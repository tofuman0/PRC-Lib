using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.PRC
{
    internal class Cipher
    {
		internal static UInt32 m_KeyIndex;
        internal static UInt32[] m_Key;
        internal Cipher()
        {
            m_KeyIndex = 0;
			m_Key = new UInt32[57];
            ZeroKey();
        }
		internal static void ZeroKey()
        {
			if (m_Key == null)
				m_Key = new UInt32[57];
			Array.Clear(m_Key, 0, m_Key.Length);
        }
		internal static UInt32 GenerateSeed()
        {
            Random rand = new Random();
            UInt32 seed = Convert.ToUInt32(rand.Next() % 256);
            for (Int32 i = 0; i < 3; i++)
            {
                seed <<= 8;
                seed |= Convert.ToUInt32(rand.Next() % 256);
            }
            return seed;
        }
		internal static bool InitKey(UInt32 seed)
        {
			UInt32[] l_TempKey = new UInt32[56];
			Array.Clear(l_TempKey, 0, l_TempKey.Length);
			ZeroKey();

			l_TempKey[49] = 1;
			l_TempKey[44] = 0x15;
			m_Key[55] = seed;
			m_Key[54] = seed;
			l_TempKey[38] = 0x2A;
			do
			{
				if ((l_TempKey[44] % 55) == 0 || (l_TempKey[38] % 55) == 0) return false;
				m_Key[(l_TempKey[44] % 55) - 1] = l_TempKey[49];
				seed -= l_TempKey[49];
				m_Key[(l_TempKey[38] % 55) - 1] = seed;
				l_TempKey[49] -= seed;
				l_TempKey[44] += 0x2A;
				l_TempKey[38] += 0x2A;
			} while (l_TempKey[38] < 0x484);
			l_TempKey[0] = m_Key[30] - (m_Key[6] - m_Key[37]);
			l_TempKey[1] = m_Key[31] - (m_Key[7] - m_Key[38]);
			l_TempKey[2] = m_Key[32] - (m_Key[8] - m_Key[39]);
			l_TempKey[3] = m_Key[33] - (m_Key[9] - m_Key[40]);
			l_TempKey[4] = m_Key[34] - (m_Key[10] - m_Key[41]);
			l_TempKey[5] = m_Key[35] - (m_Key[11] - m_Key[42]);
			l_TempKey[6] = m_Key[36] - (m_Key[12] - m_Key[43]);
			l_TempKey[7] = m_Key[37] - (m_Key[13] - m_Key[44]);
			l_TempKey[8] = m_Key[38] - (m_Key[14] - m_Key[45]);
			l_TempKey[9] = m_Key[39] - (m_Key[15] - m_Key[46]);
			l_TempKey[10] = m_Key[40] - (m_Key[16] - m_Key[47]);
			l_TempKey[11] = m_Key[41] - (m_Key[17] - m_Key[48]);
			l_TempKey[12] = m_Key[42] - (m_Key[18] - m_Key[49]);
			l_TempKey[13] = m_Key[43] - (m_Key[19] - m_Key[50]);
			l_TempKey[14] = m_Key[44] - (m_Key[20] - m_Key[51]);
			l_TempKey[15] = m_Key[45] - (m_Key[21] - m_Key[52]);
			l_TempKey[16] = m_Key[46] - (m_Key[22] - m_Key[53]);
			l_TempKey[17] = m_Key[47] - (m_Key[23] - m_Key[54]);
			l_TempKey[39] = m_Key[24] - (m_Key[0] - m_Key[31]);
			l_TempKey[45] = m_Key[25] - (m_Key[1] - m_Key[32]);
			l_TempKey[50] = m_Key[26] - (m_Key[2] - m_Key[33]);
			l_TempKey[54] = m_Key[27] - (m_Key[3] - m_Key[34]);
			l_TempKey[38] = m_Key[28] - (m_Key[4] - m_Key[35]);
			l_TempKey[36] = m_Key[48] - l_TempKey[39];
			l_TempKey[44] = m_Key[29] - (m_Key[5] - m_Key[36]);
			l_TempKey[40] = m_Key[49] - l_TempKey[45];
			l_TempKey[46] = m_Key[50] - l_TempKey[50];
			l_TempKey[51] = m_Key[51] - l_TempKey[54];
			l_TempKey[55] = (m_Key[15] - m_Key[46]) - l_TempKey[16];
			l_TempKey[52] = m_Key[52] - l_TempKey[38];
			l_TempKey[53] = m_Key[53] - l_TempKey[44];
			l_TempKey[19] = m_Key[54] - l_TempKey[0];
			l_TempKey[20] = (m_Key[0] - m_Key[31]) - l_TempKey[1];
			l_TempKey[21] = (m_Key[1] - m_Key[32]) - l_TempKey[2];
			l_TempKey[22] = (m_Key[2] - m_Key[33]) - l_TempKey[3];
			l_TempKey[23] = (m_Key[3] - m_Key[34]) - l_TempKey[4];
			l_TempKey[24] = (m_Key[4] - m_Key[35]) - l_TempKey[5];
			l_TempKey[25] = (m_Key[5] - m_Key[36]) - l_TempKey[6];
			l_TempKey[26] = (m_Key[6] - m_Key[37]) - l_TempKey[7];
			l_TempKey[27] = (m_Key[7] - m_Key[38]) - l_TempKey[8];
			l_TempKey[28] = (m_Key[8] - m_Key[39]) - l_TempKey[9];
			l_TempKey[29] = (m_Key[9] - m_Key[40]) - l_TempKey[10];
			l_TempKey[30] = (m_Key[10] - m_Key[41]) - l_TempKey[11];
			l_TempKey[31] = (m_Key[11] - m_Key[42]) - l_TempKey[12];
			l_TempKey[32] = (m_Key[12] - m_Key[43]) - l_TempKey[13];
			l_TempKey[33] = (m_Key[13] - m_Key[44]) - l_TempKey[14];
			l_TempKey[34] = (m_Key[14] - m_Key[45]) - l_TempKey[15];
			l_TempKey[35] = (m_Key[16] - m_Key[47]) - l_TempKey[17];
			l_TempKey[18] = (m_Key[17] - m_Key[48]) - l_TempKey[36];
			l_TempKey[37] = (m_Key[18] - m_Key[49]) - l_TempKey[40];
			l_TempKey[41] = (m_Key[19] - m_Key[50]) - l_TempKey[46];
			l_TempKey[47] = (m_Key[22] - m_Key[53]) - l_TempKey[53];
			l_TempKey[42] = (m_Key[20] - m_Key[51]) - l_TempKey[51];
			l_TempKey[6] -= l_TempKey[32];
			l_TempKey[43] = (m_Key[21] - m_Key[52]) - l_TempKey[52];
			l_TempKey[48] = (m_Key[23] - m_Key[54]) - l_TempKey[19];
			l_TempKey[39] -= l_TempKey[20];
			l_TempKey[45] -= l_TempKey[21];
			l_TempKey[50] -= l_TempKey[22];
			l_TempKey[54] -= l_TempKey[23];
			l_TempKey[38] -= l_TempKey[24];
			l_TempKey[44] -= l_TempKey[25];
			l_TempKey[0] -= l_TempKey[26];
			l_TempKey[1] -= l_TempKey[27];
			l_TempKey[2] -= l_TempKey[28];
			l_TempKey[3] -= l_TempKey[29];
			l_TempKey[4] -= l_TempKey[30];
			l_TempKey[5] -= l_TempKey[31];
			l_TempKey[7] -= l_TempKey[33];
			l_TempKey[8] -= l_TempKey[34];
			l_TempKey[9] -= l_TempKey[55];
			l_TempKey[10] -= l_TempKey[35];
			l_TempKey[11] -= l_TempKey[18];
			l_TempKey[12] -= l_TempKey[37];
			l_TempKey[13] -= l_TempKey[41];
			l_TempKey[14] -= l_TempKey[42];
			l_TempKey[15] -= l_TempKey[43];
			l_TempKey[16] -= l_TempKey[47];
			l_TempKey[17] -= l_TempKey[48];
			l_TempKey[36] -= l_TempKey[39];
			l_TempKey[40] -= l_TempKey[45];
			l_TempKey[46] -= l_TempKey[50];
			l_TempKey[51] -= l_TempKey[54];
			l_TempKey[52] -= l_TempKey[38];
			l_TempKey[53] -= l_TempKey[44];
			l_TempKey[19] -= l_TempKey[0];
			l_TempKey[20] -= l_TempKey[1];
			l_TempKey[21] -= l_TempKey[2];
			l_TempKey[22] -= l_TempKey[3];
			l_TempKey[23] -= l_TempKey[4];
			l_TempKey[24] -= l_TempKey[5];
			l_TempKey[25] -= l_TempKey[6];
			l_TempKey[26] -= l_TempKey[7];
			l_TempKey[27] -= l_TempKey[8];
			l_TempKey[28] -= l_TempKey[9];
			l_TempKey[29] -= l_TempKey[10];
			l_TempKey[30] -= l_TempKey[11];
			l_TempKey[31] -= l_TempKey[12];
			l_TempKey[32] -= l_TempKey[13];
			l_TempKey[45] -= l_TempKey[21];
			l_TempKey[50] -= l_TempKey[22];
			l_TempKey[54] -= l_TempKey[23];
			l_TempKey[33] -= l_TempKey[14];
			l_TempKey[38] -= l_TempKey[24];
			l_TempKey[44] -= l_TempKey[25];
			l_TempKey[34] -= l_TempKey[15];
			l_TempKey[55] -= l_TempKey[16];
			l_TempKey[35] -= l_TempKey[17];
			l_TempKey[18] -= l_TempKey[36];
			l_TempKey[37] -= l_TempKey[40];
			l_TempKey[41] -= l_TempKey[46];
			l_TempKey[42] -= l_TempKey[51];
			l_TempKey[43] -= l_TempKey[52];
			l_TempKey[47] -= l_TempKey[53];
			l_TempKey[48] -= l_TempKey[19];
			l_TempKey[39] -= l_TempKey[20];
			l_TempKey[36] -= l_TempKey[39];
			l_TempKey[40] -= l_TempKey[45];
			l_TempKey[46] -= l_TempKey[50];
			l_TempKey[51] -= l_TempKey[54];
			l_TempKey[0] -= l_TempKey[26];
			l_TempKey[1] -= l_TempKey[27];
			l_TempKey[2] -= l_TempKey[28];
			l_TempKey[3] -= l_TempKey[29];
			l_TempKey[4] -= l_TempKey[30];
			l_TempKey[5] -= l_TempKey[31];
			l_TempKey[6] -= l_TempKey[32];
			l_TempKey[7] -= l_TempKey[33];
			l_TempKey[8] -= l_TempKey[34];
			l_TempKey[9] -= l_TempKey[55];
			l_TempKey[10] -= l_TempKey[35];
			l_TempKey[11] -= l_TempKey[18];
			l_TempKey[12] -= l_TempKey[37];
			l_TempKey[13] -= l_TempKey[41];
			l_TempKey[14] -= l_TempKey[42];
			l_TempKey[15] -= l_TempKey[43];
			l_TempKey[16] -= l_TempKey[47];
			l_TempKey[17] -= l_TempKey[48];
			l_TempKey[52] -= l_TempKey[38];
			l_TempKey[53] -= l_TempKey[44];
			m_Key[15] = l_TempKey[55] - l_TempKey[16];
			l_TempKey[19] -= l_TempKey[0];
			m_Key[0] = l_TempKey[20] - l_TempKey[1];
			m_Key[1] = l_TempKey[21] - l_TempKey[2];
			m_Key[2] = l_TempKey[22] - l_TempKey[3];
			m_Key[3] = l_TempKey[23] - l_TempKey[4];
			m_Key[4] = l_TempKey[24] - l_TempKey[5];
			m_Key[5] = l_TempKey[25] - l_TempKey[6];
			m_Key[6] = l_TempKey[26] - l_TempKey[7];
			m_Key[7] = l_TempKey[27] - l_TempKey[8];
			m_Key[8] = l_TempKey[28] - l_TempKey[9];
			m_Key[9] = l_TempKey[29] - l_TempKey[10];
			m_Key[10] = l_TempKey[30] - l_TempKey[11];
			m_Key[11] = l_TempKey[31] - l_TempKey[12];
			m_Key[12] = l_TempKey[32] - l_TempKey[13];
			m_Key[13] = l_TempKey[33] - l_TempKey[14];
			m_Key[14] = l_TempKey[34] - l_TempKey[15];
			m_Key[16] = l_TempKey[35] - l_TempKey[17];
			m_Key[17] = l_TempKey[18] - l_TempKey[36];
			m_Key[18] = l_TempKey[37] - l_TempKey[40];
			m_Key[19] = l_TempKey[41] - l_TempKey[46];
			m_Key[24] = l_TempKey[39] - m_Key[0];
			m_Key[20] = l_TempKey[42] - l_TempKey[51];
			m_Key[21] = l_TempKey[43] - l_TempKey[52];
			m_Key[22] = l_TempKey[47] - l_TempKey[53];
			m_Key[23] = l_TempKey[48] - l_TempKey[19];
			m_Key[25] = l_TempKey[45] - m_Key[1];
			m_Key[26] = l_TempKey[50] - m_Key[2];
			m_Key[27] = l_TempKey[54] - m_Key[3];
			m_Key[28] = l_TempKey[38] - m_Key[4];
			m_Key[29] = l_TempKey[44] - m_Key[5];
			m_Key[30] = l_TempKey[0] - m_Key[6];
			m_Key[31] = l_TempKey[1] - m_Key[7];
			m_Key[32] = l_TempKey[2] - m_Key[8];
			m_Key[33] = l_TempKey[3] - m_Key[9];
			m_Key[34] = l_TempKey[4] - m_Key[10];
			m_Key[35] = l_TempKey[5] - m_Key[11];
			m_Key[36] = l_TempKey[6] - m_Key[12];
			m_Key[37] = l_TempKey[7] - m_Key[13];
			m_Key[38] = l_TempKey[8] - m_Key[14];
			m_Key[39] = l_TempKey[9] - m_Key[15];
			m_Key[40] = l_TempKey[10] - m_Key[16];
			m_Key[41] = l_TempKey[11] - m_Key[17];
			m_Key[42] = l_TempKey[12] - m_Key[18];
			m_Key[43] = l_TempKey[13] - m_Key[19];
			m_Key[44] = l_TempKey[14] - m_Key[20];
			m_Key[45] = l_TempKey[15] - m_Key[21];
			m_Key[46] = l_TempKey[16] - m_Key[22];
			m_Key[47] = l_TempKey[17] - m_Key[23];
			m_Key[48] = l_TempKey[36] - m_Key[24];
			m_Key[49] = l_TempKey[40] - m_Key[25];
			m_Key[50] = l_TempKey[46] - m_Key[26];
			m_Key[51] = l_TempKey[51] - m_Key[27];
			m_Key[52] = l_TempKey[52] - m_Key[28];
			m_Key[53] = l_TempKey[53] - m_Key[29];
			m_Key[54] = l_TempKey[19] - m_Key[30];
			m_KeyIndex = 54;
			return true;
		}
		internal static void IncrementKeyIndex()
        {
			m_KeyIndex += 1;
			if (m_KeyIndex > 54)
			{
				m_KeyIndex = 0;
				RotateKey();
			}
		}
		internal static void RotateKey()
        {
            for (Int32 i = 0; i < 55; i++)
                m_Key[i] -= m_Key[(i + 31) % 55];
        }
		internal static byte[] CipherBuffer(byte[] buffer, Int32 size)
		{
			Int32 intCount;
			Int32 remainder;
			intCount = size / 4;
			remainder = size % 4;
			if (intCount > 0)
			{
				Int32 i;
				for (i = 0; i < intCount; i++)
				{
					IncrementKeyIndex();

					byte[] keyBytes = BitConverter.GetBytes(m_Key[m_KeyIndex]);
					buffer[(i * 4) + 0] ^= keyBytes[0];
					buffer[(i * 4) + 1] ^= keyBytes[1];
					buffer[(i * 4) + 2] ^= keyBytes[2];
					buffer[(i * 4) + 3] ^= keyBytes[3];
				}
				if(remainder > 0)
                {
					IncrementKeyIndex();
					byte[] keyBytes = BitConverter.GetBytes(m_Key[m_KeyIndex]);
					for (Int32 j = 0; remainder > 0; remainder--, j++)
                    {
						buffer[(i * 4) + j] ^= keyBytes[j];
					}
				}
			}
			return buffer;
		}
	}
}
