using System.Drawing;
using System.Windows.Forms;

namespace CommandShapes
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pbOutput = new PictureBox();
			textBox1 = new TextBox();
			rtbInput = new RichTextBox();
			btnRun = new Button();
			btnSyntax = new Button();
			btnExit = new Button();
			lb1 = new Label();
			lb3 = new Label();
			lb2 = new Label();
			btnSave = new Button();
			lbFilePath = new Label();
			openFileDialog = new OpenFileDialog();
			btnBrowse = new Button();
			((System.ComponentModel.ISupportInitialize)pbOutput).BeginInit();
			SuspendLayout();
			// 
			// pbOutput
			// 
			pbOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			pbOutput.BackColor = Color.DarkGray;
			pbOutput.Location = new Point(468, 40);
			pbOutput.Margin = new Padding(3, 2, 3, 2);
			pbOutput.Name = "pbOutput";
			pbOutput.Size = new Size(689, 562);
			pbOutput.TabIndex = 0;
			pbOutput.TabStop = false;
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			textBox1.BackColor = Color.WhiteSmoke;
			textBox1.Location = new Point(38, 548);
			textBox1.Margin = new Padding(3, 2, 3, 2);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(373, 23);
			textBox1.TabIndex = 1;
			textBox1.KeyDown += textBox1_KeyDown;
			// 
			// rtbInput
			// 
			rtbInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			rtbInput.BackColor = Color.WhiteSmoke;
			rtbInput.Location = new Point(38, 66);
			rtbInput.Margin = new Padding(3, 2, 3, 2);
			rtbInput.Name = "rtbInput";
			rtbInput.Size = new Size(373, 456);
			rtbInput.TabIndex = 2;
			rtbInput.Text = "";
			// 
			// btnRun
			// 
			btnRun.FlatAppearance.BorderColor = Color.DarkGray;
			btnRun.FlatAppearance.CheckedBackColor = Color.Gainsboro;
			btnRun.FlatAppearance.MouseDownBackColor = Color.LightGray;
			btnRun.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
			btnRun.FlatStyle = FlatStyle.Flat;
			btnRun.Location = new Point(350, 37);
			btnRun.Margin = new Padding(3, 2, 3, 2);
			btnRun.Name = "btnRun";
			btnRun.Size = new Size(61, 25);
			btnRun.TabIndex = 3;
			btnRun.Text = "Run";
			btnRun.UseVisualStyleBackColor = true;
			btnRun.Click += btnRun_Click;
			// 
			// btnSyntax
			// 
			btnSyntax.FlatAppearance.BorderColor = Color.DarkGray;
			btnSyntax.FlatAppearance.CheckedBackColor = Color.Gainsboro;
			btnSyntax.FlatAppearance.MouseDownBackColor = Color.LightGray;
			btnSyntax.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
			btnSyntax.FlatStyle = FlatStyle.Flat;
			btnSyntax.Location = new Point(286, 37);
			btnSyntax.Margin = new Padding(3, 2, 3, 2);
			btnSyntax.Name = "btnSyntax";
			btnSyntax.Size = new Size(58, 25);
			btnSyntax.TabIndex = 4;
			btnSyntax.Text = "Syntax";
			btnSyntax.UseVisualStyleBackColor = true;
			btnSyntax.Click += btnSyntax_Click;
			// 
			// btnExit
			// 
			btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnExit.FlatAppearance.BorderColor = Color.DarkGray;
			btnExit.FlatAppearance.CheckedBackColor = Color.Gainsboro;
			btnExit.FlatAppearance.MouseDownBackColor = Color.LightGray;
			btnExit.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
			btnExit.FlatStyle = FlatStyle.Flat;
			btnExit.Location = new Point(1075, 606);
			btnExit.Margin = new Padding(3, 2, 3, 2);
			btnExit.Name = "btnExit";
			btnExit.Size = new Size(82, 25);
			btnExit.TabIndex = 5;
			btnExit.Text = "Exit";
			btnExit.UseVisualStyleBackColor = true;
			btnExit.Click += btnExit_Click;
			// 
			// lb1
			// 
			lb1.AutoSize = true;
			lb1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			lb1.Location = new Point(38, 40);
			lb1.Name = "lb1";
			lb1.Size = new Size(190, 25);
			lb1.TabIndex = 7;
			lb1.Text = "Program Commands";
			// 
			// lb3
			// 
			lb3.AutoSize = true;
			lb3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			lb3.Location = new Point(468, 13);
			lb3.Name = "lb3";
			lb3.Size = new Size(130, 25);
			lb3.TabIndex = 8;
			lb3.Text = "Shapes Board";
			// 
			// lb2
			// 
			lb2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lb2.AutoSize = true;
			lb2.Location = new Point(38, 531);
			lb2.Name = "lb2";
			lb2.Size = new Size(124, 15);
			lb2.TabIndex = 9;
			lb2.Text = "Individual Commands";
			// 
			// btnSave
			// 
			btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnSave.FlatAppearance.BorderColor = Color.DarkGray;
			btnSave.FlatAppearance.CheckedBackColor = Color.Gainsboro;
			btnSave.FlatAppearance.MouseDownBackColor = Color.LightGray;
			btnSave.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
			btnSave.FlatStyle = FlatStyle.Flat;
			btnSave.Location = new Point(364, 577);
			btnSave.Margin = new Padding(3, 2, 3, 2);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(47, 25);
			btnSave.TabIndex = 5;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// lbFilePath
			// 
			lbFilePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			lbFilePath.AutoEllipsis = true;
			lbFilePath.Location = new Point(38, 604);
			lbFilePath.Name = "lbFilePath";
			lbFilePath.Size = new Size(373, 17);
			lbFilePath.TabIndex = 10;
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "program.txt";
			// 
			// btnBrowse
			// 
			btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnBrowse.FlatAppearance.BorderColor = Color.DarkGray;
			btnBrowse.FlatAppearance.CheckedBackColor = Color.Gainsboro;
			btnBrowse.FlatAppearance.MouseDownBackColor = Color.LightGray;
			btnBrowse.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
			btnBrowse.FlatStyle = FlatStyle.Flat;
			btnBrowse.Location = new Point(302, 577);
			btnBrowse.Margin = new Padding(3, 2, 3, 2);
			btnBrowse.Name = "btnBrowse";
			btnBrowse.Size = new Size(56, 25);
			btnBrowse.TabIndex = 5;
			btnBrowse.Text = "Browse";
			btnBrowse.UseVisualStyleBackColor = true;
			btnBrowse.Click += btnBrowse_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1169, 639);
			Controls.Add(lbFilePath);
			Controls.Add(lb2);
			Controls.Add(lb3);
			Controls.Add(lb1);
			Controls.Add(btnBrowse);
			Controls.Add(btnSave);
			Controls.Add(btnExit);
			Controls.Add(btnSyntax);
			Controls.Add(btnRun);
			Controls.Add(rtbInput);
			Controls.Add(textBox1);
			Controls.Add(pbOutput);
			Margin = new Padding(3, 2, 3, 2);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Shape Commands";
			((System.ComponentModel.ISupportInitialize)pbOutput).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pbOutput;
		private TextBox textBox1;
		private RichTextBox rtbInput;
		private Button btnRun;
		private Button btnSyntax;
		private Button btnExit;
		private Label lb1;
		private Label lb2;
		private Label lb3;
		private Button btnLoad;
		private Button btnSave;
		private Label lbFilePath;
		private OpenFileDialog openFileDialog;
		private Button btnBrowse;
	}
}