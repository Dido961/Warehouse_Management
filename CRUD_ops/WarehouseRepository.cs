using Dido_Summer.Data;
using Dido_Summer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Dido_Summer.CRUD_ops
{
    public class WarehouseRepository
    {
        public void AddCategory(Category category)
        {
            using (var context = new WarehouseContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public Category GetCategory(int categoryId)
        {
            using (var context = new WarehouseContext())
            {
                return context.Categories.Find(categoryId);
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            using (var context = new WarehouseContext())
            {
                return context.Categories.ToList();
            }
        }
        public void UpdateCategory(Category category)
        {
            using (var context = new WarehouseContext())
            {
                context.Categories.Update(category);
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (var context = new WarehouseContext())
            {
                var category = context.Categories.Find(categoryId);
                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
        }

        public void AddSupplier(Supplier supplier)
        {
            using (var context = new WarehouseContext())
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
            }
        }

        public Supplier GetSupplier(int supplierId)
        {
            using (var context = new WarehouseContext())
            {
                return context.Suppliers.Find(supplierId);
            }
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            using (var context = new WarehouseContext())
            {
                return context.Suppliers.ToList();
            }
        }
        public void UpdateSupplier(Supplier supplier)
        {
            using (var context = new WarehouseContext())
            {
                context.Suppliers.Update(supplier);
                context.SaveChanges();
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            using (var context = new WarehouseContext())
            {
                var supplier = context.Suppliers.Find(supplierId);
                if (supplier != null)
                {
                    context.Suppliers.Remove(supplier);
                    context.SaveChanges();
                }
            }
        }

        public void AddItem(Item item)
        {
            using (var context = new WarehouseContext())
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
        }

        public Item GetItem(int itemId)
        {
            using (var context = new WarehouseContext())
            {
                return context.Items.Find(itemId);
            }
        }

        public List<Item> GetAllItems()
        {
            using (var context = new WarehouseContext())
            {
                return context.Items.Include(i => i.Category)
                                    .Include(i => i.Supplier) // Include Supplier for referencing supplier property
                                    .ToList();
            }
        }

        public void UpdateItem(Item item)
        {
            using (var context = new WarehouseContext())
            {
                context.Items.Update(item);
                context.SaveChanges();
            }
        }

        public void DeleteItem(int itemId)
        {
            using (var context = new WarehouseContext())
            {
                var item = context.Items.Find(itemId);
                if (item != null)
                {
                    context.Items.Remove(item);
                    context.SaveChanges();
                }
            }
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            using (var context = new WarehouseContext())
            {
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }
        }

        public Warehouse GetWarehouse(int warehouseId)
        {
            using (var context = new WarehouseContext())
            {
                return context.Warehouses.Find(warehouseId);
            }
        }

        public IEnumerable<Warehouse> GetAllWarehouses()
        {
            using (var context = new WarehouseContext())
            {
                return context.Warehouses.ToList();
            }
        }
        public void UpdateWarehouse(Warehouse warehouse)
        {
            using (var context = new WarehouseContext())
            {
                context.Warehouses.Update(warehouse);
                context.SaveChanges();
            }
        }

        public void DeleteWarehouse(int warehouseId)
        {
            using (var context = new WarehouseContext())
            {
                var warehouse = context.Warehouses.Find(warehouseId);
                if (warehouse != null)
                {
                    context.Warehouses.Remove(warehouse);
                    context.SaveChanges();
                }
            }
        }

        public void AddInventory(Inventory inventory)
        {
            using (var context = new WarehouseContext())
            {
                context.Inventories.Add(inventory);
                context.SaveChanges();
            }
        }

        public Inventory GetInventory(int warehouseId, int itemId)
        {
            using (var context = new WarehouseContext())
            {
                return context.Inventories.FirstOrDefault(i => i.WarehouseID == warehouseId && i.ItemID == itemId);
            }
        }

        public void UpdateInventory(Inventory inventory)
        {
            using (var context = new WarehouseContext())
            {
                context.Inventories.Update(inventory);
                context.SaveChanges();
            }
        }

        public void DeleteInventory(int warehouseId, int itemId)
        {
            using (var context = new WarehouseContext())
            {
                var inventory = context.Inventories.FirstOrDefault(i => i.WarehouseID == warehouseId && i.ItemID == itemId);
                if (inventory != null)
                {
                    context.Inventories.Remove(inventory);
                    context.SaveChanges();
                }
            }
        }
    }
}
