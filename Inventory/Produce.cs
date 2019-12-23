using System.Runtime.CompilerServices;
using System.Diagnostics.SymbolStore;
using System.Numerics;
using System.Net.NetworkInformation;
namespace CGrocery 
{
    namespace Inventory
    {
        public class Produce : Item
        {
            public Produce(string Type, string Vendor, string ItemName, float Cost, int PID)
            : base( Vendor, ItemName, Cost, PID )
            {
                this.Type = Type;
            }

            public string Type
            {
                get;
                set;
            }

            override public string ToString()
            {
                return string.Format("Name: {0} PID: {1}, Vendor: {2}, Cost: {3}, Type: {4}", this.ItemName, this.PID, this.Vendor, this.Cost, this.Type );
            }
        }
    }
}