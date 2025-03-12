namespace DungeonExplorer
{
    public class Room
    {
        public string roomDescription;
        public string roomName;

        public Room(string name, string description)
        {
            this.roomName = name;
            this.roomDescription = description;
        }

        public string GetDescription()
        {
            return this.roomDescription;
        }
    }
}