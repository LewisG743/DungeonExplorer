using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Creature;
using DungeonExplorer.Items;
using DungeonExplorer.World;

namespace DungeonExplorer.Creature
{
    public class Enemy : Creature 
    {
        private int health;
        public string name { get; }
        private int damage;
        private Item Item;

        public Enemy(string name)
        {
            health = 100;
            this.name = name;
            damage = 5;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
        public int GetHealth()
        {
            return health;
        }

        public int GetDamage()
        {
            return damage;
        }

        public Item DropItem(Room room) // Drops item after death
        {
            Random rGen = new Random();
            int count = room.GetItems().Count - 1;
            if (rGen.Next(100) > 30) // Randomly chooses between Meat and Potion to drop
            {
                Item meat = new Item(count, "Meat");
                return meat;
            }
            else
            {
                Potion potion = new Potion(count, "Potion");
                return potion;
            }
        }
    }
}
