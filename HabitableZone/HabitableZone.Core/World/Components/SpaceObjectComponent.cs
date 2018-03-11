using System;
using Akka.Actor;

namespace HabitableZone.Core.World.Components
{
	/// <summary>
	///     Base actor for SpaceObject's components.
	/// </summary>
	public abstract class SpaceObjectComponentActorBase : ReceiveActor
	{
		protected SpaceObjectComponentActorBase(SpaceObjectComponent component)
		{
			_guid = component.Id;
		}

		protected Guid _guid;
	}

	/// <summary>
	///     Base data type for SpaceObject's components.
	/// </summary>
	public abstract class SpaceObjectComponent
	{
		public Guid Id { get; set; }
	}
}