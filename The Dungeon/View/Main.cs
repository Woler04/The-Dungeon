using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Dungeon.Controller;

namespace The_Dungeon.View
{
    internal class Main
    {
        DungeonMaster dm;
        public Main()
        {
            dm = new DungeonMaster();
            Input();
        }

        /*
JoinParty Cock Warrior Woler
JoinParty Balls Warrior Mart
AddItemToPool PoisonPotion
PickUpItem Woler
GetStats
UseItem Woler PoisonPotion
AddItemToPool ArmorRepairKit
UseItem Mart ArmorRepairKit
GetStats
         
         */

        private void Input()
        {
            string[] input = Console.ReadLine().Split().ToArray();
            string cml = input[0];
            string[] args = input.Skip(1).ToArray();
            switch (cml)
            {
                case "JoinParty":
                    Console.WriteLine(dm.JoinParty(args));
                    break;
                case "AddItemToPool":
                    Console.WriteLine(dm.AddItemToPool(args));
                    break;
                case "PickUpItem":
                    Console.WriteLine(dm.PickUpItem(args));
                    break;
                case "UseItem":
                    Console.WriteLine(dm.UseItem(args));
                    break;
                case "UseItemOn":
                    Console.WriteLine(dm.UseItemOn(args));
                    break;
                case "GiveCharacterItem":
                    Console.WriteLine(dm.GiveCharacterItem(args));
                    break;
                case "GetStats":
                    dm.GetStats();
                    break;
                case "Attack":
                    dm.Attack(args);
                    break;
                case "Heal":
                    dm.Heal(args);
                    break;
                case "EndTurn":
                    dm.EndTurn();
                    break;
                case "IsGameOver":
                    if (dm.IsGameOver())
                    {
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("SKILL ISSIUE");
                    break;
            }

            Input();
        }
    }
}
