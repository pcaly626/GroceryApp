using System.Collections.Generic;
using CGrocery.Inventory;
using MySql.Data.MySqlClient;
using CGrocery.ProjectExceptions;
using System;

namespace CGrocery
{
    public class InventoryManager
    {
        private Dictionary<int, Item> inventory_ = new Dictionary<int, Item>();
        private MySqlConnection mySql_;
        public InventoryManager()
        {
            string connection = "SERVER=localhost; DATABASE=HEB; UID=paul; PASSWORD=''";
            this.mySql_ = new MySqlConnection( connection );
            if(mySql_.State.ToString().Equals("Closed"))
                mySql_.Open();
            LoadInventory();
        }

        ~InventoryManager()
        {
            mySql_.Close();
            inventory_.Clear();
        }

        //Schema Produce (Cost, ItemName, Vendor, Type)
        public bool AddProduce( float cost, string itemName, string vendor, string type )
        {
            bool success = false;

            string insert = 
                string.Format("insert into Produce (Cost, ItemName, Vendor, Type)" +
                "values ({0},'{1}','{2}','{3}');", cost, itemName, vendor, type);
            try 
            {
                MySqlCommand cmd = new MySqlCommand( insert, mySql_ );
                cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                //Updates the inventory in DataStructure
                Console.WriteLine(e.ToString());
            }
            success = LoadInventory();

            return success;
        }

        public Dictionary<int, Item> SelectAllProduce( )
        {
            return inventory_;
        }

        public Item FindItem( int PID )
        {
            return inventory_[PID];
        }
        private bool LoadInventory()
        {
            bool loaded = false;
            inventory_.Clear();
            MySqlCommand cmd = new MySqlCommand( "select * from Produce;", mySql_ );
            using( MySqlDataReader result = cmd.ExecuteReader())
            {
                while(result.Read())
                {
                    inventory_.Add( (int)result["PID"], 
                    new Produce((string)result["Type"], (string)result["Vendor"], 
                    (string)result["ItemName"], (float)result["Cost"], (int)result["PID"] ) );
                }
                loaded = true;
            }
            return loaded;
        }

        
    }
}