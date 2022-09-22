using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Dungeon.Model;
using The_Dungeon.Model.Bags;
using The_Dungeon.Model.Characters;
using The_Dungeon.Model.Items;

namespace The_Dungeon.View
{
    internal class TestView
    {
        public TestView()
        {
            Warrior war1 = new Warrior("Joe", "Cocken Spaniel");
            Warrior war2 = new Warrior("Boes", "Cocken Spaniel");
            Cleric cle1 = new Cleric("Ko", "Cocker Spaniel");
        }
    }
}
