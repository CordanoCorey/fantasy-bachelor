using fantasy_bachelor.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantasy_bachelor.API.Features.Rankings
{
    public class RankingModel
    {
        public int Id { get; set; }
        public int ContestantSeasonId { get; set; }
        public string Notes { get; set; }
        public int Rank { get; set; }
        public int UserId { get; set; }
    }
}
