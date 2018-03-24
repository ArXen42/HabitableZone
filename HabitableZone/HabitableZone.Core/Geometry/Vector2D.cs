using System;
using System.Globalization;

namespace HabitableZone.Core.Geometry
{
	/// <summary>
	///    Provides two-dimensional double-precision mutable vector.
	/// </summary>
	public struct Vector2D : IEquatable<Vector2D>
	{
		public static readonly Vector2D Zero = new Vector2D(0, 0);
		public static readonly Vector2D Up = new Vector2D(0, 1);
		public static readonly Vector2D Down = new Vector2D(0, -1);
		public static readonly Vector2D Right = new Vector2D(1, 0);
		public static readonly Vector2D Left = new Vector2D(-1, 0);

		public static Vector2D Parse(String value)
		{
			var split = value.Trim('<', '>').Split(',');
			if (split.Length != 2)
				throw new FormatException();

			Double x = Double.Parse(split[0], CultureInfo.InvariantCulture);
			Double y = Double.Parse(split[1], CultureInfo.InvariantCulture);
			return new Vector2D(x, y);
		}

		/// <summary>
		///    Constructs a new Vector2D with given X and Y components.
		/// </summary>
		/// <param name="x">X component.</param>
		/// <param name="y">Y component.</param>
		public Vector2D(Double x, Double y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		///    X component.
		/// </summary>
		public Double X;

		/// <summary>
		///    Y component.
		/// </summary>
		public Double Y;

		public Boolean Equals(Vector2D other)
		{
			return X.Equals(other.X) && Y.Equals(other.Y);
		}

		public override Boolean Equals(Object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			return obj is Vector2D && Equals((Vector2D) obj);
		}

		public override Int32 GetHashCode()
		{
			unchecked
			{
				return (X.GetHashCode() * 397) ^ Y.GetHashCode();
			}
		}

		public override String ToString()
		{
			return
				$"<{X.ToString(CultureInfo.InvariantCulture)},{Y.ToString(CultureInfo.InvariantCulture)}>";
		}

		public static Boolean operator ==(Vector2D left, Vector2D right)
		{
			return left.Equals(right);
		}

		public static Boolean operator !=(Vector2D left, Vector2D right)
		{
			return !left.Equals(right);
		}
	}
}