using DungeonExplorer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Items
{
    public class Item
    {
        private string ItemName { get; set; } // Encapsulation

        public Item(string itemName) // Initialises an item with an ID and name
        {
            ItemName = itemName;
        }

        public string GetItemName() // Returns the ItemName
        {
            return ItemName;
        }

        
    }
}
