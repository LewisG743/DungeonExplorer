using System;
using System.Collections.Generic;
using DungeonExplorer.Creatures;
using DungeonExplorer.Interfaces;
using DungeonExplorer.Items;
using DungeonExplorer.World;

namespace DungeonExplorer.Creatures
{
    public class Player : Creature,IDamagable
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

        public void PickUpItem(Item item)
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
        /*public void PickUpItem(Item item, Room room)
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
        }*/
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

        public void Heal(Potion healthPotion) // Heals health from a potion
        {
            int healthHealed = healthPotion.GetHealthStored();
            if(healthHealed > 0)
            {
                CurrentHealth += healthHealed;
            }
        }
    }
}