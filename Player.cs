using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string name { get; }
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
        public string InventoryContents()
        {
            foreach (Item item in inventory)
            {
                Console.WriteLine(item.GetItemName());
            }
            return string.Join(", ", inventory);
        }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                health -= damage;
            }
        }

        public void Heal(Potion healthPotion)
        {
            int healthHealed = healthPotion.GetHealthStored();
            if(healthHealed > 0)
            {
                health += healthHealed;
            }
        }
    }
}