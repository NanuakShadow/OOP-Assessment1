using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    public class Room
    {
        public string roomDescription;
        public string roomName;
        public static Dictionary<int, Room> rooms = new Dictionary<int, Room>();


        public Room(string name, string description)
        {
            this.roomName = name;
            this.roomDescription = description;
            rooms.Add(rooms.Count + 1, this);
        }

        public string GetDescription()
        {
            return this.roomDescription;
        }
        
       
    }  
}