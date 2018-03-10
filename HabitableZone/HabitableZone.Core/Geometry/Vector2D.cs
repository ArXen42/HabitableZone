using System;

namespace HabitableZone.Core.Geometry
{
	/// <summary>
	///     Provides two-dimensional double-precision mutable vector.
	/// </summary>
	public struct Vector2D : IEquatable<Vector2D>
	{
		public static readonly Vector2D Zero = new Vector2D(0, 0);
		public static readonly Vector2D Up = new Vector2D(0, 1);
		public static readonly Vector2D Down = new Vector2D(0, -1);
		public static readonly Vector2D Right = new Vector2D(1, 0);
		public static readonly Vector2D Left = new Vector2D(-1, 0);

		/// <summary>
		///     Constructs a new Vector2D with given X and Y components.
		/// </summary>
		/// <param name="x">X component.</param>
		/// <param name="y">Y component.</param>
		public Vector2D(Double x, Double y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		///     X component.
		/// </summary>
		public Double X;

		/// <summary>
		///     Y component.
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