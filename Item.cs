using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        private int id { get; set; } // Encapsulation
        private string itemName { get; set; } // Encapsulation

        public Item(int id, string itemName)
        {
            this.id = id;
            this.itemName = itemName;
        }
    }

    public class Potion : Item // Inheritance
    {
        private int healthStored { get; set; }
        public Potion(int id, string itemName) : base(id, itemName)
        {
            this.healthStored = 20;
        }
    }

    public class Weapon : Item // Inheritance
    {
        private string modifier;
        private int weaponDamage { get; set; }
        public Weapon(int id, string itemName, int weaponDamage) : base(id, itemName)
        {
            this.weaponDamage = weaponDamage;
        }

        private void setModifier()
        {
            string[] modifiers = { "Common", "Uncommon", "Rare", "Epic", "Legendary" };

            Random rGen = new Random();
            int chance = rGen.Next(100);
            if (chance < 35)
            {
                this.modifier = modifiers[0];
            }
            else if (chance > 34 && chance < 55)
            {
                this.modifier = modifiers[1];
            }
            else if (chance > 54 && chance < 75)
            {
                this.modifier = modifiers[2];
            }
            else if (chance > 74 && chance < 90)
            {
                this.modifier = modifiers[3];
            }
            else if (chance > 89 && chance < 100)
            {
                this.modifier = modifiers[4];
            }
        }
    }

}
