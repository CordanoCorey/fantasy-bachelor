using System;
using System.Collections.Generic;
using System.Text;

namespace fantasy_bachelor.Entity.DataClasses
{
    public partial class Contestant
    {
        public Contestant()
        {
            FunFacts = new HashSet<FunFact>();
            Seasons = new HashSet<ContestantSeasonXref>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public string Hometown { get; set; }
        public string Profession { get; set; }

        public virtual ICollection<FunFact> FunFacts { get; set; }
        public virtual ICollection<ContestantSeasonXref> Seasons { get; set; }
    }
}
