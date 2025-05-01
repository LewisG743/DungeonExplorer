using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Utils
{
    public static class RandomProvider // Random class so that every instance of random is random
    {
        public static readonly Random rGen = new Random();
    }
}
