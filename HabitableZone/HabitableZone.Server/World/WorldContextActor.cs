using System.Linq;
using Akka.Actor;

namespace HabitableZone.Server.World
{
	public class WorldContextActor : ReceiveActor
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
				foreach (var id in context.SpaceObjects.Select(so => so.Id))
					Context.ActorOf(SpaceObjectActor.Props(_worldContextFactory, id), $"spaceObject_{id}");
			}
		}

		private readonly WorldContextFactory _worldContextFactory;
	}
}