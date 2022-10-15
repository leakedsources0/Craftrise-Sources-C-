using System;
using System.IO;
using System.Security.Cryptography;
using SevenZip.Compression.LZMA;

namespace RiseLauncher
{
	// Token: 0x0200000A RID: 10
	public static class UtilFile
	{
		// Token: 0x06000028 RID: 40 RVA: 0x000028A0 File Offset: 0x00000AA0
		public static string getHashFile(string pathName)
		{
			string result;
			try
			{
				SHA1CryptoServiceProvider sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
				FileStream fileStream = UtilFile.GetFileStream(pathName);
				byte[] value = sha1CryptoServiceProvider.ComputeHash(fileStream);
				fileStream.Close();
				string text = BitConverter.ToString(value);
				text = text.Replace("-", "");
				result = text.ToLower();
			}
			catch (Exception ex)
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002914 File Offset: 0x00000B14
		private static FileStream GetFileStream(string pathName)
		{
			return new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002930 File Offset: 0x00000B30
		public static void ClearFolder(this DirectoryInfo directory)
		{
			try
			{
				foreach (FileInfo fileInfo in directory.GetFiles())
				{
					fileInfo.Delete();
				}
				foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
				{
					directoryInfo.Delete(true);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000029A4 File Offset: 0x00000BA4
		public static bool DecompressLZMA(string inFile, string outFile)
		{
			bool result;
			try
			{
				Decoder decoder = new Decoder();
				FileStream fileStream = new FileStream(inFile, FileMode.Open);
				FileStream fileStream2 = new FileStream(outFile, FileMode.Create);
				byte[] array = new byte[5];
				fileStream.Read(array, 0, 5);
				byte[] array2 = new byte[8];
				fileStream.Read(array2, 0, 8);
				long num = BitConverter.ToInt64(array2, 0);
				decoder.SetDecoderProperties(array);
				decoder.Code(fileStream, fileStream2, fileStream.Length, num, null);
				fileStream2.Flush();
				fileStream2.Close();
				result = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				result = false;
			}
			return result;
		}
	}
}
