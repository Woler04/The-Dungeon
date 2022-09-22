using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Dungeon.Model
{
    public abstract class Bag
    {
        private int cap = 0;
        private int load; //Calculated property. The sum of the weights of the items in the bag
        private List<Item> items;

        public Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            Items = new List<Item>();
        }

        public int Capacity { get => this.cap; private set => this.cap = value; }
        public int Load { get => this.load; private set => this.load = value; }
        public List<Item> Items { get => this.items; private set => this.items = value; }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new ArgumentException("The bag is full");
            }
            Items.Add(item);
        }

        public Item GetItem(string itemName)
        {
            if (Items.Count <= 0)
            {
                throw new ArgumentException("Bag is empty");
            }

            Item itemToReturn = Items.Where(i => i.GetType().Name == itemName).FirstOrDefault();

            if (itemToReturn == null)
            {
                throw new ArgumentException($"No item with name {itemName} in bag!");
            }

            Items.Remove(itemToReturn);

            return itemToReturn;
        }

    }
}
