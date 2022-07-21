using System;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	[Serializable]
	public class IZPITshape : Shape
	{
		#region Constructor

		public IZPITshape(RectangleF rect) : base(rect)
		{
		}

		public IZPITshape(RectangleShape rectangle) : base(rectangle)
		{
		}

		#endregion

		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
			if (base.Contains(point))
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true
				return true;
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);
			base.RotateShape(grfx);
			grfx.FillEllipse(new SolidBrush(Color.FromArgb(Opacity, FillColor)), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawEllipse(new Pen(BorderColor, BorderWidth), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			grfx.DrawLine(new Pen(BorderColor, BorderWidth), Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X + (Rectangle.Width / 70), Rectangle.Y + (Rectangle.Height / 40));
			grfx.DrawLine(new Pen(BorderColor, BorderWidth), Rectangle.X + Rectangle.Width, Rectangle.Y - 100 + Rectangle.Height, Rectangle.X + (Rectangle.Width / 70), Rectangle.Y + 95 + (Rectangle.Height / 70));
			grfx.DrawLine(new Pen(BorderColor, BorderWidth), Rectangle.X + (Rectangle.Width), Rectangle.Y, Rectangle.X + (Rectangle.Width), Rectangle.Y + (Rectangle.Height));
			grfx.ResetTransform();
		}
	}
}
