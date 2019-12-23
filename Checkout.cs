using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using CGrocery.Inventory;

namespace CGrocery
{
    public class Checkout
    {
        private List<Item> checkoutList_ = new List<Item>();
        private const float TAX = .07f;
        public Checkout( )
        {

        }

        public void AddToCheckoutList(Item item)
        {
            checkoutList_.Add( item );
        }

        public List<Item> Tally()
        {
            foreach(Item it in checkoutList_)
            {
                Console.WriteLine( it.ToString());
            }
            return checkoutList_;
        }

        public float CalculateTotal()
        {
            float total = 0.0f;
            foreach(Item it in checkoutList_)
            {
                total += it.Cost;
            }

            return total + (total * TAX);
        }
    }
}
