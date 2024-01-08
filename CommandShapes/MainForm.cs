using System.IO;
using System.Windows.Forms;
using System;

namespace CommandShapes
{
	/// <summary>
	/// Main form class for the application
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Board object for drawing shapes and lines
		/// </summary>
		Board board;

		/// <summary>
		/// Main form constructor
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			// Create a board object for drawing shapes and lines on the picture box
			board = new Board(pbOutput);
		}

		/// <summary>
		/// Execute the given command
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		private bool Execute(string command)
		{
			try
			{
				// Convert command to lowercase
				command = command.ToLower();

				// Create a parser object for parsing the command
				Parser parser = new Parser(command);

				// Check if command is special command
				if (TryHandleSpecialCommands(command))
				{
					// Update the picture box and return true
					pbOutput.Invalidate();
					return true;
				}

				// Check if command is valid
				if (!Parser.IsValidSyntax(command))
				{
					// If the syntax is invalid then show syntax error and return false
					ShowSyntaxError();
					return false;
				}

				// Execute the drawing command
				ExecuteDrawingCommand(parser);

				// Update the picture box and return true
				pbOutput.Invalidate();
				return true;
			}
			catch (Exception)
			{
				// If an exception occurs then show syntax error and return false
				ShowSyntaxError();
				return false;
			}
		}

		/// <summary>
		/// Handle special commands
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		private bool TryHandleSpecialCommands(string command)
		{
			// Check if command is run
			if (command.Equals("run"))
			{
				// Run the commands in the rich text box
				Run(rtbInput.Text);
				return true;
			}
			// Check if command is clear
			else if (command.Equals("clear"))
			{
				// Clear the picture box
				board.Clear();
				return true;
			}
			// Check if command is reset
			else if (command.Equals("reset"))
			{
				// Reset the application state
				ResetApplicationState();
				return true;
			}

			return false;
		}

		/// <summary>
		/// Execute the drawing command
		/// </summary>
		/// <param name="parser"></param>
		private void ExecuteDrawingCommand(Parser parser)
		{
			// Check the shape type and execute the command accordingly
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
					// If the shape type is invalid then show syntax error
					ShowSyntaxError();
					break;
			}
		}

		/// <summary>
		/// Reset the application state
		/// </summary>
		private void ResetApplicationState()
		{
			// Clear the rich text box and text box
			rtbInput.Text = "";
			textBox1.Text = "";

			// Clear the picture box and set the file path label to empty
			lbFilePath.Text = "";
			board.Clear();
		}

		/// <summary>
		/// Show syntax error message box
		/// </summary>
		private void ShowSyntaxError()
		{
			MessageBox.Show("Invalid syntex, please try again", "Syntax Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Exit the application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// Run the commands in the rich text box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRun_Click(object sender, EventArgs e)
		{
			// Run the commands in the rich text box
			Run(rtbInput.Text);

			// Clear label of the file path if the file was load earlier
			lbFilePath.Text = "";
		}

		/// <summary>
		/// Press enter to execute the command in the text box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			// Check if enter key is pressed
			if (e.KeyCode == Keys.Enter)
			{
				// Execute the command in the text box
				if (Execute(textBox1.Text)) textBox1.Text = "";

				// Set the event as handled
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		/// <summary>
		/// Check the syntax of the commands in the rich text box and show the result in the message box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSyntax_Click(object sender, EventArgs e)
		{
			// Check the syntax of the commands in the rich text box
			if (Parser.IsValidSyntax(rtbInput.Text))
			{
				MessageBox.Show("Given syntex is correct.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				lbFilePath.Text = "";
			}
			else
			{
				// If the syntax is invalid then show syntax error
				ShowSyntaxError();
			}
		}

		/// <summary>
		/// Run the commands in the rich text box
		/// </summary>
		/// <param name="input"></param>
		private void Run(String input)
		{
			try
			{
				// Check the syntax of the commands in the rich text box
				if (Parser.IsValidSyntax(input))
				{
					// Split the commands on basis of new line
					String[] commands = input.Split('\n');
					foreach (String command in commands)
					{
						// If the command is empty then continue
						if (command.Trim().Equals("")) continue;

						// Execute the command
						Execute(command);
					}
				}
				else
				{
					// If the syntax is invalid then show syntax error
					ShowSyntaxError();
				}
			}
			catch (Exception)
			{
				// If an exception occurs then show syntax error
				ShowSyntaxError();
			}
		}

		/// <summary>
		/// Save the commands in the rich text box to a file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				// Check if the file path label is empty or not and show save file dialog accordingly
				string filePath = string.IsNullOrWhiteSpace(lbFilePath.Text) ? ShowSaveFileDialog() : lbFilePath.Text;

				// Check if the file path is empty or not
				if (string.IsNullOrEmpty(filePath))
					return;

				// Check if the file already exists and show overwrite message box accordingly
				bool overwrite = File.Exists(filePath);

				// Check if the user wants to overwrite the file or not
				if (overwrite && MessageBox.Show("Do you want to overwrite the selected file?", "File Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
					return;

				try
				{
					// Write the commands in the rich text box to the file
					File.WriteAllText(filePath, rtbInput.Text);
					// Show save success message box
					ShowSaveSuccessMessage();
					// Set the file path label to the file path
					lbFilePath.Text = "";
				}
				catch (IOException)
				{
					// If an exception occurs then show file save error
					ShowFileSaveError();
				}
			}
			catch (Exception)
			{
				// If an exception occurs then show file save error
				ShowFileSaveError();
			}
		}

		/// <summary>
		/// Show save file dialog
		/// </summary>
		/// <returns></returns>
		private string ShowSaveFileDialog()
		{
			// Show save file dialog of txt files and return the file path
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

		/// <summary>
		/// Show file not found error message box
		/// </summary>
		private void ShowFileNotFoundError()
		{
			MessageBox.Show("No file found at the given path.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		/// <summary>
		/// Show file read error message box
		/// </summary>
		private void ShowFileReadError()
		{
			MessageBox.Show("Error reading the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Show file save error message box
		/// </summary>
		private void ShowFileSaveError()
		{
			MessageBox.Show("Error saving the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Show file save success message box
		/// </summary>
		private void ShowSaveSuccessMessage()
		{
			MessageBox.Show("The file has been saved successfully.", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Browse the file and load the commands in the rich text box from the file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBrowse_Click(object sender, EventArgs e)
		{
			try
			{
				// Show open file dialog of txt files
				openFileDialog.Filter = "Text File(*.txt)|*.txt";
				string file = "";
				DialogResult result = openFileDialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					// Get the file path and set the file path label to the file path
					file = openFileDialog.FileName;
					lbFilePath.Text = file;
				}

				// Check if the file exists or not
				if (File.Exists(file))
				{
					// Read the commands from the file and set the commands in the rich text box
					string[] lines = File.ReadAllLines(file);
					rtbInput.Text = string.Join(Environment.NewLine, lines);
				}
				else
				{
					// If the file does not exist then show file not found error
					ShowFileNotFoundError();
				}
			}
			catch (Exception)
			{
				// If an exception occurs then show file read error and set the file path label to empty
				ShowFileReadError();
				lbFilePath.Text = "";
			}
		}
	}
}