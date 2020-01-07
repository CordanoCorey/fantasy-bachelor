using System;
using System.Collections.Generic;
using System.Text;

namespace fantasy_bachelor.Entity.DataClasses
{
    public partial class FunFact
    {
        public FunFact()
        {
        }
        public int Id { get; set; }
        public int Description { get; set; }
        public int ContestantId { get; set; }

        public virtual Contestant Contestant { get; set; }
    }
}
