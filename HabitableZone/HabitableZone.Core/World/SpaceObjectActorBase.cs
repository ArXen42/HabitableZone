using System;
using Akka.Actor;

namespace HabitableZone.Core.World
{
	/// <inheritdoc />
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
}