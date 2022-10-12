namespace Area52.Models
{
	public class PlanetSpecii
	{
		public int PlanetSpeciiId { get; set; }
		public int SpeciiId { get; set; }
		public int PlanetId { get; set; }
		public virtual Planet Planet { get; set; }
		public virtual Specii Specii { get; set; }
	}
}