using API_Mission10.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Mission10.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlingLeagueRepository _bowlingLeagueRepo;

        public BowlerController(IBowlingLeagueRepository temp)
        {
            _bowlingLeagueRepo = temp;
        }

        [HttpGet]
        public IEnumerable<Bowler> Get()
        {
            var bowlerData = _bowlingLeagueRepo.GetAllBowlersWithTeams();

            return bowlerData;
        }
    }
}
