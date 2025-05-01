using System;
using System.Collections.Generic;
using DungeonExplorer.Creatures;
using DungeonExplorer.Interfaces;
using DungeonExplorer.Items;
using DungeonExplorer.World;

namespace DungeonExplorer.Creatures
{
    public class Player : Creature,IDamagable // Inheritance from Creature class and IDamagable implemented
    {
        private List<Item> inventory = new List<Item>();
        private int Defence;

        public Player(string name) : base(name, 100, 10, 10) 
        {
            Name = name;
            Defence = 50;
        }

        public override void TakeDamage(int damage)
        {
            CurrentHealth -= damage * Defence/100; 
        }

        public void PickUpItem(Item item) // picks up items
        {
            if (inventory.Count < 10)
            {
                inventory.Add(item);
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

        public List<Item> InventoryItems() // returns the inventory
        {
            return inventory;
        }

        public bool HasItem(Item item) // checks if an item is in the inventory
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

        public void Heal(Potion healthPotion) // Heals health from a potion
        {
            int healthHealed = healthPotion.GetHealthStored();
            if (CurrentHealth + healthHealed >= MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            else
            {
                CurrentHealth += healthHealed;
            }
        }
    }
}