using Akka.Actor;

namespace HabitableZone.Core.ClientServerMessages
{
	public class ServerConnectionActorMessages
	{
		public class ConnectResponce
		{
			public IActorRef PlayerActorRef { get; set; }
		}

		public class DisconnectResponce { }
	}
}