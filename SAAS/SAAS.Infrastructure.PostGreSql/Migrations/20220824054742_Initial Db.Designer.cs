﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SAAS.Infrastructure.Persistence;

#nullable disable

namespace SAAS.Infrastructure.PostGreSql.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220824054742_Initial Db")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SAAS.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PaymentDetails")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SAAS.Core.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LicenseExpiredOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LicenseStartedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("SAAS.Core.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConnectionString")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<string>("DbProvider")
                        .HasColumnType("text");

                    b.Property<string>("DbType")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<string>("TenantAddress")
                        .HasColumnType("text");

                    b.Property<string>("TenantName")
                        .HasColumnType("text");

                    b.Property<string>("TenantUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("SAAS.Core.Entities.Subscription", b =>
                {
                    b.HasOne("SAAS.Core.Entities.Customer", "Customer")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SAAS.Core.Entities.Tenant", b =>
                {
                    b.HasOne("SAAS.Core.Entities.Subscription", "Subscription")
                        .WithOne("Tenant")
                        .HasForeignKey("SAAS.Core.Entities.Tenant", "SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("SAAS.Core.Entities.Customer", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("SAAS.Core.Entities.Subscription", b =>
                {
                    b.Navigation("Tenant");
                });
#pragma warning restore 612, 618
        }
    }
}
