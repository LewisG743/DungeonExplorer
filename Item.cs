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

        public Item(int id, string itemName) // Initialises an item with an ID and name
        {
            this.id = id;
            this.itemName = itemName;
        }

        public int GetID() // Returns the ItemID
        {
            return id;
        }

        public string GetItemName() // Returns the ItemName
        {
            return itemName;
        }
    }

    public class Potion : Item // Inheritance
    {
        private int healthStored { get; set; }
        public Potion(int id, string itemName) : base(id, itemName) // Sets the health as well as the Masterclass items attributes
        {
            this.healthStored = 20;
        }

        public int GetHealthStored() // Returns health stored in the potion
        {
            return healthStored;
        }
    }

    public class Weapon : Item // Inheritance
    {
        private string modifier;
        private int weaponDamage { get; set; }
        public Weapon(int id, string itemName, int weaponDamage) : base(id, itemName) // Sets the weapon damage as well as the Masterclass items attributes
        {
            setModifier();
            this.weaponDamage = weaponDamage * (1 + (this.modifier[this.modifier.Length - 1] / 10));
        }

        private void setModifier() // Randomly chooses a modifier for the weapon with varying chances for each one
        {
            string[] modifiers = { "Common0", "Uncommon1", "Rare2", "Epic3", "Legendary4" };

            Random rGen = new Random();
            int chance = rGen.Next(100);
            if (chance < 40) // 0 to 39 (40%)
            {
                this.modifier = modifiers[0];
            }
            else if (chance > 39 && chance < 70) // 40 to 69 (30%)
            {
                this.modifier = modifiers[1];
            }
            else if (chance > 69 && chance < 85) //  70 to 84 (15%)
            {
                this.modifier = modifiers[2];
            }
            else if (chance > 84 && chance < 95) // 85 to 94 (10%)
            {
                this.modifier = modifiers[3];
            }
            else if (chance > 94 && chance < 100) // 95 to 99 (5%)
            {
                this.modifier = modifiers[4];
            }
        }

        public int GetWeaponDamage()
        {
            return this.weaponDamage;
        }
    }
}
