using System;
using HabitableZone.Core.Geometry;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Server.World.Components
{
	/// <summary>
	///     Represents component which handles position in space.
	/// </summary>
	public sealed class TransformActor : SpaceObjectComponentActor
	{
		public TransformActor(Transform component) : base(component)
		{
			_position = component.Position;
			_rotation = component.Rotation;
		}

		private Vector2D _position;
		private Double _rotation;
	}

	/// <inheritdoc />
	/// <summary>
	///     Data object for Transform component.
	/// </summary>
	public class Transform : SpaceObjectComponent
	{
		/// <summary>
		///     Position of space object.
		/// </summary>
		public Vector2D Position { get; set; }

		/// <summary>
		///     Z axis rotation of space object.
		/// </summary>
		public Double Rotation { get; set; }
	}
}