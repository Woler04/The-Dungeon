using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Dungeon.Model.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion()
        {
            Weight = 5;
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20;
        }
    }
}
