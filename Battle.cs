namespace DungeonExplorer
{
    public interface IBattle
    {
        void Battle(Entity defender)
        {
            Console.WriteLine($"{this.name} attacks {defender.name}");
        }
    }
}