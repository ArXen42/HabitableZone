using System;
using HabitableZone.Core.World;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Server.World.Components
{
	/// <inheritdoc />
	/// <summary>
	///     Represents actor which receives tick messages.
	/// </summary>
	public abstract class TickableComponentActor : SpaceObjectComponentActor
	{
		protected TickableComponentActor(WorldContextFactory worldContextFactory, SpaceObjectComponent component)
			: base(worldContextFactory, component)
		{
			Receive<Tick>(tick => OnTick(tick));

			Context
				.System
				.Scheduler
				.ScheduleTellRepeatedly(TimeSpan.Zero, TimeSpan.FromMilliseconds(20), Self, new Tick(), Self);
		}

		protected abstract void OnTick(Tick tick);
	}
}