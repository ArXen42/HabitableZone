using System.Linq;
using Akka.Actor;
using Akka.Event;
using HabitableZone.Core.World;

namespace HabitableZone.Server.World
{
	/// <summary>
	///     Server-side space object's actor. Loads components.
	/// </summary>
	public class SpaceObjectActor : SpaceObjectActorBase
	{
		public static Props Props(WorldContextFactory worldContextFactory, SpaceObject so)
			=> Akka.Actor.Props.Create(() => new SpaceObjectActor(worldContextFactory, so));

		public SpaceObjectActor(WorldContextFactory worldContextFactory, SpaceObject so) : base(so)
		{
			_worldContextFactory = worldContextFactory;
		}

		protected override void PreStart()
		{
			using (var worldContext = _worldContextFactory.CreateDbContext())
			{
				var spaceObject = worldContext
					.SpaceObjects
					.FirstOrDefault(so => so.Id == _id);

				if (spaceObject == null)
				{
					worldContext.Add(new SpaceObject
					{
						Id = _id
					});

					worldContext.SaveChanges();
					_log.Info("New SpaceObject created");
				}
				else
				{
					_log.Info("Loaded SpaceObject from database. Restoring components...");
				}

				// TODO: Instantiate components
			}
		}

		private readonly WorldContextFactory _worldContextFactory;
		private readonly ILoggingAdapter _log = Context.GetLogger();
	}
}