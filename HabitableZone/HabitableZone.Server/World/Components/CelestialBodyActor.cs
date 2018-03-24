using System;
using HabitableZone.Core.World;

namespace HabitableZone.Server.World.Components
{
	/// <inheritdoc />
	/// <summary>
	///    Represents celestial body. Controls object's Transform.
	/// </summary>
	public abstract class CelestialBodyActor : TickableComponentActor
	{
		protected CelestialBodyActor(WorldContextFactory worldContextFactory, CelestialBody component)
			: base(worldContextFactory, component) { }

		protected override void OnTick(Tick tick)
		{
			throw new NotImplementedException();
		}
	}
}