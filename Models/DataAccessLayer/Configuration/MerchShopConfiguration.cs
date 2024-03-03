using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MerchShop.Models
{
    public class MerchShopConfiguration
    {
        public MerchShopConfiguration(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new VendorConfig());
            modelBuilder.ApplyConfiguration(new WarehouseConfig());
            modelBuilder.ApplyConfiguration(new MerchConfig());
            modelBuilder.ApplyConfiguration(new InventoryConfig());
            modelBuilder.ApplyConfiguration(new VendorReviewConfig());
            modelBuilder.ApplyConfiguration(new MerchReviewConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderLinesConfig());
        }


        protected internal class VendorConfig : IEntityTypeConfiguration<Vendor>
        {
            public void Configure(EntityTypeBuilder <Vendor> entity) 
            {
                entity.HasData(
                    
                    new Vendor { VendorID = 001, Name = "Merch Master", WebURL = "www.merchmaster.com", OverallRating = 4.5f },
                    new Vendor { VendorID = 002, Name = "Merch Maven", WebURL = "www.merchmaven.com", OverallRating = 4.2f },
                    new Vendor { VendorID = 003, Name = "Trendy Threads", WebURL = "www.trendythreads.com", OverallRating = 4.8f },
                    new Vendor { VendorID = 004, Name = "Merch Mania", WebURL = "www.merchmania.com", OverallRating = 4.4f },
                    new Vendor { VendorID = 005, Name = "Street Smart Apparel", WebURL = "www.streetsmartapparel.com", OverallRating = 4.7f },
                    new Vendor { VendorID = 006, Name = "Magic Merch", WebURL = "www.magicmerch.com", OverallRating = 4.3f },
                    new Vendor { VendorID = 007, Name = "Merch Mode", WebURL = "www.merchmode.com", OverallRating = 4.6f },
                    new Vendor { VendorID = 008, Name = "Mademoiselle Merch", WebURL = "www.mademoisellemerch.com", OverallRating = 4.1f },
                    new Vendor { VendorID = 009, Name = "Merch Marvel", WebURL = "www.merchmarvel.com", OverallRating = 4.9f },
                    new Vendor { VendorID = 010, Name = "Vogue Vibes", WebURL = "www.voguevibes.com", OverallRating = 4.0f }
                );
            }
        }

        protected internal class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
        {
            public void Configure(EntityTypeBuilder<Warehouse> entity)
            {
                entity.HasData(
                
                    new Warehouse { WarehouseID = 001, WarehouseNumber = WarehouseNumber.One , ShelfNumber = "One" },
                    new Warehouse { WarehouseID = 002 , WarehouseNumber = WarehouseNumber.One , ShelfNumber = "Two" },
                    new Warehouse { WarehouseID = 003 , WarehouseNumber = WarehouseNumber.One , ShelfNumber = "Three" },
                    new Warehouse { WarehouseID = 004 , WarehouseNumber = WarehouseNumber.One , ShelfNumber = "Four" },
                    new Warehouse { WarehouseID = 005 , WarehouseNumber = WarehouseNumber.Two , ShelfNumber = "One" },
                    new Warehouse { WarehouseID = 006 , WarehouseNumber = WarehouseNumber.Two , ShelfNumber = "Two" },
                    new Warehouse { WarehouseID = 007 , WarehouseNumber = WarehouseNumber.Two , ShelfNumber = "Three" },
                    new Warehouse { WarehouseID = 008 , WarehouseNumber = WarehouseNumber.Two , ShelfNumber = "Four" },
                    new Warehouse { WarehouseID = 009, WarehouseNumber = WarehouseNumber.Three, ShelfNumber = "One" },
                    new Warehouse { WarehouseID = 010, WarehouseNumber = WarehouseNumber.Three, ShelfNumber = "Two" },
                    new Warehouse { WarehouseID = 011 , WarehouseNumber = WarehouseNumber.Three , ShelfNumber = "Three" },
                    new Warehouse { WarehouseID = 012, WarehouseNumber = WarehouseNumber.Three, ShelfNumber = "Four" }


                );
            }
        }

        protected internal class VendorReviewConfig : IEntityTypeConfiguration<VendorReview>
        {
            public void Configure(EntityTypeBuilder<VendorReview> entity)
            {
                entity.HasData(
                    new VendorReview { VendorID = 1, CustomerID = 4, Date = DateTime.Parse("2023-07-15"), ReviewScore = 4, ReviewText = "Fast shipping, would purchase again" },
                    new VendorReview { VendorID = 5, CustomerID = 3, Date = DateTime.Parse("2019-05-28"), ReviewScore = 5, ReviewText = "Fantastic quality! So pleased with my purchase" },
                    new VendorReview { VendorID = 2, CustomerID = 9, Date = DateTime.Parse("2020-11-03"), ReviewScore = 2, ReviewText = "The stitching started fraying after about a month. Bummer since I loved wearing that shirt" },
                    new VendorReview { VendorID = 7, CustomerID = 7, Date = DateTime.Parse("2022-09-19"), ReviewScore = 5, ReviewText = "Everything is always great from this vendor, I would recommend them to anyone." },
                    new VendorReview { VendorID = 4, CustomerID = 1, Date = DateTime.Parse("2021-03-12"), ReviewScore = 3, ReviewText = "Not the best quality, but not bad for the price" },
                    new VendorReview { VendorID = 9, CustomerID = 2, Date = DateTime.Parse("2018-08-06"), ReviewScore = 4, ReviewText = "My order was perfect but the shipping took fooorever." },
                    new VendorReview { VendorID = 2, CustomerID = 3, Date = DateTime.Parse("2019-11-25"), ReviewScore = 3, ReviewText = "I am not too impressed with this vendor. The items are sometimes so-so and their customer service is not the best" },
                    new VendorReview { VendorID = 10, CustomerID = 8, Date = DateTime.Parse("2020-06-10"), ReviewScore = 4, ReviewText = "Order came quickly" },
                    new VendorReview { VendorID = 3, CustomerID = 10, Date = DateTime.Parse("2023-01-05"), ReviewScore = 5, ReviewText = "Absolutely perfect! I am excited to buy more." },
                    new VendorReview { VendorID = 6, CustomerID = 5, Date = DateTime.Parse("2017-12-01"), ReviewScore = 5, ReviewText = "Purchased some things for my granddaughter and she loved them." }
                );
            }
        }

        protected internal class MerchReviewConfig : IEntityTypeConfiguration<MerchReview>
        {
            public void Configure(EntityTypeBuilder<MerchReview> entity)
            {
                entity.HasData(
                    new MerchReview { MerchID = 11, CustomerID = 9, Date = DateTime.Parse("2023-07-15"), ReviewScore = 5, ReviewText = "I love everything about it!" },
                    new MerchReview { MerchID = 15, CustomerID = 4, Date = DateTime.Parse("2019-05-28"), ReviewScore = 5, ReviewText = "Great product." },
                    new MerchReview { MerchID = 12, CustomerID = 5, Date = DateTime.Parse("2020-11-03"), ReviewScore = 4, ReviewText = "Came as advertised, nothing special about it though." },
                    new MerchReview { MerchID = 7, CustomerID = 7, Date = DateTime.Parse("2022-09-19"), ReviewScore = 2, ReviewText = "Item smelled strongly of chemicals. I returned it immediately." },
                    new MerchReview { MerchID = 40, CustomerID = 1, Date = DateTime.Parse("2021-03-12"), ReviewScore = 3, ReviewText = "It has been about 3 months since I purchased and it is already starting to show signs of wear." },
                    new MerchReview { MerchID = 9, CustomerID = 2, Date = DateTime.Parse("2018-08-06"), ReviewScore = 5, ReviewText = "My order was perfect but the shipping took fooorever." },
                    new MerchReview { MerchID = 25, CustomerID = 6, Date = DateTime.Parse("2019-11-25"), ReviewScore = 4, ReviewText = "Great item, great customer service" },
                    new MerchReview { MerchID = 17, CustomerID = 10, Date = DateTime.Parse("2020-06-10"), ReviewScore = 5, ReviewText = "Could not be happier with my purchase" },
                    new MerchReview { MerchID = 30, CustomerID = 8, Date = DateTime.Parse("2023-01-05"), ReviewScore = 3, ReviewText = "Well, its not Gucci but it gets the job done..." },
                    new MerchReview { MerchID = 26, CustomerID = 3, Date = DateTime.Parse("2017-12-01"), ReviewScore = 4, ReviewText = "It was almost perfect! The seams are really itchy and I have to wear an undershirt." }
                );
            }
        }

        protected internal class CustomerConfig : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> entity)
            {
                entity.HasData(
                    new Customer { CustomerID = 1, FirstName = "Emily", LastName = "Rodriguez", Email = "emily.rodriguez@example.com" },
                    new Customer { CustomerID = 2, FirstName = "James", LastName = "Thompson", Email = "james.thompson@example.com" },
                    new Customer { CustomerID = 3, FirstName = "Sophia", LastName = "Patel", Email = "sophia.patel@example.com" },
                    new Customer { CustomerID = 4, FirstName = "Benjamin", LastName = "Garcia", Email = "benjamin.garcia@example.com" },
                    new Customer { CustomerID = 5, FirstName = "Olivia", LastName = "Nguyen", Email = "olivia.nguyen@example.com" },
                    new Customer { CustomerID = 6, FirstName = "Ethan", LastName = "Taylor", Email = "ethan.taylor@example.com" },
                    new Customer { CustomerID = 7, FirstName = "Mia", LastName = "Smith", Email = "mia.smith@example.com" },
                    new Customer { CustomerID = 8, FirstName = "Jacob", LastName = "Martinez", Email = "jacob.martinez@example.com" },
                    new Customer { CustomerID = 9, FirstName = "Ava", LastName = "Johnson", Email = "ava.johnson@example.com" },
                    new Customer { CustomerID = 10, FirstName = "Isabella", LastName = "Brown", Email = "isabella.brown@example.com" }
                );
            }
        }

        protected internal class OrderConfig : IEntityTypeConfiguration<Order>
        {
            public void Configure(EntityTypeBuilder<Order> entity)
            {
                entity.HasData(
                    new Order { OrderID = 1, CustomerID = 9, Date = DateTime.Parse("2024-02-09") },
                    new Order { OrderID = 2, CustomerID = 4, Date = DateTime.Parse("2024-02-09") },
                    new Order { OrderID = 3, CustomerID = 5, Date = DateTime.Parse("2024-02-08") },
                    new Order { OrderID = 4, CustomerID = 7, Date = DateTime.Parse("2024-02-08") },
                    new Order { OrderID = 5, CustomerID = 1, Date = DateTime.Parse("2024-02-07") },
                    new Order { OrderID = 6, CustomerID = 2, Date = DateTime.Parse("2024-02-07") },
                    new Order { OrderID = 7, CustomerID = 6, Date = DateTime.Parse("2024-02-06") },
                    new Order { OrderID = 8, CustomerID = 10, Date = DateTime.Parse("2024-02-06") },
                    new Order { OrderID = 9, CustomerID = 8, Date = DateTime.Parse("2024-02-05") },
                    new Order { OrderID = 10, CustomerID = 3, Date = DateTime.Parse("2024-02-05") }

                );
            }
        }

        protected internal class OrderLinesConfig : IEntityTypeConfiguration<OrderLines>
        {
            public void Configure(EntityTypeBuilder<OrderLines> entity)
            {
                entity.HasData(
                    new OrderLines { OrderID = 1, InventoryID = 2, Quantity = 2, },
                    new OrderLines { OrderID = 1, InventoryID = 21, Quantity = 3 },
                    new OrderLines { OrderID = 2, InventoryID = 17, Quantity = 3 },
                    new OrderLines { OrderID = 4, InventoryID = 6, Quantity = 1 },
                    new OrderLines { OrderID = 5, InventoryID = 19, Quantity = 2 },
                    new OrderLines { OrderID = 6, InventoryID = 35, Quantity = 1 },
                    new OrderLines { OrderID = 7, InventoryID = 17, Quantity = 1 },
                    new OrderLines { OrderID = 7, InventoryID = 21, Quantity = 1 },
                    new OrderLines { OrderID = 8, InventoryID = 19, Quantity = 3 },
                    new OrderLines { OrderID = 9, InventoryID = 7, Quantity = 2 },
                    new OrderLines { OrderID = 10, InventoryID = 29, Quantity = 1 },
                    new OrderLines { OrderID = 10, InventoryID = 20, Quantity = 2 }


                );
            }
        }


        protected internal class MerchConfig : IEntityTypeConfiguration<Merch>
        {
            public void Configure(EntityTypeBuilder<Merch> entity)
            {
                entity.HasData(

                    new Merch
                    {
                        MerchID = 1,
                        VendorID = 5,
                        MerchType = MerchType.Apparel,
                        ItemName = "Cotton T-Shirt"
                    },
                    new Merch
                    {
                        MerchID = 2,
                        VendorID = 2,
                        MerchType = MerchType.Apparel,
                        ItemName = "Non-Slip Fuzzy Socks"
                    },
                    new Merch
                    {
                        MerchID = 3,
                        VendorID = 7,
                        MerchType = MerchType.Apparel,
                        ItemName = "Adjustable Baseball Cap"
                    },
                    new Merch
                    {
                        MerchID = 4,
                        VendorID = 3,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Reusable Car Decal"
                    },
                    new Merch
                    {
                        MerchID = 5,
                        VendorID = 8,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Longboard with Logo"
                    },
                    new Merch
                    {
                        MerchID = 6,
                        VendorID = 1,
                        MerchType = MerchType.Electronics,
                        ItemName = "iPhone 14 Phone Case"
                    },
                    new Merch
                    {
                        MerchID = 7,
                        VendorID = 1,
                        MerchType = MerchType.Electronics,
                        ItemName = "Portable Power Bank"
                    },
                    new Merch
                    {
                        MerchID = 8,
                        VendorID = 5,
                        MerchType = MerchType.Apparel,
                        ItemName = "Hoodie With Drawstring Closure"
                    },
                    new Merch
                    {
                        MerchID = 9,
                        VendorID = 3,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Customizable Bike Handlebar Grips"
                    },
                    new Merch
                    {
                        MerchID = 10,
                        VendorID = 4,
                        MerchType = MerchType.Apparel,
                        ItemName = "Personalized Friendship Bracelets"
                    },
                    new Merch
                    {
                        MerchID = 11,
                        VendorID = 6,
                        MerchType = MerchType.Electronics,
                        ItemName = "Logo Wireless Headphones"
                    },
                    new Merch
                    {
                        MerchID = 12,
                        VendorID = 10,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Custom Photo Car Fresheners"
                    },
                    new Merch
                    {
                        MerchID = 13,
                        VendorID = 6,
                        MerchType = MerchType.Electronics,
                        ItemName = "Laptop Sleeve with Custom Photo"
                    },
                    new Merch
                    {
                        MerchID = 14,
                        VendorID = 9,
                        MerchType = MerchType.Apparel,
                        ItemName = "Iron-On Clothing Patches"
                    },
                    new Merch
                    {
                        MerchID = 15,
                        VendorID = 8,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Personalized Writing License Plate Cover"
                    },
                    new Merch
                    {
                        MerchID = 16,
                        VendorID = 3,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Logo Steering Wheel Covers"
                    },
                    new Merch
                    {
                        MerchID = 17,
                        VendorID = 2,
                        MerchType = MerchType.Apparel,
                        ItemName = "Sun Glasses - Custom Print"
                    },
                    new Merch
                    {
                        MerchID = 18,
                        VendorID = 5,
                        MerchType = MerchType.Apparel,
                        ItemName = "Stylish Sneakers"
                    },
                    new Merch
                    {
                        MerchID = 19,
                        VendorID = 4,
                        MerchType = MerchType.Apparel,
                        ItemName = "Locket Necklace - Upload Photo"
                    },
                    new Merch
                    {
                        MerchID = 20,
                        VendorID = 7,
                        MerchType = MerchType.Apparel,
                        ItemName = "Logo Beanie For Cold Weather"
                    },
                    new Merch
                    {
                        MerchID = 21,
                        VendorID = 9,
                        MerchType = MerchType.Apparel,
                        ItemName = "Modern Boho Belt"
                    },
                    new Merch
                    {
                        MerchID = 22,
                        VendorID = 3,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Personalized Key Chain"
                    },
                    new Merch
                    {
                        MerchID = 23,
                        VendorID = 10,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Character Bobbleheads for Dashboard"
                    },
                    new Merch
                    {
                        MerchID = 24,
                        VendorID = 5,
                        MerchType = MerchType.Apparel,
                        ItemName = "Classic Demin Jacket with Patch Kit"
                    },
                    new Merch
                    {
                        MerchID = 25,
                        VendorID = 10,
                        MerchType = MerchType.Apparel,
                        ItemName = "Graphic Print T-Shirt"
                    },
                    new Merch
                    {
                        MerchID = 26,
                        VendorID = 8,
                        MerchType = MerchType.Electronics,
                        ItemName = "Wireless Phone Charger Car Mount"
                    },
                    new Merch
                    {
                        MerchID = 27,
                        VendorID = 5,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Custom Image Car Floor Mats"
                    },
                    new Merch
                    {
                        MerchID = 28,
                        VendorID = 6,
                        MerchType = MerchType.Electronics,
                        ItemName = "Aesthetic Wireless Charging Pad"
                    },
                    new Merch
                    {
                        MerchID = 29,
                        VendorID = 1,
                        MerchType = MerchType.Apparel,
                        ItemName = "Retro Flare Jeans with Custom Embroidery"
                    },
                    new Merch
                    {
                        MerchID = 30,
                        VendorID = 7,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Car Seat Organizer"
                    },
                    new Merch
                    {
                        MerchID = 31,
                        VendorID = 5,
                        MerchType = MerchType.Electronics,
                        ItemName = "Personalized Text - Wireless Earbuds Case"
                    },
                    new Merch
                    {
                        MerchID = 32,
                        VendorID = 2,
                        MerchType = MerchType.Apparel,
                        ItemName = "Athletic Jogger Pants"
                    },
                    new Merch
                    {
                        MerchID = 33,
                        VendorID = 4,
                        MerchType = MerchType.Apparel,
                        ItemName = "Super Hero Inspired Backpacks"
                    },
                    new Merch
                    {
                        MerchID = 34,
                        VendorID = 6,
                        MerchType = MerchType.Apparel,
                        ItemName = "TV Show Character Lunch Boxes"
                    },
                    new Merch
                    {
                        MerchID = 35,
                        VendorID = 8,
                        MerchType = MerchType.Electronics,
                        ItemName = "Cute Bluetooth Wireless Speaker"
                    },
                    new Merch
                    {
                        MerchID = 36,
                        VendorID = 2,
                        MerchType = MerchType.Electronics,
                        ItemName = "Compact Cable Organizer"
                    },
                    new Merch
                    {
                        MerchID = 37,
                        VendorID = 3,
                        MerchType = MerchType.Vehicles,
                        ItemName = "Mini Car Trash Can"
                    },
                    new Merch
                    {
                        MerchID = 38,
                        VendorID = 10,
                        MerchType = MerchType.Apparel,
                        ItemName = "Printed Silk Scarf"
                    },
                    new Merch
                    {
                        MerchID = 39,
                        VendorID = 6,
                        MerchType = MerchType.Apparel,
                        ItemName = "Plaid Flannel Shirt"
                    },
                    new Merch
                    {
                        MerchID = 40,
                        VendorID = 9,
                        MerchType = MerchType.Apparel,
                        ItemName = "Custom Photo Reusable Shopping Bag"
                    }

                );
            }
        }

        protected internal class InventoryConfig : IEntityTypeConfiguration<Inventory>
        {
            public void Configure(EntityTypeBuilder<Inventory> entity)
            {
                entity.HasData(

                    new Inventory
                    {
                        InventoryID = 1,
                        MerchID = 1,
                        WarehouseID = 4,
                        Quantity = 60,
                        PurchaseDate = DateTime.Parse("2022-09-14"),
                        PurchasePrice = 10.25M,
                        SalePrice = 15.99M
                    },
                    new Inventory
                    {
                        InventoryID = 2,
                        MerchID = 2,
                        WarehouseID = 5,
                        Quantity = 150,
                        PurchaseDate = DateTime.Parse("2019-07-22"),
                        PurchasePrice = 5.25M,
                        SalePrice = 7.50M
                    },
                    new Inventory
                    {
                        InventoryID = 3,
                        MerchID = 3,
                        WarehouseID = 8,
                        Quantity = 257,
                        PurchaseDate = DateTime.Parse("2023-05-01"),
                        PurchasePrice = 16.75M,
                        SalePrice = 19.95M
                    },
                    new Inventory
                    {
                        InventoryID = 4,
                        MerchID = 4,
                        WarehouseID = 6,
                        Quantity = 83,
                        PurchaseDate = DateTime.Parse("2020-11-09"),
                        PurchasePrice = 14.20M,
                        SalePrice = 17.88M
                    },
                    new Inventory
                    {
                        InventoryID = 5,
                        MerchID = 5,
                        WarehouseID = 3,
                        Quantity = 360,
                        PurchaseDate = DateTime.Parse("2021-08-18"),
                        PurchasePrice = 3.45M,
                        SalePrice = 5.56M
                    },
                    new Inventory
                    {
                        InventoryID = 6,
                        MerchID = 6,
                        WarehouseID = 1,
                        Quantity = 184,
                        PurchaseDate = DateTime.Parse("2018-04-29"),
                        PurchasePrice = 18.75M,
                        SalePrice = 23.15M
                    },
                    new Inventory
                    {
                        InventoryID = 7,
                        MerchID = 7,
                        WarehouseID = 10,
                        Quantity = 347,
                        PurchaseDate = DateTime.Parse("2023-10-12"),
                        PurchasePrice = 8.75M,
                        SalePrice = 11.50M
                    },
                    new Inventory
                    {
                        InventoryID = 8,
                        MerchID = 8,
                        WarehouseID = 12,
                        Quantity = 218,
                        PurchaseDate = DateTime.Parse("2022-07-05"),
                        PurchasePrice = 4.99M,
                        SalePrice = 6.99M
                    },
                    new Inventory
                    {
                        InventoryID = 9,
                        MerchID = 9,
                        WarehouseID = 6,
                        Quantity = 425,
                        PurchaseDate = DateTime.Parse("2020-03-18"),
                        PurchasePrice = 13.25M,
                        SalePrice = 17.85M
                    },
                    new Inventory
                    {
                        InventoryID = 10,
                        MerchID = 10,
                        WarehouseID = 5,
                        Quantity = 40,
                        PurchaseDate = DateTime.Parse("2021-11-30"),
                        PurchasePrice = 60.00M,
                        SalePrice = 65.99M
                    },
                    new Inventory
                    {
                        InventoryID = 11,
                        MerchID = 11,
                        WarehouseID = 11,
                        Quantity = 281,
                        PurchaseDate = DateTime.Parse("2022-08-17"),
                        PurchasePrice = 30.75M,
                        SalePrice = 45.88M
                    },
                    new Inventory
                    {
                        InventoryID = 12,
                        MerchID = 12,
                        WarehouseID = 9,
                        Quantity = 204,
                        PurchaseDate = DateTime.Parse("2023-04-02"),
                        PurchasePrice = 7.25M,
                        SalePrice = 10.55M
                    },
                    new Inventory
                    {
                        InventoryID = 13,
                        MerchID = 13,
                        WarehouseID = 1,
                        Quantity = 82,
                        PurchaseDate = DateTime.Parse("2017-12-08"),
                        PurchasePrice = 8.75M,
                        SalePrice = 12.54M
                    },
                    new Inventory
                    {
                        InventoryID = 14,
                        MerchID = 14,
                        WarehouseID = 3,
                        Quantity = 174,
                        PurchaseDate = DateTime.Parse("2019-09-21"),
                        PurchasePrice = 5.50M,
                        SalePrice = 8.12M
                    },
                    new Inventory
                    {
                        InventoryID = 15,
                        MerchID = 15,
                        WarehouseID = 5,
                        Quantity = 246,
                        PurchaseDate = DateTime.Parse("2021-06-14"),
                        PurchasePrice = 4.20M,
                        SalePrice = 5.45M
                    },
                    new Inventory
                    {
                        InventoryID = 16,
                        MerchID = 16,
                        WarehouseID = 11,
                        Quantity = 129,
                        PurchaseDate = DateTime.Parse("2023-02-09"),
                        PurchasePrice = 12.50M,
                        SalePrice = 14.87M
                    },
                    new Inventory
                    {
                        InventoryID = 17,
                        MerchID = 17,
                        WarehouseID = 10,
                        Quantity = 95,
                        PurchaseDate = DateTime.Parse("2021-04-27"),
                        PurchasePrice = 18.25M,
                        SalePrice = 25.35M
                    },
                    new Inventory
                    {
                        InventoryID = 18,
                        MerchID = 18,
                        WarehouseID = 12,
                        Quantity = 63,
                        PurchaseDate = DateTime.Parse("2020-10-15"),
                        PurchasePrice = 10.50M,
                        SalePrice = 16.21M
                    },
                    new Inventory
                    {
                        InventoryID = 19,
                        MerchID = 19,
                        WarehouseID = 6,
                        Quantity = 142,
                        PurchaseDate = DateTime.Parse("2019-08-03"),
                        PurchasePrice = 9.75M,
                        SalePrice = 11.32M
                    },
                    new Inventory
                    {
                        InventoryID = 20,
                        MerchID = 20,
                        WarehouseID = 2,
                        Quantity = 276,
                        PurchaseDate = DateTime.Parse("2021-03-19"),
                        PurchasePrice = 6.75M,
                        SalePrice = 8.31M
                    },
                    new Inventory
                    {
                        InventoryID = 21,
                        MerchID = 21,
                        WarehouseID = 7,
                        Quantity = 101,
                        PurchaseDate = DateTime.Parse("2022-11-25"),
                        PurchasePrice = 20.50M,
                        SalePrice = 31.57M
                    },
                    new Inventory
                    {
                        InventoryID = 22,
                        MerchID = 22,
                        WarehouseID = 9,
                        Quantity = 165,
                        PurchaseDate = DateTime.Parse("2023-08-07"),
                        PurchasePrice = 15.75M,
                        SalePrice = 28.16M
                    },
                    new Inventory
                    {
                        InventoryID = 23,
                        MerchID = 23,
                        WarehouseID = 1,
                        Quantity = 144,
                        PurchaseDate = DateTime.Parse("2019-10-30"),
                        PurchasePrice = 14.25M,
                        SalePrice = 19.54M
                    },
                    new Inventory
                    {
                        InventoryID = 24,
                        MerchID = 24,
                        WarehouseID = 4,
                        Quantity = 297,
                        PurchaseDate = DateTime.Parse("2020-12-12"),
                        PurchasePrice = 25.50M,
                        SalePrice = 30.54M
                    },
                    new Inventory
                    {
                        InventoryID = 25,
                        MerchID = 25,
                        WarehouseID = 9,
                        Quantity = 26,
                        PurchaseDate = DateTime.Parse("2021-07-03"),
                        PurchasePrice = 6.75M,
                        SalePrice = 9.95M
                    },
                    new Inventory
                    {
                        InventoryID = 26,
                        MerchID = 26,
                        WarehouseID = 7,
                        Quantity = 258,
                        PurchaseDate = DateTime.Parse("2022-04-18"),
                        PurchasePrice = 10.75M,
                        SalePrice = 15.50M
                    },
                    new Inventory
                    {
                        InventoryID = 27,
                        MerchID = 27,
                        WarehouseID = 3,
                        Quantity = 34,
                        PurchaseDate = DateTime.Parse("2018-09-22"),
                        PurchasePrice = 6.50M,
                        SalePrice = 10.05M
                    },
                    new Inventory
                    {
                        InventoryID = 28,
                        MerchID = 28,
                        WarehouseID = 8,
                        Quantity = 208,
                        PurchaseDate = DateTime.Parse("2023-01-11"),
                        PurchasePrice = 4.25M,
                        SalePrice = 7.74M
                    },
                    new Inventory
                    {
                        InventoryID = 29,
                        MerchID = 29,
                        WarehouseID = 10,
                        Quantity = 25,
                        PurchaseDate = DateTime.Parse("2020-06-29"),
                        PurchasePrice = 45.75M,
                        SalePrice = 55.90M
                    },
                    new Inventory
                    {
                        InventoryID = 30,
                        MerchID = 30,
                        WarehouseID = 1,
                        Quantity = 140,
                        PurchaseDate = DateTime.Parse("2022-05-08"),
                        PurchasePrice = 10.75M,
                        SalePrice = 14.32M
                    },
                    new Inventory
                    {
                        InventoryID = 31,
                        MerchID = 31,
                        WarehouseID = 11,
                        Quantity = 275,
                        PurchaseDate = DateTime.Parse("2023-09-17"),
                        PurchasePrice = 8.75M,
                        SalePrice = 11.95M
                    },
                    new Inventory
                    {
                        InventoryID = 32,
                        MerchID = 32,
                        WarehouseID = 5,
                        Quantity = 129,
                        PurchaseDate = DateTime.Parse("2022-03-04"),
                        PurchasePrice = 15.50M,
                        SalePrice = 19.78M
                    },
                    new Inventory
                    {
                        InventoryID = 33,
                        MerchID = 33,
                        WarehouseID = 2,
                        Quantity = 66,
                        PurchaseDate = DateTime.Parse("2020-08-21"),
                        PurchasePrice = 20.25M,
                        SalePrice = 29.35M
                    },
                    new Inventory
                    {
                        InventoryID = 34,
                        MerchID = 34,
                        WarehouseID = 6,
                        Quantity = 152,
                        PurchaseDate = DateTime.Parse("2019-06-12"),
                        PurchasePrice = 5.50M,
                        SalePrice = 9.12M
                    },
                    new Inventory
                    {
                        InventoryID = 35,
                        MerchID = 35,
                        WarehouseID = 8,
                        Quantity = 104,
                        PurchaseDate = DateTime.Parse("2021-01-28"),
                        PurchasePrice = 35.75M,
                        SalePrice = 49.99M
                    },
                    new Inventory
                    {
                        InventoryID = 36,
                        MerchID = 36,
                        WarehouseID = 4,
                        Quantity = 96,
                        PurchaseDate = DateTime.Parse("2020-10-09"),
                        PurchasePrice = 18.50M,
                        SalePrice = 25.50M
                    },
                    new Inventory
                    {
                        InventoryID = 37,
                        MerchID = 37,
                        WarehouseID = 7,
                        Quantity = 188,
                        PurchaseDate = DateTime.Parse("2022-02-15"),
                        PurchasePrice = 7.25M,
                        SalePrice = 10.32M
                    },
                    new Inventory
                    {
                        InventoryID = 38,
                        MerchID = 38,
                        WarehouseID = 9,
                        Quantity = 118,
                        PurchaseDate = DateTime.Parse("2021-11-03"),
                        PurchasePrice = 11.75M,
                        SalePrice = 14.50M
                    },
                    new Inventory
                    {
                        InventoryID = 39,
                        MerchID = 39,
                        WarehouseID = 12,
                        Quantity = 107,
                        PurchaseDate = DateTime.Parse("2022-07-19"),
                        PurchasePrice = 20.25M,
                        SalePrice = 27.98M
                    },
                    new Inventory
                    {
                        InventoryID = 40,
                        MerchID = 40,
                        WarehouseID = 1,
                        Quantity = 64,
                        PurchaseDate = DateTime.Parse("2023-04-28"),
                        PurchasePrice = 4.50M,
                        SalePrice = 6.99M
                    }
                );
            }
        }
    }
}
