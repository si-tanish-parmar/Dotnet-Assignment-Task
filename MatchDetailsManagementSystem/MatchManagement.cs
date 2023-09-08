using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDetailsManagementSystem
{
    internal class MatchManagement
    {
        private List<MatchDetails> matches = new List<MatchDetails>();

        private void DisplayMatch(MatchDetails match)
        {
            Console.WriteLine($"Match ID: {match.MatchId}");
            Console.WriteLine($"Sport: {match.Sport}");
            Console.WriteLine($"Date and Time: {match.MatchDateTime}");
            Console.WriteLine($"Location: {match.Location}");
            Console.WriteLine($"Home Team: {match.HomeTeam}");
            Console.WriteLine($"Away Team: {match.AwayTeam}");
            Console.WriteLine($"Home Team Score: {match.HomeTeamScore}");
            Console.WriteLine($"Away Team Score: {match.AwayTeamScore}");
            Console.WriteLine();
        }


        private bool IsValidMatch(MatchDetails match)
        {
            if (match.MatchId <= 0 || matches.Any(m => m.MatchId == match.MatchId))
                return false;

            if (string.IsNullOrWhiteSpace(match.Sport))
                return false;

            if (match.MatchDateTime <= DateTime.Now)
                return false;

            if (string.IsNullOrWhiteSpace(match.Location))
                return false;

            if (string.IsNullOrWhiteSpace(match.HomeTeam) || string.IsNullOrWhiteSpace(match.AwayTeam) || match.HomeTeam == match.AwayTeam)
                return false;

            if (match.HomeTeamScore < 0 || match.AwayTeamScore < 0)
                return false;

            return true;
        }
        public void AddMatch(MatchDetails match)
        {
            if (IsValidMatch(match)){
                matches.Add(match);
                Console.WriteLine("Match added successfully.");
            }
            else{
                Console.WriteLine("Match validation failed. Could not add match.");
            }
        }

        public void DisplayAllMatches()
        {
            Console.WriteLine("All Matches -");
            foreach (var match in matches){
                DisplayMatch(match);
            }
        }
       
        public void DisplayMatchById(int matchId)
        {
            var match = matches.FirstOrDefault(m => m.MatchId == matchId);
            if (match != null)
            {
                DisplayMatch(match);
            }
            else
            {
                Console.WriteLine("Error!Match not found.");
            }
        }

        public void UpdateMatchScore(int matchId, int homeTeamScore, int awayTeamScore)
        {
            var match = matches.FirstOrDefault(m => m.MatchId == matchId);
            if (match != null)
            {
                match.HomeTeamScore = homeTeamScore;
                match.AwayTeamScore = awayTeamScore;
                Console.WriteLine("updated");
            }
            else
            {
                Console.WriteLine("Error! Match not found");
            }
        }

        public void RemoveMatch(int matchId)
        {
            var match = matches.FirstOrDefault(m => m.MatchId == matchId);
            if (match != null)
            {
                matches.Remove(match);
                Console.WriteLine("Match removed");
            }
            else
            {
                Console.WriteLine("Error!Match not found");
            }
        }

    }
}
