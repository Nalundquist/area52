using System.Collections.Generic;

namespace Area52.Models
{
  public class Specii
  {
    public Specii()
    {
      this.JoinEntSpec = new HashSet<AlienSpecii>();
      this.JoinPlanSpec = new HashSet<PlanetSpecii>();
    }

      public int SpeciiId { get; set; }
      public string SpeciiName { get; set; }
      public string Description { get; set; }

      public virtual ICollection<AlienSpecii> JoinEntSpec { get; }
      public virtual ICollection<PlanetSpecii> JoinPlanSpec { get; set; }
    
  }
}