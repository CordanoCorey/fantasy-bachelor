using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using fantasy_bachelor.Entity.Context;
using Microsoft.Extensions.Hosting;

namespace fantasy_bachelor.API
{
  public partial class Startup
  {
    public static void ConfigureOrmServices(IConfiguration Configuration, IServiceCollection services)
    {
      services.AddEntityFrameworkSqlServer().AddDbContext<FantasyBachelorContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("db"));
      });
    }

    public static void ConfigureOrm(IApplicationBuilder app, IHostEnvironment env)
    {
      //using (var serviceScope = app.ApplicationServices
      //.GetRequiredService<IServiceScopeFactory>()
      //.CreateScope())
      //{
      //    using (var context = serviceScope.ServiceProvider.GetService<FantasyBachelorContext>())
      //    {
      //        var isInit = !context.Database.GetAppliedMigrations().Any();
      //        context.Database.Migrate();
      //    }
      //}
    }
  }
}
