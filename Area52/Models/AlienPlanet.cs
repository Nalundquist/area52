namespace Area52.Models
{
	public class AlienPlanet
	{
		public int AlienPlanetId { get; set; }
		public int AlienId { get; set; }
		public int PlanetId { get; set; }
		public virtual Planet Planet { get; set; }
		public virtual Alien Alien { get; set; }
	}
}