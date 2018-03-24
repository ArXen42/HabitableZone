using Akka.Actor;

namespace HabitableZone.Server.World.Components
{
	/// <inheritdoc />
	/// <summary>
	///    Represents component which handles position in space.
	/// </summary>
	public sealed class TransformActor : SpaceObjectComponentActor
	{
		public TransformActor(WorldContextFactory worldContextFactory, Transform component)
			: base(worldContextFactory, component) { }

		public static Props Props(WorldContextFactory worldContextFactory, Transform component)
		{
			return Akka.Actor.Props.Create(() => new TransformActor(worldContextFactory, component));
		}
	}
}