using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Creatures;
using DungeonExplorer.Interfaces;
using DungeonExplorer.Items;
using DungeonExplorer.World;

namespace DungeonExplorer.Creatures
{
    public abstract class Creature : IDamagable // Base class for inheritance as well as IDamagable interface
    {
        public string Name { get; set; }

        public int CurrentHealth { get; protected set; } // protected (only the base class and derived classes can change)
        public int MaxHealth { get; protected set; }
        public int BaseDamage { get; protected set; }
        public int BaseSpeed { get; protected set; }

        public bool IsAlive => CurrentHealth > 0;
        public Creature(string name, int maxHealth, int baseDamage, int baseSpeed) // base constructor
        {
            Name = name;
            CurrentHealth = maxHealth;
            MaxHealth = maxHealth;
            BaseDamage = baseDamage;
            BaseSpeed = baseSpeed;
        }

        public virtual void TakeDamage(int damage) // virtual so can be overriden when necessary
        {
            CurrentHealth -= damage;
        }

        public virtual void Attack(Creature creature) // Inherited class with all Creatures
        {
            creature.TakeDamage(BaseDamage);
        }


    }
}
