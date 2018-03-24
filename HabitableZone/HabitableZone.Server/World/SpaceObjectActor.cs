using System;
using System.Linq;
using Akka.Actor;
using Akka.Event;
using HabitableZone.Core.World;
using HabitableZone.Core.World.Components;
using HabitableZone.Server.World.Components;

namespace HabitableZone.Server.World
{
	/// <summary>
	///    Server-side space object's actor. Loads components.
	/// </summary>
	public class SpaceObjectActor : SpaceObjectActorBase
	{
		private readonly WorldContextFactory _worldContextFactory;
		private readonly ILoggingAdapter _log = Context.GetLogger();

		public SpaceObjectActor(WorldContextFactory worldContextFactory, SpaceObject so) : base(so)
		{
			_worldContextFactory = worldContextFactory;

			using (var worldContext = _worldContextFactory.CreateDbContext())
			{
				var peristedSpaceObject = GetPersistedSpaceObject(worldContext, so);

				foreach (var component in peristedSpaceObject.Components)
				{
					var props = ResolveComponent(component);
					Context.ActorOf(props, $"component_{component.Id}");
				}

				_log.Info($"{peristedSpaceObject.Components.Count} child components loaded.");
			}
		}

		public static Props Props(WorldContextFactory worldContextFactory, SpaceObject so)
		{
			return Akka.Actor.Props.Create(() => new SpaceObjectActor(worldContextFactory, so));
		}

		/// <summary>
		///    Search database for space object with Id identical to Id of given object and returns it.
		///    If such object was not found then given SpaceObject is saved to database and returned back.
		/// </summary>
		private SpaceObject GetPersistedSpaceObject(WorldContext worldContext, SpaceObject so)
		{
			var persistedSpaceObject = worldContext
				.SpaceObjects
				.FirstOrDefault(s => s.Id == so.Id);

			if (persistedSpaceObject == null)
			{
				worldContext.Add(so);
				worldContext.SaveChanges();

				_log.Info("New SpaceObject created and saved to database. Starting components actors...");
			}
			else
			{
				_log.Info("Loaded SpaceObject from database. Starting components actors...");
			}

			return persistedSpaceObject ?? so;
		}

		/// <summary>
		///    Returns Props of given component's data corresponding actor.
		/// </summary>
		private Props ResolveComponent(SpaceObjectComponent component)
		{
			if (component is Transform transform)
				return TransformActor.Props(_worldContextFactory, transform);

			throw new TypeLoadException("Can't find corresponding space object component actor type for given data type.");
		}
	}
}