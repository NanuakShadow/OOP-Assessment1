using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Entity
    {
        private static Random random = new Random();
        public string name;
        public int health;
        public int defense;
        public int attackPower;
        public string description;

        // Constructor to initialize the entity's attributes
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
    }


}
