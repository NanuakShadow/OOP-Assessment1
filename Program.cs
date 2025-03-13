using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
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
                        Console.WriteLine("The chest contains a smooth metal cube of unknown origins");
                        //Gives the player the option to pick up the item and ensures that the chest is empty if they do
                        if (player1.PickUpItem("metal cube"))
                        {
                            player1.currentRoom.roomDescription += "The chest is now empty.";
                        }
                    }
                }
            }
        }

        public static void MoveRoom(Player player1)
        {
            if (player1.name == "Admin" && player1.currentRoom.roomName == "Start")
            {
                Console.WriteLine("You have access to test room. Please enter pin to enter the room: ");
                string adminPin = Console.ReadLine();
                if (adminPin == "1234")
                {
                    player1.SetCurrentRoom(Game.roomTest);
                    Console.WriteLine("You have been moved to the test room");
                }
                else
                {
                    Console.WriteLine("Incorrect pin. You can not enter this room");
                }
            }
            else if (player1.name == "Admin" && player1.currentRoom.roomName == "Test Room")
            {
                player1.SetCurrentRoom(Game.room1);
                Console.WriteLine("You have exited the test room and returned to your previous room");
            }
            else
            {
                Console.WriteLine("You do not any available rooms to move to");
            }
        }

        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
