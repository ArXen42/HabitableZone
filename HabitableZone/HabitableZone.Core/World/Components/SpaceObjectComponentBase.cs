using System;
using Akka.Actor;

namespace HabitableZone.Core.World.Components
{
	public abstract class SpaceObjectComponentActorBase : ReceiveActor
	{
	}

	public abstract class SpaceObjectComponentBase
	{
		public Guid Id { get; set; }
	}
}