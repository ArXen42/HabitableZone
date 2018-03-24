using Akka.Actor;
using Akka.Event;
using HabitableZone.Core.ClientServerMessages;

namespace HabitableZone.Server
{
	/// <inheritdoc />
	/// <summary>
	///    Handles communication with outer world.
	/// </summary>
	internal class SessionsManagerActor : ReceiveActor
	{
		private readonly ILoggingAdapter _log = Context.GetLogger();

		public SessionsManagerActor()
		{
			Receive<SessionsManagerActorMessages.ConnectRequest>(message =>
			{
				var playerActorRef = Context.ActorOf(
					ClientSessionActor.Props(message.PlayerGuid, message.Nick, Sender),
					$"player_{message.PlayerGuid}");

				var responce = new ServerConnectionActorMessages.ConnectResponce
				{
					PlayerActorRef = playerActorRef
				};
				Sender.Tell(responce);

				_log.Info($"Connected player {message.PlayerGuid} ({message.Nick}) from [Sender.Path] on [playerActorRef.Path]");
			});
		}
	}
}