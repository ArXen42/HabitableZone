using System;
using System.Linq;
using Akka.Actor;
using Akka.Event;
using HabitableZone.Core.World;

namespace HabitableZone.Server.World
{
	public class SpaceObjectActor : ReceiveActor
	{
		public static Props Props(WorldContextFactory worldContextFactory, Guid id)
			=> Akka.Actor.Props.Create(() => new SpaceObjectActor(worldContextFactory, id));

		public SpaceObjectActor(WorldContextFactory worldContextFactory, Guid id)
		{
			_worldContextFactory = worldContextFactory;
			_id = id;
		}

		protected override void PreStart()
		{
			using (var worldContext = new WorldContext())
			{
				var spaceObject = worldContext
					.SpaceObjects
					.FirstOrDefault(so => so.Id == _id);

				if (spaceObject == null)
					worldContext.Add(new SpaceObject
					{
						Id = _id
					});

				worldContext.SaveChanges();
				_log.Info($"New SpaceObject (Id: {_id}) created");
			}
		}

		private readonly WorldContextFactory _worldContextFactory;
		private readonly Guid _id;

		private readonly ILoggingAdapter _log = Context.GetLogger();
	}
}