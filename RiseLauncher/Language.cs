using System;

namespace RiseLauncher
{
	// Token: 0x02000005 RID: 5
	public interface Language
	{
		// Token: 0x06000013 RID: 19
		void init();

		// Token: 0x06000014 RID: 20
		string getCountryCode();

		// Token: 0x06000015 RID: 21
		string getMessage(string key);
	}
}
