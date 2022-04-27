using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data
{
    public partial class WarehouseManagementContext : DbContext
    {
        public WarehouseManagementContext()
        {
        }

        public WarehouseManagementContext(DbContextOptions<WarehouseManagementContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<CostAccount> CostAccounts { get; set; }
        public virtual DbSet<CostAccountItem> CostAccountItems { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ExportHistory> ExportHistories { get; set; }
        public virtual DbSet<ImportHistory> ImportHistories { get; set; }
        public virtual DbSet<Inspection> Inspections { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=WarehouseMG;User ID=sa;Password=1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CostAccount>(entity =>
            {
                entity.ToTable("CostAccount");

                entity.HasIndex(e => e.Name, "UIdx_CostAccount_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(d => d.Name).IsRequired().HasMaxLength(95);
            });
            modelBuilder.Entity<CostAccountItem>(entity =>
            {
                entity.ToTable("CostAccountItem");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CostAccountNavigation)
                    .WithMany(p => p.CostAccountItems)
                    .HasForeignKey(d => d.CostAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CostAccountItem_CostAccount");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.EmployeeId, "UIdx_Employee_Code")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExportHistory>(entity =>
            {
                entity.ToTable("ExportHistory");
                entity.Property(e => e.Remark).HasMaxLength(300);
                entity.HasOne(e => e.CostAccountItemNavigation).WithMany(p => p.ExportHistories).HasForeignKey(d => d.CostAccountItem);
                entity.HasOne(e=>e.CostAccountNavigation)
                .WithMany(p => p.ExportHistories).HasForeignKey(d => d.CostAccount);
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExportDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Requestor).HasMaxLength(200);

                entity.HasOne(d => d.HandlerNavigation)
                    .WithMany(p => p.ExportHistories)
                    .HasForeignKey(d => d.Handler)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ExportHistory_Handler");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.ExportHistories)
                    .HasForeignKey(d => d.Material)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ExportHistory_Material");

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.ExportHistories)
                    .HasForeignKey(d => d.Receiver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ExportHistory_Receiver");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.ExportHistories)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_EmportHistory_Deparment");
            });

            modelBuilder.Entity<ImportHistory>(entity =>
            {
                entity.ToTable("ImportHistory");

                entity.Property(e => e.Buyer).HasMaxLength(100);
                entity.Property(e => e.Remark).HasMaxLength(500);
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImportDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Po)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PO");

                entity.Property(e => e.Supplier).HasMaxLength(200);

                entity.HasOne(d => d.HandlerNavigation)
                    .WithMany(p => p.ImportHistories)
                    .HasForeignKey(d => d.Handler)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ImportHistory_Handler");

                entity.HasOne(d => d.LineRequestNavigation)
                    .WithMany(p => p.ImportHistories)
                    .HasForeignKey(d => d.LineRequest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ImportHistory_LineRequest");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.ImportHistories)
                    .HasForeignKey(d => d.Material)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ImportHistory_Material");
            });

            modelBuilder.Entity<Inspection>(entity =>
            {
                entity.HasKey(e => e.ImportId)
                    .HasName("PK__Inspecti__869767EA51B9482C");

                entity.ToTable("Inspection");

                entity.Property(e => e.ImportId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Inspector).HasMaxLength(100);

                entity.Property(e => e.Result).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Import)
                    .WithOne(p => p.InspectionNavigation)
                    .HasForeignKey<Inspection>(d => d.ImportId)
                    .HasConstraintName("Fk_Inspection_ImportHistory");
            });

            modelBuilder.Entity<Line>(entity =>
            {
                entity.ToTable("Line");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.HasIndex(e => e.Qcode, "UIdx_Material_QCode")
                    .IsUnique();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Item).HasMaxLength(100);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Qcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("QCode");

                entity.Property(e => e.Specification).HasMaxLength(1500);

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.Unit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Material_Unit");

                entity.HasOne(d => d.ZoneNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.Zone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Material_Zone");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.ToTable("Zone");

                entity.HasIndex(e => e.Name, "UIdx_Zone_Name")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
