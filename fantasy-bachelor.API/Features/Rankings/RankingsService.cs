using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fantasy_bachelor.API.Features.Rankings
{
    public interface IRankingsService
    {
        IEnumerable<RankingModel> GetRankings();
        RankingModel GetRanking(int id);
        RankingModel AddRanking(RankingModel model);
        RankingModel UpdateRanking(RankingModel model);
        IEnumerable<RankingModel> UpdateUserRankings(int userId, IEnumerable<RankingModel> rankings);
    }

    public class RankingsService : IRankingsService
    {
        private readonly IRankingsRepository _repo;
        public RankingsService(IRankingsRepository repo)
        {
            _repo = repo;
        }

        public RankingModel AddRanking(RankingModel model)
        {
            var inserted = _repo.Insert(model);
            return GetRanking(inserted.Id);
        }

        public RankingModel GetRanking(int id)
        {
            return _repo.FindByKey(id);
        }

        public IEnumerable<RankingModel> GetRankings()
        {
            return _repo.All();
        }

        public RankingModel UpdateRanking(RankingModel model)
        {
            var updated = _repo.Update(model);
            return GetRanking(updated.Id);
        }

        public IEnumerable<RankingModel> UpdateUserRankings(int userId, IEnumerable<RankingModel> rankings)
        {
            _repo.SaveUserRankings(rankings);
            return _repo.GetUserRankings(userId);
        }
    }
}
