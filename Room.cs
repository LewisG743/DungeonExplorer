using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<char> doors;
        private List<Item> Items = new List<Item>();

        public Room(string description)
        {
            this.description = description;
            SetItems();
            SetDoors();
        }

        private void SetItems()
        {
            Random rGen = new Random();
            for (int i = 0; i < 5; i++)
            {
                if(rGen.Next(100) > 40) // 0 to 99
                {
                    switch (rGen.Next(2))
                    {
                        case 0:
                            Weapon weapon = new Weapon(0, "Sword", 10);
                            this.Items.Add(weapon);
                            break;
                        case 1:
                            Potion potion = new Potion(0, "Health Potion");
                            this.Items.Add(potion);
                            break;
                    }
                } 
            }
        }

        private void SetDoors()
        {

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