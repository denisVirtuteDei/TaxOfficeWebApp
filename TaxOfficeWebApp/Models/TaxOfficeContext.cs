using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaxOfficeWebApp.Models
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

        public virtual DbSet<BankChecks> BankChecks { get; set; }
        public virtual DbSet<Debts> Debts { get; set; }
        public virtual DbSet<Departures> Departures { get; set; }
        public virtual DbSet<DeparturesExecutors> DeparturesExecutors { get; set; }
        public virtual DbSet<EconomicActivityTypes> EconomicActivityTypes { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<Executors> Executors { get; set; }
        public virtual DbSet<NaturalPersons> NaturalPersons { get; set; }
        public virtual DbSet<PayedTaxes> PayedTaxes { get; set; }
        public virtual DbSet<PersonRegistrations> PersonRegistrations { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Priorities> Priorities { get; set; }
        public virtual DbSet<SelfEmployed> SelfEmployed { get; set; }
        public virtual DbSet<ToVisit> ToVisit { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VRandom> VRandom { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=TaxOffice; Trusted_Connection=True; User ID=NETWORK SERVICE;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankChecks>(entity =>
            {
                entity.Property(e => e.FinalSum).HasColumnType("money");

                entity.Property(e => e.FkRegPerson).HasColumnName("FK_RegPerson");

                entity.Property(e => e.PayedDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.FkRegPersonNavigation)
                    .WithMany(p => p.BankChecks)
                    .HasForeignKey(d => d.FkRegPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankChecks_PersonRegistrations");
            });

            modelBuilder.Entity<Debts>(entity =>
            {
                entity.Property(e => e.DebtBillingDate).HasColumnType("date");

                entity.Property(e => e.DebtPayedDate).HasColumnType("date");

                entity.Property(e => e.DebtSum).HasColumnType("money");

                entity.Property(e => e.FkBankCheck).HasColumnName("FK_BankCheck");

                entity.HasOne(d => d.FkBankCheckNavigation)
                    .WithMany(p => p.Debts)
                    .HasForeignKey(d => d.FkBankCheck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Debts_BankChecks");
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
                    .HasName("PK__Economic__D94007192703BA2E");

                entity.Property(e => e.Ncea)
                    .HasColumnName("NCEA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasIndex(e => e.PersonalNumber)
                    .HasName("UQ__Employee__AC2CC42EABA8C620")
                    .IsUnique();

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.HasKey(e => e.Unp)
                    .HasName("PK__Entity__C5B17EBF54F75199");

                entity.Property(e => e.Unp)
                    .HasColumnName("UNP")
                    .HasMaxLength(9);

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
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Executors>(entity =>
            {
                entity.Property(e => e.FkEmployee).HasColumnName("FK_Employee");

                entity.Property(e => e.FkPosition).HasColumnName("FK_Position");

                entity.Property(e => e.FkUser).HasColumnName("FK_User");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Executors_Positions");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.Executors)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Executors_Users");
            });

            modelBuilder.Entity<NaturalPersons>(entity =>
            {
                entity.HasKey(e => e.Unp)
                    .HasName("PK__NaturalP__C5B17EBF5377D29A");

                entity.Property(e => e.Unp)
                    .HasColumnName("UNP")
                    .HasMaxLength(9);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.PassportCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PersonalAddress)
                    .IsRequired()
                    .HasMaxLength(50);

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

            modelBuilder.Entity<PayedTaxes>(entity =>
            {
                entity.Property(e => e.FkBankCheck).HasColumnName("FK_BankCheck");

                entity.Property(e => e.FkNcea).HasColumnName("FK_NCEA");

                entity.Property(e => e.TaxAmount).HasColumnType("money");

                entity.HasOne(d => d.FkBankCheckNavigation)
                    .WithMany(p => p.PayedTaxes)
                    .HasForeignKey(d => d.FkBankCheck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayedTaxes_BankChecks");

                entity.HasOne(d => d.FkNceaNavigation)
                    .WithMany(p => p.PayedTaxes)
                    .HasForeignKey(d => d.FkNcea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayedTaxes_EconomicActivityTypes");
            });

            modelBuilder.Entity<PersonRegistrations>(entity =>
            {
                entity.Property(e => e.Bankrupt).HasDefaultValueSql("((0))");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FkEmployee).HasColumnName("FK_Employee");

                entity.Property(e => e.FkInitNcea).HasColumnName("FK_Init_NCEA");

                entity.Property(e => e.FkPerson).HasColumnName("FK_Person");

                entity.Property(e => e.RegDate).HasColumnType("date");

                entity.HasOne(d => d.FkEmployeeNavigation)
                    .WithMany(p => p.PersonRegistrations)
                    .HasForeignKey(d => d.FkEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonRegistrations_Executors");

                entity.HasOne(d => d.FkInitNceaNavigation)
                    .WithMany(p => p.PersonRegistrations)
                    .HasForeignKey(d => d.FkInitNcea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonRegistrations_EconomicActivityTypes");

                entity.HasOne(d => d.FkPersonNavigation)
                    .WithMany(p => p.PersonRegistrations)
                    .HasForeignKey(d => d.FkPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonRegistrations_Persons");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasIndex(e => e.FkUser)
                    .HasName("UQ__Persons__E7E87D0C7892CF49")
                    .IsUnique();

                entity.Property(e => e.FkEntityPersonUnp)
                    .HasColumnName("FK_EntityPersonUNP")
                    .HasMaxLength(9);

                entity.Property(e => e.FkIndividualPersonUnp)
                    .HasColumnName("FK_IndividualPersonUNP")
                    .HasMaxLength(9);

                entity.Property(e => e.FkSelfEmployedPersonUnp)
                    .HasColumnName("FK_SelfEmployedPersonUNP")
                    .HasMaxLength(9);

                entity.Property(e => e.FkUser).HasColumnName("FK_User");

                entity.HasOne(d => d.FkEntityPersonUnpNavigation)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.FkEntityPersonUnp)
                    .HasConstraintName("FK_Persons_Entity");

                entity.HasOne(d => d.FkIndividualPersonUnpNavigation)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.FkIndividualPersonUnp)
                    .HasConstraintName("FK_Persons_NaturalPersons");

                entity.HasOne(d => d.FkSelfEmployedPersonUnpNavigation)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.FkSelfEmployedPersonUnp)
                    .HasConstraintName("FK_Persons_SelfEmployed");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithOne(p => p.Persons)
                    .HasForeignKey<Persons>(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persons_Users");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.FkUnitStructure)
                    .IsRequired()
                    .HasColumnName("FK_Unit_structure")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

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

            modelBuilder.Entity<SelfEmployed>(entity =>
            {
                entity.HasKey(e => e.Unp)
                    .HasName("PK__SelfEmpl__C5B17EBFD250C566");

                entity.Property(e => e.Unp)
                    .HasColumnName("UNP")
                    .HasMaxLength(9);

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
                    .HasMaxLength(50);

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
                    .HasName("PK__Units__9499A7475F7E13D2");

                entity.Property(e => e.UnitTitle).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.UserLogin)
                    .HasName("UQ__Users__7F8E8D5E2DC0F791")
                    .IsUnique();

                entity.Property(e => e.FkPriority).HasColumnName("FK_Priority");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.FkPriorityNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkPriority)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Priorities");
            });

            modelBuilder.Entity<VRandom>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vRandom");

                entity.Property(e => e.Randval)
                    .HasColumnName("randval")
                    .HasMaxLength(8000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
