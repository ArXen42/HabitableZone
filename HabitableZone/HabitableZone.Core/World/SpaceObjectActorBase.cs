using System;
using Akka.Actor;

namespace HabitableZone.Core.World
{
	/// <inheritdoc />
	/// <summary>
	///    Base SpaceObject actor.
	/// </summary>
	public abstract class SpaceObjectActorBase : ReceiveActor
	{
		protected readonly Guid Id;

		protected SpaceObjectActorBase(SpaceObject so)
		{
			Id = so.Id;
		}
	}
}