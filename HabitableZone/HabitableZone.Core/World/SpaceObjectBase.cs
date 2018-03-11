using System;
using System.Collections.Generic;
using Akka.Actor;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Core.World
{
	/// <summary>
	///     Base SpaceObject actor.
	/// </summary>
	public abstract class SpaceObjectActorBase : ReceiveActor
	{
		protected SpaceObjectActorBase(SpaceObject so)
		{
			_id = so.Id;
		}

		protected readonly Guid _id;
	}

	/// <summary>
	///     SpaceObject data object.
	/// </summary>
	public class SpaceObject
	{
		public Guid Id { get; set; }

		public virtual ICollection<SpaceObjectComponent> Components { get; set; }
	}
}