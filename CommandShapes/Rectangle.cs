using System.Drawing;

namespace CommandShapes
{
	/// <summary>
	/// Rectangle class for drawing rectangles on the canvas
	/// </summary>
	public class Rectangle : Shape
	{
		/// <summary>
		/// Rectangle constructor
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Rectangle(Graphics graphics, int x, int y) : base(graphics, x, y)
		{
		}

		/// <summary>
		/// Override Draw method of shape parent class for drawing rectangles
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="color"></param>
		public override void Draw(int width, int height, Color color)
		{
			graphics.DrawRectangle(new Pen(color), x - (width / 2), y - (height / 2), width, height);
		}

		/// <summary>
		/// Override DrawFilled method of shape parent class for drawing filled rectangles
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="color"></param>
		public override void DrawFilled(int width, int height, Color color)
		{
			graphics.FillRectangle(new SolidBrush(color), x - width / 2, y - height / 2, width, height);
		}
	}
}
