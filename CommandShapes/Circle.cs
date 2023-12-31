using System.Drawing;

namespace CommandShapes
{
	public class Circle : Shape
	{
		public Circle(Graphics graphics, int x, int y) : base(graphics, x, y)
		{
		}

		public override void Draw(int radius, int zero, Color color)
		{
			graphics.DrawEllipse(new Pen(color), x - radius, y - radius, 2 * radius, 2 * radius);
		}

		public override void DrawFilled(int radius, int zero, Color color)
		{
			graphics.FillEllipse(new SolidBrush(color), x - radius, y - radius, 2 * radius, 2 * radius);
		}
	}
}
