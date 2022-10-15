using System;
using System.Collections.Generic;

namespace RiseLauncher
{
	// Token: 0x02000007 RID: 7
	internal class UnitedKingdom : Language
	{
		// Token: 0x0600001A RID: 26 RVA: 0x000022E7 File Offset: 0x000004E7
		public UnitedKingdom()
		{
			this.init();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002304 File Offset: 0x00000504
		public void init()
		{
			this.messages["CraftRise sunucularına bağlanılamıyor."] = "Unable to connect to CraftRise servers. ";
			this.messages["Java sürümü kontrol ediliyor..."] = "Checking Java version...";
			this.messages["Java indiriliyor..."] = "Downloading Java...";
			this.messages["Java yükleme işlemi başarısız, antivirüs aktif ise kapatın."] = "Java installation failed, if antivirus is active, turn it off.";
			this.messages["Launcher için güncelleme kontrolü yapılıyor..."] = "Checking updates for Launcher...";
			this.messages["Launcher indirilemedi, tekrar deneyin. (Bilgisayarınızı yeniden başlatmayı deneyin)"] = "Launcher failed to download, try again. (Restarting your computer might work)";
			this.messages["Launcher başlatılıyor..."] = "Launching game launcher...";
			this.messages["RAM değerleri güncellenemedi, bir hata mevcut."] = "The RAM values could not be updated, there is an error.";
			this.messages["Launcher başlatılamadı, tekrar deneyin."] = "Launcher failed to start, try again.";
			this.messages["Launcher indiriliyor..."] = "Downloading Launcher...";
			this.messages["Launcher indirildi, dosya kontrol ediliyor..."] = "Launcher downloaded, checking hash...";
			this.messages["Java indirildi, dosya kontrol ediliyor..."] = "Java downloaded, checking hash...";
			this.messages["Java indirilemedi, lütfen tekrar deneyin."] = "Java could not be downloaded, please try again.";
			this.messages["Java dosyaları çıkartılıyor..."] = "Extracting Java files...";
			this.messages["Java kurulum işlemi başarısız, antivirüs aktif ise kapatın."] = "Java installation process failed, if antivirus is active, turn it off.";
			this.messages["Java kuruldu, sürüm kontrolü yapılıyor..."] = "Java installed, version control in progress...";
			this.messages["Sürüm kontrolü başarısız, sürüm geçersiz."] = "Version control failed, version invalid.";
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002488 File Offset: 0x00000688
		public string getCountryCode()
		{
			return "none";
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024A0 File Offset: 0x000006A0
		public string getMessage(string key)
		{
			return (!this.messages.ContainsKey(key)) ? key : this.messages[key];
		}

		// Token: 0x04000013 RID: 19
		private Dictionary<string, string> messages = new Dictionary<string, string>();
	}
}
