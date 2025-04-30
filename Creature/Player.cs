using System;
using System.Collections.Generic;
using DungeonExplorer.Creature;
using DungeonExplorer.Items;
using DungeonExplorer.World;

namespace DungeonExplorer.Creature
{
    public class Player
    {
        public string name { get; set; }
        private int health { get; set; }
        private List<Item> inventory = new List<Item>();

        public Player(string Name, int initialHealth) 
        {
            name = Name;
            health = initialHealth;
        }
        public void PickUpItem(Item item, Room room)
        {
            if (inventory.Count < 10) // Checks to see if inventory is full
            {
                inventory.Add(item); // Adds the item found to inventory
                for (int i = room.GetItems().Count - 1; i >= 0; i--)
                {
                    if (room.GetItems()[i].GetID() == item.GetID()) // Checks to see if the items are the same item
                    {
                        room.GetItems().Remove(room.GetItems()[i]); // removes the item from the room 
                    }
                }
            }
            else
            {
                Console.WriteLine("Inventory is full");
            }
        }
        public void InventoryContents() // Displays the inventory contents
        {
            foreach (Item item in inventory)
            {
                Console.WriteLine(item.GetItemName());
            }
        }

        public List<Item> InventoryItems()
        {
            return inventory;
        }

        public bool HasItem(Item item)
        { 
            foreach(Item x in inventory)
            {
                if(item.GetItemName() == x.GetItemName())
                {
                    return true;
                }
            }
            return false;
        }

        public void TakeDamage(int damage) // Takes damage
        {
            if (damage > 0)
            {
                health -= damage;
            }
        }

        public void Heal(Potion healthPotion) // Heals health from a potion
        {
            int healthHealed = healthPotion.GetHealthStored();
            if(healthHealed > 0)
            {
                health += healthHealed;
            }
        }

        public int GetHealth()
        {
            return health;
        }
    }
}