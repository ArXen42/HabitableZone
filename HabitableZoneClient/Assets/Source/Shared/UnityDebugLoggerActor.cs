using System;
using Akka.Actor;
using Akka.Dispatch;
using Akka.Event;
using Debug = UnityEngine.Debug;

namespace HabitableZone.Client.Shared
{
	public class UnityDebugLoggerActor : ReceiveActor, IRequiresMessageQueue<ILoggerMessageQueueSemantics>
	{
		private static String GetLogLevelString(LogLevel logLevel)
		{
			switch (logLevel)
			{
				case LogLevel.DebugLevel:
					return "DEBUG";
				case LogLevel.InfoLevel:
					return "INFO";
				case LogLevel.WarningLevel:
					return "WARNING";
				case LogLevel.ErrorLevel:
					return "ERROR";
				default:
					throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
			}
		}

		private static void Log(LogEvent message)
		{
			Debug.Log($"[{GetLogLevelString(message.LogLevel())}]" +
						 $"[{message.Timestamp}]" +
						 $"[Thread {message.Thread.ManagedThreadId}]" +
						 $"[{message.LogSource}]" +
						 $" {message.Message}");
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="UnityDebugLoggerActor" /> class.
		/// </summary>
		public UnityDebugLoggerActor()
		{
			Receive<Error>(message => Log(message));
			Receive<Warning>(message => Log(message));
			Receive<Info>(message => Log(message));
			Receive<Akka.Event.Debug>(message => Log(message));
			Receive<InitializeLogger>(message =>
			{
				Context.GetLogger().Info("DebugLogger started");
				Sender.Tell(new LoggerInitialized());
			});
		}
	}
}