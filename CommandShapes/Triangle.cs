using System.Drawing;

namespace CommandShapes
{
	public class Triangle : Shape
	{
		public Triangle(Graphics graphics, int x, int y) : base(graphics, x, y)
		{
		}

		public override void Draw(int size, int zero, Color color)
		{
			Point[] points = { new Point(x, y - size), new Point(x - size, y + size), new Point(x + size, y + size) };
			graphics.DrawPolygon(new Pen(color), points);
		}

		public override void DrawFilled(int size, int zero, Color color)
		{
			Point[] points = { new Point(x, y - size), new Point(x - size, y + size), new Point(x + size, y + size) };
			graphics.FillPolygon(new SolidBrush(color), points);
		}
	}
}
