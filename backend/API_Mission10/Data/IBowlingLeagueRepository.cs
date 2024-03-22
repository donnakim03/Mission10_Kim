namespace API_Mission10.Data
{
    public interface IBowlingLeagueRepository
    {
        IEnumerable<Bowler> Bowlers { get; }

        IEnumerable<Bowler> GetAllBowlersWithTeams(); // To join the Bowlers and Teams table
    }
}
