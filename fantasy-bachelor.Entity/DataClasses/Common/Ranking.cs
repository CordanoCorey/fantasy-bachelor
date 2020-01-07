using System;
using System.Collections.Generic;
using System.Text;

namespace fantasy_bachelor.Entity.DataClasses
{
    public partial class Ranking
    {
        public Ranking()
        {
        }
        public int Id { get; set; }
        public int ContestantSeasonId { get; set; }
        public string Notes { get; set; }
        public int Rank { get; set; }
        public int UserId { get; set; }

        public virtual ContestantSeasonXref ContestantSeason { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
