using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Dungeon.Model.Items
{
    internal class ArmorKit : Item
    {
        public ArmorKit()
        {
            Weight = 10;
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}
