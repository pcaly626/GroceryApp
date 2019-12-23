using System.Net.NetworkInformation;
namespace CGrocery
{
    namespace Inventory
    {
        public abstract class Item
        {
            public Item( string Vendor, string ItemName, float Cost, int PID )
            {
                this.Vendor = Vendor;
                this.ItemName = ItemName;
                this.Cost = Cost;
                this.PID = PID;
            }

            public string Vendor{
                get;
            }

            public string ItemName{
                get;
            }

            public float Cost{
                get;
                set;
            }

            public int PID{
                get;
            }


            override public string ToString()
            {
                return string.Format("Name: {0} PID: {1}, Vendor: {2}, Cost: {3}", this.ItemName, this.PID, this.Vendor, this.Cost);
            }
        }
    }
}