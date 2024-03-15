namespace CommandShapes
{
	partial class ParallelCode
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lb1 = new System.Windows.Forms.Label();
			this.btnSyntax = new System.Windows.Forms.Button();
			this.btnRun = new System.Windows.Forms.Button();
			this.rtbInput = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// lb1
			// 
			this.lb1.AutoSize = true;
			this.lb1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.lb1.Location = new System.Drawing.Point(12, 19);
			this.lb1.Name = "lb1";
			this.lb1.Size = new System.Drawing.Size(190, 25);
			this.lb1.TabIndex = 17;
			this.lb1.Text = "Program Commands";
			// 
			// btnSyntax
			// 
			this.btnSyntax.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.btnSyntax.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
			this.btnSyntax.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
			this.btnSyntax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btnSyntax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSyntax.Location = new System.Drawing.Point(224, 16);
			this.btnSyntax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSyntax.Name = "btnSyntax";
			this.btnSyntax.Size = new System.Drawing.Size(50, 22);
			this.btnSyntax.TabIndex = 14;
			this.btnSyntax.Text = "Syntax";
			this.btnSyntax.UseVisualStyleBackColor = true;
			this.btnSyntax.Click += new System.EventHandler(this.btnSyntax_Click);
			// 
			// btnRun
			// 
			this.btnRun.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.btnRun.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
			this.btnRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
			this.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRun.Location = new System.Drawing.Point(279, 16);
			this.btnRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(52, 22);
			this.btnRun.TabIndex = 13;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// rtbInput
			// 
			this.rtbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.rtbInput.BackColor = System.Drawing.Color.WhiteSmoke;
			this.rtbInput.Location = new System.Drawing.Point(12, 46);
			this.rtbInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbInput.Name = "rtbInput";
			this.rtbInput.Size = new System.Drawing.Size(320, 457);
			this.rtbInput.TabIndex = 12;
			this.rtbInput.Text = "";
			// 
			// NewProgram
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(343, 514);
			this.Controls.Add(this.lb1);
			this.Controls.Add(this.btnSyntax);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.rtbInput);
			this.Name = "NewProgram";
			this.Text = "NewProgram";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lb1;
		private System.Windows.Forms.Button btnSyntax;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.RichTextBox rtbInput;
	}
}