using API_Mission10.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/*
 * Donna Kim
 * Section 03
 * Description: Calling an API that accesses the BowlingLeague database to display a table in React
 */

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
            // Getting Bowler data with team names
            var bowlerData = _bowlingLeagueRepo.GetAllBowlersWithTeams();

            return bowlerData;
        }
    }
}
