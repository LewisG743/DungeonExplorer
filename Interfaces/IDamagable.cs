using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Interfaces
{
    public interface IDamagable // IDamagable interface with TakeDamage Function
    {
        void TakeDamage(int amount);
    }
}
