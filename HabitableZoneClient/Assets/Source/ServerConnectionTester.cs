using System;
using Akka.Actor;
using Akka.Configuration;
using HabitableZone.Client.Shared;
using HabitableZone.Core.ClientServerMessages;
using UnityEngine;

namespace HabitableZone.Client
{
	public class ServerConnectionTester : MonoBehaviour
	{
		private void OnEnable()
		{
			var config = ConfigurationFactory.ParseString(@"
akka {  
    actor {
        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""

        debug {
            unhandled = on
        }
    }
    remote {
        dot-netty.tcp {
		    port = 8082
		    hostname = localhost
        }
    }

    loggers = [""HabitableZone.Client.Shared.UnityDebugLoggerActor, Assembly-CSharp""]
}"
			);
			_system = ActorSystem.Create("HabitableZoneClient", config);
			_serverConnectionActorRef = _system.ActorOf(ServerConnectionActor.Props("127.0.0.1"), "serverConnection");

			_serverConnectionActorRef.Tell(
				new SessionsManagerActorMessages.ConnectRequest
				{
					PlayerGuid = Guid.NewGuid(),
					Nick = "ArXen42"
				});
		}

		private void OnDestroy()
		{
			_system.Terminate();
		}

		private ActorSystem _system;
		private IActorRef _serverConnectionActorRef;
	}
}