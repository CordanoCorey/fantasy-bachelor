using Microsoft.EntityFrameworkCore;
using fantasy_bachelor.Entity.Context;
using fantasy_bachelor.Entity.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantasy_bachelor.API.Infrastructure.Lookup
{

  public interface ILookupRepository
  {
    IEnumerable<LookupModel> GetLookups();
  }
  public class LookupRepository : ILookupRepository
  {
    private FantasyBachelorContext _context;

    public LookupRepository(FantasyBachelorContext context)
    {
      _context = context;
    }

    public IEnumerable<LookupModel> GetLookups()
    {
      var lookups = new List<LookupModel>();


      foreach (var entity in _context.Model.GetEntityTypes())
      {
        var name = entity.Name;
        var type = entity.ClrType;


        var schema = _context.Model.FindEntityType(type).GetSchema();

        if (schema == "Lookup")
        {

          var dbObject = (IQueryable<ILookup>)
             typeof(DbContext).GetMethod("Set", Type.EmptyTypes)
             .MakeGenericMethod(type)
             .Invoke(_context, null);

          lookups.Add(new LookupModel()
          {
            Name = name.Split('.').Last(),
            Values = dbObject.AsNoTracking()
          });
        }
      }

      return lookups;
    }
  }
}
