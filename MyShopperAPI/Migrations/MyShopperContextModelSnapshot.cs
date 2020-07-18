﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyShopperAPI.Models;

namespace MyShopperAPI.Migrations
{
    [DbContext(typeof(MyShopperContext))]
    partial class MyShopperContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyShopperAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MyShopperAPI.Models.MainStore", b =>
                {
                    b.Property<int>("MainStoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MainStoreID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MainStoreName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("MainStoreId");

                    b.ToTable("MainStore");
                });

            modelBuilder.Entity("MyShopperAPI.Models.MainStoreStore", b =>
                {
                    b.Property<int>("MainStoreStoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MainStoreStoreID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MainStoreId")
                        .HasColumnName("MainStoreID")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnName("StoreID")
                        .HasColumnType("int");

                    b.HasKey("MainStoreStoreId");

                    b.HasIndex("MainStoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("MainStoreStore");
                });

            modelBuilder.Entity("MyShopperAPI.Models.Price", b =>
                {
                    b.Property<int>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PriceID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price1")
                        .HasColumnName("Price")
                        .HasColumnType("money");

                    b.Property<DateTime>("PriceCreationDate")
                        .HasColumnType("date");

                    b.HasKey("PriceId");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("MyShopperAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<byte[]>("ProductPicture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MyShopperAPI.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductCategoryID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ProductCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("MyShopperAPI.Models.ProductPrice", b =>
                {
                    b.Property<int>("ProductPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductPriceID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PriceId")
                        .HasColumnName("PriceID")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ProductPriceId");

                    b.HasIndex("PriceId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPrice");
                });

            modelBuilder.Entity("MyShopperAPI.Models.ShoppingList", b =>
                {
                    b.Property<int>("ShoppingListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ShoppingListID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<string>("ShoppingListName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("ShoppingListId");

                    b.ToTable("ShoppingList");
                });

            modelBuilder.Entity("MyShopperAPI.Models.ShoppingListProduct", b =>
                {
                    b.Property<int>("ShoppingListProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ShoppingListProductID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingListId")
                        .HasColumnName("ShoppingListID")
                        .HasColumnType("int");

                    b.HasKey("ShoppingListProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ShoppingListProduct");
                });

            modelBuilder.Entity("MyShopperAPI.Models.ShoppingListStore", b =>
                {
                    b.Property<int>("ShoppingListStoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ShoppingListStoreID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ShoppingListId")
                        .HasColumnName("ShoppingListID")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnName("StoreID")
                        .HasColumnType("int");

                    b.HasKey("ShoppingListStoreId");

                    b.HasIndex("ShoppingListId");

                    b.HasIndex("StoreId");

                    b.ToTable("ShoppingListStore");
                });

            modelBuilder.Entity("MyShopperAPI.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StoreID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StoreLocation")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("StoreRating")
                        .HasColumnType("int");

                    b.HasKey("StoreId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("MyShopperAPI.Models.MainStoreStore", b =>
                {
                    b.HasOne("MyShopperAPI.Models.MainStore", "MainStore")
                        .WithMany("MainStoreStore")
                        .HasForeignKey("MainStoreId")
                        .HasConstraintName("FK_MainStoreStore_MainStore")
                        .IsRequired();

                    b.HasOne("MyShopperAPI.Models.Store", "Store")
                        .WithMany("MainStoreStore")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK_MainStoreStore_Store")
                        .IsRequired();
                });

            modelBuilder.Entity("MyShopperAPI.Models.ProductCategory", b =>
                {
                    b.HasOne("MyShopperAPI.Models.Category", "Category")
                        .WithMany("ProductCategory")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_ProductCategory_Category")
                        .IsRequired();

                    b.HasOne("MyShopperAPI.Models.Product", "Product")
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductCategory_Product")
                        .IsRequired();
                });

            modelBuilder.Entity("MyShopperAPI.Models.ProductPrice", b =>
                {
                    b.HasOne("MyShopperAPI.Models.Price", "Price")
                        .WithMany("ProductPrice")
                        .HasForeignKey("PriceId")
                        .HasConstraintName("FK_ProductPrice_Price1")
                        .IsRequired();

                    b.HasOne("MyShopperAPI.Models.Product", "Product")
                        .WithMany("ProductPrice")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductPrice_Product")
                        .IsRequired();
                });

            modelBuilder.Entity("MyShopperAPI.Models.ShoppingListProduct", b =>
                {
                    b.HasOne("MyShopperAPI.Models.Product", "Product")
                        .WithMany("ShoppingListProduct")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ShoppingListProduct_Product")
                        .IsRequired();

                    b.HasOne("MyShopperAPI.Models.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListProduct")
                        .HasForeignKey("ShoppingListId")
                        .HasConstraintName("FK_ShoppingListProduct_ShoppingList")
                        .IsRequired();
                });

            modelBuilder.Entity("MyShopperAPI.Models.ShoppingListStore", b =>
                {
                    b.HasOne("MyShopperAPI.Models.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListStore")
                        .HasForeignKey("ShoppingListId")
                        .HasConstraintName("FK_ShoppingListStore_ShoppingList")
                        .IsRequired();

                    b.HasOne("MyShopperAPI.Models.Store", "Store")
                        .WithMany("ShoppingListStore")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK_ShoppingListStore_Store")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
