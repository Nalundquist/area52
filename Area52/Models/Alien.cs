using System.Collections.Generic;

namespace Area52.Models
{
  public class Alien
  {
    public Alien()
    {
      this.JoinEntPlan = new HashSet<AlienPlanet>();
      this.JoinEntSpec = new HashSet<AlienSpecii>();      
    }

    public int AlienId { get; set; }
    public string AlienName { get; set; }
    public virtual ICollection<AlienPlanet> JoinEntPlan { get; set; }
    public virtual ICollection<AlienSpeii> JoinEntSpec { get; set; }
  }
}
