using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace RiseLauncher.Properties
{
	// Token: 0x02000016 RID: 22
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.6.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00004458 File Offset: 0x00002658
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000030 RID: 48
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
