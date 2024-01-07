using System.IO;
using System.Windows.Forms;
using System;

namespace CommandShapes
{
	public partial class MainForm : Form
	{
		Board board;

		public MainForm()
		{
			InitializeComponent();
			board = new Board(pbOutput);
		}

		private bool Execute(string command)
		{
			try
			{
				command = command.ToLower();
				Parser parser = new Parser(command);

				if (TryHandleSpecialCommands(command))
				{
					pbOutput.Invalidate();
					return true;
				}

				if (!Parser.IsValidSyntax(command))
				{
					ShowSyntaxError();
					return false;
				}

				ExecuteDrawingCommand(parser);
				pbOutput.Invalidate();
				return true;
			}
			catch (Exception)
			{
				ShowSyntaxError();
				return false;
			}
		}

		private bool TryHandleSpecialCommands(string command)
		{
			if (command.Equals("run"))
			{
				Run(rtbInput.Text);
				return true;
			}
			else if (command.Equals("clear"))
			{
				board.Clear();
				return true;
			}
			else if (command.Equals("reset"))
			{
				ResetApplicationState();
				return true;
			}

			return false;
		}

		private void ExecuteDrawingCommand(Parser parser)
		{
			switch (parser.GetShapeType())
			{
				case "moveto":
					board.MoveTo(Convert.ToInt32(parser.Parameters[0]), Convert.ToInt32(parser.Parameters[1]));
					break;
				case "drawto":
					board.DrawTo(Convert.ToInt32(parser.Parameters[0]), Convert.ToInt32(parser.Parameters[1]), parser.GetPenColor());
					break;
				case "circle":
					board.Circle(Convert.ToInt32(parser.Parameters[0]), parser.GetPenColor(), parser.GetFill());
					break;
				case "triangle":
					board.Triangle(Convert.ToInt32(parser.Parameters[0]), parser.GetPenColor(), parser.GetFill());
					break;
				case "rectangle":
					board.Rectangle(Convert.ToInt32(parser.Parameters[0]), Convert.ToInt32(parser.Parameters[1]), parser.GetPenColor(), parser.GetFill());
					break;
				default:
					ShowSyntaxError();
					break;
			}
		}

		private void ResetApplicationState()
		{
			rtbInput.Text = "";
			textBox1.Text = "";
			lbFilePath.Text = "";
			board.Clear();
		}

		private void ShowSyntaxError()
		{
			MessageBox.Show("Invalid syntex, please try again", "Syntax Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			Run(rtbInput.Text);
			lbFilePath.Text = "";
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (Execute(textBox1.Text)) textBox1.Text = "";
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void btnSyntax_Click(object sender, EventArgs e)
		{
			if (Parser.IsValidSyntax(rtbInput.Text))
			{
				MessageBox.Show("Given syntex is correct.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				lbFilePath.Text = "";
			}
			else
			{
				ShowSyntaxError();
			}
		}

		private void Run(String input)
		{
			try
			{
				if (Parser.IsValidSyntax(input))
				{
					String[] commands = input.Split('\n');
					foreach (String command in commands)
					{
						if (command.Equals("")) continue;
						Execute(command);
					}
				}
				else
				{
					ShowSyntaxError();
				}
			}
			catch (Exception)
			{
				ShowSyntaxError();
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			if (File.Exists(lbFilePath.Text))
			{
				try
				{
					string[] lines = File.ReadAllLines(lbFilePath.Text);
					rtbInput.Text = string.Join(Environment.NewLine, lines);
					lbFilePath.Text = "";
				}
				catch (Exception)
				{
					ShowFileReadError();
				}
			}
			else
			{
				ShowFileNotFoundError();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				string filePath = string.IsNullOrWhiteSpace(lbFilePath.Text) ? ShowSaveFileDialog() : lbFilePath.Text;

				if (string.IsNullOrEmpty(filePath))
					return;

				bool overwrite = File.Exists(filePath);

				if (overwrite && MessageBox.Show("Do you want to overwrite the selected file?", "File Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
					return;

				try
				{
					File.WriteAllText(filePath, rtbInput.Text);
					ShowSaveSuccessMessage();
					lbFilePath.Text = "";
				}
				catch (IOException)
				{
					ShowFileSaveError();
				}
			}
			catch (Exception)
			{
				ShowFileSaveError();
			}
		}

		private string ShowSaveFileDialog()
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
				DialogResult result = saveFileDialog.ShowDialog();

				if (result == DialogResult.OK)
				{
					return saveFileDialog.FileName;
				}

				return null;
			}
		}

		private void ShowFileNotFoundError()
		{
			MessageBox.Show("No file found at the given path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void ShowFileReadError()
		{
			MessageBox.Show("Error reading the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void ShowFileSaveError()
		{
			MessageBox.Show("Error saving the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void ShowSaveSuccessMessage()
		{
			MessageBox.Show("The file has been saved successfully.", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			try
			{
				openFileDialog.Filter = "Text File(*.txt)|*.txt";
				string file = "";
				DialogResult result = openFileDialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					file = openFileDialog.FileName;
					lbFilePath.Text = file;
				}

				if (File.Exists(file))
				{
					string[] lines = File.ReadAllLines(file);
					rtbInput.Text = string.Join(Environment.NewLine, lines);
				}
				else
				{
					ShowFileNotFoundError();
				}
			}
			catch (Exception)
			{
				ShowFileReadError();
				lbFilePath.Text = "";
			}
		}
	}
}