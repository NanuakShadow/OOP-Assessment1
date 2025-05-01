using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Player : Entity
    {
        
        public Player(string name)
        {
            this.name = name;
            this.health = random.Next(8, 10);

        }

        public string GetInventory()
        {
            string inventoryContents = "Inventory:";
            Dictionary<string, int> itemAmount = new Dictionary<string, int>();

            if (this.inventory.Count == 0)
            {
                return "Inventory is empty.";
            }
            else
            {
                foreach (string item in this.inventory)
                {
                    if (itemAmount.ContainsKey(item))
                    {
                        itemAmount[item]++;
                    }
                    else
                    {
                        itemAmount[item] = 1;
                    }
                }

                foreach (var item in itemAmount)
                {
                    if (item.Value > 1)
                    {
                        inventoryContents += $"\n - {item.Key} x{item.Value}";
                    }
                    else
                    {
                        inventoryContents += $"\n - {item.Key}";
                    }
                }
            }
            return inventoryContents;
        }
        //Updates the room being accesessed by the game when the player moves to a new room
        
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
        public void Battle(Entity defender)
        {
            if (defender.health > 0)
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
                    Monster.MonsterDrops(this, defender);
                }
                else
                {
                    Console.WriteLine($"{defender.name}'s remaining health: {defender.health}");
                }
            }
        }
    }
}