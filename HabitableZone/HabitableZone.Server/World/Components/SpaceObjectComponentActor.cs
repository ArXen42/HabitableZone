using System;
using System.Linq;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Server.World.Components
{
	/// <summary>
	///    Server-side SpaceObject's component actor.
	/// </summary>
	public abstract class SpaceObjectComponentActor : SpaceObjectComponentActorBase
	{
		protected WorldContextFactory WorldContextFactory;

		protected SpaceObjectComponentActor(WorldContextFactory worldContextFactory, SpaceObjectComponent component) :
			base(component)
		{
			WorldContextFactory = worldContextFactory;

			using (var worldContext = worldContextFactory.CreateDbContext())
			{
				// Unlike SpaceObjectActor, it is assumed here that component is already persisted in database.
				// Adding components to already existing SpaceObject is not needed now.
				Boolean idFound = worldContext
					.Components
					.Any(c => c.Id == component.Id);

				if (!idFound)
					throw new ArgumentException("Component with given Id not found.");
			}
		}
	}
}