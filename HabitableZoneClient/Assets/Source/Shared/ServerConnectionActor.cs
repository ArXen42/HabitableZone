using System;
using Akka.Actor;
using Akka.Event;
using HabitableZone.Core.ClientServerMessages;

namespace HabitableZone.Client.Shared
{
	/// <inheritdoc />
	/// <summary>
	///    Handles communication with game server.
	/// </summary>
	public class ServerConnectionActor : ReceiveActor
	{
		public static Props Props(String serverAddress)
		{
			return Akka.Actor.Props.Create(() => new ServerConnectionActor(serverAddress));
		}

		public ServerConnectionActor(String serverAddress)
		{
			_playersManagerActorRef = Context.ActorSelection($"akka.tcp://HabitableZoneServer@{serverAddress}:8081/user/sessionsManager");

			Receive<SessionsManagerActorMessages.ConnectRequest>(message =>
			{
				_log.Info("Sending connect request to server");

				_playersManagerActorRef.Tell(message);
			});

			Receive<ServerConnectionActorMessages.ConnectResponce>(message =>
			{
				_playerActorRef = message.PlayerActorRef;
				_log.Info($"Connected to [{_playerActorRef.Path}]");
			});
		}

		private readonly ActorSelection _playersManagerActorRef;
		private IActorRef _playerActorRef;
		private readonly ILoggingAdapter _log = Context.GetLogger();
	}
}