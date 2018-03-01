using System;
using Akka.Actor;
using HabitableZone.Core.Messages;

namespace HabitableZone.Server
{
	/// <summary>
	///    Handles connections with player.
	/// </summary>
	public class PlayersManagerActor : ReceiveActor
	{
		public PlayersManagerActor()
		{
			Receive<PlayersManagerMessages.ConnectionRequest>(message =>
			{
				Console.WriteLine($"Request from {Sender.Path}, nick is {message.Nick}");
				IActorRef childPlayerActorRef = Context.ActorOf<PlayerActor>($"player{message.Nick}");

				var responce = new PlayersManagerMessages.ConnectionResponce
				{
					PlayerActorRef = childPlayerActorRef
				};
				Sender.Tell(responce);
			});
		}
	}
}