using System;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	[Serializable]
	public class PolygonShape : Shape
	{
		#region Constructor

		public PolygonShape(RectangleF rect) : base(rect)
		{
		}

		public PolygonShape(RectangleShape rectangle) : base(rectangle)
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
		/// 
		//Point[] PolyPoints = new Point[10];
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			//  base.RotateShape(grfx);

			Point[] p1 = { new Point(100, 100), new Point(200, 100), new Point(200, 50), new Point(50, 0) };

			Point[] p = {
				new Point((int)Rectangle.X + ((int)Rectangle.Width / 2), (int)Rectangle.Y),
				new Point((int)Rectangle.X, (int)(Rectangle.Y + Rectangle.Height)),
				 new Point((int)(Rectangle.X + Rectangle.Width), (int)(Rectangle.Y + Rectangle.Height)),
				new Point((int)(Rectangle.X + Rectangle.Width),(int)Rectangle.Y)
				};



			// diagonal     Point[] p = { new Point((int)Rectangle.X / 2, (int)Rectangle.X / 2), new Point((int)(Rectangle.X + Rectangle.Y), (int)Rectangle.X) };

			grfx.FillPolygon(new SolidBrush(Color.FromArgb(Opacity, FillColor)), p);
			grfx.DrawPolygon(new Pen(BorderColor, BorderWidth), p);

			grfx.ResetTransform();

		}
	}
}
