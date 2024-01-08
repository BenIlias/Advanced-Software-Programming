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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pbOutput = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.rtbInput = new System.Windows.Forms.RichTextBox();
			this.btnRun = new System.Windows.Forms.Button();
			this.btnSyntax = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.lb1 = new System.Windows.Forms.Label();
			this.lb3 = new System.Windows.Forms.Label();
			this.lb2 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.lbFilePath = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnBrowse = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
			this.SuspendLayout();
			// 
			// pbOutput
			// 
			this.pbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbOutput.BackColor = System.Drawing.Color.DarkGray;
			this.pbOutput.Location = new System.Drawing.Point(535, 43);
			this.pbOutput.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.pbOutput.Name = "pbOutput";
			this.pbOutput.Size = new System.Drawing.Size(788, 599);
			this.pbOutput.TabIndex = 0;
			this.pbOutput.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.textBox1.Location = new System.Drawing.Point(44, 585);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(425, 22);
			this.textBox1.TabIndex = 1;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// rtbInput
			// 
			this.rtbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.rtbInput.BackColor = System.Drawing.Color.WhiteSmoke;
			this.rtbInput.Location = new System.Drawing.Point(44, 70);
			this.rtbInput.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.rtbInput.Name = "rtbInput";
			this.rtbInput.Size = new System.Drawing.Size(425, 486);
			this.rtbInput.TabIndex = 2;
			this.rtbInput.Text = "";
			// 
			// btnRun
			// 
			this.btnRun.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.btnRun.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
			this.btnRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
			this.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRun.Location = new System.Drawing.Point(400, 39);
			this.btnRun.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(69, 27);
			this.btnRun.TabIndex = 3;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// btnSyntax
			// 
			this.btnSyntax.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.btnSyntax.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
			this.btnSyntax.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
			this.btnSyntax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btnSyntax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSyntax.Location = new System.Drawing.Point(327, 39);
			this.btnSyntax.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnSyntax.Name = "btnSyntax";
			this.btnSyntax.Size = new System.Drawing.Size(67, 27);
			this.btnSyntax.TabIndex = 4;
			this.btnSyntax.Text = "Syntax";
			this.btnSyntax.UseVisualStyleBackColor = true;
			this.btnSyntax.Click += new System.EventHandler(this.btnSyntax_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.btnExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
			this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
			this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Location = new System.Drawing.Point(1228, 646);
			this.btnExit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(93, 27);
			this.btnExit.TabIndex = 5;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// lb1
			// 
			this.lb1.AutoSize = true;
			this.lb1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.lb1.Location = new System.Drawing.Point(44, 43);
			this.lb1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lb1.Name = "lb1";
			this.lb1.Size = new System.Drawing.Size(237, 32);
			this.lb1.TabIndex = 7;
			this.lb1.Text = "Program Commands";
			// 
			// lb3
			// 
			this.lb3.AutoSize = true;
			this.lb3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.lb3.Location = new System.Drawing.Point(535, 14);
			this.lb3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lb3.Name = "lb3";
			this.lb3.Size = new System.Drawing.Size(162, 32);
			this.lb3.TabIndex = 8;
			this.lb3.Text = "Shapes Board";
			// 
			// lb2
			// 
			this.lb2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lb2.AutoSize = true;
			this.lb2.Location = new System.Drawing.Point(44, 566);
			this.lb2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lb2.Name = "lb2";
			this.lb2.Size = new System.Drawing.Size(136, 16);
			this.lb2.TabIndex = 9;
			this.lb2.Text = "Individual Commands";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
			this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
			this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(416, 615);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(53, 27);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// lbFilePath
			// 
			this.lbFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbFilePath.AutoEllipsis = true;
			this.lbFilePath.Location = new System.Drawing.Point(44, 644);
			this.lbFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbFilePath.Name = "lbFilePath";
			this.lbFilePath.Size = new System.Drawing.Size(427, 18);
			this.lbFilePath.TabIndex = 10;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "program.txt";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.btnBrowse.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
			this.btnBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
			this.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
			this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBrowse.Location = new System.Drawing.Point(345, 615);
			this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(64, 27);
			this.btnBrowse.TabIndex = 5;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1336, 682);
			this.Controls.Add(this.lbFilePath);
			this.Controls.Add(this.lb2);
			this.Controls.Add(this.lb3);
			this.Controls.Add(this.lb1);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnSyntax);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.rtbInput);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pbOutput);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shape Commands";
			((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

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