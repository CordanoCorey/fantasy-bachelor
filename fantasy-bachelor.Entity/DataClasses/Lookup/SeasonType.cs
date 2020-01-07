using System;
using System.Collections.Generic;

namespace fantasy_bachelor.Entity.DataClasses
{
  public partial class SeasonType : ILookup
  {
    public SeasonType()
    {
      Seasons = new HashSet<Season>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int Sort { get; set; }

    public virtual ICollection<Season> Seasons { get; set; }
  }
}
