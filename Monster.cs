using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster : Entity
    {

        public Monster()
        {
            Console.WriteLine("A monster has appeared!");
        }
        public void Battle(Entity defender)
        {
            if (this.health > 0)
            {
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
            else
            {
                return;
            }
        }
    }
}

