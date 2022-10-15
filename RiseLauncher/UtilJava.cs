using System;
using System.Diagnostics;
using System.IO;

namespace RiseLauncher
{
	// Token: 0x02000008 RID: 8
	internal class UtilJava
	{
		// Token: 0x0600001E RID: 30 RVA: 0x000024D0 File Offset: 0x000006D0
		public static string getJavaMainFolderPath()
		{
			string launcherFolderPath = UtilJava.getLauncherFolderPath();
			string str = launcherFolderPath + Path.DirectorySeparatorChar.ToString() + "java";
			return str + Path.DirectorySeparatorChar.ToString();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002514 File Offset: 0x00000714
		public static string getJavaFolderPath()
		{
			string launcherFolderPath = UtilJava.getLauncherFolderPath();
			string str = launcherFolderPath + Path.DirectorySeparatorChar.ToString() + "java";
			bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
			bool flag = is64BitOperatingSystem;
			if (flag)
			{
				str = str + Path.DirectorySeparatorChar.ToString() + FormMain.getSelectedJavaType() + "-x64";
			}
			else
			{
				str = str + Path.DirectorySeparatorChar.ToString() + FormMain.getSelectedJavaType() + "-x32";
			}
			return str + Path.DirectorySeparatorChar.ToString();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000025AC File Offset: 0x000007AC
		public static string getJavaExePath()
		{
			string launcherFolderPath = UtilJava.getLauncherFolderPath();
			string text = launcherFolderPath + Path.DirectorySeparatorChar.ToString() + "java";
			bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
			bool flag = is64BitOperatingSystem;
			if (flag)
			{
				text = text + Path.DirectorySeparatorChar.ToString() + FormMain.getSelectedJavaType() + "-x64";
			}
			else
			{
				text = text + Path.DirectorySeparatorChar.ToString() + FormMain.getSelectedJavaType() + "-x32";
			}
			return string.Concat(new string[]
			{
				text,
				Path.DirectorySeparatorChar.ToString(),
				"bin",
				Path.DirectorySeparatorChar.ToString(),
				"java.exe"
			});
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002670 File Offset: 0x00000870
		public static string getJavaWExePath()
		{
			string launcherFolderPath = UtilJava.getLauncherFolderPath();
			string text = launcherFolderPath + Path.DirectorySeparatorChar.ToString() + "java";
			bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
			bool flag = is64BitOperatingSystem;
			if (flag)
			{
				text = text + Path.DirectorySeparatorChar.ToString() + FormMain.getSelectedJavaType() + "-x64";
			}
			else
			{
				text = text + Path.DirectorySeparatorChar.ToString() + FormMain.getSelectedJavaType() + "-x32";
			}
			return string.Concat(new string[]
			{
				text,
				Path.DirectorySeparatorChar.ToString(),
				"bin",
				Path.DirectorySeparatorChar.ToString(),
				"java.exe"
			});
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002734 File Offset: 0x00000934
		public static string getLauncherFolderPath()
		{
			string str = ".craftrise";
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string str2 = folderPath + Path.DirectorySeparatorChar.ToString() + str;
			return str2 + Path.DirectorySeparatorChar.ToString();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002780 File Offset: 0x00000980
		public static string getCurrentJavaVersion()
		{
			string result;
			try
			{
				string text = null;
				Process process = Process.Start(new ProcessStartInfo
				{
					FileName = UtilJava.getJavaExePath(),
					Arguments = " -version",
					CreateNoWindow = true,
					RedirectStandardError = true,
					UseShellExecute = false
				});
				while (!process.StandardError.EndOfStream)
				{
					string text2 = process.StandardError.ReadLine().ToLower();
					bool flag = text2.StartsWith("java version \"");
					if (flag)
					{
						text = text2.Split(new char[]
						{
							' '
						})[2].Replace("\"", "");
						break;
					}
				}
				process.WaitForExit();
				result = text;
			}
			catch (Exception ex)
			{
				result = null;
			}
			return result;
		}
	}
}
