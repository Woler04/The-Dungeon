using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Dungeon.Model;
using The_Dungeon.Model.Characters;
using The_Dungeon.Model.Items;

namespace The_Dungeon.Controller
{
    public class DungeonMaster
    {
        private static Queue<Character> party = new Queue<Character>();
        private static Stack<Item> itemPool = new Stack<Item>();
        private static int survivors = 0;

        //args - faction, characterType, name;
        public string JoinParty(string[] args)
        {
            Character charaToAdd;
            switch (args[1])
            {
                case "Warrior":
                    charaToAdd = new Warrior(args[2], args[0]);
                    break;
                case "Cleric":
                    charaToAdd = new Cleric(args[2], args[0]);
                    break;
                default:
                    throw new ArgumentException($"No type? bro get real {args[0]} is not a thing");
            }

            survivors++;
            party.Enqueue(charaToAdd);
            return $"{args[2]} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            Item itemToAdd;
            switch (args[0])
            {
                case "ArmorRepairKit":
                    itemToAdd = new ArmorRepairKit();
                    break;
                case "HealthPotion":
                    itemToAdd = new HealthPotion();
                    break;
                case "PoisonPotion":
                    itemToAdd = new PoisonPotion();
                    break;
                case "AbilityPotion":
                    itemToAdd = new AbilityPotion();
                    break;
                default:
                    throw new ArgumentException($"Invalid item {args[0]}");
                    
            }

            itemPool.Push(itemToAdd);
            return $"{args[0]} added to pool!";
        }

        public string PickUpItem(string[] args)
        {
            Character chara = party.Where(c => c.Name == args[0]).FirstOrDefault();

            if (chara == null)
            {
                //throw new ArgumentException($"Character {args[0]} not found!");
                return $"Character {args[0]} not found!";
            }
            if (itemPool.Count <= 0)
            {
                //throw new InvalidOperationException($"No items left in pool!");
                return $"No items left in pool!";
            }
            else
            {
                Item lastItem = itemPool.Pop();
                chara.ReceiveItem(lastItem);
                return $"{args[0]} picked up {lastItem.GetType().Name}!";
            }
        }

        public string UseItem(string[] args)
        {
            Character chara = party.Where(c => c.Name == args[0]).FirstOrDefault();
            Item itemToUse = chara.Bag.Items.Where(o => o.GetType().Name == args[1]).FirstOrDefault();

            if (chara == null)
            {
                //throw new ArgumentException($"Character {args[0]} not found!");
                return $"Character {args[0]} not found!";
            }
            if (itemToUse == null)
            {
                //throw new ArgumentException($"Item {args[0]} not found!");
                return $"Item {args[1]} not found!";
            }
            else
            {
                chara.UseItem(itemToUse);
                return $"{chara.Name} used {args[1]}";
            }
        }

        public string UseItemOn(string[] args)
        {
            Character chara = party.Where(c => c.Name == args[0]).FirstOrDefault();
            Item itemToUse = itemPool.Where(o => o.GetType().Name == args[2]).FirstOrDefault();
            Character victim = party.Where(c => c.Name == args[1]).FirstOrDefault();

            if (itemToUse == null)
            {
                return $"Invalid Operation: No items left in pool!";
            }

            chara.UseItemOn(itemToUse, victim);

            return $"{chara} used {itemToUse} on {victim}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            Character chara = party.Where(c => c.Name == args[0]).FirstOrDefault();
            Item itemToGive = itemPool.Where(o => o.GetType().Name == args[2]).FirstOrDefault();
            Character reciver = party.Where(c => c.Name == args[1]).FirstOrDefault();

            if (itemToGive == null)
            {
                return $"Invalid Operation: No item with name HealthPotion in bag!";
            }

            chara.GiveCharacterItem(itemToGive, reciver);
            return $"{chara} gave {itemToGive} to {reciver}.";
        }

        public void GetStats()
        {
            foreach (var chara in party)
            {
                if (chara.IsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine($"{chara.Name} - {chara.Faction} : {chara.GetType().Name}");
                Console.WriteLine($"HP = {chara.Health}/{chara.BaseHealth}");
                Console.WriteLine($"DEF = {chara.Armor}/{chara.BaseArmor}");
                Console.WriteLine($"AP = {chara.AbilityPoint}");
                Console.WriteLine($"Bag: {chara.Bag.GetType().Name}");
                foreach (var item in chara.Bag.Items)
                {
                    Console.WriteLine(item.GetType().Name);
                }
                Console.WriteLine("------------------------------------------------------");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Attack(string[] args)
        {
            Warrior chara = (Warrior)party.FirstOrDefault(c => c.GetType().Name == "Warrior"  && c.Name == args[0]);
            Character reciver = party.Where(c => c.Name == args[1]).FirstOrDefault();
            if (chara != null)
            {
                chara.Attack(reciver);
                Console.WriteLine($"{reciver.Name} HP: {reciver.Health}");
            }
        }

        public void Heal(string[] args)
        {
            Cleric chara = (Cleric)party.FirstOrDefault(c => c.GetType().Name == "Cleric" && c.Name == args[0]);
            Character reciver = party.Where(c => c.Name == args[1]).FirstOrDefault();
            if (chara != null)
            {
                chara.Heal(reciver);
            }
        }
        public void EndTurn()
        {
            foreach (var chara in party)
            {
                if (chara.IsAlive)
                {
                    chara.Rest();
                }
                else
                {
                    survivors--;
                }
            }
        }
        public bool IsGameOver()
        {
            if (survivors < 1)
            {
                return true;
            }
            Console.WriteLine($"THE WINNER IS {party.Where(c => c.IsAlive).FirstOrDefault().Name}");
            return false;
        }
    }
}
