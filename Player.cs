using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Player
    {
        private static Random random = new Random();
        public string name;
        public int health;
        private List<string> inventory = new List<string>();
        public Room currentRoom;

        public Player(string name) 
        {
            this.name = name;
            this.health = random.Next(14, 18);
        }

        public string GetPlayerData()
        {

            return "Name: " + this.name + "\n" + "Health: " + this.health;
        }
        public string GetInventory()
        {
            string inventoryContents = "Inventory: " + "\n";
            if (this.inventory.Count == 0)
            {
                return "Inventory is empty.";
            }
            else
            {
                foreach (string item in this.inventory)
                {
                    inventoryContents += "-" + item + "\n";
                }
            }
            return inventoryContents;
        }
        public void SetCurrentRoom(Room roomName)
        {
            this.currentRoom = roomName;
        }
        public string InspectRoom()
        {
            return this.currentRoom.GetDescription();
        }
        public void PickUpItem(string item)
        {
            Console.WriteLine("Would you like to pick up this item? (yes/no)");
            if (Console.ReadLine() == "yes")
            {
                this.inventory.Add(item);
                Console.WriteLine("You have picked up the item.");
            }
            else
            {
                Console.WriteLine("You left the item behind.");
            }
        }
    }
}