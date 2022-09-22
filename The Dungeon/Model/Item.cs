using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Dungeon.Model
{
    public abstract class Item
    {
        private int weight = 0;

        public int Weight { 
            get => this.weight; 
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("bruh this potion is imaginary or what?");
                }
                this.weight = value; 
            }
        }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException("Character must be alive");
            }
        }
    }
}
