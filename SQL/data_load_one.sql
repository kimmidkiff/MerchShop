-- Check if data exists in Orderline table
IF EXISTS (SELECT 1 FROM Orderline)
BEGIN
    -- Delete data from OrderLines table
    DELETE FROM Orderline;
END

-- Check if data exists in VendorReviews table
IF EXISTS (SELECT 1 FROM VendorReviews)
BEGIN
    -- Delete data from VendorReviews table
    DELETE FROM VendorReviews;
END

-- Check if data exists in Vendors table
IF EXISTS (SELECT 1 FROM Vendors)
BEGIN
    -- Delete data from Vendors table
    DELETE FROM Vendors;
END

-- Check if data exists in MerchReviews table
IF EXISTS (SELECT 1 FROM MerchReviews)
BEGIN
    -- Delete data from MerchReviews table
    DELETE FROM MerchReviews;
END

-- Check if data exists in Orders table
IF EXISTS (SELECT 1 FROM Orders)
BEGIN
    -- Delete data from Orders table
    DELETE FROM Orders;
END

-- Check if data exists in Merch table
IF EXISTS (SELECT 1 FROM Merch)
BEGIN
    -- Delete data from Merch table
    DELETE FROM Merch;
END

-- Check if data exists in Customers table
IF EXISTS (SELECT 1 FROM Customers)
BEGIN
    -- Delete data from Customers table
    DELETE FROM Customers;
END

-- Check if data exists in Warehouses table
IF EXISTS (SELECT 1 FROM Warehouses)
BEGIN
    -- Delete data from Warehouses table
    DELETE FROM Warehouses;
END

-- Check if data exists in Inventory table
IF EXISTS (SELECT 1 FROM Inventory)
BEGIN
    -- Delete data from Inventory table
    DELETE FROM Inventory;
END



-- Reset auto-increment IDs after deletion
DBCC CHECKIDENT('Vendors', RESEED, 0);
DBCC CHECKIDENT('Inventory', RESEED, 0);
DBCC CHECKIDENT('Orders', RESEED, 0);
DBCC CHECKIDENT('Merch', RESEED, 0);
DBCC CHECKIDENT('Customers', RESEED, 0);
DBCC CHECKIDENT('MerchReviews', RESEED, 0);
DBCC CHECKIDENT('VendorReviews', RESEED, 0);
DBCC CHECKIDENT('Warehouses', RESEED, 0);

-- Drop existing foreign key constraints
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'FOREIGN KEY')
BEGIN
    ALTER TABLE Orderline DROP CONSTRAINT FK_Orderline_Inventory_InventoryID;
    ALTER TABLE Orderline DROP CONSTRAINT FK_Orderline_Orders_OrderID;
    ALTER TABLE Inventory DROP CONSTRAINT FK_Inventory_Merch_MerchID;
    ALTER TABLE Inventory DROP CONSTRAINT FK_Inventory_Warehouses_WarehouseID;
    ALTER TABLE Merch DROP CONSTRAINT FK_Merch_Vendors_VendorID;
    ALTER TABLE Orders DROP CONSTRAINT FK_Order_Customers_CustomerID;
    ALTER TABLE MerchReviews DROP CONSTRAINT FK_MerchReviews_Customers_CustomerID;
    ALTER TABLE MerchReviews DROP CONSTRAINT FK_MerchReviews_Vendors_VendorID;
    ALTER TABLE VendorReviews DROP CONSTRAINT FK_VendorReviews_Customers_CustomerID;
    ALTER TABLE VendorReviews DROP CONSTRAINT FK_VendorReviews_Vendors_VendorID;

    -- Add any additional foreign key constraints here for other tables

    PRINT 'Foreign key constraints have been dropped.';
END

