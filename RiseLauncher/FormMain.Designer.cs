namespace RiseLauncher
{
	// Token: 0x0200000B RID: 11
	public partial class FormMain : global::System.Windows.Forms.Form
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00003B8C File Offset: 0x00001D8C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003BC4 File Offset: 0x00001DC4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RiseLauncher.FormMain));
			this.statusText = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.javaProgress = new global::CustomProgress();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.statusText.Font = new global::System.Drawing.Font("Arial", 12f);
			this.statusText.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.statusText.Location = new global::System.Drawing.Point(12, 261);
			this.statusText.Name = "statusText";
			this.statusText.Size = new global::System.Drawing.Size(360, 51);
			this.statusText.TabIndex = 0;
			this.statusText.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.statusText.UseCompatibleTextRendering = true;
			this.statusText.Click += new global::System.EventHandler(this.statusText_Click);
			this.pictureBox1.Image = global::RiseLauncher.Properties.Resources.icon;
			this.pictureBox1.Location = new global::System.Drawing.Point(121, 80);
			this.pictureBox1.Margin = new global::System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(135, 135);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.javaProgress.BackColor = global::System.Drawing.Color.FromArgb(38, 38, 38);
			this.javaProgress.ForeColor = global::System.Drawing.Color.FromArgb(234, 91, 12);
			this.javaProgress.Location = new global::System.Drawing.Point(0, 396);
			global::CustomProgress customProgress = this.javaProgress;
			int[] array = new int[4];
			array[0] = 100;
			customProgress.Maximum = new decimal(array);
			this.javaProgress.Minimum = new decimal(new int[4]);
			this.javaProgress.Name = "javaProgress";
			this.javaProgress.Size = new global::System.Drawing.Size(400, 5);
			this.javaProgress.TabIndex = 2;
			this.javaProgress.Value = new decimal(new int[4]);
			this.AllowDrop = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(38, 38, 38);
			base.ClientSize = new global::System.Drawing.Size(400, 400);
			base.ControlBox = false;
			base.Controls.Add(this.javaProgress);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.statusText);
			this.Cursor = global::System.Windows.Forms.Cursors.Default;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormMain";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CraftRise Launcher";
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000019 RID: 25
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Label statusText;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400001C RID: 28
		private global::CustomProgress javaProgress;
	}
}
