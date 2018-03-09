using System;
using System.IO;
using Akka.Actor;
using Akka.Configuration;
using HabitableZone.Server.World;

namespace HabitableZone.Server
{
	internal static class Program
	{
		public static void Main(String[] args)
		{
			var config = ConfigurationFactory.ParseString(File.ReadAllText(@"Properties/ServerConfig.hocon"));

			using (var system = ActorSystem.Create("HabitableZoneServer", config))
			{
				var mgr = system.ActorOf<SessionsManagerActor>("sessionsManager");
				var worldContextActor = system.ActorOf(WorldContextActor.Props(new WorldContextFactory()));

				Console.ReadLine();
			}
		}
	}
}