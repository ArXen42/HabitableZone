using System;

namespace HabitableZone.Core.ClientServerMessages
{
	public class SessionsManagerActorMessages
	{
		public class ConnectRequest
		{
			public Guid PlayerGuid { get; set; }
			public String Nick { get; set; }
		}
	}
}