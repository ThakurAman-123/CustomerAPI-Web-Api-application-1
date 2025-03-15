﻿// <auto-generated />
using System;
using CustomerAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerAPI.Migrations
{
    [DbContext(typeof(CustomerContext))]
    [Migration("20250310101932_MyFirstMigration")]
    partial class MyFirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerAPI.Models.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Address_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AddressId"));

                    b.Property<long>("AccountNo")
                        .HasColumnType("bigint")
                        .HasColumnName("Account_No_FK");

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("City");

                    b.Property<string>("DoorNo")
                        .HasColumnType("varchar(4)")
                        .HasColumnName("Door_No");

                    b.Property<long>("Pincode")
                        .HasColumnType("bigint")
                        .HasColumnName("Pincode");

                    b.Property<string>("State")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("State");

                    b.Property<string>("StreetName")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Street_Name");

                    b.HasKey("AddressId");

                    b.HasIndex("AccountNo");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CustomerAPI.Models.Customer", b =>
                {
                    b.Property<long>("AccountNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Account_No");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AccountNo"));

                    b.Property<long>("ContactNo")
                        .HasColumnType("bigint")
                        .HasColumnName("ContactNo");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Password");

                    b.HasKey("AccountNo");

                    b.ToTable("Customer");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("CustomerAPI.Models.Corporate", b =>
                {
                    b.HasBaseType("CustomerAPI.Models.Customer");

                    b.Property<string>("CompanyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Company_Type");

                    b.ToTable("Corporate");
                });

            modelBuilder.Entity("CustomerAPI.Models.Individual", b =>
                {
                    b.HasBaseType("CustomerAPI.Models.Customer");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2")
                        .HasColumnName("DOB");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Gender");

                    b.ToTable("Individual");
                });

            modelBuilder.Entity("CustomerAPI.Models.Address", b =>
                {
                    b.HasOne("CustomerAPI.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("AccountNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CustomerAPI.Models.Customer", b =>
                {
                    b.OwnsOne("CustomerAPI.Models.FullName", "Name", b1 =>
                        {
                            b1.Property<long>("CustomerAccountNo")
                                .HasColumnType("bigint");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("First_Name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Last_Name");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Middle_Name");

                            b1.HasKey("CustomerAccountNo");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerAccountNo");
                        });

                    b.Navigation("Name");
                });

            modelBuilder.Entity("CustomerAPI.Models.Corporate", b =>
                {
                    b.HasOne("CustomerAPI.Models.Customer", null)
                        .WithOne()
                        .HasForeignKey("CustomerAPI.Models.Corporate", "AccountNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerAPI.Models.Individual", b =>
                {
                    b.HasOne("CustomerAPI.Models.Customer", null)
                        .WithOne()
                        .HasForeignKey("CustomerAPI.Models.Individual", "AccountNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
