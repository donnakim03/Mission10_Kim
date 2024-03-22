
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_Mission10.Data
{
    public class EFBowlingLeagueRepository : IBowlingLeagueRepository
    {
        private BowlingLeagueContext _context;

        public EFBowlingLeagueRepository(BowlingLeagueContext temp)
        {
            _context = temp;
        }
        public IEnumerable<Bowler> Bowlers => _context.Bowlers;

        public IEnumerable<Bowler> GetAllBowlersWithTeams()
        {
            // Query to join data and only get bowlers in team Marlins or Sharks
            var joinedData = from Bowler in _context.Bowlers
                             join Team in _context.Teams
                             on Bowler.TeamId equals Team.TeamId
                             where Team.TeamName == "Marlins" || Team.TeamName == "Sharks"
                             select new Bowler
                             {
                                 BowlerId = Bowler.BowlerId,
                                 BowlerFirstName = Bowler.BowlerFirstName,
                                 BowlerLastName = Bowler.BowlerLastName,
                                 BowlerMiddleInit = Bowler.BowlerMiddleInit,
                                 BowlerAddress = Bowler.BowlerAddress,
                                 BowlerCity = Bowler.BowlerCity,
                                 BowlerState = Bowler.BowlerState,
                                 BowlerZip = Bowler.BowlerZip,
                                 BowlerPhoneNumber = Bowler.BowlerPhoneNumber,
                                 Team = new Team
                                 {
                                     TeamName = Team.TeamName
                                 }
                             };

            return joinedData.ToList();
        }
    }
}
