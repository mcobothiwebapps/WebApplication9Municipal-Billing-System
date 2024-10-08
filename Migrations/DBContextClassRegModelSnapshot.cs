﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication9Municipal_Billing_System.Models;

#nullable disable

namespace WebApplication9Municipal_Billing_System.Migrations
{
    [DbContext(typeof(DBContextClassReg))]
    partial class DBContextClassRegModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication9Municipal_Billing_System.Models.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"), 1L, 1);

                    b.Property<decimal>("BasicCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ElectricityId")
                        .HasColumnType("int");

                    b.Property<decimal>("TarriffDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TarriffId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WaterId")
                        .HasColumnType("int");

                    b.HasKey("BillId");

                    b.HasIndex("ElectricityId");

                    b.HasIndex("TarriffId");

                    b.HasIndex("UserId");

                    b.HasIndex("WaterId");

                    b.ToTable("bills");
                });

            modelBuilder.Entity("WebApplication9Municipal_Billing_System.Models.Electricity", b =>
                {
                    b.Property<int>("ElectricityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElectricityId"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RegUserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Usage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ElectricityId");

                    b.HasIndex("RegUserId");

                    b.ToTable("electricities");
                });

            modelBuilder.Entity("WebApplication9Municipal_Billing_System.Models.Reg", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Regs");
                });

            modelBuilder.Entity("WebApplication9Municipal_Billing_System.Models.Tarriff", b =>
                {
                    b.Property<int>("TarriffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TarriffId"), 1L, 1);

                    b.Property<decimal>("DiscRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TarriffId");

                    b.ToTable("tarriffs");
                });

            modelBuilder.Entity("WebApplication9Municipal_Billing_System.Models.Water", b =>
                {
                    b.Property<int>("WaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WaterId"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RegUserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Usage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WaterId");

                    b.HasIndex("RegUserId");

                    b.ToTable("waters");
                });

            modelBuilder.Entity("WebApplication9Municipal_Billing_System.Models.Bill", b =>
                {
                    b.HasOne("WebApplication9Municipal_Billing_System.Models.Electricity", "Electricity")
                        .WithMany()
                        .HasForeignKey("ElectricityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApplication9Municipal_Billing_System.Models.Tarriff", "Tarriff")
                        .WithMany()
                        .HasForeignKey("TarriffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication9Municipal_Billing_System.Models.Reg", "Reg")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApplication9Municipal_Billing_System.Models.Water", "Water")
                        .WithMany()
                        .HasForeignKey("WaterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Electricity");

                    b.Navigation("Reg");

                    b.Navigation("Tarriff");

                    b.Navigation("Water");
                });

            modelBuilder.Entity("WebApplication9Municipal_Billing_System.Models.Electricity", b =>
                {
                    b.HasOne("WebApplication9Municipal_Billing_System.Models.Reg", "Reg")
                        .WithMany()
                        .HasForeignKey("RegUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reg");
                });

            modelBuilder.Entity("WebApplication9Municipal_Billing_System.Models.Water", b =>
                {
                    b.HasOne("WebApplication9Municipal_Billing_System.Models.Reg", "Reg")
                        .WithMany()
                        .HasForeignKey("RegUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reg");
                });
#pragma warning restore 612, 618
        }
    }
}
