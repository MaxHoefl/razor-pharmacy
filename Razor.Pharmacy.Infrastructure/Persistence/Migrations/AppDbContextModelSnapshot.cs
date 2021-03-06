// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Razor.Pharmacy.Infrastructure.Persistence;

#nullable disable

namespace Razor.Pharmacy.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.Basket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BasketId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerClientId")
                        .HasColumnType("integer");

                    b.Property<string>("OfferCode")
                        .HasColumnType("text");

                    b.HasKey("BasketId");

                    b.HasIndex("CustomerClientId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClientId"));

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PostCode")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("ClientId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerClientId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer");

                    b.Property<float>("PercentageDiscount")
                        .HasColumnType("real");

                    b.Property<DateTime?>("PickupTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.PharmacyItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<int?>("BasketId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<bool>("RequiresPrescription")
                        .HasColumnType("boolean");

                    b.HasKey("ItemId");

                    b.HasIndex("BasketId");

                    b.HasIndex("OrderId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.Basket", b =>
                {
                    b.HasOne("Razor.Pharmacy.Domain.Entities.Customer", null)
                        .WithMany("Baskets")
                        .HasForeignKey("CustomerClientId");
                });

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.Order", b =>
                {
                    b.HasOne("Razor.Pharmacy.Domain.Entities.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerClientId");
                });

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.PharmacyItem", b =>
                {
                    b.HasOne("Razor.Pharmacy.Domain.Entities.Basket", null)
                        .WithMany("Items")
                        .HasForeignKey("BasketId");

                    b.HasOne("Razor.Pharmacy.Domain.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.Basket", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Baskets");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Razor.Pharmacy.Domain.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
