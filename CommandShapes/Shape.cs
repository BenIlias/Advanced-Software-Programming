using System.Drawing;

namespace CommandShapes
{
	/// <summary>
	/// Shape abstract class for drawing different types of shapes on the canvas
	/// </summary>
	public abstract class Shape
	{
		/// <summary>
		/// Graphics object for drawing shapes
		/// </summary>
		protected Graphics graphics;

		/// <summary>
		/// X and Y coordinates
		/// </summary>
		protected int x, y;
		
		/// <summary>
		/// Constructor for Shape
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		protected Shape(Graphics graphics, int x, int y)
		{
			this.graphics = graphics;
			this.x = x;
			this.y = y;
		}

		/// <summary>
		/// Draw method for shapes
		/// </summary>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="color"></param>
		public abstract void Draw(int arg1, int arg2, Color color);

		/// <summary>
		/// DrawFilled method for shapes
		/// </summary>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="color"></param>
		public abstract void DrawFilled(int arg1, int arg2, Color color);
	}
}
