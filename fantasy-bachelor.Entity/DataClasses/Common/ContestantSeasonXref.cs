using System;
using System.Collections.Generic;
using System.Text;

namespace fantasy_bachelor.Entity.DataClasses
{
    public partial class ContestantSeasonXref
    {
        public ContestantSeasonXref()
        {
            Rankings = new HashSet<Ranking>();
        }
        public int Id { get; set; }
        public int ContestantId { get; set; }
        public int? Finish { get; set; }
        public int SeasonId { get; set; }

        public virtual Contestant Contestant { get; set; }
        public virtual Season Season { get; set; }
        public virtual ICollection<Ranking> Rankings { get; set; }
    }
}
