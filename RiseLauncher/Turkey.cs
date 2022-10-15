using System;
using System.Collections.Generic;

namespace RiseLauncher
{
	// Token: 0x02000006 RID: 6
	internal class Turkey : Language
	{
		// Token: 0x06000016 RID: 22 RVA: 0x0000227F File Offset: 0x0000047F
		public Turkey()
		{
			this.init();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000229B File Offset: 0x0000049B
		public void init()
		{
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000022A0 File Offset: 0x000004A0
		public string getCountryCode()
		{
			return "tr";
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000022B8 File Offset: 0x000004B8
		public string getMessage(string key)
		{
			return (!this.messages.ContainsKey(key)) ? key : this.messages[key];
		}

		// Token: 0x04000012 RID: 18
		private Dictionary<string, string> messages = new Dictionary<string, string>();
	}
}
