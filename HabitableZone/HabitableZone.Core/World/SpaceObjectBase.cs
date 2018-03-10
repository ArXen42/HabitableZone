using System;
using System.Collections.Generic;
using Akka.Actor;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Core.World
{
	public abstract class SpaceObjectActorBase : ReceiveActor { }

	public sealed class SpaceObject
	{
		public Guid Id { get; set; }

		public List<SpaceObjectComponentBase> Components { get; set; }
	}
}