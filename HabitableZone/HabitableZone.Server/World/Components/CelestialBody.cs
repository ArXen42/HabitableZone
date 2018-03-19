using HabitableZone.Core.World;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Server.World.Components
{
	/// <inheritdoc />
	/// <summary>
	///     Represents celestial body. Controls object's Transform.
	/// </summary>
	public abstract class CelestialBodyActor : TickableComponentActor
	{
		protected CelestialBodyActor(WorldContextFactory worldContextFactory, CelestialBody component)
			: base(worldContextFactory, component) { }

		protected override void OnTick(Tick tick)
		{
			throw new System.NotImplementedException();
		}
	}

	/// <inheritdoc />
	/// <summary>
	///     Data object for CelestialBody component.
	/// </summary>
	public abstract class CelestialBody : SpaceObjectComponent { }
}