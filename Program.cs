using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketAcademy
{
    public interface IPlayer
    {
        int PlayerId { get; set; }
        string PlayerName { get; set; }
        int PlayerAge { get; set; }
    }

    public class Player : IPlayer
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
    }

    public class Team
    {
        private List<Player> players = new List<Player>();

        public void AddPlayer()
        {
            Console.WriteLine("Enter Player Id:");
            int playerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Player Name:");
            string playerName = Console.ReadLine();

            Console.WriteLine("Enter Player Age:");
            int playerAge = int.Parse(Console.ReadLine());

            if (players.Count < 11)
            {
                Player newPlayer = new Player { PlayerId = playerId, PlayerName = playerName, PlayerAge = playerAge };
                players.Add(newPlayer);
                Console.WriteLine("Player is added successfully");
            }
            else
            {
                Console.WriteLine("Cannot add more than 11 players to the team.");
            }
        }

        public void RemovePlayer()
        {
            Console.WriteLine("Enter Player Id to Remove:");
            int playerIdToRemove = int.Parse(Console.ReadLine());

            Player playerToRemove = players.FirstOrDefault(p => p.PlayerId == playerIdToRemove);
            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                Console.WriteLine("Player is removed successfully");
            }
            else
            {
                Console.WriteLine($"Player with ID {playerIdToRemove} not found in the team.");
            }
        }

        public void GetPlayerDetailsById()
        {
            Console.WriteLine("Enter Player Id:");
            int playerId = int.Parse(Console.ReadLine());

            Player player = players.FirstOrDefault(p => p.PlayerId == playerId);
            if (player != null)
            {
                Console.WriteLine($"{player.PlayerId} {player.PlayerName} {player.PlayerAge}");
            }
            else
            {
                Console.WriteLine($"Player with ID {playerId} not found in the team.");
            }
        }

        public void GetPlayerDetailsByName()
        {
            Console.WriteLine("Enter Player Name:");
            string playerName = Console.ReadLine();

            Player player = players.FirstOrDefault(p => p.PlayerName.Equals(playerName, StringComparison.OrdinalIgnoreCase));
            if (player != null)
            {
                Console.WriteLine($"{player.PlayerId} {player.PlayerName} {player.PlayerAge}");
            }
            else
            {
                Console.WriteLine($"Player with Name {playerName} not found in the team.");
            }
        }

        public void GetAllPlayerDetails()
        {
            Console.WriteLine("All Players in the team:");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.PlayerId} {player.PlayerName} {player.PlayerAge}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Team cricketTeam = new Team();

            string continueChoice;
            do
            {
                Console.WriteLine("Enter \n1: To Add Player \n2: To Remove Player by Id \n3. Get Player By Id \n4. Get Player by Name \n5. Get All Players");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        cricketTeam.AddPlayer();
                        break;
                    case 2:
                        cricketTeam.RemovePlayer();
                        break;
                    case 3:
                        cricketTeam.GetPlayerDetailsById();
                        break;
                    case 4:
                        cricketTeam.GetPlayerDetailsByName();
                        break;
                    case 5:
                        cricketTeam.GetAllPlayerDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                Console.WriteLine("Do you want to continue (yes/no)?:");
                continueChoice = Console.ReadLine();
            } while (continueChoice.ToLower() == "yes");
        }

    }
}

