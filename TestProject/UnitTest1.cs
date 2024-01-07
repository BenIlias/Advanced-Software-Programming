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
			Assert.Pass();
			Parser parser = new Parser("rectangle 10,20");
			Assert.That(parser.Parameters[0], Is.EqualTo("rectangle"));
			Assert.That(parser.Parameters[1], Is.EqualTo("10"));
			Assert.That(parser.Parameters[3], Is.EqualTo("20"));
		}

		[Test]
		public void Fill()
		{
			Assert.Pass();
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
			Assert.Pass();
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
			Assert.Pass();
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
		public void SyntexCheck()
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
			Assert.That(Parser.IsValidSyntax(MultiLineCommands), Is.True);
		}
	}
}