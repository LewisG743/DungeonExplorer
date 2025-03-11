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
                foreach (Item x in room.GetItems()) // Loops through all the items in the room
                {
                    if (x.GetID() == item.GetID()) // Checks to see if the items are the same item
                    {
                        room.GetItems().Remove(x); // removes the item from the room 
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