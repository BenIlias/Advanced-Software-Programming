using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommandShapes
{
	/// <summary>
	/// Board class using factory pattern for drawing shapes and lines graphic on the given picture box.
	/// </summary>
	public class Board
	{
		/// <summary>
		/// Graphics object for drawing shapes and lines
		/// </summary>
		Graphics graphics;

		/// <summary>
		/// X and Y coordinates
		/// </summary>
		int x, y;

		/// <summary>
		/// Colors array for storing colors of the pointer background
		/// </summary>
		Color[,] colors;

		/// <summary>
		/// Size for drawing pointer
		/// </summary>
		int PointerSize = 10;

		/// <summary>
		/// Bitmap object for storing the drawing
		/// </summary>
		static Bitmap bitmap;

		/// <summary>
		/// Board constructor
		/// </summary>
		/// <param name="pictureBox"></param>
		public Board(PictureBox pictureBox)
		{
			// Set the initial coordinates to 0
			x = y = 0;

			// Create a bitmap object for storing the drawing
			if(bitmap == null ) 
				bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

			// Set the picture box image to the bitmap
			pictureBox.Image = bitmap;

			// Create a graphics object for drawing shapes and lines
			graphics = Graphics.FromImage(bitmap);

			// Set the background color of the picture box to dark gray
			colors = new Color[PointerSize, PointerSize];

			TempState(x, y);

			DrawPointer(x, y);
		}

		/// <summary>
		/// Remove the pointer from the board
		/// </summary>
		private void Remove()
		{
			for (int i = x - 1; i < x + (PointerSize - 1); i++)
			{
				for (int j = y - 1; j < y + (PointerSize - 1); j++)
				{
					try
					{
						// Set the color to the pointer background from the color stored in the colors array
						bitmap.SetPixel(i, j, colors[i - x + 1, j - y + 1]);
					}
					catch (Exception)
					{ }
				}
			}
		}

		/// <summary>
		/// Factory method for drawing shapes on the board
		/// </summary>
		/// <param name="shapeType"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="penColor"></param>
		/// <param name="isFilled"></param>
		/// <exception cref="ArgumentException"></exception>
		public void DrawShape(string shapeType, int arg1, int arg2, Color penColor, bool isFilled)
		{
			// Remove the pointer from the board
			Remove();

			// Create a shape object based on the shape type
			Shape currentShape;
			switch (shapeType.ToLower())
			{
				case "circle":
					currentShape = new Circle(graphics, x, y);
					break;
				case "triangle":
					currentShape = new Triangle(graphics, x, y);
					break;
				case "rectangle":
					currentShape = new Rectangle(graphics, x, y);
					break;
				default:
					throw new ArgumentException("Invalid shape type");
			}

			// Draw the shape on the board
			if (isFilled)
				currentShape.DrawFilled(arg1, arg2, penColor);
			else
				currentShape.Draw(arg1, arg2, penColor);

			// Draw the pointer on the board
			DrawPointer(x, y);
		}

		/// <summary>
		/// Draw the pointer on the board
		/// </summary>
		/// <param name="toX"></param>
		/// <param name="toY"></param>
		private void DrawPointer(int toX, int toY)
		{
			// Set the color of the pointer background to color stored in the colors array
			TempState(toX, toY);

			// Draw the pointer on the board
			graphics.FillEllipse(new SolidBrush(Color.Red), x - 1, y - 1, PointerSize - 2, PointerSize - 2);
		}

		/// <summary>
		/// Temporarily store the color of the pointer background in the colors array
		/// </summary>
		/// <param name="toX"></param>
		/// <param name="toY"></param>
		private void TempState(int toX, int toY)
		{
			// Update the coordinates
			x = toX;
			y = toY;

			for (int i = x - 1; i < x + (PointerSize - 1); i++)
			{
				for (int j = y - 1; j < y + (PointerSize - 1); j++)
				{
					try
					{
						// Store the color of the pointer background in the colors array, default color is dark gray
						colors[i - x + 1, j - y + 1] = Color.DarkGray;
						colors[i - x + 1, j - y + 1] = bitmap.GetPixel(i, j);
					}
					catch (Exception)
					{ }
				}
			}
		}

		/// <summary>
		/// Move the pointer to the given coordinates
		/// </summary>
		/// <param name="toX"></param>
		/// <param name="toY"></param>
		public void MoveTo(int toX, int toY)
		{
			// Remove the pointer from the board
			Remove();

			// Draw the pointer on the board at the given coordinates
			DrawPointer(toX, toY);
		}

		/// <summary>
		/// Draw a line from the current pointer position to the given coordinates
		/// </summary>
		/// <param name="toX"></param>
		/// <param name="toY"></param>
		/// <param name="penColor"></param>
		public void DrawTo(int toX, int toY, Color penColor)
		{
			// Remove the pointer from the board
			Remove();

			// Draw the line on the board from the current pointer position to the given coordinates
			using (Pen pen = new Pen(penColor, 1f))
			{
				graphics.DrawLine(pen, x, y, toX, toY);
			}

			// Draw the pointer on the board at the given coordinates
			DrawPointer(toX, toY);
		}

		/// <summary>
		/// Circle method for drawing circles on the board
		/// </summary>
		/// <param name="radius"></param>
		/// <param name="penColor"></param>
		/// <param name="isFilled"></param>
		public void Circle(int radius, Color penColor, bool isFilled)
		{
			// Draw the circle on the board
			DrawShape("circle", radius, 0, penColor, isFilled);
		}

		/// <summary>
		/// Triangle method for drawing triangles on the board
		/// </summary>
		/// <param name="size"></param>
		/// <param name="penColor"></param>
		/// <param name="isFilled"></param>
		public void Triangle(int size, Color penColor, bool isFilled)
		{
			// Draw the triangle on the board
			DrawShape("triangle", size, 0, penColor, isFilled);
		}

		/// <summary>
		/// Rectangle method for drawing rectangles on the board
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="penColor"></param>
		/// <param name="isFilled"></param>
		public void Rectangle(int width, int height, Color penColor, bool isFilled)
		{
			// Draw the rectangle on the board
			DrawShape("rectangle", width, height, penColor, isFilled);
		}

		/// <summary>
		/// Clear the drawing
		/// </summary>
		public void Clear()
		{
			try
			{
				// set the background color of the picture box to dark gray
				graphics.Clear(Color.DarkGray);

				// set the initial coordinates to 0
				x = y = 0;

				// draw the pointer on the board at the given coordinates
				DrawPointer(x, y);

				// store dark gray color in the colors array
				for (int i = 0; i < PointerSize; i++)
				{
					for (int j = 0; j < PointerSize; j++)
					{
						colors[i, j] = Color.DarkGray;
					}
				}
			}
			catch (Exception)
			{ }
		}
	}
}
