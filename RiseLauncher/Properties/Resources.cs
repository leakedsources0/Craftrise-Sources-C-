using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace RiseLauncher.Properties
{
	// Token: 0x02000015 RID: 21
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public class Resources
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00004383 File Offset: 0x00002583
		internal Resources()
		{
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00004390 File Offset: 0x00002590
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("RiseLauncher.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000043D8 File Offset: 0x000025D8
		// (set) Token: 0x06000065 RID: 101 RVA: 0x000043EF File Offset: 0x000025EF
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000043F8 File Offset: 0x000025F8
		public static byte[] gilroy
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("gilroy", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00004428 File Offset: 0x00002628
		public static Bitmap icon
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("icon", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x0400002E RID: 46
		private static ResourceManager resourceMan;

		// Token: 0x0400002F RID: 47
		private static CultureInfo resourceCulture;
	}
}
