using Lab8.domain.validator;
using Lab8.repository.file;
using Lab8.service;
using Lab8.utils;

namespace Lab8
{
    internal class Program
    {
        private static TeamService GetTeamService()
        {
            return new TeamService(new TeamRepository(new TeamValidator(), Constants.TeamsPath));
        }

        private static PlayerService GetPlayerService()
        {
            return new PlayerService(
                new PlayerRepository(new PlayerValidator(), Constants.PlayersPath), 
                new TeamRepository(new TeamValidator(), Constants.TeamsPath)
            );
        }

        private static MatchService GetMatchService()
        {
            return new MatchService(
                new MatchRepository(new MatchValidator(), Constants.MatchesPath),
                new TeamRepository(new TeamValidator(), Constants.TeamsPath)
            );
        }

        private static ActivePlayerService GetActivePlayerService()
        {
            return new ActivePlayerService(
                new ActivePlayerRepository(new ActivePlayerValidator(), Constants.ActivePlayersPath),
                new PlayerRepository(new PlayerValidator(), Constants.PlayersPath),
                new MatchRepository(new MatchValidator(), Constants.MatchesPath),
                new TeamRepository(new TeamValidator(), Constants.TeamsPath)
            );
        }

        private static void PrintAll()
        {
            TeamService teamService = GetTeamService();
            PlayerService playerService = GetPlayerService();
            MatchService matchService = GetMatchService();
            ActivePlayerService activePlayerService = GetActivePlayerService();

            Console.WriteLine("All data stored in the application");
            Console.WriteLine();

            teamService.FindAll()
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();

            playerService.FindAll()
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();

            matchService.FindAll()
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();

            activePlayerService.FindAll()
                .ToList()
                .ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        private static void GenerateReports()
        {
            TeamService teamService = GetTeamService();
            PlayerService playerService = GetPlayerService();
            MatchService matchService = GetMatchService();
            ActivePlayerService activePlayerService = GetActivePlayerService();

            Console.WriteLine("Generated reports");
            Console.WriteLine();

            long idMatch = 1;
            string teamName = "Los Angeles Lakers";

            // First report
            playerService.FindAll()
                .Where(x => x.Team.Name.Equals(teamName))
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine();

            // Second report
            (from activePlayer in activePlayerService.FindAll()
            where activePlayer.Match.Id == idMatch && (activePlayer.Player.Team.Name.Equals(teamName))
            select activePlayer)
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine();

            // Third report
            DateOnly firstDate = new DateOnly(2023, 1, 1);
            DateOnly lastDate = new DateOnly(2023, 1, 4);

            (from match in matchService.FindAll()
            where firstDate <= match.Date && match.Date <= lastDate
            select match)
                .ToList()
                .ForEach(Console.WriteLine); 

            Console.WriteLine();

            // Fourth report
            Console.Write("First team: ");
            var firstScore = activePlayerService.FindAll()
                .Where(x => x.Match.Id == idMatch && x.Match.FirstTeam.Equals(x.Player.Team))
                .Sum(x => x.NumberOfPointsScored);
            Console.WriteLine(firstScore);

            Console.Write("Second team: ");
            var secondScore = activePlayerService.FindAll()
                .Where(x => x.Match.Id == idMatch && x.Match.SecondTeam.Equals(x.Player.Team))
                .Sum(x => x.NumberOfPointsScored);
            Console.WriteLine(secondScore);

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //PrintAll();
            GenerateReports();
        }
    }
}