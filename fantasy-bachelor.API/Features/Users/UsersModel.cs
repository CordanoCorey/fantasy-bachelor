using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantasy_bachelor.API.Features.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Paid { get; set; }
        public string Password { get; set; }
        public string PasswordResetCode { get; set; }
        public int? PickToWinId { get; set; }
        public string PickToWinName { get; set; }
        public int TotalPoints { get; set; }
    }
}
