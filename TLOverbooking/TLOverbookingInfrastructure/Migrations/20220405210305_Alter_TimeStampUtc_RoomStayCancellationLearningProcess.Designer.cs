﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TLOverbookingInfrastructure.Foundation;

namespace TLOverbookingInfrastructure.Migrations
{
    [DbContext(typeof(TLOverbookingDbContext))]
    [Migration("20220405210305_Alter_TimeStampUtc_RoomStayCancellationLearningProcess")]
    partial class Alter_TimeStampUtc_RoomStayCancellationLearningProcess
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TLOverbookingDomain.BookingCancellation.BookingCancellation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("BookingCancellationName")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProviderId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoomTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("BookingCancellation");
                });

            modelBuilder.Entity("TLOverbookingDomain.Provider.ProviderPredictionModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ProviderPredictionModelId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProviderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ProviderPredictionModel");
                });

            modelBuilder.Entity("TLOverbookingDomain.RoomStayCancellation.RoomStayCancellationLearningProcess", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("RoomStayCancellationLearningProcessId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ProviderId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStampUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RoomStayCancellationLearningProcess");
                });

            modelBuilder.Entity("TLOverbookingDomain.RoomStayFact.RoomStayFact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("RoomStayFactId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdultsAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ChildrenAmount")
                        .HasColumnType("int");

                    b.Property<int?>("DaysBetweenCheckInAndCanceling")
                        .HasColumnType("int");

                    b.Property<int>("DuratuionInDays")
                        .HasColumnType("int");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<long>("ProviderId")
                        .HasColumnType("bigint");

                    b.Property<long>("RatePlanId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoomTypeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("RoomStayFact");
                });
#pragma warning restore 612, 618
        }
    }
}
