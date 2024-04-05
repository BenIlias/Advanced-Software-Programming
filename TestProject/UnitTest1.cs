namespace TestProject
{
	using CommandShapes;

	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Parameters()
		{
			Parser parser = new Parser("rectangle 10,20");
			Assert.That(parser.Parameters[0], Is.EqualTo("10"));
			Assert.That(parser.Parameters[1], Is.EqualTo("20"));
		}

		[Test]
		public void Fill()
		{
			Parser parser = new Parser("rectangle 10,20 pen red fill on");
			Assert.That(parser.IsFill, Is.True);
			parser = new Parser("rectangle 10,20 pen red fill off");
			Assert.That(parser.IsFill, Is.False);
			parser = new Parser("rectangle 10,20 pen red");
			Assert.That(parser.IsFill, Is.False);
			parser = new Parser("rectangle 10,20");
			Assert.That(parser.IsFill, Is.False);
		}

		[Test]
		public void Color()
		{
			Parser parser = new Parser("rectangle 10,20 pen red");
			Assert.That(parser.PenColor, Is.EqualTo(System.Drawing.Color.Red));
			parser = new Parser("rectangle 10,20 pen green");
			Assert.That(parser.PenColor, Is.EqualTo(System.Drawing.Color.Green));
			parser = new Parser("rectangle 10,20 pen yellow");
			Assert.That(parser.PenColor, Is.EqualTo(System.Drawing.Color.Yellow));
			parser = new Parser("rectangle 10,20 pen black");
			Assert.That(parser.PenColor, Is.EqualTo(System.Drawing.Color.Black));
			parser = new Parser("rectangle 10,20");
			Assert.That(parser.PenColor, Is.EqualTo(System.Drawing.Color.Black));
		}

		[Test]
		public void ShapeType()
		{
			Parser parser = new Parser("rectangle 10,20 pen red");
			Assert.That(parser.GetShapeType(), Is.EqualTo("rectangle"));
			parser = new Parser("circle 10,20 pen red");
			Assert.That(parser.GetShapeType(), Is.EqualTo("circle"));
			parser = new Parser("triangle 10,20 pen red");
			Assert.That(parser.GetShapeType(), Is.EqualTo("triangle"));
			parser = new Parser("moveto 10,20");
			Assert.That(parser.GetShapeType(), Is.EqualTo("moveto"));
			parser = new Parser("drawto 10,20 pen red");
			Assert.That(parser.GetShapeType(), Is.EqualTo("drawto"));
		}

		[Test]
		public async Task MoveTo()
		{
			string commands = "moveto 10,20\n" +
				"moveto 30,40";
			Assert.That(await Parser.IsValidSyntax(commands), Is.True);
		}

		[Test]
		public async Task DrawTo()
		{
			string commands = "drawto 10,20\n" +
				"drawto 30,40";
			Assert.That(await Parser.IsValidSyntax(commands), Is.True);
		}

		[Test]
		public async Task Circle()
		{
			string commands = "circle 10,20 pen red\n" +
				"circle 30,40 pen red";
			Assert.That(await Parser.IsValidSyntax(commands), Is.True);
		}

		[Test]
		public async Task Triangle()
		{
			string commands = "triangle 10,20 pen red\n" +
				"triangle 30,40 pen red";
			Assert.That(await Parser.IsValidSyntax(commands), Is.True);
		}

		[Test]
		public async Task Rectangle()
		{
			string commands = "rectangle 10,20 pen red\n" +
				"rectangle 30,40 pen red";
			Assert.That(await Parser.IsValidSyntax(commands), Is.True);
		}

		[Test]
		public async Task FillCommands()
		{
			string commands = "rectangle 10,20 pen red fill on\n" +
				"rectangle 30,40 pen red fill off";
			Assert.That(await Parser.IsValidSyntax(commands), Is.True);
		}

		[Test]
		public async Task PenColor()
		{
			string commands = "rectangle 10,20 pen red\n" +
				"rectangle 30,40 pen green\n" +
				"rectangle 30,40 pen yellow\n" +
				"rectangle 30,40 pen black";
			Assert.That(await Parser.IsValidSyntax(commands), Is.True);
		}

		[Test]
		public async Task SyntexCheck()
		{
			string MultiLineCommands = "moveto 10,20\n" +
				"drawto 10,20 pen red\n" +
				"circle 10,20 pen red\n" +
				"circle 10,34 pen red\n" +
				"triangle 10,45 pen red\n" +
				"rectangle 10,20 pen red\n" +
				"rectangle 10,20 pen black fill on\n" +
				"rectangle 10,20 pen red fill off\n" +
				"moveto 10,20\n" +
				"drawto 10,20 pen yellow\n" +
				"circle 10,10 pen yellow fill on\n" +
				"triangle 10,10 pen green fill on";
			Assert.That(await Parser.IsValidSyntax(MultiLineCommands), Is.True);
		}

		[Test]
		[TestCase("var = var + 20", 40)]
		[TestCase("var = var - 20", 0)]
		[TestCase("var = var * 10", 200)]
		[TestCase("var = var / 10", 2)]
		public void Variables(string operation, int output)
		{
			string var = "var = 20";
			Assert.That(Parser.ExecuteVariableCommand(var), Is.True);
			Assert.That(Parser.Variables[0].Item1, Is.EqualTo("var"));
			Assert.That(Parser.Variables[0].Item2, Is.EqualTo(20));
			Assert.That(Parser.ExecuteVariableCommand(operation), Is.True);
			Assert.That(Parser.Variables[0].Item1, Is.EqualTo("var"));
			Assert.That(Parser.Variables[0].Item2, Is.EqualTo(output));
		}

		[Test]
		[TestCase("if 20 < 21", true)]
		[TestCase("if 20 > 21", false)]
		[TestCase("if 20 <= -21", false)]
		[TestCase("if 20 == 20", true)]
		public void IfCondition(string operation, bool output)
		{
			Assert.That(Parser.CheckCondition("if", operation), Is.EqualTo(output));
		}

		[Test]
		[TestCase("while 20 < 21", true)]
		[TestCase("while 20 > 21", false)]
		[TestCase("while 20 <= -21", false)]
		[TestCase("while 20 == 20", true)]
		public void WhileCondition(string operation, bool output)
		{
			Assert.That(Parser.CheckCondition("while", operation), Is.EqualTo(output));
		}

		[Test]
		[TestCase("if var < 21", true)]
		[TestCase("if var > 21", false)]
		[TestCase("if var <= -21", false)]
		[TestCase("if var == 20", true)]
		public void IfConditionWithVariable(string operation, bool output)
		{
			string var = "var = 20";
			Assert.That(Parser.ExecuteVariableCommand(var), Is.True);
			Assert.That(Parser.CheckCondition("if", operation), Is.EqualTo(output));
		}

		[Test]
		[TestCase("while var < 21", true)]
		[TestCase("while var > 21", false)]
		[TestCase("while var <= -21", false)]
		[TestCase("while var == 20", true)]
		public void WhileConditionWithVariable(string operation, bool output)
		{
			string var = "var = 20";
			Assert.That(Parser.ExecuteVariableCommand(var), Is.True);
			Assert.That(Parser.CheckCondition("while", operation), Is.EqualTo(output));
		}
	}
}