using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer;



namespace DungeonExplorer
{
    public class Monster : Entity
    {
        public static List<Monster> monsters = new List<Monster>();

        public Monster()
        {
            this.name = $"Monster {monsters.Count}";
            monsters.Add(this);
        }

        public void Battle(Entity defender)
        {

            if (this.health > 0)
            {
                Console.WriteLine($"{this.name} attacks {defender.name}");
                bool attackHit = false;

                if (random.Next(1, 20) > defender.defense)
                {
                    attackHit = true;
                }
                else
                {
                    attackHit = false;
                }

                if (attackHit)
                {
                    Console.WriteLine($"{this.name} hit {defender.name}!");
                    defender.health -= this.attackPower;
                    Console.WriteLine($"{defender.name} took {this.attackPower} damage!");
                }
                else
                {
                    Console.WriteLine($"{this.name}'s attack missed!");
                    return;
                }


                if (defender.health <= 0)
                {
                    Console.WriteLine($"{defender.name}'s health has been depleted");
                    Console.WriteLine($"{defender.name} has been defeated!");
                    
                }
                else
                {
                    Console.WriteLine($"{defender.name}'s remaining health: {defender.health}");
                }
            }
        }
        public static void MonsterDrops(Entity attacker, Entity defender)
        {
            
            int lootRoll = random.Next(1, 100);
            List<string> drops = LootTable.GenerateLoot(lootRoll);
            foreach (string drop in drops)
            {
                Console.WriteLine($"{defender.name} has dropped {drop}");
            }
            attacker.inventory.AddRange(drops);
        }
    }
}

