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
        public void SetCurrentRoom(Room roomName)
        {
            this.currentRoom = roomName;
        }
        public string InspectRoom()
        {
            return this.currentRoom.GetDescription();
        }
    }
}