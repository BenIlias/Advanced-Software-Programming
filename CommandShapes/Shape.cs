using System.Drawing;

namespace CommandShapes
{
	public abstract class Shape
	{
		protected Graphics graphics;
		protected int x, y;

		protected Shape(Graphics graphics, int x, int y)
		{
			this.graphics = graphics;
			this.x = x;
			this.y = y;
		}

		public abstract void Draw(int arg1, int arg2, Color color);
		public abstract void DrawFilled(int arg1, int arg2, Color color);
	}
}