-- Add foreign key constraints
-- Add foreign key constraints
ALTER TABLE Orderline ADD CONSTRAINT FK_Orderline_Inventory_InventoryID FOREIGN KEY (InventoryID) REFERENCES Inventory(InventoryID) ON DELETE CASCADE;
ALTER TABLE Orderline ADD CONSTRAINT FK_Orderline_Orders_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE;
ALTER TABLE Inventory ADD CONSTRAINT FK_Inventory_Merch_MerchID FOREIGN KEY (MerchID) REFERENCES Merch(MerchID) ON DELETE CASCADE;
ALTER TABLE Inventory ADD CONSTRAINT FK_FK_Inventory_Warehouses_WarehouseID FOREIGN KEY (WarehouseID) REFERENCES Warehouses(WarehouseID) ON DELETE CASCADE;
ALTER TABLE Merch ADD CONSTRAINT FK_Merch_Vendors_VendorID FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID) ON DELETE CASCADE;
ALTER TABLE MerchReviews ADD CONSTRAINT FK_MerchReviews_Customers_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE;
ALTER TABLE MerchReviews ADD CONSTRAINT FK_Merch_Vendors_VendorID FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID) ON DELETE CASCADE;
ALTER TABLE Orders ADD CONSTRAINT FK_Order_Customers_CustomerID FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId) ON DELETE CASCADE;
ALTER TABLE VendorReviews ADD CONSTRAINT FK_VendorReviews_Customers_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE;
ALTER TABLE VendorReviews ADD CONSTRAINT FK_VendorReviews_Vendors_VendorID FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID) ON DELETE CASCADE;

-- Add any additional foreign key constraints here for other tables

PRINT 'Data has been cleared, and foreign key constraints have been regenerated.';

-- Populate Vendors table with 10 entries
INSERT INTO Vendors (VendorID, Name, WebURL) 
VALUES 
    (1, 'Merch Master', 'www.merchmaster.com'),
    (2, 'Merch Maven', 'www.merchmaven.com'),
    (3, 'Trendy Threads', 'www.trendythreads.com'),
    (4, 'Merch Mania', 'www.merchmania.com'),
    (5, 'Street Smart Apparel', 'www.streetsmartapparel.com'),
    (6, 'Magic Merch', 'www.magicmerch.com'),
    (7, 'Merch Mode', 'www.merchmode.com'),
    (8, 'Mademoiselle Merch', 'www.mademoisellemerch.com'),
    (9, 'Merch Marvel', 'www.merchmarvel.com'),
    (10, 'Vogue Vibes', 'www.voguevibes.com');


-- Populate Warehouses table with 10 entries
INSERT INTO Warehouses (WarehouseID, WarehouseNumber, ShelfNumber) 
VALUES
    (1, 1, 'One'),
    (2, 1, 'Two'),
    (3, 1, 'Three'),
    (4, 1, 'Four'),
    (5, 2, 'One'),
    (6, 2, 'Two'),
    (7, 2, 'Three'),
    (8, 2, 'Four'),
    (9, 3, 'One'),
    (10, 3, 'Two'),
    (11, 3, 'Three'),
    (12, 3, 'Four');
    

    -- Populate VendorReviews table with 10 entries
INSERT INTO VendorReviews (VendorID, CustomerID, ReviewScore, ReviewText) 
VALUES
    (1, 4, 4, 'Fast shipping, would purchase again'),
    (5, 3, 5, 'Fantastic quality! So pleased with my purchase'),
    (2, 9, 2, 'The stitching started fraying after about a month. Bummer since I loved wearing that shirt'),
    (7, 7, 5, 'Everything is always great from this vendor, I would recommend them to anyone.'),
    (4, 1, 3, 'Not the best quality, but not bad for the price'),
    (9, 2, 4,'My order was perfect but the shipping took fooorever.'),
    (2, 3, 3, 'I am not too impressed with this vendor. The items are sometimes so-so and their customer service is not the best'),
    (10, 8, 4, 'Order came quickly'),
    (3, 10, 5, 'Absolutely perfect! I am excited to buy more.'),
    (6, 5, 5, 'Purchased some things for my granddaughter and she loved them.');


