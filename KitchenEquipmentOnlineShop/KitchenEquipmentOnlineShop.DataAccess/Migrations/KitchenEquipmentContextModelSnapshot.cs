﻿// <auto-generated />
using System;
using KitchenEquipmentOnlineShop.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KitchenEquipmentOnlineShop.DataAccess.Migrations
{
    [DbContext(typeof(KitchenEquipmentContext))]
    partial class KitchenEquipmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KitchenEquipmentOnlineShop.DataAccess.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("Country");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("KitchenEquipmentOnlineShop.DataAccess.Entities.ExhaustHood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Description")
                        .HasMaxLength(1500);

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("Type");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("ExhaustHoods");
                });

            modelBuilder.Entity("KitchenEquipmentOnlineShop.DataAccess.Entities.Sink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<int?>("CompanyId");

                    b.Property<float>("Depth");

                    b.Property<string>("Description")
                        .HasMaxLength(1500);

                    b.Property<int>("Form");

                    b.Property<byte[]>("Image");

                    b.Property<int>("Material");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("Type");

                    b.Property<float>("Width");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Sinks");
                });

            modelBuilder.Entity("KitchenEquipmentOnlineShop.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KitchenEquipmentOnlineShop.DataAccess.Entities.ExhaustHood", b =>
                {
                    b.HasOne("KitchenEquipmentOnlineShop.DataAccess.Entities.Company", "Company")
                        .WithMany("ExhaustHoods")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KitchenEquipmentOnlineShop.DataAccess.Entities.Sink", b =>
                {
                    b.HasOne("KitchenEquipmentOnlineShop.DataAccess.Entities.Company", "Company")
                        .WithMany("Sinks")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
