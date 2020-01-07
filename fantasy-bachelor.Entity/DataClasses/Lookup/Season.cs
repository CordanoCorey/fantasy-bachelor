using System;
using System.Collections.Generic;

namespace fantasy_bachelor.Entity.DataClasses
{
    public partial class Season : ILookup
    {
        public Season()
        {
            Contestants = new HashSet<ContestantSeasonXref>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Sort { get; set; }
        public int SeasonTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual SeasonType SeasonType { get; set; }
        public virtual ICollection<ContestantSeasonXref> Contestants { get; set; }
    }
}
