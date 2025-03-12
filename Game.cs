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
        private static Room room1;
        private static Room roomTest;
        public Game()
        {
            // Initialize the game with the first room and player
            playerTest = new Player("Test Player");
            Console.WriteLine("Please try and be reasonable with your name choice, It's not that hard");
            Console.WriteLine("I will, however, not stop you. Just know that any problems are on you, not me");
            Console.WriteLine("Enter player name: ");
            player1 = new Player(Console.ReadLine());
            room1 = new Room("Start", "This is the first room. " +
                "It is empty, except for a wooden chest in a corner. There is a locked door to the north.");
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
                string choice = Console.ReadLine();
                bool choiceValid = int.TryParse(choice, out int choiceInt);
                if (!choiceValid)
                {
                    
                    choiceInt = -1;
                }
                switch (choiceInt)
                {
                    case 1:
                        Console.WriteLine(player1.InspectRoom());
                        if (player1.currentRoom.roomDescription.Contains("chest"))
                        {
                            Console.WriteLine("Do you want to open the chest? (yes/no)");
                            string openChest = Console.ReadLine();
                            if (player1.currentRoom.roomDescription.Contains("The chest is now empty"))
                            {
                                Console.WriteLine("You already emptied this chest. There is nothing else to see.");   
                            }
                            else
                            {

                                if (openChest == "yes")
                                {
                                    Console.WriteLine("The chest contains a smooth metal cube of unknown origins");
                                    if (player1.PickUpItem("metal cube"))
                                    {
                                        player1.currentRoom.roomDescription += "The chest is now empty.";
                                    } 
                                }
                            }
                        }
                        break;
                    case 2:   
                            if (player1.name == "Admin")
                            {
                                player1.SetCurrentRoom(roomTest);
                                Console.WriteLine("You have been moved to the test room");
                            }
                            else
                            {
                                Console.WriteLine("You do not any available rooms to move to");
                            }
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