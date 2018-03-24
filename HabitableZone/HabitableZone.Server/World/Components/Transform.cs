using System;
using HabitableZone.Core.Geometry;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Server.World.Components
{
	/// <inheritdoc />
	/// <summary>
	///    Data object for Transform component.
	/// </summary>
	public class Transform : SpaceObjectComponent
	{
		/// <summary>
		///    Position of space object.
		/// </summary>
		public Vector2D Position { get; set; }

		/// <summary>
		///    Z axis rotation of space object.
		/// </summary>
		public Double Rotation { get; set; }
	}
}