using System;

namespace HabitableZone.Core.World.Components
{
	/// <summary>
	///     Base data type for SpaceObject's components.
	/// </summary>
	public abstract class SpaceObjectComponent
	{
		public Guid Id { get; set; }
	}
}