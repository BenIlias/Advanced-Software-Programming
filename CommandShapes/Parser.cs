using System.Collections.Generic;
using System.Drawing;
using System;
using System.Linq;
using System.Threading.Tasks;

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

		// The varibles used to store the integer values in the program.
		public static List<Tuple<string, int>> Variables { get; private set; } = new List<Tuple<string, int>>();

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
			try
			{
				int ColorIndex = 0;
				ColorIndex = Parameters.IndexOf("red");
				if (ColorIndex > -1)
					return Color.Red;

				ColorIndex = Parameters.IndexOf("green");
				if (ColorIndex > -1)
					return Color.Green;

				ColorIndex = Parameters.IndexOf("yellow");
				if (ColorIndex > -1)
					return Color.Yellow;
			}
			catch (Exception)
			{
			}
			// default color is black
			return Color.Black;
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
		public static Task<bool> IsValidSyntax(string input)
		{
			try
			{
				List<Tuple<string, int>> variables = new List<Tuple<string, int>>();
				// Split the input string on basis of new line
				string[] commands = input.ToLower().Split('\n');
				foreach (string command in commands)
				{
					if(IsKeyword(command))
					{
						continue;
					}

					if (ExecuteVariableCommand(command, variables))
					{
						continue;
					}

					// Split the command on basis of space
					string[] parts = command.Split(' ');
					int numParts = parts.Length;

					// Check if number of parts is 2, 4 or 6
					if (numParts == 2 || numParts == 4 || numParts == 6)
					{
						// Check if the command parts are valid
						if (IsValidCommand(parts, variables))
						{
							// Check if the pen color is valid
							if (numParts > 2 && !IsValidPenColor(parts[3]))
								return Task.FromResult(false);

							// Check if the fill is valid
							if (numParts > 4 && !IsValidFill(parts[5]))
								return Task.FromResult(false);
						}
						else
						{
							return Task.FromResult(false);
						}
					}
					else
					{
						return Task.FromResult(false);
					}
				}
			}
			catch (Exception)
			{
				return Task.FromResult(false);
			}
			return Task.FromResult(true);
		}

		private static bool IsKeyword(string command)
		{
			command = command.ToLower().Trim();
			// Check if the color is black, red, green or yellow
			return command == "endwhile" || command == "endif" || command.StartsWith("while") || command.StartsWith("if");
		}

		/// <summary>
		/// Check if the command parts are valid
		/// </summary>
		/// <param name="parts"></param>
		/// <returns></returns>
		private static bool IsValidCommand(string[] parts, List<Tuple<string, int>> variables = null)
		{
			if (variables == null) variables = Variables;

			// Split the second part of the command on basis of comma
			string[] parameters = parts[1].Split(',');

			// Length of the parameters should be 1 or 2
			if (parameters.Length != 1 && parameters.Length != 2)
				return false;

			// Check if the parameters are valid integers
			try
			{
				GetVariableValue(parameters[0], variables);
			}
			catch (Exception)
			{
				return false;
			}

			// If the length of the parameters is 2 then check if the second parameter is a valid integer
			if (parameters.Length == 2)
			{
				try
				{
					GetVariableValue(parameters[1], variables);
				}
				catch (Exception)
				{
					return false;
				}
			}

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


		public static int GetVariableValue(string value, List<Tuple<string, int>> variables = null)
		{
			if (variables == null) variables = Variables;
			if (IsVariable(value, variables))
			{
				return variables.First(x => x.Item1 == value).Item2;
			}
			else if (int.TryParse(value, out int valueInt))
			{
				return valueInt;
			}
			else
			{
				throw new Exception("Invalid variable name or non-integer value");
			}
		}

		public static bool ExecuteVariableCommand(string command, List<Tuple<string, int>> variables = null)
		{
			if (variables == null) variables = Variables;
			string[] commandArgs = command.Split('=');

			if (commandArgs.Length != 2)
			{
				return false; // Invalid command format
			}

			string variableName = commandArgs[0].Trim();
			string variableValue = commandArgs[1].Trim();

			if (variables.Any(x => x.Item1.Equals(variableName)))
			{
				UpdateVariable(variableName, variableValue, variables);
			}
			else if (int.TryParse(variableValue, out int value))
			{
				variables.Add(new Tuple<string, int>(variableName, value));
			}

			return true;
		}

		private static void UpdateVariable(string variableName, string variableValue, List<Tuple<string, int>> variables = null)
		{
			if (variables == null) variables = Variables;
			if (TryParseExpression(variableValue, out int result, variables))
			{
				variables[variables.FindIndex(x => x.Item1.Equals(variableName))] = new Tuple<string, int>(variableName, result);
			}
			else
			{
				throw new Exception("Invalid expression");
			}
		}

		private static bool TryParseExpression(string expression, out int result, List<Tuple<string, int>> variables = null)
		{
			if (variables == null) variables = Variables;
			char[] operators = { '+', '-', '*', '/' };
			foreach (var op in operators)
			{
				if (expression.Contains(op))
				{
					string[] variableValueArgs = expression.Split(op);
					if (variableValueArgs.Length == 2)
					{
						int value1 = GetVariableValue(variableValueArgs[0].Trim(), variables);
						int value2 = GetVariableValue(variableValueArgs[1].Trim(), variables);

						switch (op)
						{
							case '+':
								result = value1 + value2;
								return true;
							case '-':
								result = value1 - value2;
								return true;
							case '*':
								result = value1 * value2;
								return true;
							case '/':
								if (value2 == 0)
								{
									throw new Exception("Cannot divide by zero");
								}
								result = value1 / value2;
								return true;
						}
					}
				}
			}

			if (int.TryParse(expression, out int valueInt))
			{
				result = valueInt;
				return true;
			}

			result = 0;
			return false;
		}

		public static bool IsVariable(string value, List<Tuple<string, int>> variables = null)
		{
			if (variables == null) variables = Variables;
			return variables.Any(x => x.Item1 == value);
		}

		public static bool CheckCondition(string conditional, string conditionalStatement)
		{
			string condition = conditionalStatement.Substring(conditionalStatement.IndexOf(conditional) + conditional.Length).Trim();

			string[] operands = condition.Split(new string[] { "==", "<=", ">=", "<", ">" }, StringSplitOptions.None);

			string left = operands[0].Trim();
			string right = operands[1].Trim();

			int leftValue = GetVariableValue(left);
			int rightValue = GetVariableValue(right);

			if (condition.Contains("==")) return leftValue == rightValue;
			else if (condition.Contains("<=")) return leftValue <= rightValue;
			else if (condition.Contains(">=")) return leftValue >= rightValue;
			else if (condition.Contains("<")) return leftValue < rightValue;
			else if (condition.Contains(">")) return leftValue > rightValue;

			return true;
		}

		public static int GetEndIndex(int i, string[] commands, string endTag)
		{
			int endIndex = -1;
			for (int j = i; j < commands.Length; j++)
			{
				if (commands[j].Trim().Equals(endTag))
				{
					endIndex = j;
					break;
				}
			}
			return endIndex;
		}
	}
}