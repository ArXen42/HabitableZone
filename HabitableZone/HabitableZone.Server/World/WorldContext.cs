using HabitableZone.Core.World;
using HabitableZone.Server.World.Components;
using Microsoft.EntityFrameworkCore;

namespace HabitableZone.Server.World
{
	/// <summary>
	///     Provides data storage of world information (space objects, their components, etc).
	/// </summary>
	public class WorldContext : DbContext
	{
		public DbSet<SpaceObject> SpaceObjects { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseNpgsql(@"Server=localhost;Database=HabitableZone"); //TODO: Configuration
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Transform>();
		}
	}

	public class WorldContextFactory
	{
		public WorldContext CreateDbContext()
		{
			return new WorldContext();
		}
	}
}