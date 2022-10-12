using System.Collections.Generic;

namespace Area52.Models
{
  public class Planet
  {
    public Planet()
    {
      this.JoinEntPlan = new HashSet<AlienPlanet>();
      this.JoinPlanSpec = new HashSet<PlanetSpecii>();
    }

    public int PlanetId { get; set; }
    public string PlanetName { get; set; }
    public string Atmosphere { get; set; }
    public virtual ICollection<AlienPlanet> JoinEntPlan { get; }
    public virtual ICollection<PlanetSpecii> JoinPlanSpec { get; }
  }
}