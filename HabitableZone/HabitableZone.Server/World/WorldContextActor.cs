using HabitableZone.Core.World;

namespace HabitableZone.Server.World
{
	public class WorldContextActor : WorldContextBase
	{
		private readonly WorldContextFactory _worldContextFactory;

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
	}
}