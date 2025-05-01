using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Items;

namespace DungeonExplorer.Interfaces
{
    public interface ILootable // ILootable with Loot function
    {
        Item Loot();
    }
}
