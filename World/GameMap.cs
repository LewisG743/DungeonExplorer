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
    public class GameMap // GameMap handles multiple connected rooms
    {
        private Room[,] dungeon = new Room[6, 6];
        private Room currentRoom; // sets current room
        public GameMap()
        {
            int width = dungeon.GetLength(0);
            int height = dungeon.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    dungeon[i, j] = new Room(); // Assigns each cell in the 2d array a new room
                }
            }
            
            for (int i = 0;i < width; i++)
            {
                for(int j = 0;j < height; j++)
                {
                    currentRoom = dungeon[i, j];
                    GetAdjacentRooms(dungeon, currentRoom, i, j); // Checks the adjacent rooms and sets doors (directions) for each room
                }
            }
            bool ZeroZero = true;
            int randI = -1;
            int randJ = -1;
            while (ZeroZero) // makes sure that the room at 0,0 is not a boss room
            {
                randI = RandomProvider.rGen.Next(0, dungeon.GetLength(0));
                randJ = RandomProvider.rGen.Next(0, dungeon.GetLength(1));
                if (!(randI == 0 && randJ == 0))
                {
                    ZeroZero = false;
                }
            }
            // changes the specified room to a boss room
            dungeon[randI, randJ].description = "Boss Room";
            dungeon[randI, randJ].HasEnemy = true;
            dungeon[randI, randJ].enemy = new Dragon();
            currentRoom = dungeon[0, 0];
        }

        public Room GetCurrentRoom() // gets the current room
        {
            return currentRoom;
        }

        public Room[,] GetDungeon() // gets the dungeon map
        {
            return dungeon;
        }
        public void SetCurrentRoom(Room NewCurrentRoom) // sets current room
        {
            currentRoom = NewCurrentRoom;
        }

        public void GetAdjacentRooms(Room[,] map, Room currentRoom, int row, int col) // sets doors if there are adjacent rooms
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

        public void DisplayMap(Room currentRoom) // displays the map and which type of room each room is
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
