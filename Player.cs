using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Player : Entity
    {
        private Random random = new Random();
        private List<string> inventory = new List<string>();
        public Room currentRoom;

        public Player(string name) 
        {
            this.name = name;
            this.health = random.Next(8, 10);

        }

        public string GetInventory()
        {
            string inventoryContents = "Inventory:";
            if (this.inventory.Count == 0)
            {
                return "Inventory is empty.";
            }
            else
            {
                foreach (string item in this.inventory)
                {
                    inventoryContents += $"\n - {item}";
                }
            }
            return inventoryContents;
        }
        //Updates the room being accesessed by the game when the player moves to a new room
        public void SetCurrentRoom(Room roomName)
        {
            this.currentRoom = roomName;
        }
        public string InspectRoom()
        {
            return this.currentRoom.GetDescription();
        }
        public bool PickUpItem(string item)
        {
            bool emptied = false;
            Console.WriteLine("Would you like to pick up this item?");
            //If the player adds the item to their inventory, the item is removed from the room
            if (Console.ReadLine() == "yes")
            {
                this.inventory.Add(item);
                Console.WriteLine("You have picked up the item.");
                emptied = true;
            }
            else
            {
                Console.WriteLine("You left the item behind.");

            }
            return emptied;
        }
    }
}