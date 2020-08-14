using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyShopperAPI.Models
{
    public partial class MyShopperContext : DbContext
    {
        public MyShopperContext()
        {
        }

        public MyShopperContext(DbContextOptions<MyShopperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<MainStore> MainStore { get; set; }
        //public virtual DbSet<MainStoreStore> MainStoreStore { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductPrice> ProductPrice { get; set; }
        public virtual DbSet<ShoppingList> ShoppingList { get; set; }
        public virtual DbSet<ShoppingListProduct> ShoppingListProduct { get; set; }
        public virtual DbSet<ShoppingListStore> ShoppingListStore { get; set; }
        public virtual DbSet<Store> Store { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=172.105.35.125;Database=MyShopper;Persist Security Info=False;User ID=SA;Password=Bobona21?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
//            }
//        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>(entity =>
        //    {
        //        entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

        //        entity.Property(e => e.CategoryDescription).IsUnicode(false);

        //        entity.Property(e => e.CategoryName)
        //            .IsRequired()
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<MainStore>(entity =>
        //    {
        //        entity.Property(e => e.MainStoreId).HasColumnName("MainStoreID");

        //        entity.Property(e => e.MainStoreName)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //    });

        //    //modelBuilder.Entity<MainStoreStore>(entity =>
        //    //{
        //    //    entity.Property(e => e.MainStoreStoreId).HasColumnName("MainStoreStoreID");

        //    //    entity.Property(e => e.MainStoreId).HasColumnName("MainStoreID");

        //    //    entity.Property(e => e.StoreId).HasColumnName("StoreID");

        //    //    //entity.HasOne(d => d.MainStore)
        //    //    //    .WithMany(p => p.MainStoreStore)
        //    //    //    .HasForeignKey(d => d.MainStoreId)
        //    //    //    .OnDelete(DeleteBehavior.ClientSetNull)
        //    //    //    .HasConstraintName("FK_MainStoreStore_MainStore");

        //    //    //entity.HasOne(d => d.Store)
        //    //    //    .WithMany(p => p.MainStoreStore)
        //    //    //    .HasForeignKey(d => d.StoreId)
        //    //    //    .OnDelete(DeleteBehavior.ClientSetNull)
        //    //    //    .HasConstraintName("FK_MainStoreStore_Store");
        //    //});

        //    modelBuilder.Entity<Price>(entity =>
        //    {
        //        entity.Property(e => e.PriceId).HasColumnName("PriceID");

        //        entity.Property(e => e.Price1)
        //            .HasColumnName("Price")
        //            .HasColumnType("money");

        //        entity.Property(e => e.PriceCreationDate).HasColumnType("date");
        //    });

        //    modelBuilder.Entity<Product>(entity =>
        //    {
        //        entity.Property(e => e.ProductId).HasColumnName("ProductID");

        //        entity.Property(e => e.ProductName)
        //            .IsRequired()
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<ProductCategory>(entity =>
        //    {
        //        entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

        //        entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

        //        entity.Property(e => e.ProductId).HasColumnName("ProductID");

        //        entity.HasOne(d => d.Category)
        //            .WithMany(p => p.ProductCategory)
        //            .HasForeignKey(d => d.CategoryId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProductCategory_Category");

        //        entity.HasOne(d => d.Product)
        //            .WithMany(p => p.ProductCategory)
        //            .HasForeignKey(d => d.ProductId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProductCategory_Product");
        //    });

        //    modelBuilder.Entity<ProductPrice>(entity =>
        //    {
        //        entity.Property(e => e.ProductPriceId).HasColumnName("ProductPriceID");

        //        entity.Property(e => e.PriceId).HasColumnName("PriceID");

        //        entity.Property(e => e.ProductId).HasColumnName("ProductID");

        //        entity.HasOne(d => d.Price)
        //            .WithMany(p => p.ProductPrice)
        //            .HasForeignKey(d => d.PriceId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProductPrice_Price1");

        //        entity.HasOne(d => d.Product)
        //            .WithMany(p => p.ProductPrice)
        //            .HasForeignKey(d => d.ProductId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProductPrice_Product");
        //    });

        //    modelBuilder.Entity<ShoppingList>(entity =>
        //    {
        //        entity.Property(e => e.ShoppingListId).HasColumnName("ShoppingListID");

        //        entity.Property(e => e.CreationDate).HasColumnType("date");

        //        entity.Property(e => e.ShoppingListName)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<ShoppingListProduct>(entity =>
        //    {
        //        entity.Property(e => e.ShoppingListProductId).HasColumnName("ShoppingListProductID");

        //        entity.Property(e => e.ProductId).HasColumnName("ProductID");

        //        entity.Property(e => e.ShoppingListId).HasColumnName("ShoppingListID");

        //        entity.HasOne(d => d.Product)
        //            .WithMany(p => p.ShoppingListProduct)
        //            .HasForeignKey(d => d.ProductId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ShoppingListProduct_Product");

        //        entity.HasOne(d => d.ShoppingList)
        //            .WithMany(p => p.ShoppingListProduct)
        //            .HasForeignKey(d => d.ShoppingListId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ShoppingListProduct_ShoppingList");
        //    });

        //    modelBuilder.Entity<ShoppingListStore>(entity =>
        //    {
        //        entity.Property(e => e.ShoppingListStoreId).HasColumnName("ShoppingListStoreID");

        //        entity.Property(e => e.ShoppingListId).HasColumnName("ShoppingListID");

        //        entity.Property(e => e.StoreId).HasColumnName("StoreID");

        //        entity.HasOne(d => d.ShoppingList)
        //            .WithMany(p => p.ShoppingListStore)
        //            .HasForeignKey(d => d.ShoppingListId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ShoppingListStore_ShoppingList");

        //        entity.HasOne(d => d.Store)
        //            .WithMany(p => p.ShoppingListStore)
        //            .HasForeignKey(d => d.StoreId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ShoppingListStore_Store");
        //    });

        //    modelBuilder.Entity<Store>(entity =>
        //    {
        //        entity.Property(e => e.StoreId).HasColumnName("StoreID");

        //        entity.Property(e => e.StoreLocation)
        //            .IsRequired()
        //            .HasMaxLength(250)
        //            .IsUnicode(false);

        //        entity.Property(e => e.StoreName)
        //            .IsRequired()
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
