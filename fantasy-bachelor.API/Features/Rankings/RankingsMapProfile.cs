using AutoMapper;
using fantasy_bachelor.Entity.DataClasses;

namespace fantasy_bachelor.API.Features.Rankings
{
    public class RankingsMapProfile : Profile
    {
        public RankingsMapProfile()
        {
            CreateMap<Ranking, RankingModel>().ReverseMap();
        }
    }
}
