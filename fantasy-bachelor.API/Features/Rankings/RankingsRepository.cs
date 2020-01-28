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
        int CalculatePoints(int userId);
        IEnumerable<RankingModel> FindByUser(int userId);
        string FindPickToWinName(int userId);
        int? FindPickToWinId(int userId);
        void SaveUserRankings(IEnumerable<RankingModel> rankings);
    }

    public class RankingsRepository : BaseRepository<FantasyBachelorContext, Ranking, RankingModel>, IRankingsRepository
    {
        public RankingsRepository(FantasyBachelorContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int CalculatePoints(int userId)
        {
            var userRankings = FindByUser(userId);
            if (!userRankings.Any())
            {
                return 0;
            }
            return userRankings.Aggregate(0, (acc, ranking) =>
            {
                var pts = 0;
                if (ranking.ContestantFinish < 23 && (ranking.Rank + 1) < 23)
                {
                    pts += 1;
                }
                if (ranking.ContestantFinish < 20 && (ranking.Rank + 1) < 20)
                {
                    pts += 2;
                }
                if (ranking.ContestantFinish < 17 && (ranking.Rank + 1) < 17)
                {
                    pts += 7;
                }
                return acc + pts;
            });
        }

        public IEnumerable<RankingModel> FindByUser(int userId)
        {
            return FindBy(x => x.UserId == userId);
        }

        public string FindPickToWinName(int userId)
        {
            return FindFirst(x => x.UserId == userId && x.Rank == 0)?.ContestantName;
        }

        public int? FindPickToWinId(int userId)
        {
            return FindFirst(x => x.UserId == userId && x.Rank == 0)?.ContestantSeasonId;
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

        protected override IQueryable<Ranking> Include(IQueryable<Ranking> queryable)
        {
            return queryable
                .Include(x => x.ContestantSeason)
                    .ThenInclude(y => y.Contestant)
            ;
        }
    }
}
