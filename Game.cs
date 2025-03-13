using System;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player playerTest;
        private Player player1;
        public static Room room1;
        public static Room roomTest;
        public Game()
        {

            playerTest = new Player("Test Player");

            // Initialize the game with the first room and player
            Console.WriteLine("Please try and be reasonable with your name choice, It's not that hard");
            Console.WriteLine("I will, however, not stop you. Just know that any problems are on you, not me");
            Console.WriteLine("Enter player name: ");
            player1 = new Player(Console.ReadLine());
            room1 = new Room("Start", "This is the first room. " +
                "It is empty, except for a wooden chest in a corner. There is a locked door to the north.");

            // Test room initialized for admin testing
            roomTest = new Room("Test Room", "A test room. Normally inaccessible to the player.");

        }

        public void Start()
        {
            player1.SetCurrentRoom(room1);

            bool playing = true;
            while (playing)
            {   
                
                
                Console.WriteLine("Player options (enter one of the following numbers to carry out the assigned action): ");
                Console.WriteLine("1. Inspect room");
                Console.WriteLine("2. Move rooms");
                Console.WriteLine("3. View character");
                Console.WriteLine("4. Open Inventory");
                Console.WriteLine("5. Quit game");
                string choiceStr = Console.ReadLine();

                //Converts non integer values to -1 so that they will be handled by the default case
                bool choiceValid = int.TryParse(choiceStr, out int choiceInt);
                if (!choiceValid)
                {
                    
                    choiceInt = -1;
                }
                switch (choiceInt)
                {
                    case 1:
                        Program.InspectRoom(player1);
                        break;
                    case 2:   
                        Program.MoveRoom(player1);
                        break;
                    case 3:
                        Console.WriteLine(player1.GetPlayerData());
                        break;
                    case 4:
                        Console.WriteLine(player1.GetInventory());
                        break;
                    case 5:
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}