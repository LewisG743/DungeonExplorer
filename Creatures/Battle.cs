using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Items;
using DungeonExplorer.Creatures;
using System.Xml.Serialization;

namespace DungeonExplorer.Creatures
{
    public class Battle
    {
        private Player _player;
        private Creature _enemy;

        public Battle(Player player, Creature enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public void Start()
        {
            Console.WriteLine($"You have been attacked by an enemy {_enemy.Name}");
            int turn = 0;
            while (_player.IsAlive && _enemy.IsAlive)
            {
                turn++;
                UI();
                string choice = Console.ReadLine();
                bool validInput = false;
                while ( !validInput)
                {
                    if (choice == "1")
                    {
                        validInput = true;
                        _player.Attack(_enemy);
                    }
                    else if (choice == "2")
                    {
                        validInput = true;
                        InventoryUI();
                    }
                    else if (choice == "3")
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        validInput = false;
                    }
                }
            }
        }

        public void UI()
        {
            Console.WriteLine("1: Attack   2: Inventory   3: Run");
            Console.WriteLine($"{_player.Name} has {_player.CurrentHealth}/{_player.MaxHealth}");
            Console.WriteLine($"{_enemy.Name} has {_enemy.CurrentHealth}/{_player.MaxHealth}");
        }

        public void InventoryUI()
        {
            if (_player.InventoryItems().Count == 0)
            {
                Console.WriteLine("Inventory is empty");
                return;
            }
            Console.WriteLine("Your Inventory");
            for(int i = 0; i < _player.InventoryItems().Count; i++)
            {
                Console.WriteLine($"{i}: {_player.InventoryItems()[i].GetItemName()}");
            }

            Console.WriteLine("Choose an item (0 to cancel)");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                Console.WriteLine("No item used");
                return;
            }

            if (choice > 0 && choice <= _player.InventoryItems().Count)
            {
                if (_player.InventoryItems()[choice - 1] is Potion)
                {
                    Potion chosenItem = (Potion)_player.InventoryItems()[choice - 1];
                    chosenItem.Consume(_player.InventoryItems(), _player);
                }
                else
                {
                    Console.WriteLine("Item is not consumable");
                }
            }
        }
    }
}
