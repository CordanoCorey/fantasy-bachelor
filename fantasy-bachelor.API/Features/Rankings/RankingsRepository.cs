using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fantasy_bachelor.API.Infrastructure;
using fantasy_bachelor.Entity.Context;
using fantasy_bachelor.Entity.DataClasses;

namespace fantasy_bachelor.API.Features.Rankings
{
    public interface IRankingsRepository : IBaseRepository<Ranking, RankingModel>
    {
        IEnumerable<RankingModel> GetUserRankings(int userId);
        void SaveUserRankings(IEnumerable<RankingModel> rankings);
    }

    public class RankingsRepository : BaseRepository<FantasyBachelorContext, Ranking, RankingModel>, IRankingsRepository
    {
        public RankingsRepository(FantasyBachelorContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<RankingModel> GetUserRankings(int userId)
        {
            return FindBy(x => x.UserId == userId);
        }

        public void SaveUserRankings(IEnumerable<RankingModel> rankings)
        {
            foreach (var ranking in rankings)
            {
                if (ranking.Id == 0)
                {
                    Insert(ranking);
                }
                else
                {
                    Update(ranking);
                }
            }
        }
    }
}
