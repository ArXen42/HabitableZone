using HabitableZone.Core.World.Components;

namespace HabitableZone.Server.World.Components
{
	/// <summary>
	///     Server-side SpaceObject's component actor.
	/// </summary>
	public abstract class SpaceObjectComponentActor : SpaceObjectComponentActorBase
	{
		protected SpaceObjectComponentActor(SpaceObjectComponent component) : base(component)
		{
		}
	}
}