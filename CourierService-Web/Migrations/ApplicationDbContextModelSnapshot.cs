﻿// <auto-generated />
using System;
using CourierService_Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourierService_Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourierService_Web.Models.Admin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = "A-123",
                            Email = "flyerbd@gmail.com",
                            Name = "Admin",
                            Password = "1111"
                        });
                });

            modelBuilder.Entity("CourierService_Web.Models.Complain", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MerchantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("Complain");
                });

            modelBuilder.Entity("CourierService_Web.Models.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CourierService_Web.Models.DeliveredParcel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MerchantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ParcelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RiderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HubId");

                    b.HasIndex("MerchantId");

                    b.HasIndex("RiderId");

                    b.ToTable("DeliveredParcels");
                });

            modelBuilder.Entity("CourierService_Web.Models.ExchangeParcel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExchangeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ParcelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RiderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HubId");

                    b.HasIndex("ParcelId");

                    b.HasIndex("RiderId");

                    b.ToTable("ExchangeParcels");
                });

            modelBuilder.Entity("CourierService_Web.Models.Hub", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Hubs");

                    b.HasData(
                        new
                        {
                            Id = "H-123",
                            Address = "Dhaka, Bangladesh",
                            AdminId = "A-123",
                            Area = "Mirpur",
                            CreatedAt = new DateTime(2024, 3, 13, 3, 13, 53, 57, DateTimeKind.Local).AddTicks(4598),
                            CreatedBy = "Admin",
                            District = "Dhaka",
                            Email = "hub@gmail.com",
                            Name = "Hub",
                            Password = "1111",
                            PhoneNumber = "01837730317",
                            Status = 1
                        });
                });

            modelBuilder.Entity("CourierService_Web.Models.Merchant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TradeLicense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HubId");

                    b.ToTable("Merchants");

                    b.HasData(
                        new
                        {
                            Id = "M-123",
                            Area = "Mirpur",
                            CompanyName = "Merchant Company",
                            ConfirmPassword = "1111",
                            ContactNumber = "01837730317",
                            CreatedAt = new DateTime(2024, 3, 13, 3, 13, 53, 57, DateTimeKind.Local).AddTicks(4534),
                            Email = "merchant@gmail.com",
                            FullAddress = "Dhaka, Bangladesh",
                            Name = "Merchant",
                            Password = "1111"
                        });
                });

            modelBuilder.Entity("CourierService_Web.Models.Parcel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CancelDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryCharge")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DispatchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MerchantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PaymentInHand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PickupLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PickupRequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("int");

                    b.Property<int?>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReceiverAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RiderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId")
                        .IsUnique()
                        .HasFilter("[DeliveryId] IS NOT NULL");

                    b.HasIndex("HubId");

                    b.HasIndex("MerchantId");

                    b.HasIndex("RiderId");

                    b.ToTable("Parcels");
                });

            modelBuilder.Entity("CourierService_Web.Models.ReturnParcel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ParcelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RiderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HubId");

                    b.HasIndex("ParcelId");

                    b.HasIndex("RiderId");

                    b.ToTable("ReturnParcels");
                });

            modelBuilder.Entity("CourierService_Web.Models.Rider", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HubId");

                    b.ToTable("Riders");

                    b.HasData(
                        new
                        {
                            Id = "R-123",
                            Area = "Dhaka",
                            ContactNumber = "01837730317",
                            CreatedAt = new DateTime(2024, 3, 13, 3, 13, 53, 57, DateTimeKind.Local).AddTicks(4652),
                            District = "Dhaka",
                            Email = "rider@gmail.com",
                            FullAddress = "Dhaka, Bangladesh",
                            HubId = "H-123",
                            NID = "0123456789",
                            Name = "Rider",
                            Password = "1111",
                            Salary = 10000,
                            State = "Available",
                            Status = 1
                        });
                });

            modelBuilder.Entity("CourierService_Web.Models.Complain", b =>
                {
                    b.HasOne("CourierService_Web.Models.Merchant", "Merchant")
                        .WithMany("complains")
                        .HasForeignKey("MerchantId");

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("CourierService_Web.Models.DeliveredParcel", b =>
                {
                    b.HasOne("CourierService_Web.Models.Hub", "Hub")
                        .WithMany("DeliveredParcels")
                        .HasForeignKey("HubId");

                    b.HasOne("CourierService_Web.Models.Merchant", "Merchant")
                        .WithMany("DeliveredParcels")
                        .HasForeignKey("MerchantId");

                    b.HasOne("CourierService_Web.Models.Rider", "Rider")
                        .WithMany("DeliveredParcels")
                        .HasForeignKey("RiderId");

                    b.Navigation("Hub");

                    b.Navigation("Merchant");

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("CourierService_Web.Models.ExchangeParcel", b =>
                {
                    b.HasOne("CourierService_Web.Models.Hub", "Hub")
                        .WithMany("ExchangeParcels")
                        .HasForeignKey("HubId");

                    b.HasOne("CourierService_Web.Models.Parcel", "Parcel")
                        .WithMany("ExchangeParcel")
                        .HasForeignKey("ParcelId");

                    b.HasOne("CourierService_Web.Models.Rider", "Rider")
                        .WithMany("ExchangeParcels")
                        .HasForeignKey("RiderId");

                    b.Navigation("Hub");

                    b.Navigation("Parcel");

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("CourierService_Web.Models.Hub", b =>
                {
                    b.HasOne("CourierService_Web.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("CourierService_Web.Models.Merchant", b =>
                {
                    b.HasOne("CourierService_Web.Models.Hub", "Hub")
                        .WithMany("Merchants")
                        .HasForeignKey("HubId");

                    b.Navigation("Hub");
                });

            modelBuilder.Entity("CourierService_Web.Models.Parcel", b =>
                {
                    b.HasOne("CourierService_Web.Models.DeliveredParcel", "DeliveryParcel")
                        .WithOne("Parcel")
                        .HasForeignKey("CourierService_Web.Models.Parcel", "DeliveryId");

                    b.HasOne("CourierService_Web.Models.Hub", "Hub")
                        .WithMany("parcels")
                        .HasForeignKey("HubId");

                    b.HasOne("CourierService_Web.Models.Merchant", "Merchant")
                        .WithMany("Parcels")
                        .HasForeignKey("MerchantId");

                    b.HasOne("CourierService_Web.Models.Rider", "Rider")
                        .WithMany("Parcels")
                        .HasForeignKey("RiderId");

                    b.Navigation("DeliveryParcel");

                    b.Navigation("Hub");

                    b.Navigation("Merchant");

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("CourierService_Web.Models.ReturnParcel", b =>
                {
                    b.HasOne("CourierService_Web.Models.Hub", "Hub")
                        .WithMany("ReturnParcels")
                        .HasForeignKey("HubId");

                    b.HasOne("CourierService_Web.Models.Parcel", "Parcel")
                        .WithMany("ReturnParcel")
                        .HasForeignKey("ParcelId");

                    b.HasOne("CourierService_Web.Models.Rider", "Rider")
                        .WithMany("ReturnParcels")
                        .HasForeignKey("RiderId");

                    b.Navigation("Hub");

                    b.Navigation("Parcel");

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("CourierService_Web.Models.Rider", b =>
                {
                    b.HasOne("CourierService_Web.Models.Hub", "Hub")
                        .WithMany("Riders")
                        .HasForeignKey("HubId");

                    b.Navigation("Hub");
                });

            modelBuilder.Entity("CourierService_Web.Models.DeliveredParcel", b =>
                {
                    b.Navigation("Parcel")
                        .IsRequired();
                });

            modelBuilder.Entity("CourierService_Web.Models.Hub", b =>
                {
                    b.Navigation("DeliveredParcels");

                    b.Navigation("ExchangeParcels");

                    b.Navigation("Merchants");

                    b.Navigation("ReturnParcels");

                    b.Navigation("Riders");

                    b.Navigation("parcels");
                });

            modelBuilder.Entity("CourierService_Web.Models.Merchant", b =>
                {
                    b.Navigation("DeliveredParcels");

                    b.Navigation("Parcels");

                    b.Navigation("complains");
                });

            modelBuilder.Entity("CourierService_Web.Models.Parcel", b =>
                {
                    b.Navigation("ExchangeParcel");

                    b.Navigation("ReturnParcel");
                });

            modelBuilder.Entity("CourierService_Web.Models.Rider", b =>
                {
                    b.Navigation("DeliveredParcels");

                    b.Navigation("ExchangeParcels");

                    b.Navigation("Parcels");

                    b.Navigation("ReturnParcels");
                });
#pragma warning restore 612, 618
        }
    }
}
