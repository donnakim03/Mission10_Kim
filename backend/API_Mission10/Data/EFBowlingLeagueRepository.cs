
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
    }
}
