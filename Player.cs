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