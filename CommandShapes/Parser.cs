using System.Collections.Generic;
using System.Drawing;
using System;

namespace CommandShapes
{
	public class Parser
	{
		private readonly string input;
		public List<string> Parameters;
		public bool IsFill;
		public Color PenColor;

		public Parser(string commands)
		{
			this.input = commands.ToLower();
			Parameters = ProcessInput();
			IsFill = GetFill();
			PenColor = GetPenColor();
		}

		public List<string> ProcessInput()
		{
			try
			{
				string[] commands = GetValues();
				if (commands.Length > 6) return new List<string>();

				List<string> parameters = new List<string>();
				string[] values = commands[1].Trim().Split(',');
				parameters.AddRange(values);

				if (commands.Length > 3) parameters.Add(commands[3]);
				if (commands.Length > 4) parameters.Add(commands[5]);

				return parameters;
			}
			catch (Exception)
			{ }
			return new List<string>();
		}

		public bool GetFill()
		{
			return GetValues().Length > 5 && GetValues()[5].ToLower() == "on";
		}

		public Color GetPenColor()
		{
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

		public string GetShapeType()
		{
			return input.Split(' ')[0];
		}

		public string[] GetValues()
		{
			return input.Split(' ');
		}

		public int GetValuesLength()
		{
			return GetValues().Length;
		}

		public static bool IsValidSyntax(string input)
		{
			try
			{
				string[] commands = input.ToLower().Split('\n');
				foreach (string command in commands)
				{
					string[] parts = command.Split(' ');
					int numParts = parts.Length;

					if (numParts == 2 || numParts == 4 || numParts == 6)
					{
						if (IsValidCommand(parts))
						{
							if (numParts > 2 && !IsValidPenColor(parts[3]))
								return false;

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

		private static bool IsValidCommand(string[] parts)
		{
			string[] parameters = parts[1].Split(',');

			if (parameters.Length != 1 && parameters.Length != 2)
				return false;

			if (!int.TryParse(parameters[0], out _))
				return false;

			if (parameters.Length == 2 && !int.TryParse(parameters[1], out _))
				return false;

			return true;
		}

		private static bool IsValidPenColor(string color)
		{
			return color.ToLower() == "black" || color.ToLower() == "red" || color.ToLower() == "green" || color.ToLower() == "yellow";
		}

		private static bool IsValidFill(string fill)
		{
			return fill.ToLower() == "on" || fill.ToLower() == "off";
		}
	}
}