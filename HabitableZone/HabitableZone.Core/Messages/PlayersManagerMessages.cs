using System;
using Akka.Actor;

namespace HabitableZone.Core.Messages
{
	public static class PlayersManagerMessages
	{
		public class ConnectionRequest
		{
			public String Nick { get; set; }
		}

		public class ConnectionResponce
		{
			public IActorRef PlayerActorRef { get; set; }
		}
	}
}