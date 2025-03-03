using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        public int id {  get; private set; }
        public string itemName { get; private set; }

        public Item(int id, string itemName)
        {
            this.id = id;
            this.itemName = itemName;
        }
    }
}
