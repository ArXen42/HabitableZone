using System;
using Akka.Actor;
using Akka.Configuration;
using HabitableZone.Core.Messages;

namespace HabitableZone.Server
{
	internal static class Program
	{
		public static void Main(String[] args)
		{
			var config = ConfigurationFactory.ParseString(@"
akka {  
    actor {
        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
    }
    remote {
        dot-netty.tcp {
            port = 8081
            hostname = 127.0.0.1
        }
    }
}"
			);

			using (var system = ActorSystem.Create("HabitableZoneServer", config))
			{
				var mgr = system.ActorOf<PlayersManagerActor>("playersManager");

				Console.ReadLine();
			}
		}
	}
}