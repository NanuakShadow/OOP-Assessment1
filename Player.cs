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
            //The player's health is randomly generated between 14 and 18 for some possible variation in gameplay
            this.health = random.Next(14, 18);
        }

        public string GetPlayerData()
        {
            //Only displays name and health for now. Inventory is viewed from a separate method
            return "Name: " + this.name + "\n" + "Health: " + this.health;
        }
        public string GetInventory()
        {
            string inventoryContents = "Inventory: ";
            if (this.inventory.Count == 0)
            {
                return "Inventory is empty.";
            }
            else
            {
                foreach (string item in this.inventory)
                {
                    inventoryContents += "\n" + "-" + item;
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