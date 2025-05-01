using DungeonExplorer.Creatures;
using DungeonExplorer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Items
{
    public class Potion : Item,IConsumable // Inheritance
    {
        private int healthStored { get; set; }
        public Potion() : base("Potion") // Sets the health as well as the Masterclass items attributes
        {
            healthStored = 20;
        }

        public void Consume(List<Item> items, Player player)
        {
            items.Remove(this);
            player.Heal(this);
        }

        public int GetHealthStored()
        {
            return healthStored;
        }
    }
}
