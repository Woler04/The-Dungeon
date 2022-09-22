using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Dungeon.Model.Bags;
using The_Dungeon.Model.Interfaces;

namespace The_Dungeon.Model.Characters
{
    internal class Warrior : Character, IAttackable
    {
        public Warrior(string name, string faction) : base(name, 100, 50, 40, new Satchel(), faction)
        { }

        public void Attack(Character character)
        {
            if (character == this)
            {
                Console.WriteLine("You attacked yourself hahahahaha");
            }

            if (!character.IsAlive)
            {
                throw new ArgumentException($"{character.Name} is already dead...");
            }
            
            if (Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {Faction} faction!");
            }

            character.TakeDamage(AbilityPoint);
        }
    }
}
