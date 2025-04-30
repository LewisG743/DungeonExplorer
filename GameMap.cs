using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
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
                    dungeon[i, j] = new Room();
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
            currentRoom = dungeon[0, 0];
        }

        public Room GetCurrentRoom()
        {
            return currentRoom;
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
                currentRoom.SetDoors('N');
            }
            if (row < totalRows - 1) // Room below
            {
                currentRoom.SetDoors('S');
            }
            if (col > 0) // Room left
            {
                currentRoom.SetDoors('W');
            }
            if (col < totalCols - 1) // Room right
            {
                currentRoom.SetDoors('E');
            }
        }
    }
}
