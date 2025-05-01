using System;
using System.Collections.Generic;
using DungeonExplorer.Creature;
using DungeonExplorer.Items;
using DungeonExplorer.World;

namespace DungeonExplorer.World
{
    public class Room
    {
        private string[] descriptions = {"Safe Room", "Enemy Room", "Treasure Room", "Boss Room"};
        private string description;
        private List<char> doors;
        private List<Item> Items = new List<Item>();
        private static Random rGen = new Random();
        public bool hasEnemy { get; private set; } // Can be read from outside the class but can only be changed inside the class

        public Room() // Initialises rooms description, if theres an enemy, a number of items and 
                                        // a number of doors
        {
            this.description = descriptions[rGen.Next(0,descriptions.Length)];
            this.doors = new List<char>();
            SetItems();
            SetEnemies();
        }

        private void SetItems()
        {
            int count = 0;
            Random rGen = new Random();
            for (int i = 0; i < 5; i++) 
            {
                int random = rGen.Next(100);
                if (random > 40) // 0 to 99   60% chance to spawn an item 
                {
                    switch (rGen.Next(2)) // Coin flip to decide if the item is a sword or potion
                    {
                        case 0:
                            Weapon weapon = new Weapon(count, "Sword", 10);
                            this.Items.Add(weapon);
                            break;
                        case 1:
                            Potion potion = new Potion();
                            this.Items.Add(potion);
                            break;
                    }
                }
                count++; // Changes count so that each item has a unique ItemID
            }
        }

        public void HasEnemy(bool boolean)
        {
            this.hasEnemy = boolean;
        }

        public void SetItem(Item item)
        {
            this.Items.Add(item);
        }

        public void SetDoors(char direction) // Creates an empty list of doors so the room has no doors in it
        {
            doors.Add(direction);
        }

        private void SetEnemies()
        {
            
        }

        public string GetDescription() // Returns the discription of the room
        {
            return description; 
        }

        public List<char> GetDoors() // Returns the doors in the room
        {
            return doors;
        }

        public List<Item> GetItems() // Returns the items in the room
        {
            return Items;
        }
    }
}