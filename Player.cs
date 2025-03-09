using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<Item> inventory = new List<Item>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(Item item)
        {
            if (inventory.Count < 9)
            {
                inventory.Add(item);
            }
            else
            {
                Console.WriteLine("Inventory is full");
            }
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}