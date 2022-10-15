using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RiseLauncher
{
	// Token: 0x02000003 RID: 3
	public class DropShadow
	{
		// Token: 0x0600000A RID: 10
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref DropShadow.MARGINS pMarInset);

		// Token: 0x0600000B RID: 11
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

		// Token: 0x0600000C RID: 12
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("dwmapi.dll")]
		public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

		// Token: 0x0600000D RID: 13 RVA: 0x00002194 File Offset: 0x00000394
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool IsCompositionEnabled()
		{
			bool flag = Environment.OSVersion.Version.Major < 6;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2;
				DropShadow.DwmIsCompositionEnabled(out flag2);
				result = flag2;
			}
			return result;
		}

		// Token: 0x0600000E RID: 14
		[DllImport("dwmapi.dll")]
		private static extern int DwmIsCompositionEnabled(out bool enabled);

		// Token: 0x0600000F RID: 15
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x06000010 RID: 16 RVA: 0x000021CC File Offset: 0x000003CC
		private bool CheckIfAeroIsEnabled()
		{
			bool flag = Environment.OSVersion.Version.Major >= 6;
			bool result;
			if (flag)
			{
				int num = 0;
				DropShadow.DwmIsCompositionEnabled(ref num);
				result = (num == 1);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002210 File Offset: 0x00000410
		public void ApplyShadows(Form form)
		{
			int num = 2;
			DropShadow.DwmSetWindowAttribute(form.Handle, 2, ref num, 4);
			DropShadow.MARGINS margins = new DropShadow.MARGINS
			{
				bottomHeight = 0,
				leftWidth = 0,
				rightWidth = 0,
				topHeight = 0
			};
			DropShadow.DwmExtendFrameIntoClientArea(form.Handle, ref margins);
		}

		// Token: 0x04000004 RID: 4
		private bool _isAeroEnabled = false;

		// Token: 0x04000005 RID: 5
		private bool _isDraggingEnabled = false;

		// Token: 0x04000006 RID: 6
		private const int WM_NCHITTEST = 132;

		// Token: 0x04000007 RID: 7
		private const int WS_MINIMIZEBOX = 131072;

		// Token: 0x04000008 RID: 8
		private const int HTCLIENT = 1;

		// Token: 0x04000009 RID: 9
		private const int HTCAPTION = 2;

		// Token: 0x0400000A RID: 10
		private const int CS_DBLCLKS = 8;

		// Token: 0x0400000B RID: 11
		private const int CS_DROPSHADOW = 131072;

		// Token: 0x0400000C RID: 12
		private const int WM_NCPAINT = 133;

		// Token: 0x0400000D RID: 13
		private const int WM_ACTIVATEAPP = 28;

		// Token: 0x02000004 RID: 4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public struct MARGINS
		{
			// Token: 0x0400000E RID: 14
			public int leftWidth;

			// Token: 0x0400000F RID: 15
			public int rightWidth;

			// Token: 0x04000010 RID: 16
			public int topHeight;

			// Token: 0x04000011 RID: 17
			public int bottomHeight;
		}
	}
}
