using System;
using Akka.Actor;
using HabitableZone.Core.Messages;
using UnityEngine;
using Object = System.Object;

namespace HabitableZone.Client.Shared
{
	public class ServerConnectionActor : ReceiveActor, ILogReceive
	{
		public static Props Props(String serverAddress) =>
			Akka.Actor.Props.Create(() => new ServerConnectionActor(serverAddress));

		public ServerConnectionActor(String serverAddress)
		{
			_playersManagerActorRef = Context.ActorSelection($"akka.tcp://HabitableZoneServer@{serverAddress}:8081/user/playersManager");

			Receive<PlayersManagerMessages.ConnectionRequest>(message =>
			{
				Debug.Log("Sending request to server");

				_playersManagerActorRef.Tell(message);
			});


			Receive<PlayersManagerMessages.ConnectionResponce>(message =>
			{
				_playerActorRef = message.PlayerActorRef;
				Debug.Log($"Connected to {_playerActorRef.Path}");
			});
		}

		private ActorSelection _playersManagerActorRef;
		private IActorRef _playerActorRef;
	}
}