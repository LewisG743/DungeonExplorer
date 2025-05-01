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
    public class Dragon : Creature,ILootable
    {
        private List<Item> _items;
        public Dragon() : base("Dragon", 300, 25, 20)
        {
            _items = new List<Item>();
            _items.Add(new DragonScale());
            _items.Add(new Potion());
        }

        public Item Loot()
        {
            if (_items.Count > 0)
            {
                Item item = _items[RandomProvider.rGen.Next(0, _items.Count)];
                _items.Remove(item);
                return item;
            }
            else
            {
                return null;
            }
        }
    }
}