-- Populate Inventory table with 40 entries
INSERT INTO Inventory (InventoryID, MerchID, WarehouseID, Quantity, SalePrice) 
VALUES
    (1, 1, 4, 60, 15.99),
    (2, 2, 5, 150, 7.50),
    (3, 3, 8, 257, 19.95),
    (4, 4, 6, 83, 17.88),
    (5, 5, 3, 360, 5.56),
    (6, 6, 1, 184, 23.15),
    (7, 7, 10, 347, 11.50),
    (8, 8, 12, 218, 6.99),
    (9, 9, 6, 425, 17.85),
    (10, 10, 5, 40, 65.99),
    (11, 11, 11, 281, 45.88),
    (12, 12, 9, 204, 10.55),
    (13, 13, 1, 82, 12.54),
    (14, 14, 3, 174, 8.12),
    (15, 15, 5, 246,  5.45),
    (16, 16, 11, 129, 14.87),
    (17, 17, 10, 95, 25.35),
    (18, 18, 12, 63, 16.21),
    (19, 19, 6, 142, 11.32),
    (20, 20, 2, 276, 8.31),
    (21, 21, 7, 101, 31.57),
    (22, 22, 9, 165, 28.16),
    (23, 23, 1, 144, 19.54),
    (24, 24, 4, 297, 30.54),
    (25, 25, 9, 26, 9.95),
    (26, 26, 7, 258, 15.50),
    (27, 27, 3, 34, 10.05),
    (28, 28, 8, 208, 7.74),
    (29, 29, 10, 25, 55.90),
    (30, 30, 1, 140,  14.32),
    (31, 31, 11, 275, 11.95),
    (32, 32, 5, 129, 19.78),
    (33, 33, 2, 66, 29.35),
    (34, 34, 6, 152, 9.12),
    (35, 35, 8, 104, 49.99),
    (36, 36, 4, 96, 25.50),
    (37, 37, 7, 188, 10.32),
    (38, 38, 9, 118, 14.50),
    (39, 39, 12, 107, 27.98),
    (40, 40, 1, 64, 6.99);

    -- Populate MerchReviews table with 10 entries
INSERT INTO MerchReviews (MerchID, CustomerID, ReviewScore, ReviewText) 
VALUES
    (11, 9, 5, 'I love everything about it!'),
    (15, 4, 5, 'Great product.'),
    (12, 5, 4, 'Came as advertised, nothing special about it though.'),
    (7, 7, 2, 'Item smelled strongly of chemcials. I returned it immediately.'),
    (40, 1, 3, 'It has been about 3 months since I purchased and it is already starting to show signs of wear.'),
    (9, 2, 5,'My order was perfect but the shipping took fooorever.'),
    (25, 6, 4, 'Great item, great customer service'),
    (17, 10, 5, 'Could not be happier with my purchase'),
    (30, 8, 3, 'Well, its not Gucci but it gets the job done...'),
    (26, 3, 4, 'It was almost perfect! The seams are really itchy and I have to wear an undershirt.');
 

-- Insert into Customers table
INSERT INTO Customers (CustomerID, FirstName, LastName, Email)
VALUES
    (1, 'Emily', 'Rodriguez', 'emily.rodriguez@example.com'),
    (2, 'James', 'Thompson', 'james.thompson@example.com'),
    (3, 'Sophia', 'Patel', 'sophia.patel@example.com'),
    (4, 'Benjamin', 'Garcia', 'benjamin.garcia@example.com'),
    (5, 'Olivia', 'Nguyen', 'olivia.nguyen@example.com'),
    (6, 'Ethan', 'Taylor', 'ethan.taylor@example.com'),
    (7, 'Mia', 'Smith', 'mia.smith@example.com'),
    (8, 'Jacob', 'Martinez', 'jacob.martinez@example.com'),
    (9, 'Ava', 'Johnson', 'ava.johnson@example.com'),
    (10, 'Isabella', 'Brown', 'isabella.brown@example.com');

    -- Insert into Orders table
