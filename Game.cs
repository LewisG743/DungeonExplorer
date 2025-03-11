using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            Room room = new Room("Starting room. This room has nothing in it and is safe from enemies");
            currentRoom = room;

            Player player1 = new Player("Input", 100);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("Welcome to Dungeon Explorer");
                Console.WriteLine("Room description - D");
                Console.WriteLine("Search for doors - E");

            }
        }
    }
}