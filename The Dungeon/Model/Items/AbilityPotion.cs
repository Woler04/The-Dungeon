using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Dungeon.Model.Items
{
    internal class AbilityPotion : Item
    {
        public AbilityPotion()
        {
            Weight = 5;
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.AbilityPoint += 50;
        }
    }
}