INSERT INTO Orders (OrderID, CustomerId, Date)
VALUES
    (1, 9,'2024-02-09'),
    (2, 4, '2024-02-09'),
    (3, 5, '2024-02-08'),
    (4, 7, '2024-02-08'),
    (5, 1, '2024-02-07'),
    (6, 2, '2024-02-07'),
    (7, 6, '2024-02-06'),
    (8, 10, '2024-02-06'),
    (9, 8, '2024-02-05'),
    (10, 3, '2024-02-05');

-- Insert into OrderLines table
INSERT INTO OrderLines (OrderId, InventoryId, Quantity)
VALUES
    (1, 2, 2),
    (1, 21, 3),
    (2, 17, 3),
    (4, 6, 1),
    (5, 19, 2),
    (6, 35, 1),
    (7, 17, 1),
    (7, 21, 1),
    (8, 19, 3),
    (9, 7, 2),
    (10, 29, 1),
    (10, 20, 2);
    

    
    -- Insert into Merch table
INSERT INTO Merch (MerchID, VendorID, MerchType, ItemName)
VALUES
    (1, 5, 1, 'Cotton T-Shirt'),
    (2, 2, 1, 'Non-Slip Fuzzy Socks'),
    (3, 7, 1, 'Adjustable Baseball Cap'),
    (4, 3, 3, 'Reusable Car Decal'),
    (5, 8, 3, 'Longboard with Logo'),
    (6, 1, 2, 'iPhone 14 Phone Case'),
    (7, 1, 2, 'Portable Power Bank'),
    (8, 5, 1, 'Hoodie With Drawstring Closure'),
    (9, 3, 3, 'Customizable Bike Handlebar Grips'),
    (10, 4, 1, 'Personalized Friendship Bracelets'),
    (11, 6, 2, 'Logo Wireless Headphones'),
    (12, 10, 3, 'Custom Photo Car Fresheners'),
    (13, 6, 2, 'Laptop Sleeve with Custom Photo'),
    (14, 9, 1, 'Iron-On Clothing Patches'),
    (15, 8, 3, 'Personalized Writing License Plate Cover'),
    (16, 3, 3, 'Logo Steering Wheel Covers'),
    (17, 2, 1, 'Sun Glasses - Custom Print'),
    (18, 5, 1, 'Stylish Sneakers'),
    (19, 4, 1, 'Locket Necklace - Upload Photo'),
    (20, 7, 1, 'Logo Beanie For Cold Weather'),
    (21, 9, 1, 'Modern Boho Belt'),
    (22, 3, 3, 'Personalized Key Chain'),
    (23, 10, 3, 'Character Bobbleheads for Dashboard'),
    (24, 5, 1, 'Classic Demin Jacket with Patch Kit'),
    (25, 10, 1, 'Graphic Print T-Shirt'),
    (26, 8, 2, 'Wireless Phone Charger Car Mount'),
    (27, 5, 3, 'Custom Image Car Floor Mats'),
    (28, 6, 2, 'Aesthetic Wireless Charging Pad'),
    (29, 1, 1, 'Retro Flare Jeans with Custom Embroidery'),
    (30, 7, 3, 'Car Seat Organizer'),
    (31, 5, 2, 'Personalized Text - Wireless Earbuds Case'),
    (32, 2, 1, 'Athletic Jogger Pants'),
    (33, 4, 1, 'Super Hero Inspired Backpacks'),
    (34, 6, 1, 'TV Show Character Lunch Boxes'),
    (35, 8, 2, 'Cute Bluetooth Wireless Speaker'),
    (36, 2, 2, 'Compact Cable Organizer'),
    (37, 3, 3, 'Mini Car Trash Can'),
    (38, 10, 1, 'Printed Silk Scarf'),
    (39, 6, 1, 'Plaid Flannel Shirt'),
    (40, 9, 1, 'Custom Photo Reusable Shopping Bag');
    

   

