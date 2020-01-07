using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace fantasy_bachelor.Entity.Migrations
{
  public partial class init
  {
    private void Pre(MigrationBuilder migrationBuilder)
    {
      CreateUser(migrationBuilder);
    }

    private void CreateUser(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("CREATE USER [FantasyBachelor] FOR LOGIN [FantasyBachelor]");
      migrationBuilder.Sql("ALTER ROLE [db_owner] ADD MEMBER [FantasyBachelor]");
    }
  }
}
