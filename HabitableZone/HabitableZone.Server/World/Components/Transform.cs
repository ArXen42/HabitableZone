using System;
using Akka.Actor;
using HabitableZone.Core.Geometry;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Server.World.Components
{
	/// <summary>
	///     Represents component which handles position in space.
	/// </summary>
	public sealed class TransformActor : SpaceObjectComponentActor
	{
		public static Props Props(WorldContextFactory worldContextFactory, Transform component)
			=> Akka.Actor.Props.Create(() => new TransformActor(worldContextFactory, component));

		public TransformActor(WorldContextFactory worldContextFactory, Transform component)
			: base(worldContextFactory, component) { }
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