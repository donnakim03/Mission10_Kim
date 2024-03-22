
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
            var joinedData = from Bowler in _context.Bowlers
                             join Team in _context.Teams
                             on Bowler.TeamId equals Team.TeamId
                             select new
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
                                 TeamName = Team.TeamName
                             };

            var bowlersWithTeams = joinedData
                .Select(j => new Bowler
                {
                    BowlerId = j.BowlerId,
                    BowlerFirstName = j.BowlerFirstName,
                    BowlerLastName = j.BowlerLastName,
                    BowlerMiddleInit = j.BowlerMiddleInit,
                    BowlerAddress = j.BowlerAddress,
                    BowlerCity = j.BowlerCity,
                    BowlerState = j.BowlerState,
                    BowlerZip = j.BowlerZip,
                    BowlerPhoneNumber = j.BowlerPhoneNumber,
                    Team = new Team
                    {
                        TeamName = j.TeamName
                    }
                })
                .ToList();

            return bowlersWithTeams;
        }
    }
}
