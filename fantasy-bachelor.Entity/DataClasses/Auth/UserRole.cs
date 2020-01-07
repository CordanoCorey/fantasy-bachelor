using System;
using System.Collections.Generic;

namespace fantasy_bachelor.Entity.DataClasses
{
    public partial class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
