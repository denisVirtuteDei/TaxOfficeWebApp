using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaxOfficeWebApp
{
    public partial class TaxOfficeContext : DbContext
    {
        public TaxOfficeContext()
        {
        }

        public TaxOfficeContext(DbContextOptions<TaxOfficeContext> options)
            : base(options)
        {
        }

        #region DbSet

        public virtual DbSet<Declarations> Declarations { get; set; }
        public virtual DbSet<Departures> Departures { get; set; }
        public virtual DbSet<DeparturesExecutors> DeparturesExecutors { get; set; }
        public virtual DbSet<EconomicActivityTypes> EconomicActivityTypes { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<Executors> Executors { get; set; }
        public virtual DbSet<NaturalPersons> NaturalPersons { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Priorities> Priorities { get; set; }
        public virtual DbSet<Registrations> Registrations { get; set; }
        public virtual DbSet<SelfEmployed> SelfEmployed { get; set; }
        public virtual DbSet<ToVisit> ToVisit { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GJEGN1G;Database=TaxOffice;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Declarations>(entity =>
            {
                entity.Property(e => e.FillingDate).HasColumnType("date");

                entity.Property(e => e.FkPerson).HasColumnName("FK_Person");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkPersonNavigation)
                    .WithMany(p => p.Declarations)
                    .HasForeignKey(d => d.FkPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Declarations_Persons");
            });

            modelBuilder.Entity<Departures>(entity =>
            {
                entity.Property(e => e.DepartureAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DeparturesExecutors>(entity =>
            {
                entity.Property(e => e.FkDeparture).HasColumnName("FK_Departure");

                entity.Property(e => e.FkExecutor).HasColumnName("FK_Executor");

                entity.HasOne(d => d.FkDepartureNavigation)
                    .WithMany(p => p.DeparturesExecutors)
                    .HasForeignKey(d => d.FkDeparture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeparturesExecutors_Departures");

                entity.HasOne(d => d.FkExecutorNavigation)
                    .WithMany(p => p.DeparturesExecutors)
                    .HasForeignKey(d => d.FkExecutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeparturesExecutors_Executors");
            });

            modelBuilder.Entity<EconomicActivityTypes>(entity =>
            {
                entity.HasKey(e => e.Ncea)
                    .HasName("PK__Economic__D9400719A97B7E8D");

                entity.Property(e => e.Ncea)
                    .HasColumnName("NCEA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.HasKey(e => e.Unp)
                    .HasName("PK__Entity__C5B17EBFCA21ED06");

                entity.Property(e => e.Unp)
                    .HasColumnName("UNP")
                    .HasMaxLength(10);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MiddleName).HasMaxLength(20);

                entity.Property(e => e.OrgAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ShortOrgTitle)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Executors>(entity =>
            {
                entity.Property(e => e.FkEmployee).HasColumnName("FK_Employee");

                entity.Property(e => e.FkPosition).HasColumnName("FK_Position");

                entity.Property(e => e.LastWorkDate).HasColumnType("date");

                entity.Property(e => e.StartWorkDate).HasColumnType("date");

                entity.HasOne(d => d.FkEmployeeNavigation)
                    .WithMany(p => p.Executors)
                    .HasForeignKey(d => d.FkEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Executors_Employees");

                entity.HasOne(d => d.FkPositionNavigation)
                    .WithMany(p => p.Executors)
                    .HasForeignKey(d => d.FkPosition)
                    .HasConstraintName("FK_Executors_Positions");
            });

            modelBuilder.Entity<NaturalPersons>(entity =>
            {
                entity.HasKey(e => e.Unp)
                    .HasName("PK__NaturalP__C5B17EBF085A3C7C");

                entity.Property(e => e.Unp)
                    .HasColumnName("UNP")
                    .HasMaxLength(10);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.PassportCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PersonalNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.FkPriorities).HasColumnName("FK_Priorities");

                entity.Property(e => e.FkUnp)
                    .IsRequired()
                    .HasColumnName("FK_UNP")
                    .HasMaxLength(10);

                entity.HasOne(d => d.FkPrioritiesNavigation)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.FkPriorities)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persons_Priorities");

                entity.HasOne(d => d.FkUnpNavigation)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.FkUnp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persons_Entity");

                entity.HasOne(d => d.FkUnp1)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.FkUnp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persons_NaturalPersons");

                entity.HasOne(d => d.FkUnp2)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.FkUnp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persons_SelfEmployed");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.FkPriority).HasColumnName("FK_Priority");

                entity.Property(e => e.FkUnitStructure)
                    .IsRequired()
                    .HasColumnName("FK_Unit_structure")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkPriorityNavigation)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.FkPriority)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Positions_Priorities");

                entity.HasOne(d => d.FkUnitStructureNavigation)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.FkUnitStructure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Positions_Units");
            });

            modelBuilder.Entity<Priorities>(entity =>
            {
                entity.Property(e => e.PriorityTitle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Registrations>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FkEmployee).HasColumnName("FK_Employee");

                entity.Property(e => e.FkNcea).HasColumnName("FK_NCEA");

                entity.Property(e => e.FkPerson).HasColumnName("FK_Person");

                entity.Property(e => e.RegDate).HasColumnType("date");

                entity.HasOne(d => d.FkEmployeeNavigation)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.FkEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registrations_Executors");

                entity.HasOne(d => d.FkNceaNavigation)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.FkNcea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registrations_EconomicActivityTypes");

                entity.HasOne(d => d.FkPersonNavigation)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.FkPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registrations_Persons");
            });

            modelBuilder.Entity<SelfEmployed>(entity =>
            {
                entity.HasKey(e => e.Unp)
                    .HasName("PK__SelfEmpl__C5B17EBF5B3C5177");

                entity.Property(e => e.Unp)
                    .HasColumnName("UNP")
                    .HasMaxLength(10);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MiddleName).HasMaxLength(20);

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ShortOrgTitle)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ToVisit>(entity =>
            {
                entity.Property(e => e.FkDeparture).HasColumnName("FK_Departure");

                entity.Property(e => e.FkPerson).HasColumnName("FK_Person");

                entity.HasOne(d => d.FkDepartureNavigation)
                    .WithMany(p => p.ToVisit)
                    .HasForeignKey(d => d.FkDeparture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToVisit_Departures");

                entity.HasOne(d => d.FkPersonNavigation)
                    .WithMany(p => p.ToVisit)
                    .HasForeignKey(d => d.FkPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToVisit_Persons");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.UnitTitle)
                    .HasName("PK__Units__9499A7473B3805FA");

                entity.Property(e => e.UnitTitle).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.UserLogin)
                    .HasName("UQ__Users__7F8E8D5E31E0E0C0")
                    .IsUnique();

                entity.Property(e => e.FkPriority).HasColumnName("FK_Priority");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkPriorityNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkPriority)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopSecrets_Priorities");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
