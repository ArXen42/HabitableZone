using System;
using System.Collections.Generic;
using HabitableZone.Core.World.Components;

namespace HabitableZone.Core.World
{
	/// <summary>
	///     SpaceObject data object.
	/// </summary>
	public class SpaceObject
	{
		public Guid Id { get; set; }

		public virtual ICollection<SpaceObjectComponent> Components { get; set; }
	}
}