using Akka.Actor;
using HabitableZone.Core.World;

namespace HabitableZone.Server.World
{
	public class WorldContextActor : WorldContextBase
	{
		public static Props Props(WorldContextFactory worldContextFactory)
			=> Akka.Actor.Props.Create(() => new WorldContextActor(worldContextFactory));

		public WorldContextActor(WorldContextFactory worldContextFactory)
		{
			_worldContextFactory = worldContextFactory;
		}

		protected override void PreStart()
		{
			using (var context = _worldContextFactory.CreateDbContext())
			{
				foreach (var so in context.SpaceObjects)
					Context.ActorOf(SpaceObjectActor.Props(_worldContextFactory, so), $"spaceObject_{so.Id}");
			}
		}

		private readonly WorldContextFactory _worldContextFactory;
	}
}