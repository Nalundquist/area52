using Microsoft.EntityFrameworkCore;

namespace Area52.Models
{
	public class Area52Context : DbContext
	{
		public DbSet<Planet> Planets { get; set; }
		public DbSet<Alien> Aliens { get; set; }
		public DbSet<Specii> Species { get; set; }
		public DbSet<AlienPlanet> AlienPlanet { get; set; }
		public DbSet<AlienSpecii> AlienSpecii { get; set; }
		public DbSet<PlanetSpecii> PlanetSpecii { get; set; }

		public Area52Context(DbContextOptions options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
		}
	}
}