using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fantasy_bachelor.API.Infrastructure;
using System.Collections;
using System.Collections.Generic;

namespace fantasy_bachelor.API.Features.Rankings
{
    [Route("api/rankings")]
    public class RankingsController : BaseController
    {
        private readonly IRankingsService _service;
        public RankingsController(IRankingsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Get(_service.GetRankings);
        }

        [HttpPost]
        public IActionResult Post([FromBody]RankingModel model)
        {
            return Post(_service.AddRanking, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RankingModel model)
        {
            return Put(_service.UpdateRanking, model);
        }

        [HttpGet("~/api/users/{id}/rankings")]
        public IActionResult GetUserRankings(int id)
        {
            var result = _service.GetUserRankings(id);
            return Ok(result);
        }

        [HttpPut("~/api/users/{id}/rankings")]
        public IActionResult PutUserRankings(int id, [FromBody]IEnumerable<RankingModel> model)
        {
            var result = _service.UpdateUserRankings(id, model);
            return Ok(result);
        }
    }
}
