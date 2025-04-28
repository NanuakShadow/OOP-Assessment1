using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster
    {
        private static Random random = new Random();
        public string name;
        public int health;
        public int defense;
        public int attackPower;
        public string description;

        // Constructor to initialize the monster's attributes
        public Monster(string name)
        {
            this.name = name;
            this.health = random.Next(1, 3);
            this.attackPower = random.Next(1, 3);
            this.defense = random.Next(12, 16);
        }
    }
}
}
