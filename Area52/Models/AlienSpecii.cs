namespace Area52.Models
{
	public class AlienSpecii
	{
		public int AlienSpeciiId { get; set; }
		public int AlienId { get; set; }
		public int SpeciiId { get; set; }
		public virtual Specii Specii { get; set; }
		public virtual Alien Alien { get; set; }
	}
}