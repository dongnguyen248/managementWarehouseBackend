﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(WarehouseManagementContext))]
    [Migration("20220408091758_updateInventoriesforExportHistories")]
    partial class updateInventoriesforExportHistories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.CostAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UIdx_CostAccount_Name")
                        .IsUnique();

                    b.ToTable("CostAccount");
                });

            modelBuilder.Entity("Data.CostAccountItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CostAccount")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CostAccount");

                    b.ToTable("CostAccountItem");
                });

            modelBuilder.Entity("Data.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(95)
                        .HasColumnType("nvarchar(95)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Data.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "EmployeeId" }, "UIdx_Employee_Code")
                        .IsUnique();

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Data.ExportHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExportDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Handler")
                        .HasColumnType("int");

                    b.Property<int>("Material")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Receiver")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Requestor")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("costAccount")
                        .HasColumnType("int");

                    b.Property<int>("costAccountItem")
                        .HasColumnType("int");

                    b.Property<int>("inventories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Department");

                    b.HasIndex("Handler");

                    b.HasIndex("Material");

                    b.HasIndex("Receiver");

                    b.HasIndex("costAccount");

                    b.HasIndex("costAccountItem");

                    b.ToTable("ExportHistory");
                });

            modelBuilder.Entity("Data.ImportHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Allocated")
                        .HasColumnType("bit");

                    b.Property<string>("Buyer")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Handler")
                        .HasColumnType("int");

                    b.Property<DateTime>("ImportDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("LineRequest")
                        .HasColumnType("int");

                    b.Property<int>("Material")
                        .HasColumnType("int");

                    b.Property<string>("Po")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("PO");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Supplier")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Handler");

                    b.HasIndex("LineRequest");

                    b.HasIndex("Material");

                    b.ToTable("ImportHistory");
                });

            modelBuilder.Entity("Data.Inspection", b =>
                {
                    b.Property<int>("ImportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Inspector")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Result")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ImportId")
                        .HasName("PK__Inspecti__869767EA51B9482C");

                    b.ToTable("Inspection");
                });

            modelBuilder.Entity("Data.Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CostCenter")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Line");
                });

            modelBuilder.Entity("Data.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Item")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Qcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("QCode");

                    b.Property<string>("Specification")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.Property<int>("Zone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Unit");

                    b.HasIndex("Zone");

                    b.HasIndex(new[] { "Qcode" }, "UIdx_Material_QCode")
                        .IsUnique();

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Data.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("Data.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UIdx_Zone_Name")
                        .IsUnique();

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("Data.CostAccountItem", b =>
                {
                    b.HasOne("Data.CostAccount", "CostAccountNavigation")
                        .WithMany("CostAccountItems")
                        .HasForeignKey("CostAccount")
                        .HasConstraintName("Fk_CostAccountItem_CostAccount")
                        .IsRequired();

                    b.Navigation("CostAccountNavigation");
                });

            modelBuilder.Entity("Data.ExportHistory", b =>
                {
                    b.HasOne("Data.Department", "DepartmentNavigation")
                        .WithMany("ExportHistories")
                        .HasForeignKey("Department")
                        .HasConstraintName("Fk_EmportHistory_Deparment")
                        .IsRequired();

                    b.HasOne("Data.Employee", "HandlerNavigation")
                        .WithMany("ExportHistories")
                        .HasForeignKey("Handler")
                        .HasConstraintName("Fk_ExportHistory_Handler")
                        .IsRequired();

                    b.HasOne("Data.Material", "MaterialNavigation")
                        .WithMany("ExportHistories")
                        .HasForeignKey("Material")
                        .HasConstraintName("Fk_ExportHistory_Material")
                        .IsRequired();

                    b.HasOne("Data.Line", "ReceiverNavigation")
                        .WithMany("ExportHistories")
                        .HasForeignKey("Receiver")
                        .HasConstraintName("Fk_ExportHistory_Receiver")
                        .IsRequired();

                    b.HasOne("Data.CostAccount", "CostAccountNavigation")
                        .WithMany("ExportHistories")
                        .HasForeignKey("costAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.CostAccountItem", "CostAccountItemNavigation")
                        .WithMany("ExportHistories")
                        .HasForeignKey("costAccountItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CostAccountItemNavigation");

                    b.Navigation("CostAccountNavigation");

                    b.Navigation("DepartmentNavigation");

                    b.Navigation("HandlerNavigation");

                    b.Navigation("MaterialNavigation");

                    b.Navigation("ReceiverNavigation");
                });

            modelBuilder.Entity("Data.ImportHistory", b =>
                {
                    b.HasOne("Data.Employee", "HandlerNavigation")
                        .WithMany("ImportHistories")
                        .HasForeignKey("Handler")
                        .HasConstraintName("Fk_ImportHistory_Handler")
                        .IsRequired();

                    b.HasOne("Data.Line", "LineRequestNavigation")
                        .WithMany("ImportHistories")
                        .HasForeignKey("LineRequest")
                        .HasConstraintName("Fk_ImportHistory_LineRequest")
                        .IsRequired();

                    b.HasOne("Data.Material", "MaterialNavigation")
                        .WithMany("ImportHistories")
                        .HasForeignKey("Material")
                        .HasConstraintName("Fk_ImportHistory_Material")
                        .IsRequired();

                    b.Navigation("HandlerNavigation");

                    b.Navigation("LineRequestNavigation");

                    b.Navigation("MaterialNavigation");
                });

            modelBuilder.Entity("Data.Inspection", b =>
                {
                    b.HasOne("Data.ImportHistory", "Import")
                        .WithOne("InspectionNavigation")
                        .HasForeignKey("Data.Inspection", "ImportId")
                        .HasConstraintName("Fk_Inspection_ImportHistory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Import");
                });

            modelBuilder.Entity("Data.Material", b =>
                {
                    b.HasOne("Data.Unit", "UnitNavigation")
                        .WithMany("Materials")
                        .HasForeignKey("Unit")
                        .HasConstraintName("Fk_Material_Unit")
                        .IsRequired();

                    b.HasOne("Data.Zone", "ZoneNavigation")
                        .WithMany("Materials")
                        .HasForeignKey("Zone")
                        .HasConstraintName("Fk_Material_Zone")
                        .IsRequired();

                    b.Navigation("UnitNavigation");

                    b.Navigation("ZoneNavigation");
                });

            modelBuilder.Entity("Data.CostAccount", b =>
                {
                    b.Navigation("CostAccountItems");

                    b.Navigation("ExportHistories");
                });

            modelBuilder.Entity("Data.CostAccountItem", b =>
                {
                    b.Navigation("ExportHistories");
                });

            modelBuilder.Entity("Data.Department", b =>
                {
                    b.Navigation("ExportHistories");
                });

            modelBuilder.Entity("Data.Employee", b =>
                {
                    b.Navigation("ExportHistories");

                    b.Navigation("ImportHistories");
                });

            modelBuilder.Entity("Data.ImportHistory", b =>
                {
                    b.Navigation("InspectionNavigation");
                });

            modelBuilder.Entity("Data.Line", b =>
                {
                    b.Navigation("ExportHistories");

                    b.Navigation("ImportHistories");
                });

            modelBuilder.Entity("Data.Material", b =>
                {
                    b.Navigation("ExportHistories");

                    b.Navigation("ImportHistories");
                });

            modelBuilder.Entity("Data.Unit", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("Data.Zone", b =>
                {
                    b.Navigation("Materials");
                });
#pragma warning restore 612, 618
        }
    }
}
