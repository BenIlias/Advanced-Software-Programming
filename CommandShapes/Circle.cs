using System.Drawing;

namespace CommandShapes
{
	/// <summary>
	/// Circle class for drawing circles on the canvas
	/// </summary>
	public class Circle : Shape
	{
		/// <summary>
		/// Circle constructor
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Circle(Graphics graphics, int x, int y) : base(graphics, x, y)
		{
		}

		/// <summary>
		/// Override Draw method of shape parent class for drawing circles
		/// </summary>
		/// <param name="radius"></param>
		/// <param name="zero"></param>
		/// <param name="color"></param>
		public override void Draw(int radius, int zero, Color color)
		{
			graphics.DrawEllipse(new Pen(color), x - radius, y - radius, 2 * radius, 2 * radius);
		}

		/// <summary>
		/// Override DrawFilled method of shape parent class for drawing filled circles
		/// </summary>
		/// <param name="radius"></param>
		/// <param name="zero"></param>
		/// <param name="color"></param>
		public override void DrawFilled(int radius, int zero, Color color)
		{
			graphics.FillEllipse(new SolidBrush(color), x - radius, y - radius, 2 * radius, 2 * radius);
		}
	}
}
