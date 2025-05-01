using System;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player playerTest;
        private Player player1;
        private Monster monster1;
        public static Room room1;
        public Game()
        {

            playerTest = new Player("Test Player");

            // Initialize the game with the first room and player
            Console.WriteLine("Please try and be reasonable with your name choice, It's not that hard");
            Console.WriteLine("I will, however, not stop you. Just know that any problems are on you, not me");
            Console.WriteLine("Enter player name: ");
            player1 = new Player(Console.ReadLine());
            room1 = new Room("Room 1 (Start)", "This is the first room. " +
                "It is empty, except for a wooden chest in a corner. There is a locked door to the north.");

           
        }
        public static void InspectRoom(Player player1)
        {
            Console.WriteLine(player1.InspectRoom());
            // Check if the room contains a chest and provides the option to open it
            //(may not be entirely necessary with current data but is open to change in the second half of development)
            if (player1.currentRoom.roomDescription.Contains("chest"))
            {
                Console.WriteLine("Do you want to open the chest?");
                Console.WriteLine("Anything other than 'yes' will be deemed as a negative response");
                string openChest = Console.ReadLine();
                if (player1.currentRoom.roomDescription.Contains("The chest is now empty"))
                {
                    Console.WriteLine("You already emptied this chest. There is nothing else to see.");
                }
                else
                {

                    if (openChest == "yes")
                    {
                        Console.WriteLine("The chest contains a small metal key");
                        //Gives the player the option to pick up the item and ensures that the chest is empty if they do
                        if (player1.PickUpItem("metal key"))
                        {
                            player1.currentRoom.roomDescription += "The chest is now empty.";
                        }
                    }
                }
            }
        }

        public static void MoveRoom(Player player1)
        {
            if (player1.GetInventory().Contains("metal key") || player1.name == "Admin")
            {
                Room newRoom = GenerateRoom();
                player1.SetCurrentRoom(newRoom);
                Console.WriteLine("You have used your key to enter the door to the new room");
            }
            else
            {
                Console.WriteLine("You can not enter this room. You need to find a key");
            }
        }

        public static Room GenerateRoom()
        {
            Room newRoom = new Room($"Room {Room.rooms.Count + 1}", "A new room containing a monster");
            Monster newMonster = new Monster();
            newMonster.SetCurrentRoom(newRoom);
            return newRoom;

        }

        public static string ListRooms()
        {

            string roomList = "Available Rooms:\n";
            foreach (var room in Room.rooms)
            {
                roomList += $"- {room.Key}: {room.Value.roomName}\n";
            }

            return roomList;
        }

        public static Monster LocateTarget(Player player)
        {

            foreach (var monster in Monster.monsters)
            {
                if (monster.currentRoom == player.currentRoom)
                {
                    return monster;
                }
            }
            return null;
        }
        public void Start()
        {
            player1.SetCurrentRoom(room1);

            bool playing = true;
            while (playing)
            {
                

                Console.WriteLine("Player options (enter one of the following numbers to carry out the assigned action): ");
                Console.WriteLine("1. Inspect room");
                Console.WriteLine("2. New room");
                Console.WriteLine("3. View character");
                Console.WriteLine("4. Open Inventory");
                Console.WriteLine("5. Battle monster");
                Console.WriteLine("6. View Map");
                Console.WriteLine("7. View all entities");
                Console.WriteLine("8. Quit game");
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
                        Game.InspectRoom(player1);
                        Console.WriteLine(player1.currentRoom.roomName);
                        break;
                    case 2:   
                        Game.MoveRoom(player1);
                        break;
                    case 3:
                        Console.WriteLine(player1.GetData());
                        break;
                    case 4:
                        Console.WriteLine(player1.GetInventory());
                        break;
                    case 5:
                        Monster targetMonster = Game.LocateTarget(player1);
                        if (targetMonster == null)
                        {
                            Console.WriteLine("There are no monsters in this room.");
                            break;
                        }
                        else
                        {
                            player1.Battle(targetMonster);
                            break;
                        }
                    case 6:
                        Console.WriteLine(ListRooms());
                        break;
                    case 7:
                        foreach (var monster in Monster.monsters)
                        {
                            Console.WriteLine(monster.GetData());
                            Console.WriteLine("\n");

                        }
                        break;
                    case 8:
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }


                Monster targetPlayer = Game.LocateTarget(player1);
                if (targetPlayer == null)
                {
                    Console.WriteLine("There are no monsters in this room.");
                    
                }
                else
                {
                    targetPlayer.Battle(player1);
                    
                }
                if (player1.health <= 0)
                {
                    Console.WriteLine("You have been defeated. Game over.");
                    playing = false;
                }

            }
        }
    }
}