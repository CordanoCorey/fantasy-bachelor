using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace fantasy_bachelor.Entity.DataClasses
{
    public partial class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            RankingUser = new HashSet<Ranking>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordResetCode { get; set; }

        public virtual ICollection<Ranking> RankingUser { get; set; }
    }
}
