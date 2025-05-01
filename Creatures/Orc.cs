using DungeonExplorer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Items;
using DungeonExplorer.Utils;
using DungeonExplorer.Creatures;

namespace DungeonExplorer.Creatures
{
    public class Orc : Creature,IDamagable,ILootable // Interface implementation in Orc class
    {
        private List<Item> _items = new List<Item>();

        public Orc() : base("Orc", 100, 5, 5) // Creates a new orc
        {
            _items.Add(new Potion());
        }

        public List<Item> Items()
        {
            return _items;
        }
        public Item Loot() // Requires Loot() function due to the ILootable interface
                           // Checks to see if the items on the enemy is empty
        {
            if (_items.Count == 0)
            {
                return null;
            }
            int index = RandomProvider.rGen.Next(0, _items.Count); // Randomly chooses an item to take
            Item item = _items[index];
            _items.RemoveAt(index);
            return item;
        }

        public override void TakeDamage(int amount) // Override from Creature base class because it has been altered
                                                    // Take damage required from IDamagable
        {
            CurrentHealth -= amount;
            Console.WriteLine("The orc let out a deep, blood-curdling howl");
            Console.WriteLine($"You have delt {amount} damage to the orc: {CurrentHealth}/{MaxHealth}");
        }
    }
}
