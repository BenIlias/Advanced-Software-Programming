using System.Drawing;

namespace CommandShapes
{
	/// <summary>
	/// Triangle class for drawing triangles on the canvas
	/// </summary>
	public class Triangle : Shape
	{
		/// <summary>
		/// Triangle constructor
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Triangle(Graphics graphics, int x, int y) : base(graphics, x, y)
		{
		}

		/// <summary>
		/// Override Draw method of shape parent class for drawing triangles
		/// </summary>
		/// <param name="size"></param>
		/// <param name="zero"></param>
		/// <param name="color"></param>
		public override void Draw(int size, int zero, Color color)
		{
			Point[] points = { new Point(x, y - size), new Point(x - size, y + size), new Point(x + size, y + size) };
			graphics.DrawPolygon(new Pen(color), points);
		}

		/// <summary>
		/// Override DrawFilled method of shape parent class for drawing filled triangles
		/// </summary>
		/// <param name="size"></param>
		/// <param name="zero"></param>
		/// <param name="color"></param>
		public override void DrawFilled(int size, int zero, Color color)
		{
			Point[] points = { new Point(x, y - size), new Point(x - size, y + size), new Point(x + size, y + size) };
			graphics.FillPolygon(new SolidBrush(color), points);
		}
	}
}
