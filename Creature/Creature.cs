using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Creature;
using DungeonExplorer.Items;
using DungeonExplorer.World;

namespace DungeonExplorer.Creature
{
    public abstract class Creature
    {
        public string Name { get; set; }

        public int CurrentHealth { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int BaseDamage { get; protected set; }
        public int BaseSpeed { get; protected set; }

        public bool IsAlive => CurrentHealth > 0;
        public Creature(string name, int maxHealth, int baseDamage, int baseSpeed)
        {
            Name = name;
            CurrentHealth = maxHealth;
            MaxHealth = maxHealth;
            BaseDamage = baseDamage;
            BaseSpeed = baseSpeed;
        }

        public virtual void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
        }

        public virtual void DealDamage(Creature creature)
        {
            creature.TakeDamage(BaseDamage);
        }
    }
}
