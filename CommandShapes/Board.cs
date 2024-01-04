using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommandShapes
{
	public class Board
	{
		Graphics graphics;
		int x, y;
		Color[,] colors;
		int PointerSize = 10;
		Bitmap bitmap;

		public Board(PictureBox pictureBox)
		{
			x = y = 0;
			bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
			pictureBox.Image = bitmap;
			graphics = Graphics.FromImage(bitmap);
			colors = new Color[PointerSize, PointerSize];
			Clear();
		}

		private void Remove()
		{
			for (int i = x - 1; i < x + (PointerSize - 1); i++)
			{
				for (int j = y - 1; j < y + (PointerSize - 1); j++)
				{
					try
					{
						bitmap.SetPixel(i, j, colors[i - x + 1, j - y + 1]);
					}
					catch (Exception)
					{ }
				}
			}
		}

		public void DrawShape(string shapeType, int arg1, int arg2, Color penColor, bool isFilled)
		{
			Remove();
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

			if (isFilled)
				currentShape.DrawFilled(arg1, arg2, penColor);
			else
				currentShape.Draw(arg1, arg2, penColor);
			DrawPointer(x, y);
		}

		private void DrawPointer(int toX, int toY)
		{
			TempState(toX, toY);
			graphics.FillEllipse(new SolidBrush(Color.Red), x - 1, y - 1, PointerSize - 2, PointerSize - 2);
		}

		private void TempState(int toX, int toY)
		{
			x = toX;
			y = toY;

			for (int i = x - 1; i < x + (PointerSize - 1); i++)
			{
				for (int j = y - 1; j < y + (PointerSize - 1); j++)
				{
					try
					{
						colors[i - x + 1, j - y + 1] = Color.DarkGray;
						colors[i - x + 1, j - y + 1] = bitmap.GetPixel(i, j);
					}
					catch (Exception)
					{ }
				}
			}
		}

		public void MoveTo(int toX, int toY)
		{
			Remove();
			DrawPointer(toX, toY);
		}

		public void DrawTo(int toX, int toY, Color penColor)
		{
			Remove();
			using (Pen pen = new Pen(penColor, 1f))
			{
				graphics.DrawLine(pen, x, y, toX, toY);
			}
			DrawPointer(toX, toY);
		}

		public void Circle(int radius, Color penColor, bool isFilled)
		{
			DrawShape("circle", radius, 0, penColor, isFilled);
		}

		public void Triangle(int size, Color penColor, bool isFilled)
		{
			DrawShape("triangle", size, 0, penColor, isFilled);
		}

		public void Rectangle(int width, int height, Color penColor, bool isFilled)
		{
			DrawShape("rectangle", width, height, penColor, isFilled);
		}

		public void Clear()
		{
			try
			{
				graphics.Clear(Color.DarkGray);
				x = y = 0;
				DrawPointer(x, y);
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
