-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 10, 2024 at 06:45 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `warehousedb`
--
CREATE DATABASE IF NOT EXISTS `warehousedb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `warehousedb`;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `CategoryID` int(11) NOT NULL,
  `CategoryName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`CategoryID`, `CategoryName`) VALUES
(1, 'Electronics'),
(2, 'Furniture'),
(3, 'Clothing'),
(4, 'Toys'),
(5, 'Food'),
(6, 'Books'),
(7, 'Tools'),
(8, 'Sports'),
(9, 'Health'),
(10, 'Beauty'),
(11, 'Automotive'),
(12, 'Gardening'),
(13, 'Office Supplies'),
(14, 'Pet Supplies'),
(15, 'Home Decor'),
(16, 'Jewelry'),
(17, 'Footwear'),
(18, 'Accessories'),
(19, 'Music'),
(20, 'Baby Products');

-- --------------------------------------------------------

--
-- Table structure for table `inventories`
--

CREATE TABLE `inventories` (
  `WarehouseID` int(11) NOT NULL,
  `ItemID` int(11) NOT NULL,
  `Quantity` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventories`
--

INSERT INTO `inventories` (`WarehouseID`, `ItemID`, `Quantity`) VALUES
(1, 1, 50),
(1, 2, 30),
(2, 3, 20),
(2, 4, 25),
(3, 5, 100),
(3, 6, 80),
(4, 7, 40),
(4, 8, 35),
(5, 9, 60),
(5, 10, 70),
(6, 11, 50),
(6, 12, 45),
(7, 13, 30),
(7, 14, 20),
(8, 15, 50),
(8, 16, 55),
(9, 17, 60),
(9, 18, 50),
(10, 19, 40),
(10, 20, 30);

-- --------------------------------------------------------

--
-- Table structure for table `items`
--

CREATE TABLE `items` (
  `ItemID` int(11) NOT NULL,
  `ItemName` varchar(255) NOT NULL,
  `CategoryID` int(11) DEFAULT NULL,
  `SupplierID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `items`
--

INSERT INTO `items` (`ItemID`, `ItemName`, `CategoryID`, `SupplierID`) VALUES
(1, 'Smartphone', 1, 1),
(2, 'Laptop', 1, 1),
(3, 'Sofa', 2, 2),
(4, 'Dining Table', 2, 2),
(5, 'T-shirt', 3, 3),
(6, 'Jeans', 3, 3),
(7, 'Action Figure', 4, 4),
(8, 'Lego Set', 4, 4),
(9, 'Apple', 5, 5),
(10, 'Banana', 5, 5),
(11, 'Novel', 6, 6),
(12, 'Textbook', 6, 6),
(13, 'Hammer', 7, 7),
(14, 'Drill', 7, 7),
(15, 'Football', 8, 8),
(16, 'Basketball', 8, 8),
(17, 'Vitamins', 9, 9),
(18, 'First Aid Kit', 9, 9),
(19, 'Lipstick', 10, 10),
(20, 'Shampoo', 10, 10);

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

CREATE TABLE `suppliers` (
  `SupplierID` int(11) NOT NULL,
  `SupplierName` varchar(255) NOT NULL,
  `ContactInfo` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`SupplierID`, `SupplierName`, `ContactInfo`) VALUES
(1, 'ABC Electronics', 'abc@electronics.com'),
(2, 'XYZ Furniture', 'xyz@furniture.com'),
(3, 'Fashion Hub', 'contact@fashionhub.com'),
(4, 'Toy World', 'info@toyworld.com'),
(5, 'Grocery Mart', 'support@grocerymart.com'),
(6, 'Book Haven', 'contact@bookhaven.com'),
(7, 'Tool Depot', 'sales@tooldepot.com'),
(8, 'Sports Gear', 'info@sportsgear.com'),
(9, 'Health Plus', 'support@healthplus.com'),
(10, 'Beauty Bliss', 'contact@beautybliss.com'),
(11, 'Auto Parts', 'sales@autoparts.com'),
(12, 'Garden Tools', 'info@gardentools.com'),
(13, 'Office Mart', 'contact@officemart.com'),
(14, 'Pet World', 'support@petworld.com'),
(15, 'Home Decor', 'info@homedecor.com'),
(16, 'Jewelry Store', 'contact@jewelrystore.com'),
(17, 'Footwear Co.', 'info@footwearco.com'),
(18, 'Accessory Shop', 'support@accessoryshop.com'),
(19, 'Music Store', 'info@musicstore.com'),
(20, 'Baby World', 'support@babyworld.com');

-- --------------------------------------------------------

--
-- Table structure for table `warehouses`
--

CREATE TABLE `warehouses` (
  `WarehouseID` int(11) NOT NULL,
  `WarehouseName` varchar(255) NOT NULL,
  `Location` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `warehouses`
--

INSERT INTO `warehouses` (`WarehouseID`, `WarehouseName`, `Location`) VALUES
(1, 'Central Warehouse', 'New York'),
(2, 'West Coast Warehouse', 'Los Angeles'),
(3, 'East Coast Warehouse', 'Miami'),
(4, 'Southern Warehouse', 'Houston'),
(5, 'Midwest Warehouse', 'Chicago'),
(6, 'Northwest Warehouse', 'Seattle'),
(7, 'Northeast Warehouse', 'Boston'),
(8, 'Southwest Warehouse', 'Phoenix'),
(9, 'Southeast Warehouse', 'Atlanta'),
(10, 'Mountain Warehouse', 'Denver'),
(11, 'Plains Warehouse', 'Kansas City'),
(12, 'Desert Warehouse', 'Las Vegas'),
(13, 'Great Lakes Warehouse', 'Detroit'),
(14, 'Gulf Coast Warehouse', 'New Orleans'),
(15, 'Heartland Warehouse', 'Omaha'),
(16, 'River Warehouse', 'St. Louis'),
(17, 'Capital Warehouse', 'Washington D.C.'),
(18, 'Bay Area Warehouse', 'San Francisco'),
(19, 'Valley Warehouse', 'Sacramento'),
(20, 'Sunshine Warehouse', 'Orlando');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`CategoryID`);

--
-- Indexes for table `inventories`
--
ALTER TABLE `inventories`
  ADD PRIMARY KEY (`WarehouseID`,`ItemID`),
  ADD KEY `ItemID` (`ItemID`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`ItemID`),
  ADD KEY `CategoryID` (`CategoryID`),
  ADD KEY `SupplierID` (`SupplierID`);

--
-- Indexes for table `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`SupplierID`);

--
-- Indexes for table `warehouses`
--
ALTER TABLE `warehouses`
  ADD PRIMARY KEY (`WarehouseID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `CategoryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `items`
--
ALTER TABLE `items`
  MODIFY `ItemID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `SupplierID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `warehouses`
--
ALTER TABLE `warehouses`
  MODIFY `WarehouseID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `inventories`
--
ALTER TABLE `inventories`
  ADD CONSTRAINT `inventories_ibfk_1` FOREIGN KEY (`WarehouseID`) REFERENCES `warehouses` (`WarehouseID`),
  ADD CONSTRAINT `inventories_ibfk_2` FOREIGN KEY (`ItemID`) REFERENCES `items` (`ItemID`);

--
-- Constraints for table `items`
--
ALTER TABLE `items`
  ADD CONSTRAINT `items_ibfk_1` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`CategoryID`),
  ADD CONSTRAINT `items_ibfk_2` FOREIGN KEY (`SupplierID`) REFERENCES `suppliers` (`SupplierID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
