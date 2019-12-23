using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using CGrocery.Inventory;

namespace CGrocery
{
    public class Program
    {
        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();
            Checkout co = new Checkout();
            Dictionary<int, Item> m = manager.SelectAllProduce();
            foreach( Item it in m.Values)
            {
                Console.WriteLine(it.ToString());
            }
            manager.AddProduce(30.99f, "Friskeys", "Purina", "Cat");
            Console.WriteLine("\n\n");
            manager.SelectAllProduce();

            co.AddToCheckoutList(m[1]);
            co.AddToCheckoutList(m[2]);
            co.Tally();
            float total = co.CalculateTotal();
            Console.Write(total);
        }
    }
}
