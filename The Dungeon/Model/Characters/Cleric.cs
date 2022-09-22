using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Dungeon.Model.Bags;
using The_Dungeon.Model.Interfaces;

namespace The_Dungeon.Model.Characters
{
    public class Cleric : Character , IHealable
    {
        public Cleric(string name, string faction) : base(name, 50, 25, 40, new Backpack(), faction)
        {
            RestHealMultiplier = 0.5f;
        }

        public void Heal(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException($"{character.Name} is already dead...");
            }

            if (Faction != character.Faction)
            {
                throw new ArgumentException($"You cant heal {character.Name} beacause is from different faction ({Faction})");
            }

            character.Health += AbilityPoint;
        }
    }
}
