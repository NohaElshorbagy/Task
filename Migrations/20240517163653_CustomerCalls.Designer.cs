﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task.Models;

#nullable disable

namespace Task.Migrations
{
    [DbContext(typeof(TaskDBContext))]
    [Migration("20240517163653_CustomerCalls")]
    partial class CustomerCalls
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task.Models.CustomerCall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Call_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Call_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerDataId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerDataId");

                    b.ToTable("CustomerCalls");
                });

            modelBuilder.Entity("Task.Models.CustomerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Client_source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber1")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumber2")
                        .HasColumnType("int");

                    b.Property<string>("Salesman")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Whatsapp_Number")
                        .HasColumnType("int");

                    b.Property<string>("residence")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerDatas");
                });

            modelBuilder.Entity("Task.Models.CustomerCall", b =>
                {
                    b.HasOne("Task.Models.CustomerData", "CustomerData")
                        .WithMany("CustomerCalls")
                        .HasForeignKey("CustomerDataId");

                    b.Navigation("CustomerData");
                });

            modelBuilder.Entity("Task.Models.CustomerData", b =>
                {
                    b.Navigation("CustomerCalls");
                });
#pragma warning restore 612, 618
        }
    }
}
