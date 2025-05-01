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
    public class Dragon : Creature,ILootable,IDamagable
    {
        private List<Item> _items = new List<Item>();
        public Dragon() : base("Dragon", 300, 25, 20)
        {
            _items.Add(new DragonScale());
            _items.Add(new DragonScale());
        }

        public override void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            Console.WriteLine("The dragon screams in pain");
            Console.WriteLine($"You have delt {amount} damage to the dragon: {CurrentHealth}/{MaxHealth}");
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
    }
}
