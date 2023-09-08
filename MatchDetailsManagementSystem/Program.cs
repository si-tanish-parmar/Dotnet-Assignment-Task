namespace MatchDetailsManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatchManagement matchManagement = new MatchManagement();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("******Sportz Interactive*****");
                Console.WriteLine("1.Add a Match");
                Console.WriteLine("2.Display All Matches");
                Console.WriteLine("3.Display Match by ID");
                Console.WriteLine("4.Update Match Score");
                Console.WriteLine("5.Remove a Match");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter match details:");
                        MatchDetails newMatch = new MatchDetails();
                        Console.Write("Match ID: ");
                        newMatch.MatchId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Sport: ");
                        newMatch.Sport = Console.ReadLine();
                        Console.Write("Date and Time (yyyy-MM-dd HH:mm): ");
                        newMatch.MatchDateTime = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Location: ");
                        newMatch.Location = Console.ReadLine();
                        Console.Write("Home Team: ");
                        newMatch.HomeTeam = Console.ReadLine();
                        Console.Write("Away Team: ");
                        newMatch.AwayTeam = Console.ReadLine();
                        Console.Write("Home Team Score: ");
                        newMatch.HomeTeamScore = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Away Team Score: ");
                        newMatch.AwayTeamScore = Convert.ToInt32(Console.ReadLine());
                        matchManagement.AddMatch(newMatch);
                        break;
                    case 2:
                        matchManagement.DisplayAllMatches();
                        break;
                    case 3:
                        Console.Write("Enter Match ID: ");
                        int matchId = Convert.ToInt32(Console.ReadLine());
                        matchManagement.DisplayMatchById(matchId);
                        break;
                    case 4:
                        Console.Write("Enter Match ID: ");
                        int updateMatchId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Home Team Score: ");
                        int homeTeamScore = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Away Team Score: ");
                        int awayTeamScore = Convert.ToInt32(Console.ReadLine());
                        matchManagement.UpdateMatchScore(updateMatchId, homeTeamScore, awayTeamScore);
                        break;
                    case 5:
                        Console.Write("Enter Match ID to remove: ");
                        int removeMatchId = int.Parse(Console.ReadLine());
                        matchManagement.RemoveMatch(removeMatchId);
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice !!!");
                        break;
                }

            }
        }
    }
}