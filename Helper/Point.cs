namespace ProjectEuler.Helper
{
	public class Point
	{
		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public int X { get; set; }

		public int Y { get; set; }

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash *= 23 + this.X.GetHashCode();
				hash *= 23 + this.Y.GetHashCode();
				return hash;
			}
		}

		public override bool Equals(object obj)
		{
			Point point = obj as Point;
			return obj is Point && point.X == this.X && point.Y == this.Y;
		}
	}
}