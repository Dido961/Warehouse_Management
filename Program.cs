using Dido_Summer.Models;
using Dido_Summer.CRUD_ops;
using Dido_Summer.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dido_Summer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new WarehouseRepository();
            using (var context = new WarehouseContext()) // Added context here
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*^*^*Warehouse Management System*^*^*");
                    Console.ResetColor();
                    Console.WriteLine("1 } Add Category");
                    Console.WriteLine("2 } View Category");
                    Console.WriteLine("3 } Update Category");
                    Console.WriteLine("4 } Delete Category");
                    Console.WriteLine("5 } Add Supplier");
                    Console.WriteLine("6 } View Supplier");
                    Console.WriteLine("7 } Update Supplier");
                    Console.WriteLine("8 } Delete Supplier");
                    Console.WriteLine("9 } Add Item");
                    Console.WriteLine("10} View Item");
                    Console.WriteLine("11} Update Item");
                    Console.WriteLine("12} Delete Item");
                    Console.WriteLine("13} Add Warehouse");
                    Console.WriteLine("14} View Warehouse");
                    Console.WriteLine("15} Update Warehouse");
                    Console.WriteLine("16} Delete Warehouse");/*
                    Console.WriteLine("17} Add Inventory");
                    Console.WriteLine("18} View Inventory");
                    Console.WriteLine("19} Update Inventory");
                    Console.WriteLine("20} Delete Inventory");*/
                    Console.WriteLine("0 } Exit");
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.Write("Select an option: ");
                    Console.ResetColor();
                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Category Name: ");
                            Console.ResetColor();
                            var categoryName = Console.ReadLine();
                            repo.AddCategory(new Category { CategoryName = categoryName });
                            break;
                        case "2":
                            var categories = repo.GetAllCategories();
                            Console.WriteLine("||<=========================================================>||");
                            Console.Write("||");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" ID\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" Name\t\t\t\t\t\t     ");
                            Console.ResetColor();
                            Console.WriteLine("||");
                            Console.WriteLine("||<=========================================================>||");
                            foreach (var cat in categories)
                            {
                                //Console.Write($"|| {cat.CategoryID}\t| {cat.CategoryName,-50} ||");
                                Console.Write("||");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($" {cat.CategoryID}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write($" {cat.CategoryName,-50} ");
                                Console.ResetColor();
                                Console.WriteLine("||");
                            }
                            Console.WriteLine("||<=========================================================>||");
                            break;
                        case "3":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Category ID: ");
                            Console.ResetColor();
                            var categoryId = int.Parse(Console.ReadLine());
                            var category = repo.GetCategory(categoryId);
                            if (category != null)
                            {
                                Console.Write("Enter new Category Name: ");
                                categoryName = Console.ReadLine();
                                category.CategoryName = categoryName;
                                repo.UpdateCategory(category);
                            }
                            else
                            {
                                Console.WriteLine("Category not found");
                            }
                            break;
                        case "4":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Category ID: ");
                            Console.ResetColor();
                            categoryId = int.Parse(Console.ReadLine());
                            repo.DeleteCategory(categoryId);
                            break;

                        case "5":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Supplier Name: ");
                            Console.ResetColor();
                            var supplierName = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Contact Info: ");
                            Console.ResetColor();
                            var contactInfo = Console.ReadLine();
                            repo.AddSupplier(new Supplier { SupplierName = supplierName, ContactInfo = contactInfo });
                            break;
                        case "6":
                            var suppliers = repo.GetAllSuppliers();
                            Console.WriteLine("||<=============================================================================>||");
                            //Console.WriteLine("|| ID\t| Name\t\t\t\t\t| Contact\t\t\t ||");
                            Console.Write("||");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" ID\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" Name\t\t\t\t\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" Contact\t\t\t ");
                            Console.ResetColor();
                            Console.WriteLine("||");
                            Console.WriteLine("||<=============================================================================>||");
                            foreach (var supp in suppliers)
                            {
                                //Console.WriteLine($"|| {supp.SupplierID}\t| {supp.SupplierName,-30}\t| {supp.ContactInfo,-30} ||");

                                Console.Write("||");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($" {supp.SupplierID}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write($" {supp.SupplierName,-30}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($" {supp.ContactInfo,-30} ");
                                Console.ResetColor();
                                Console.WriteLine("||");
                            }
                            Console.WriteLine("||<=============================================================================>||");
                            break;
                        case "7":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Supplier ID: ");
                            Console.ResetColor();
                            var supplierId = int.Parse(Console.ReadLine());
                            var supplier = repo.GetSupplier(supplierId);
                            if (supplier != null)
                            {
                                Console.Write("Enter new Supplier Name: ");
                                supplierName = Console.ReadLine();
                                Console.Write("Enter new Contact Info: ");
                                contactInfo = Console.ReadLine();
                                supplier.SupplierName = supplierName;
                                supplier.ContactInfo = contactInfo;
                                repo.UpdateSupplier(supplier);
                            }
                            else
                            {
                                Console.WriteLine("Supplier not found");
                            }
                            break;
                        case "8":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Supplier ID: ");
                            Console.ResetColor();
                            supplierId = int.Parse(Console.ReadLine());
                            repo.DeleteSupplier(supplierId);
                            break;

                        case "9":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Item Name: ");
                            Console.ResetColor();
                            var itemName = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Category ID: ");
                            Console.ResetColor();
                            categoryId = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Supplier ID: ");
                            Console.ResetColor();
                            var supplierID = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Warehouse ID: ");
                            Console.ResetColor();
                            var warehouseId = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Quantity: ");
                            Console.ResetColor();
                            var quantity = int.Parse(Console.ReadLine());

                            var item = new Item { ItemName = itemName, CategoryID = categoryId, SupplierID = supplierID };
                            repo.AddItem(item);

                            var newItem = repo.GetAllItems().Last();
                            repo.AddInventory(new Inventory { WarehouseID = warehouseId, ItemID = newItem.ItemID, Quantity = quantity });
                            break;
                        case "10":
                            var items = repo.GetAllItems();
                            Console.WriteLine("||<====================================================================================================================>||");
                            //Console.WriteLine("|| ID\t| Name\t\t\t| Category\t\t| Warehouse\t\t| Supplier\t\t| Quantity\t||");
                            Console.Write("||");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" ID\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" Name\t\t\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" Category\t\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" Warehouse\t\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" Supplier\t\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(" Quantity\t");
                            Console.ResetColor();
                            Console.WriteLine("||");
                            Console.WriteLine("||<====================================================================================================================>||");
                            foreach (var aitem in items)
                            {
                                var inventorya = context.Inventories
                                    .Include(i => i.Warehouse)
                                    .FirstOrDefault(i => i.ItemID == aitem.ItemID);

                                /*Console.WriteLine($"|| {aitem.ItemID}\t| {aitem.ItemName,-20}\t| {aitem.Category.CategoryName,-20}\t| " +
                                                  $"{inventorya?.Warehouse.WarehouseName,-20}\t| {aitem.Supplier.SupplierName,-20}\t| {inventorya?.Quantity,-10}\t||");*/
                                Console.Write("||");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($" {aitem.ItemID}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write($" {aitem.ItemName,-20}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write($" {aitem.Category.CategoryName,-20}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($" {inventorya?.Warehouse.WarehouseName,-20}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($" {aitem.Supplier.SupplierName,-20}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write($" {inventorya?.Quantity,-10}\t");
                                Console.ResetColor();
                                Console.WriteLine("||");
                            }
                            Console.WriteLine("||<====================================================================================================================>||");
                            break;

                        case "11":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Item ID: ");
                            Console.ResetColor();
                            var itemId = int.Parse(Console.ReadLine());
                            var itemToUpdate = repo.GetItem(itemId);
                            if (itemToUpdate != null)
                            {
                                // Delete previous inventory entries
                                var inventoriesToDelete = context.Inventories.Where(i => i.ItemID == itemId).ToList();
                                context.Inventories.RemoveRange(inventoriesToDelete);
                                context.SaveChanges();
                                Console.ForegroundColor= ConsoleColor.Green;
                                Console.Write("Enter new Item Name: ");
                                Console.ResetColor();
                                itemName = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter new Category ID: ");
                                Console.ResetColor();
                                categoryId = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter new Supplier ID: ");
                                Console.ResetColor();
                                supplierID = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter new Warehouse ID: ");
                                Console.ResetColor();
                                warehouseId = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter new Quantity: ");
                                Console.ResetColor();
                                quantity = int.Parse(Console.ReadLine());

                                itemToUpdate.ItemName = itemName;
                                itemToUpdate.CategoryID = categoryId;
                                itemToUpdate.SupplierID = supplierID;
                                repo.UpdateItem(itemToUpdate);

                                // Add new inventory entry
                                repo.AddInventory(new Inventory { WarehouseID = warehouseId, ItemID = itemToUpdate.ItemID, Quantity = quantity });
                            }
                            else
                            {
                                Console.WriteLine("Item not found");
                            }
                            break;

                        case "12":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Item ID: ");
                            Console.ResetColor();
                            var AitemId = int.Parse(Console.ReadLine());
                            repo.DeleteItem(AitemId);
                            break;

                        case "13":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Warehouse Name: ");
                            Console.ResetColor();
                            var warehouseName = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Location: ");
                            Console.ResetColor();
                            var location = Console.ReadLine();
                            repo.AddWarehouse(new Warehouse { WarehouseName = warehouseName, Location = location });
                            break;
                        case "14":
                            var warehouses = repo.GetAllWarehouses();
                            Console.WriteLine("||<=================================================================================================>||");
                            //Console.WriteLine("|| ID\t| Name\t\t\t\t\t| Location\t\t\t\t\t     ||");
                            Console.Write("||");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" ID\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" Name\t\t\t\t\t");
                            Console.ResetColor();
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" Location\t\t\t\t\t     ");
                            Console.ResetColor();
                            Console.WriteLine("||");
                            Console.WriteLine("||<=================================================================================================>||");
                            foreach (var awarehouse in warehouses)
                            {
                                //Console.WriteLine($"|| {awarehouse.WarehouseID}\t| {awarehouse.WarehouseName,-30}\t| {awarehouse.Location,-50} ||");
                                Console.Write("||");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($" {awarehouse.WarehouseID}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write($" {awarehouse.WarehouseName,-30}\t");
                                Console.ResetColor();
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($" {awarehouse.Location,-50} ");
                                Console.ResetColor();
                                Console.WriteLine("||");
                            }
                            Console.WriteLine("||<=================================================================================================>||");
                            break;
                        case "15":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Warehouse ID: ");
                            Console.ResetColor();
                            var AnwarehouseId = int.Parse(Console.ReadLine());
                            var warehouse = repo.GetWarehouse(AnwarehouseId);
                            if (warehouse != null)
                            {
                                Console.ForegroundColor= ConsoleColor.Green;
                                Console.Write("Enter new Warehouse Name: ");
                                Console.ResetColor();
                                warehouseName = Console.ReadLine();
                                Console.ForegroundColor=ConsoleColor.Green;
                                Console.Write("Enter new Location: ");
                                Console.ResetColor();
                                location = Console.ReadLine();
                                warehouse.WarehouseName = warehouseName;
                                warehouse.Location = location;
                                repo.UpdateWarehouse(warehouse);
                            }
                            else
                            {
                                Console.WriteLine("Warehouse not found");
                            }
                            break;
                        case "16":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Warehouse ID: ");
                            Console.ResetColor();
                            warehouseId = int.Parse(Console.ReadLine());
                            repo.DeleteWarehouse(warehouseId);
                            break;
                            /*
                        case "17":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Warehouse ID: ");
                            Console.ResetColor();
                            warehouseId = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Item ID: ");
                            Console.ResetColor();
                            itemId = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Quantity: ");
                            Console.ResetColor();
                            var Anquantity = int.Parse(Console.ReadLine());
                            repo.AddInventory(new Inventory { WarehouseID = warehouseId, ItemID = itemId, Quantity = Anquantity });
                            break;
                        case "18":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Warehouse ID: ");
                            Console.ResetColor();
                            warehouseId = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Item ID: ");
                            Console.ResetColor();
                            itemId = int.Parse(Console.ReadLine());
                            var inventory = repo.GetInventory(warehouseId, itemId);
                            if (inventory != null)
                            {
                                Console.WriteLine($"Warehouse ID: {inventory.WarehouseID}, Item ID: {inventory.ItemID}, Quantity: {inventory.Quantity}");
                            }
                            else
                            {
                                Console.WriteLine("Inventory record not found");
                            }
                            break;
                        case "19":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Warehouse ID: ");
                            Console.ResetColor();
                            warehouseId = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Item ID: ");
                            Console.ResetColor();
                            itemId = int.Parse(Console.ReadLine());
                            inventory = repo.GetInventory(warehouseId, itemId);
                            if (inventory != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter new Quantity: ");
                                Console.ResetColor();
                                quantity = int.Parse(Console.ReadLine());
                                inventory.Quantity = quantity;
                                repo.UpdateInventory(inventory);
                            }
                            else
                            {
                                Console.WriteLine("Inventory record not found");
                            }
                            break;
                        case "20":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Warehouse ID: ");
                            Console.ResetColor();
                            warehouseId = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter Item ID: ");
                            Console.ResetColor();
                            itemId = int.Parse(Console.ReadLine());
                            repo.DeleteInventory(warehouseId, itemId);
                            break;*/

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press Enter to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
