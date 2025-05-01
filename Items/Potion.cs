using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Items
{
    public class Potion : Item // Inheritance
    {
        private int healthStored { get; set; }
        public Potion() : base("Potion") // Sets the health as well as the Masterclass items attributes
        {
            this.healthStored = 20;
        }

        public int GetHealthStored() // Returns health stored in the potion
        {
            return healthStored;
        }
    }
}
