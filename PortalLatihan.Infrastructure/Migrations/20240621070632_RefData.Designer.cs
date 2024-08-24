﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalLatihan.Infrastructure.Data.Context;

#nullable disable

namespace PortalLatihan.Infrastructure.Migrations
{
    [DbContext(typeof(PortalLatihanDBContext))]
    [Migration("20240621070632_RefData")]
    partial class RefData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortalLatihan.Domain.Entities.Participant", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParticipantStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SysDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SysDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SysUserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SysUserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TicketID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("PARTICIPANT");
                });

            modelBuilder.Entity("PortalLatihan.Domain.Entities.RefRegion", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SysDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SysDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SysUserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SysUserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ZoneID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("REF_REGION");
                });

            modelBuilder.Entity("PortalLatihan.Domain.Entities.RefZone", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SysDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SysDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SysUserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SysUserModified")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("REF_ZONE");
                });

            modelBuilder.Entity("PortalLatihan.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BuyerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BuyerType")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinalFee")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("OriginalFee")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SysDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SysDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SysUserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SysUserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TrainingDiscountCodeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TrainingDiscountGroupID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainingID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("TICKET");
                });

            modelBuilder.Entity("PortalLatihan.Domain.Entities.Training", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationInDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fee")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxParticipant")
                        .HasColumnType("int");

                    b.Property<int>("MinParticipant")
                        .HasColumnType("int");

                    b.Property<Guid>("RegionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SysDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SysDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SysUserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SysUserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ZoneID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("TRAINING");
                });

            modelBuilder.Entity("PortalLatihan.Domain.Entities.TrainingDiscountCode", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fee")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SysDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SysDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SysUserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SysUserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrainingID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("TRAINING_DISCOUNT_CODE");
                });

            modelBuilder.Entity("PortalLatihan.Domain.Entities.TrainingDiscountGroup", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Discount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SysDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SysDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SysUserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SysUserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maxParticipant")
                        .HasColumnType("int");

                    b.Property<int>("minParticipant")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("TRAINING_DISCOUNT_GROUP");
                });

            modelBuilder.Entity("PortalLatihan.Domain.Entities.TrainingStatusHistory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SysDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SysDateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SysUserCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SysUserModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrainingID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("TRAINING_STATUS_HISTORY");
                });
#pragma warning restore 612, 618
        }
    }
}
