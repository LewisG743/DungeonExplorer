using DungeonExplorer.Creatures;
using DungeonExplorer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.World
{
    public class GameMap
    {
        private Room[,] dungeon = new Room[6, 6];
        private Room currentRoom;
        public GameMap()
        {
            int width = dungeon.GetLength(0);
            int height = dungeon.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    dungeon[i, j].description = "Boss Room";
                    dungeon[i, j].enemy = new Dragon();
                    dungeon[i, j].HasEnemy = true;
                }
            }
            
            for (int i = 0;i < width; i++)
            {
                for(int j = 0;j < height; j++)
                {
                    currentRoom = dungeon[i, j];
                    GetAdjacentRooms(dungeon, currentRoom, i, j);
                }
            }
            bool ZeroZero = true;
            int randI = -1;
            int randJ = -1;
            while (ZeroZero)
            {
                randI = RandomProvider.rGen.Next(0, dungeon.GetLength(0));
                randJ = RandomProvider.rGen.Next(0, dungeon.GetLength(1));
                if (!(randI == 0 && randJ == 0))
                {
                    ZeroZero = false;
                }
            }
            dungeon[randI, randJ] = new Room();
            currentRoom = dungeon[0, 0];
        }

        public Room GetCurrentRoom()
        {
            return currentRoom;
        }

        public Room[,] GetDungeon()
        {
            return dungeon;
        }
        public void SetCurrentRoom(Room NewCurrentRoom)
        {
            currentRoom = NewCurrentRoom;
        }

        public void GetAdjacentRooms(Room[,] map, Room currentRoom, int row, int col)
        {
            int totalRows = map.GetLength(0);
            int totalCols = map.GetLength(1);
            if (row > 0) // Room above
            {
                currentRoom.SetDoors('n');
            }
            if (row < totalRows - 1) // Room below
            {
                currentRoom.SetDoors('s');
            }
            if (col > 0) // Room left
            {
                currentRoom.SetDoors('w');
            }
            if (col < totalCols - 1) // Room right
            {
                currentRoom.SetDoors('e');
            }
        }

        public void DisplayMap(Room currentRoom)
        {
            Room[,] map = dungeon;
            Console.WriteLine("\n");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write("[");
                    if (map[i, j] == currentRoom)
                    {
                        Console.Write("c");
                    }
                    else
                    {
                        Console.Write(map[i, j].description[0]);
                    }
                    Console.Write("]");
                }
                Console.Write("\n");
            }
        }

        public int GetMapRows()
        {
            return dungeon.GetLength(0);
        }

        public int GetMapCols()
        {
            return dungeon.GetLength(1);
        }
    }
}
