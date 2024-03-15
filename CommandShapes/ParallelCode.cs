using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandShapes
{
	public partial class ParallelCode : Form
	{
		/// <summary>
		/// Board object for drawing shapes and lines
		/// </summary>
		Board board;


		public ParallelCode()
		{
			InitializeComponent();
			board = new Board(MainForm.Instance.pbOutput);
		}

		/// <summary>
		/// Check the syntax of the commands in the rich text box and show the result in the message box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnSyntax_Click(object sender, EventArgs e)
		{
			// Check the syntax of the commands in the rich text box
			if (await Parser.IsValidSyntax(rtbInput.Text))
			{
				MessageBox.Show("Given syntex is correct.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				// If the syntax is invalid then show syntax error
				await MainForm.Instance.ShowSyntaxError();
			}
		}

		/// <summary>
		/// Run the commands in the rich text box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnRun_Click(object sender, EventArgs e)
		{
			// Run the commands in the rich text box
			await MainForm.Instance.Run(rtbInput.Text, board);

		}
	}
}
