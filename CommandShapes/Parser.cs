using System.Collections.Generic;
using System.Drawing;
using System;

namespace CommandShapes
{
	/// <summary>
	/// Parser class for parsing commands from the user
	/// </summary>
	public class Parser
	{
		/// <summary>
		/// Input string from the user
		/// </summary>
		private readonly string input;

		/// <summary>
		/// Parameters from the input string
		/// </summary>
		public List<string> Parameters;

		/// <summary>
		/// Check if fill is on or off
		/// </summary>
		public bool IsFill;

		/// <summary>
		/// Color of the pen
		/// </summary>
		public Color PenColor;

		/// <summary>
		/// Parser constructor.
		/// </summary>
		/// <param name="commands"></param>
		public Parser(string commands)
		{
			// Convert commands to lowercase
			this.input = commands.ToLower();

			// Process input
			Parameters = ProcessInput();

			// Get fill and pen color
			IsFill = GetFill();
			PenColor = GetPenColor();
		}

		/// <summary>
		/// Process input string from the user and return a list of parameters
		/// </summary>
		/// <returns></returns>
		public List<string> ProcessInput()
		{
			try
			{
				// Split input string into commands on basis of space
				string[] commands = GetValues();

				// Check if number of commands is greater than 6 then return empty list
				if (commands.Length > 6) return new List<string>();

				// Create a list of parameters
				List<string> parameters = new List<string>();

				/*
				 * Split the second command on basis of comma 100,400
				 * Add the values to the parameters list
				 */
				string[] values = commands[1].Trim().Split(',');
				parameters.AddRange(values);

				// Add the pen color and fill to the parameters list if they exist
				if (commands.Length > 3) parameters.Add(commands[3]);
				if (commands.Length > 4) parameters.Add(commands[5]);

				// Return the parameters list
				return parameters;
			}
			catch (Exception)
			{ }
			return new List<string>();
		}

		/// <summary>
		/// Get fill value from the parameters list
		/// </summary>
		/// <returns></returns>
		public bool GetFill()
		{
			return GetValues().Length > 5 && GetValues()[5].ToLower() == "on";
		}

		/// <summary>
		/// Get pen color from the parameters list
		/// </summary>
		/// <returns></returns>
		public Color GetPenColor()
		{
			// default color is black
			Color color = Color.Black;
			if (Parameters.Count > 2)
			{
				switch (Parameters[2].ToLower())
				{
					case "red":
						color = Color.Red;
						break;
					case "green":
						color = Color.Green;
						break;
					case "yellow":
						color = Color.Yellow;
						break;
				}
			}
			return color;
		}

		/// <summary>
		/// Get shape type from the input string
		/// </summary>
		/// <returns></returns>
		public string GetShapeType()
		{
			return input.Split(' ')[0];
		}

		/// <summary>
		/// Get space separated values from the input string
		/// </summary>
		/// <returns></returns>
		public string[] GetValues()
		{
			return input.Split(' ');
		}

		/// <summary>
		/// Get the number of values in the input string
		/// </summary>
		/// <returns></returns>
		public int GetValuesLength()
		{
			return GetValues().Length;
		}

		/// <summary>
		/// Check if the input string is valid
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsValidSyntax(string input)
		{
			try
			{
				// Split the input string on basis of new line
				string[] commands = input.ToLower().Split('\n');
				foreach (string command in commands)
				{
					// Split the command on basis of space
					string[] parts = command.Split(' ');
					int numParts = parts.Length;

					// Check if number of parts is 2, 4 or 6
					if (numParts == 2 || numParts == 4 || numParts == 6)
					{
						// Check if the command parts are valid
						if (IsValidCommand(parts))
						{
							// Check if the pen color is valid
							if (numParts > 2 && !IsValidPenColor(parts[3]))
								return false;

							// Check if the fill is valid
							if (numParts > 4 && !IsValidFill(parts[5]))
								return false;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Check if the command parts are valid
		/// </summary>
		/// <param name="parts"></param>
		/// <returns></returns>
		private static bool IsValidCommand(string[] parts)
		{
			// Split the second part of the command on basis of comma
			string[] parameters = parts[1].Split(',');

			// Length of the parameters should be 1 or 2
			if (parameters.Length != 1 && parameters.Length != 2)
				return false;

			// Check if the parameters are valid integers
			if (!int.TryParse(parameters[0], out _))
				return false;

			// If the length of the parameters is 2 then check if the second parameter is a valid integer
			if (parameters.Length == 2 && !int.TryParse(parameters[1], out _))
				return false;

			return true;
		}

		/// <summary>
		/// Check if the pen color is valid
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		private static bool IsValidPenColor(string color)
		{
			// Check if the color is black, red, green or yellow
			return color.ToLower() == "black" || color.ToLower() == "red" || color.ToLower() == "green" || color.ToLower() == "yellow";
		}

		/// <summary>
		/// Check if the fill is valid
		/// </summary>
		/// <param name="fill"></param>
		/// <returns></returns>
		private static bool IsValidFill(string fill)
		{
			return fill.ToLower() == "on" || fill.ToLower() == "off";
		}
	}
}