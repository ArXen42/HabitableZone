using System;
using System.Collections.Generic;
using System.IO;
using Akka.Actor;
using Akka.Configuration;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;
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
			var builder = new ContainerBuilder();
			builder
				.RegisterType<WorldContextFactory>()
				.SingleInstance();

			builder.RegisterType<SessionsManagerActor>();
			builder.RegisterType<WorldContextActor>();

			var container = builder.Build();

			ReinitializeDatabase(container.Resolve<WorldContextFactory>());

			var akkaConfig = ConfigurationFactory.ParseString(File.ReadAllText(@"Properties/ServerConfig.hocon"));
			using (var system = ActorSystem.Create("HabitableZoneServer", akkaConfig))
			{
				var propsResolver = new AutoFacDependencyResolver(container, system);

				var mgr = system.ActorOf(
					system.DI().Props<SessionsManagerActor>(),
					"sessionsManager");

				var worldContextActor = system.ActorOf(
					system.DI().Props<WorldContextActor>(),
					"worldContext");

				Console.ReadLine();
				system.Terminate();
				system.WhenTerminated.Wait();
			}
		}

		/// <summary>
		///    Drops database and fills with predefined data. Temporary solution.
		/// </summary>
		private static void ReinitializeDatabase(WorldContextFactory worldContextFactory)
		{
			using (var context = worldContextFactory.CreateDbContext())
			{
				Console.WriteLine("Dropping database if exists");
				context.Database.EnsureDeleted();

				Console.WriteLine("Creating fresh database with dev data");
				context.Database.EnsureCreated();

				var testSpaceObject = new SpaceObject
				{
					Id = Guid.NewGuid(),
					Components = new List<SpaceObjectComponent>
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