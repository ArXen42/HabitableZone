using System;
using Akka.Actor;
using Akka.Configuration;
using HabitableZone.Client.Shared;
using HabitableZone.Core.Messages;
using UnityEngine;

namespace HabitableZone.Client
{
	public class ServerConnectionTester : MonoBehaviour
	{
		private ActorSystem _system;

		private void OnEnable()
		{
			var config = ConfigurationFactory.ParseString(@"
akka {  
    actor {
        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
    }
    remote {
        dot-netty.tcp {
		    port = 0
		    hostname = localhost
        }
    }
}"
			);
			Debug.Log("Creating system");
			_system = ActorSystem.Create("MyClient", config);
			Debug.Log("System created");
			var serverConnectionActorRef = _system.ActorOf(ServerConnectionActor.Props("127.0.0.1"), "serverConnection");
			Debug.Log($"Actor created on path {serverConnectionActorRef.Path}");
		}

		private void Start()
		{
			_system
				.ActorSelection(ActorPath.Parse("akka://MyClient/user/serverConnection"))
				.ResolveOne(TimeSpan.FromSeconds(10))
				.Result
				.Tell(new PlayersManagerMessages.ConnectionRequest {Nick = "ArXen42"});
		}
	}
}