using System;
using System.Collections.Generic;
using System.IO;
using Akka.Actor;
using Akka.Configuration;
using HabitableZone.Core.Geometry;
using HabitableZone.Core.World;
using HabitableZone.Core.World.Components;
using HabitableZone.Server.World;
using HabitableZone.Server.World.Components;

namespace HabitableZone.Server
{
	internal static class Program
	{
		public static void Main(String[] args)
		{
			ReinitializeDatabase();

			var akkaConfig = ConfigurationFactory.ParseString(File.ReadAllText(@"Properties/ServerConfig.hocon"));

			using (var system = ActorSystem.Create("HabitableZoneServer", akkaConfig))
			{
				var mgr = system.ActorOf<SessionsManagerActor>("sessionsManager");
				var worldContextActor = system.ActorOf(WorldContextActor.Props(new WorldContextFactory()), "worldContext");

				Console.ReadLine();
				system.Terminate();
				system.WhenTerminated.Wait();
			}
		}

		/// <summary>
		///     Drops database and fills with predefined data. Temporary solution.
		/// </summary>
		private static void ReinitializeDatabase()
		{
			using (var context = new WorldContextFactory().CreateDbContext())
			{
				Console.WriteLine("Dropping database if exists");
				context.Database.EnsureDeleted();

				Console.WriteLine("Creating fresh database with dev data");
				context.Database.EnsureCreated();

				var testSpaceObject = new SpaceObject
				{
					Id = Guid.NewGuid(),
					Components = new List<SpaceObjectComponent>()
					{
						new Transform
						{
							Id = Guid.NewGuid(),
							Position = new Vector2D(1e9, 2e9),
							Rotation = Math.PI / 3
						}
					}
				};
				context.SpaceObjects.Add(testSpaceObject);
				context.SaveChanges();
			}
		}
	}
}