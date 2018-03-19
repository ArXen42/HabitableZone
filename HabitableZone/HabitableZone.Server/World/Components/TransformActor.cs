using Akka.Actor;

namespace HabitableZone.Server.World.Components
{
	/// <inheritdoc />
	/// <summary>
	///     Represents component which handles position in space.
	/// </summary>
	public sealed class TransformActor : SpaceObjectComponentActor
	{
		public static Props Props(WorldContextFactory worldContextFactory, Transform component)
			=> Akka.Actor.Props.Create(() => new TransformActor(worldContextFactory, component));

		public TransformActor(WorldContextFactory worldContextFactory, Transform component)
			: base(worldContextFactory, component) { }
	}
}