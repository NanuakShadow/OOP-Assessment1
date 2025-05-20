using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class LootTable
    {
        public static Random random = new Random();
        public static Dictionary<int, string> lootTable = new Dictionary<int, string>()
        {
            { 1, "Armour" },
            { 2, "Weapon" },
            { 55, "Potion" },
            { 40, "Gold coin" },
            { 95, "Monster remains" }
        };

        public static List<string> GenerateLoot(int lootRoll)
        {
            List<string> lootList = new List<string>();
            foreach (var loot in lootTable)
            {
                if (lootRoll <= loot.Key)
                {
                    lootList.Add(loot.Value);
                }
            }
            return lootList;
        }
    }
}