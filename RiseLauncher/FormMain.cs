using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ionic.Zip;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiseLauncher.Properties;

namespace RiseLauncher
{
	// Token: 0x0200000B RID: 11
	public partial class FormMain : Form
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00002A4C File Offset: 0x00000C4C
		public FormMain()
		{
			base.FormBorderStyle = FormBorderStyle.None;
			this.InitializeComponent();
			try
			{
				new DropShadow().ApplyShadows(this);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			this.registerLanguages();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002AB0 File Offset: 0x00000CB0
		private void registerLanguages()
		{
			string country = this.getCountry();
			FormMain.languages.Add("tr", new Turkey());
			FormMain.languages.Add("none", new UnitedKingdom());
			bool flag = country.Equals("tr");
			if (flag)
			{
				FormMain.currentLanguage = FormMain.languages["tr"];
			}
			else
			{
				FormMain.currentLanguage = FormMain.languages["none"];
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002B2C File Offset: 0x00000D2C
		private unsafe void AddFontFromMemory(PrivateFontCollection pfc)
		{
			try
			{
				Stream manifestResourceStream = base.GetType().Assembly.GetManifestResourceStream("RiseLauncher.Resources.gilroy.otf");
				byte[] array = new byte[manifestResourceStream.Length];
				manifestResourceStream.Read(array, 0, (int)manifestResourceStream.Length);
				manifestResourceStream.Close();
				try
				{
					byte[] array2;
					byte* value;
					if ((array2 = array) == null || array2.Length == 0)
					{
						value = null;
					}
					else
					{
						value = &array2[0];
					}
					pfc.AddMemoryFont((IntPtr)((void*)value), array.Length);
				}
				finally
				{
					byte[] array2 = null;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002BD8 File Offset: 0x00000DD8
		public static string Base64Encode(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(bytes);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002BFC File Offset: 0x00000DFC
		public void updateText(string text)
		{
			text = this.getMessage(text);
			try
			{
				bool invokeRequired = this.statusText.InvokeRequired;
				if (invokeRequired)
				{
					this.statusText.Invoke(new Action(delegate()
					{
						this.statusText.Text = text;
					}));
				}
				else
				{
					this.statusText.Text = text;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002C90 File Offset: 0x00000E90
		public void updateProgress(long percent)
		{
			base.BeginInvoke(new MethodInvoker(delegate()
			{
				try
				{
					bool invokeRequired = this.javaProgress.InvokeRequired;
					if (invokeRequired)
					{
						this.javaProgress.Invoke(new Action(delegate()
						{
							this.javaProgress.Value = percent;
						}));
					}
					else
					{
						this.javaProgress.Value = percent;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}));
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002CC8 File Offset: 0x00000EC8
		public void start()
		{
			try
			{
				PrivateFontCollection privateFontCollection = new PrivateFontCollection();
				this.AddFontFromMemory(privateFontCollection);
				this.statusText.Font = new Font(privateFontCollection.Families[0], 13f);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			this.updateText("Java sürümü kontrol ediliyor...");
			bool datasFromSite = this.getDatasFromSite();
			bool flag = !datasFromSite;
			if (flag)
			{
				bool flag2 = this.loadDatasFromCache();
				bool flag3 = !flag2;
				if (flag3)
				{
					this.updateText("CraftRise sunucularına bağlanılamıyor.");
					return;
				}
			}
			bool flag4 = this.isJavaInstalled();
			bool flag5 = !flag4;
			if (!flag5)
			{
				this.checkLauncherFile();
				goto IL_CF;
			}
			this.updateText("Java indiriliyor...");
			bool flag6 = this.DownloadJava();
			bool flag7 = !flag6;
			if (flag7)
			{
				this.updateText("Java yükleme işlemi başarısız, antivirüs aktif ise kapatın.");
				return;
			}
			goto IL_CF;
			IL_CF:
			goto IL_D3;
			for (;;)
			{
				IL_D3:
				goto IL_D3;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002DC0 File Offset: 0x00000FC0
		private bool getDatasFromSite()
		{
			bool flag = true;
			int num = 3;
			int num2 = 0;
			string content = this.getContent(FormMain.API_URL);
			while (content == null || string.IsNullOrEmpty(content))
			{
				content = this.getContent(FormMain.API_URL);
				bool flag2 = content == null || string.IsNullOrEmpty(content);
				if (!flag2)
				{
					flag = true;
					break;
				}
				try
				{
					Thread.Sleep(3000);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
				flag = false;
				bool flag3 = num2++ >= num;
				if (flag3)
				{
					break;
				}
			}
			bool flag4 = !flag;
			bool result;
			if (flag4)
			{
				result = flag;
			}
			else
			{
				try
				{
					JObject api_JSON = JObject.Parse(content);
					FormMain.API_JSON = api_JSON;
				}
				catch (Exception ex2)
				{
					Console.WriteLine(ex2.ToString());
					return false;
				}
				string content2 = this.getContent(this.getSelectedJavaURL());
				bool flag5 = content2 == null || string.IsNullOrEmpty(content2);
				if (flag5)
				{
					result = false;
				}
				else
				{
					try
					{
						JObject java_JSON = JObject.Parse(content2);
						FormMain.JAVA_JSON = java_JSON;
					}
					catch (Exception ex3)
					{
						Console.WriteLine(ex3.ToString());
						return false;
					}
					this.updateJSONCache(content, content2);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002F1C File Offset: 0x0000111C
		private bool loadDatasFromCache()
		{
			bool result;
			try
			{
				string text = File.ReadAllText(this.getHashFileCache());
				string text2 = File.ReadAllText(this.getJavaFileCache());
				try
				{
					JObject api_JSON = JObject.Parse(text);
					FormMain.API_JSON = api_JSON;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					return false;
				}
				try
				{
					JObject java_JSON = JObject.Parse(text2);
					FormMain.JAVA_JSON = java_JSON;
				}
				catch (Exception ex2)
				{
					Console.WriteLine(ex2.ToString());
					return false;
				}
				result = (FormMain.API_JSON != null && FormMain.JAVA_JSON != null && FormMain.API_JSON.Count > 0 && FormMain.JAVA_JSON.Count > 0);
			}
			catch (Exception ex3)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002FF4 File Offset: 0x000011F4
		private void updateJSONCache(string hashs, string java)
		{
			try
			{
				try
				{
					File.Delete(this.getHashFileCache());
					File.Delete(this.getJavaFileCache());
				}
				catch (Exception ex)
				{
				}
				File.WriteAllText(this.getHashFileCache(), hashs);
				File.WriteAllText(this.getJavaFileCache(), java);
			}
			catch (Exception ex2)
			{
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003064 File Offset: 0x00001264
		public bool DownloadFileWithRange(string link, string FilePath, int id)
		{
			bool flag = File.Exists(FilePath);
			if (flag)
			{
				File.Delete(FilePath);
			}
			long num = 0L;
			long num2 = 0L;
			long num3 = 0L;
			int num4 = 0;
			while (num2 == 0L || num < num2)
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
				bool flag2 = num > 0L;
				if (flag2)
				{
					httpWebRequest.AddRange(num);
				}
				try
				{
					WebResponse response = httpWebRequest.GetResponse();
					Console.WriteLine("=============== Request #{0} ==================", ++num4);
					foreach (object obj in response.Headers)
					{
					}
					bool flag3 = response.ContentLength > num2;
					if (flag3)
					{
						num2 = response.ContentLength;
					}
					Stream responseStream = response.GetResponseStream();
					num3 = 0L;
					try
					{
						using (Stream responseStream2 = response.GetResponseStream())
						{
							using (FileStream fileStream = new FileStream(FilePath, FileMode.Append))
							{
								byte[] array = new byte[4096];
								int num5;
								while ((num5 = responseStream2.Read(array, 0, array.Length)) > 0)
								{
									num += (long)num5;
									num3 += (long)num5;
									fileStream.Write(array, 0, num5);
									long percent = (long)((int)((double)num / (double)num2 * 100.0));
									this.updateProgress(percent);
								}
								Console.WriteLine("Got bytes: {0}", num3);
							}
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine("Got bytes: {0}", num3);
					}
				}
				catch (Exception ex2)
				{
					Console.WriteLine("Can't connect to website!");
					Thread.Sleep(1000);
				}
			}
			return num2 == num;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000032BC File Offset: 0x000014BC
		private void checkLauncherFile()
		{
			this.updateText("Launcher için güncelleme kontrolü yapılıyor...");
			string webLauncherHash = this.getWebLauncherHash();
			string hashFile = UtilFile.getHashFile(this.getLauncherFile());
			bool flag = !hashFile.Equals(webLauncherHash);
			if (flag)
			{
				bool flag2 = this.DownloadLauncherJAR();
				bool flag3 = !flag2;
				if (flag3)
				{
					this.updateText("Launcher indirilemedi, tekrar deneyin. (Bilgisayarınızı yeniden başlatmayı deneyin)");
				}
			}
			else
			{
				this.startLauncher();
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003324 File Offset: 0x00001524
		private void startLauncher()
		{
			this.updateText("Launcher başlatılıyor...");
			int num = 512;
			try
			{
				int ram = UtilRAM.getRam();
				bool flag = ram > 2;
				if (flag)
				{
					num = ram * 256;
					bool flag2 = num > 4096;
					if (flag2)
					{
						num = 4096;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			string text = this.getStartArguments();
			try
			{
				text = text.Replace("%selectedRAM%", num.ToString());
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
				this.updateText("RAM değerleri güncellenemedi, bir hata mevcut.");
			}
			object obj = new JObject();
			if (FormMain.<>o__17.<>p__0 == null)
			{
				FormMain.<>o__17.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "executablepath", typeof(FormMain), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			FormMain.<>o__17.<>p__0.Target(FormMain.<>o__17.<>p__0, obj, Application.ExecutablePath);
			if (FormMain.<>o__17.<>p__3 == null)
			{
				FormMain.<>o__17.<>p__3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(FormMain)));
			}
			Func<CallSite, object, string> target = FormMain.<>o__17.<>p__3.Target;
			CallSite <>p__ = FormMain.<>o__17.<>p__3;
			if (FormMain.<>o__17.<>p__2 == null)
			{
				FormMain.<>o__17.<>p__2 = CallSite<Func<CallSite, FormMain, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName, "Base64Encode", null, typeof(FormMain), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, FormMain, object, object> target2 = FormMain.<>o__17.<>p__2.Target;
			CallSite <>p__2 = FormMain.<>o__17.<>p__2;
			if (FormMain.<>o__17.<>p__1 == null)
			{
				FormMain.<>o__17.<>p__1 = CallSite<Func<CallSite, Type, object, Formatting, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "SerializeObject", null, typeof(FormMain), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			string str = target(<>p__, target2(<>p__2, this, FormMain.<>o__17.<>p__1.Target(FormMain.<>o__17.<>p__1, typeof(JsonConvert), obj, 1)));
			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = UtilJava.getJavaWExePath(),
					Arguments = text + " -jar launcher.jar launcherStartup " + str,
					WorkingDirectory = UtilJava.getLauncherFolderPath(),
					UseShellExecute = false,
					CreateNoWindow = true
				});
			}
			catch (Exception ex3)
			{
				Console.WriteLine(ex3.ToString());
				this.updateText("Launcher başlatılamadı, tekrar deneyin.");
				return;
			}
			Thread.Sleep(1000);
			Environment.Exit(0);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000035D8 File Offset: 0x000017D8
		private string getWebLauncherHash()
		{
			JObject jobject = (JObject)FormMain.API_JSON.GetValue("MAIN");
			return (string)jobject.GetValue("launcher.jar");
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003610 File Offset: 0x00001810
		private string getWebLauncherURL()
		{
			JObject jobject = (JObject)FormMain.API_JSON.GetValue("WINDOWS_BS");
			return (string)jobject.GetValue("launcherURL");
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003648 File Offset: 0x00001848
		public static string getSelectedJavaType()
		{
			JObject jobject = (JObject)FormMain.API_JSON.GetValue("WINDOWS_BS");
			return (string)jobject.GetValue("javaType");
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003680 File Offset: 0x00001880
		private string getSelectedJavaURL()
		{
			JObject jobject = (JObject)FormMain.API_JSON.GetValue("WINDOWS_BS");
			return (string)jobject.GetValue("javaURL");
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000036B8 File Offset: 0x000018B8
		private string getStartArguments()
		{
			JObject jobject = (JObject)FormMain.API_JSON.GetValue("WINDOWS_BS");
			return (string)jobject.GetValue("startArguments");
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000036F0 File Offset: 0x000018F0
		private string getContent(string URL)
		{
			string result;
			try
			{
				WebClient webClient = new WebClient();
				result = webClient.DownloadString(URL);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				result = null;
			}
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003734 File Offset: 0x00001934
		private string getJSONJavaURL()
		{
			JObject jobject = (JObject)FormMain.JAVA_JSON.GetValue("windows");
			JObject jobject2 = (JObject)jobject.GetValue(Environment.Is64BitOperatingSystem ? "64" : "32");
			JObject jobject3 = (JObject)jobject2.GetValue(FormMain.getSelectedJavaType());
			return (string)jobject3.GetValue("url");
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000379C File Offset: 0x0000199C
		private string getJSONJavaKey()
		{
			JObject jobject = (JObject)FormMain.JAVA_JSON.GetValue("windows");
			JObject jobject2 = (JObject)jobject.GetValue(Environment.Is64BitOperatingSystem ? "64" : "32");
			JObject jobject3 = (JObject)jobject2.GetValue(FormMain.getSelectedJavaType());
			return (string)jobject3.GetValue("sha1");
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003804 File Offset: 0x00001A04
		private string getJSONJavaVersion()
		{
			JObject jobject = (JObject)FormMain.JAVA_JSON.GetValue("windows");
			JObject jobject2 = (JObject)jobject.GetValue(Environment.Is64BitOperatingSystem ? "64" : "32");
			JObject jobject3 = (JObject)jobject2.GetValue(FormMain.getSelectedJavaType());
			return (string)jobject3.GetValue("version");
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000386C File Offset: 0x00001A6C
		private bool isJavaInstalled()
		{
			string jsonjavaVersion = this.getJSONJavaVersion();
			string currentJavaVersion = UtilJava.getCurrentJavaVersion();
			bool flag = currentJavaVersion == null || !currentJavaVersion.Equals(jsonjavaVersion);
			return !flag;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000038A4 File Offset: 0x00001AA4
		private string getLauncherFile()
		{
			return UtilJava.getLauncherFolderPath() + "launcher.jar";
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000038C8 File Offset: 0x00001AC8
		private string getHashFileCache()
		{
			return UtilJava.getLauncherFolderPath() + "launcher_hashs.json";
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000038EC File Offset: 0x00001AEC
		private string getJavaFileCache()
		{
			return UtilJava.getLauncherFolderPath() + "launcher_java.json";
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003910 File Offset: 0x00001B10
		private string getCacheLZMAFile()
		{
			return UtilJava.getLauncherFolderPath() + "java.lzma";
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003934 File Offset: 0x00001B34
		private string getCacheLZMAFileZip()
		{
			return UtilJava.getLauncherFolderPath() + "java.zip";
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003958 File Offset: 0x00001B58
		private bool DownloadJava()
		{
			bool result;
			try
			{
				string fileName = this.getCacheLZMAFile();
				try
				{
					bool flag = File.Exists(fileName);
					if (flag)
					{
						File.Delete(fileName);
					}
					bool flag2 = File.Exists(this.getCacheLZMAFileZip());
					if (flag2)
					{
						File.Delete(this.getCacheLZMAFileZip());
					}
					DirectoryInfo directory = new DirectoryInfo(UtilJava.getJavaMainFolderPath());
					directory.ClearFolder();
					bool flag3 = !Directory.Exists(UtilJava.getJavaMainFolderPath());
					if (flag3)
					{
						Directory.CreateDirectory(UtilJava.getJavaMainFolderPath());
					}
					bool flag4 = !Directory.Exists(UtilJava.getJavaFolderPath());
					if (flag4)
					{
						Directory.CreateDirectory(UtilJava.getJavaFolderPath());
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
				this.updateText("Java indiriliyor...");
				Thread thread = new Thread(delegate()
				{
					bool status = this.DownloadFileWithRange(this.getJSONJavaURL(), fileName, 2);
					this.BeginInvoke(new MethodInvoker(delegate()
					{
						bool flag5 = !status;
						if (flag5)
						{
							this.updateText("Java indirilemedi, lütfen tekrar deneyin.");
						}
						else
						{
							this.javaDownloadCompleted();
						}
					}));
				});
				thread.Start();
				result = true;
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003A84 File Offset: 0x00001C84
		private bool DownloadLauncherJAR()
		{
			bool result;
			try
			{
				string fileName = this.getLauncherFile();
				bool flag = File.Exists(fileName);
				if (flag)
				{
					File.Delete(fileName);
				}
				this.updateText("Launcher indiriliyor...");
				Thread thread = new Thread(delegate()
				{
					bool status = this.DownloadFileWithRange(this.getWebLauncherURL(), fileName, 1);
					this.BeginInvoke(new MethodInvoker(delegate()
					{
						bool flag2 = !status;
						if (flag2)
						{
							this.updateText("Launcher indirilemedi, tekrar deneyin. (Bilgisayarınızı yeniden başlatmayı deneyin)");
						}
						else
						{
							bool flag3 = File.Exists(this.getLauncherFile());
							if (flag3)
							{
								this.updateText("Launcher indirildi, dosya kontrol ediliyor...");
								string hashFile = UtilFile.getHashFile(this.getLauncherFile());
								string webLauncherHash = this.getWebLauncherHash();
								bool flag4 = !hashFile.Equals(webLauncherHash);
								if (flag4)
								{
									this.updateText("Launcher indirilemedi, tekrar deneyin. (Bilgisayarınızı yeniden başlatmayı deneyin)");
								}
								else
								{
									this.startLauncher();
								}
							}
						}
					}));
				});
				thread.Start();
				result = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003B18 File Offset: 0x00001D18
		private void javaDownloadCompleted()
		{
			base.BeginInvoke(new MethodInvoker(delegate()
			{
				this.updateProgress(0L);
				bool flag = File.Exists(this.getCacheLZMAFile());
				if (flag)
				{
					this.updateText("Java indirildi, dosya kontrol ediliyor...");
					string hashFile = UtilFile.getHashFile(this.getCacheLZMAFile());
					string jsonjavaKey = this.getJSONJavaKey();
					bool flag2 = !hashFile.Equals(jsonjavaKey);
					if (flag2)
					{
						this.updateText("Java indirilemedi, lütfen tekrar deneyin.");
						return;
					}
				}
				this.updateText("Java dosyaları çıkartılıyor...");
				string cacheLZMAFile = this.getCacheLZMAFile();
				string cacheLZMAFileZip = this.getCacheLZMAFileZip();
				bool flag3 = UtilFile.DecompressLZMA(cacheLZMAFile, cacheLZMAFileZip);
				bool flag4 = !flag3;
				if (flag4)
				{
					this.updateText("Java kurulum işlemi başarısız, antivirüs aktif ise kapatın.");
				}
				else
				{
					try
					{
						ZipFile zipFile = new ZipFile(cacheLZMAFileZip);
						zipFile.ExtractAll(UtilJava.getJavaFolderPath(), 1);
						zipFile.Dispose();
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
						this.updateText("Java kurulum işlemi başarısız, antivirüs aktif ise kapatın.");
						return;
					}
					bool flag5 = File.Exists(this.getCacheLZMAFile());
					if (flag5)
					{
						File.Delete(this.getCacheLZMAFile());
					}
					bool flag6 = File.Exists(this.getCacheLZMAFileZip());
					if (flag6)
					{
						File.Delete(this.getCacheLZMAFileZip());
					}
					this.updateText("Java kuruldu, sürüm kontrolü yapılıyor...");
					string currentJavaVersion = UtilJava.getCurrentJavaVersion();
					string jsonjavaVersion = this.getJSONJavaVersion();
					bool flag7 = currentJavaVersion == null || !currentJavaVersion.Equals(jsonjavaVersion);
					if (flag7)
					{
						this.updateText("Sürüm kontrolü başarısız, sürüm geçersiz.");
					}
					this.checkLauncherFile();
				}
			}));
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000229B File Offset: 0x0000049B
		private void statusText_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003B30 File Offset: 0x00001D30
		public string getCountry()
		{
			string result;
			try
			{
				CultureInfo installedUICulture = CultureInfo.InstalledUICulture;
				result = installedUICulture.TwoLetterISOLanguageName;
			}
			catch (Exception ex)
			{
				result = "tr";
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003B6C File Offset: 0x00001D6C
		public string getMessage(string key)
		{
			return FormMain.currentLanguage.getMessage(key);
		}

		// Token: 0x04000014 RID: 20
		public static Dictionary<string, Language> languages = new Dictionary<string, Language>();

		// Token: 0x04000015 RID: 21
		public static Language currentLanguage;

		// Token: 0x04000016 RID: 22
		public static string API_URL = "https://client.craftrise.network/api/launcher/hashs.php";

		// Token: 0x04000017 RID: 23
		public static JObject API_JSON;

		// Token: 0x04000018 RID: 24
		public static JObject JAVA_JSON;
	}
}
