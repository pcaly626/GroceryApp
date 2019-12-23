using System;

namespace CGrocery
{
    namespace ProjectExceptions
    {
        public class InventoryExceptions : Exception
        {
            public InventoryExceptions()
            {
                Console.WriteLine("ERROR: Item Name Is Not Unique or Not able to add");
            }

            public InventoryExceptions(string message)
                : base(message)
            {
                Console.WriteLine(message + ": Item Name Is Not Unique");
            }

            public InventoryExceptions(string message, Exception inner)
                : base(message, inner)
            {
                Console.WriteLine(message + ": Item Name Is Not Unique");
                Console.WriteLine(inner);
            }
        }
    }
}