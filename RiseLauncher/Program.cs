using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Windows.Forms;

namespace RiseLauncher
{
	// Token: 0x02000013 RID: 19
	internal static class Program
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00004324 File Offset: 0x00002524
		[STAThread]
		[HandleProcessCorruptedStateExceptions]
		private static void Main()
		{
			Application.SetCompatibleTextRenderingDefault(false);
			FormMain form = new FormMain();
			new Thread(delegate()
			{
				form.start();
			})
			{
				IsBackground = false
			}.Start();
			Application.Run(form);
		}
	}
}
