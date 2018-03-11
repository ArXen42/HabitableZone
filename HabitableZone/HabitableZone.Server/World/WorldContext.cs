using System;
using HabitableZone.Core.Geometry;
using HabitableZone.Core.World;
using HabitableZone.Server.World.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Converters;

namespace HabitableZone.Server.World
{
	/// <inheritdoc />
	/// <summary>
	///     Provides data storage of world information (space objects, their components, etc).
	/// </summary>
	public class WorldContext : DbContext
	{
		public DbSet<SpaceObject> SpaceObjects { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseLazyLoadingProxies()
				.UseNpgsql(@"Server=localhost;Database=HabitableZone"); //TODO: Configuration
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var vector2DConverter = new ValueConverter<Vector2D, String>(
				v => v.ToString(),
				s => Vector2D.Parse(s));

			modelBuilder
				.Entity<Transform>()
				.Property(t => t.Position).HasConversion(vector2DConverter);
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