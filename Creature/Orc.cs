using DungeonExplorer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Items;
using DungeonExplorer.Utils;

namespace DungeonExplorer.Creature
{
    public class Orc : Creature,IDamagable,ILootable
    {
        private List<Item> _items = new List<Item>();

        public Orc() : base("Orc", 100, 5, 5)
        {
            _items.Add(new Potion());
        }

        public Item Loot()
        {
            if (_items.Count == 0)
            {
                return null;
            }
            int index = RandomProvider.rGen.Next(0, _items.Count);
            Item item = _items[index];
            _items.RemoveAt(index);
            return item;
        }

        public override void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            Console.WriteLine("The orc let out a deep, blood-curdling howl");
            Console.WriteLine($"You have delt {amount} damage to the orc: {CurrentHealth}/{MaxHealth}");
        }
    }
}
