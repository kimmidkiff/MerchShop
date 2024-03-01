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

        protected internal class MerchConfig : IEntityTypeConfiguration<Merch>
        {
            public void Configure(EntityTypeBuilder<Merch> entity)
            {
                entity.HasData(
                
                    new Merch { MerchID = 001, VendorID = 009, MerchType = MerchType.Electronics, 
                        ItemName = "Protective Phone Case for iPhone 14", Rating = 3.4f, ItemDescripion = "Protective phone " +
                        "case created with polycarbonate and TPU materials for the iPhone 14." },
                    new Merch { MerchID = 002, VendorID = 003, MerchType = MerchType.Apparel, 
                        ItemName = "Cotton Baseball Cap", Rating = 4.7f, ItemDescripion = "High quality cotton baseball " +
                        "cap with adjustable closure to fit most head sizes." }
                );
            }
        }

        protected internal class InventoryConfig : IEntityTypeConfiguration<Inventory>
        {
            public void Configure(EntityTypeBuilder<Inventory> entity)
            {
                entity.HasData(

                    new Inventory { InventoryID = 001, MerchID = 002, WarehouseID = 007, Quantity = 243, 
                        PurchaseDate = DateTime.Parse("2024-01-06"), PurchasePrice = 4.50M, SalePrice = 14.99M }
                );
            }
        }
    }
}
