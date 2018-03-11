using System;
using System.Collections.Generic;
using Akka.Actor;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Core.World
{
	/// <summary>
	///     Base SpaceObject actor.
	/// </summary>
	public abstract class SpaceObjectActorBase : ReceiveActor { }

	/// <summary>
	///     SpaceObject data object.
	/// </summary>
	public sealed class SpaceObject
	{
		public Guid Id { get; set; }

		public ICollection<SpaceObjectComponent> Components { get; set; }
	}
}