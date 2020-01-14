using AutoMapper;
using fantasy_bachelor.Entity.DataClasses;

namespace fantasy_bachelor.API.Features.Rankings
{
    public class RankingsMapProfile : Profile
    {
        public RankingsMapProfile()
        {
            CreateMap<Ranking, RankingModel>()
                .ForMember(d => d.ContestantFinish, o => o.MapFrom(s => s.ContestantSeason.Finish == null ? 1 : s.ContestantSeason.Finish))
                .ForMember(d => d.ContestantName, o => o.MapFrom(s => s.ContestantSeason.Contestant.Name))
                .ReverseMap();
        }
    }
}
