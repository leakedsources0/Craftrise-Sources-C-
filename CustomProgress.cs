using System;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000002 RID: 2
internal class CustomProgress : Control
{
	// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
	public CustomProgress()
	{
		base.SetStyle(ControlStyles.ResizeRedraw, true);
		base.SetStyle(ControlStyles.Selectable, false);
		this.Maximum = 100m;
		this.ForeColor = Color.Red;
		this.BackColor = Color.White;
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000003 RID: 3 RVA: 0x000020AA File Offset: 0x000002AA
	// (set) Token: 0x06000004 RID: 4 RVA: 0x000020B2 File Offset: 0x000002B2
	public decimal Minimum { get; set; }

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000005 RID: 5 RVA: 0x000020BB File Offset: 0x000002BB
	// (set) Token: 0x06000006 RID: 6 RVA: 0x000020C3 File Offset: 0x000002C3
	public decimal Maximum { get; set; }

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000007 RID: 7 RVA: 0x000020CC File Offset: 0x000002CC
	// (set) Token: 0x06000008 RID: 8 RVA: 0x000020E4 File Offset: 0x000002E4
	public decimal Value
	{
		get
		{
			return this.mValue;
		}
		set
		{
			this.mValue = value;
			base.Invalidate();
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000020F8 File Offset: 0x000002F8
	protected override void OnPaint(PaintEventArgs e)
	{
		RectangleF rect = new RectangleF(0f, 0f, (float)(base.Width * (this.Value - this.Minimum) / this.Maximum), (float)base.Height);
		using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
		{
			e.Graphics.FillRectangle(solidBrush, rect);
		}
		base.OnPaint(e);
	}

	// Token: 0x04000003 RID: 3
	private decimal mValue;
}
