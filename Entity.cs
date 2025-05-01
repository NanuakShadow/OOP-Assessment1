using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Entity
    {
        public static Random random = new Random();
        public string name = "Default name";
        public int health;
        public int defense;
        public int attackPower;
        public string description;
        public List<string> inventory = new List<string>();
        public Room currentRoom;


        public Entity()
        {
            this.health = random.Next(1, 3);
            this.attackPower = random.Next(1, 3);
            this.defense = random.Next(12, 16);

        }
        public string GetData()
        {
            
            return $"Name: {this.name}\nHealth: {this.health}\nAttack: {this.attackPower}\nDefense: {this.defense}";
        }
        public void SetCurrentRoom(Room roomName)
        {
            this.currentRoom = roomName;
        }
    }


}
