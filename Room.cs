using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<char> doors;
        private List<Item> Items;

        public Room(string description)
        {
            this.description = description;

        }

        public string GetDescription()
        {
            return description;
        }

        public List<char> GetDoors()
        {
            return doors;
        }
    }
}