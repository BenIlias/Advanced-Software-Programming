using System.Drawing;

namespace CommandShapes
{
	public class Rectangle : Shape
	{
		public Rectangle(Graphics graphics, int x, int y) : base(graphics, x, y)
		{
		}

		public override void Draw(int width, int height, Color color)
		{
			graphics.DrawRectangle(new Pen(color), x - (width / 2), y - (height / 2), width, height);
		}

		public override void DrawFilled(int width, int height, Color color)
		{
			graphics.FillRectangle(new SolidBrush(color), x - width / 2, y - height / 2, width, height);
		}
	}
}
