using System;
using Microsoft.VisualBasic.Devices;

namespace RiseLauncher
{
	// Token: 0x02000009 RID: 9
	internal class UtilRAM
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002860 File Offset: 0x00000A60
		private static ulong GetTotalMemoryInBytes()
		{
			return new ComputerInfo().TotalPhysicalMemory;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000287C File Offset: 0x00000A7C
		public static int getRam()
		{
			return Convert.ToInt32(UtilRAM.GetTotalMemoryInBytes() / 1073741824UL);
		}
	}
}
