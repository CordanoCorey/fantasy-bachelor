using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fantasy_bachelor.Entity.DataClasses;

namespace fantasy_bachelor.API.Infrastructure.Lookup
{
  public class LookupModel
  {
    public string Name { get; set; }
    public IEnumerable<ILookup> Values { get; set; }
  }
}
