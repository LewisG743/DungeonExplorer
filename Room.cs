using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<char> doors;
        private List<Item> Items = new List<Item>();
        public bool hasEnemy { get; }

        public Room(string description)
        {
            this.description = description;
            this.hasEnemy = false;
            SetItems();
            SetDoors();
        }

        private void SetItems()
        {
            int count = 0;
            Random rGen = new Random();
            for (int i = 0; i < 5; i++)
            {
                int random = rGen.Next(100);
                if (random > 40) // 0 to 99
                {
                    switch (rGen.Next(2))
                    {
                        case 0:
                            Weapon weapon = new Weapon(count, "Sword", 10);
                            this.Items.Add(weapon);
                            break;
                        case 1:
                            Potion potion = new Potion(count, "Health Potion");
                            this.Items.Add(potion);
                            break;
                    }
                }
                count++;
            }
        }

        private void SetDoors()
        {
            this.doors = new List<char>();
        }

        public string GetDescription()
        {
            return description;
        }

        public List<char> GetDoors()
        {
            return doors;
        }

        public List<Item> GetItems()
        {
            return Items;
        }

    }
}