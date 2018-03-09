using System;
using System.IO;
using Akka.Actor;
using Akka.Configuration;
using HabitableZone.Core.World;
using HabitableZone.Server.World;
using Microsoft.EntityFrameworkCore;

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

				var testSpaceObject = new SpaceObject() {Id = Guid.NewGuid()};
				context.SpaceObjects.Add(testSpaceObject);
				context.SaveChanges();
			}
		}
	}
}