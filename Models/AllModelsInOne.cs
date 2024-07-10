using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dido_Summer.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Item> Items { get; set; }
    }

    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactInfo { get; set; }
        public ICollection<Item> Items { get; set; }
    }

    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }

    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public string Location { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }

    public class Inventory
    {
        public int WarehouseID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }

        public Warehouse Warehouse { get; set; }
        public Item Item { get; set; }
    }

}
