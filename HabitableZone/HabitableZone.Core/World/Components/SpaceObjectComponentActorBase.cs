using System;
using Akka.Actor;

namespace HabitableZone.Core.World.Components
{
	/// <summary>
	///    Base actor for SpaceObject's components.
	/// </summary>
	public abstract class SpaceObjectComponentActorBase : ReceiveActor
	{
		protected Guid Guid;

		protected SpaceObjectComponentActorBase(SpaceObjectComponent component)
		{
			Guid = component.Id;
		}
	}
}