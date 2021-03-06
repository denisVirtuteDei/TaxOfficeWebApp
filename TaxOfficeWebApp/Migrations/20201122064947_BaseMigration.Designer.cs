﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxOfficeWebApp.Models;

namespace TaxOfficeWebApp.Migrations
{
    [DbContext(typeof(TaxOfficeContext))]
    [Migration("20201122064947_BaseMigration")]
    partial class BaseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaxOfficeWebApp.Models.BankChecks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("FinalSum")
                        .HasColumnType("money");

                    b.Property<int>("FkRegPerson")
                        .HasColumnName("FK_RegPerson")
                        .HasColumnType("int");

                    b.Property<bool>("IsDebtRepayment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PayedDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FkRegPerson");

                    b.ToTable("BankChecks");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Debts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DebtBillingDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DebtPayedDate")
                        .HasColumnType("date");

                    b.Property<decimal>("DebtSum")
                        .HasColumnType("money");

                    b.Property<int>("FkBankCheck")
                        .HasColumnName("FK_BankCheck")
                        .HasColumnType("int");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FkBankCheck");

                    b.ToTable("Debts");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Departures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartureAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.DeparturesExecutors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FkDeparture")
                        .HasColumnName("FK_Departure")
                        .HasColumnType("int");

                    b.Property<int>("FkExecutor")
                        .HasColumnName("FK_Executor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FkDeparture");

                    b.HasIndex("FkExecutor");

                    b.ToTable("DeparturesExecutors");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.EconomicActivityTypes", b =>
                {
                    b.Property<int>("Ncea")
                        .HasColumnName("NCEA")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Ncea")
                        .HasName("PK__Economic__D94007192703BA2E");

                    b.ToTable("EconomicActivityTypes");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("PersonalNumber")
                        .IsUnique()
                        .HasName("UQ__Employee__AC2CC42EABA8C620");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Entity", b =>
                {
                    b.Property<string>("Unp")
                        .HasColumnName("UNP")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("OrgAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ShortOrgTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Unp")
                        .HasName("PK__Entity__C5B17EBF54F75199");

                    b.ToTable("Entity");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Executors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FkEmployee")
                        .HasColumnName("FK_Employee")
                        .HasColumnType("int");

                    b.Property<int>("FkPosition")
                        .HasColumnName("FK_Position")
                        .HasColumnType("int");

                    b.Property<int>("FkUser")
                        .HasColumnName("FK_User")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastWorkDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("StartWorkDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("FkEmployee");

                    b.HasIndex("FkPosition");

                    b.HasIndex("FkUser");

                    b.ToTable("Executors");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.NaturalPersons", b =>
                {
                    b.Property<string>("Unp")
                        .HasColumnName("UNP")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PassportCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PersonalAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Unp")
                        .HasName("PK__NaturalP__C5B17EBF5377D29A");

                    b.ToTable("NaturalPersons");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.PayedTaxes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FkBankCheck")
                        .HasColumnName("FK_BankCheck")
                        .HasColumnType("int");

                    b.Property<int>("FkNcea")
                        .HasColumnName("FK_NCEA")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("FkBankCheck");

                    b.HasIndex("FkNcea");

                    b.ToTable("PayedTaxes");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.PersonRegistrations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Bankrupt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("FkEmployee")
                        .HasColumnName("FK_Employee")
                        .HasColumnType("int");

                    b.Property<int>("FkInitNcea")
                        .HasColumnName("FK_Init_NCEA")
                        .HasColumnType("int");

                    b.Property<int>("FkPerson")
                        .HasColumnName("FK_Person")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("FkEmployee");

                    b.HasIndex("FkInitNcea");

                    b.HasIndex("FkPerson");

                    b.ToTable("PersonRegistrations");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Persons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FkEntityPersonUnp")
                        .HasColumnName("FK_EntityPersonUNP")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("FkIndividualPersonUnp")
                        .HasColumnName("FK_IndividualPersonUNP")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("FkSelfEmployedPersonUnp")
                        .HasColumnName("FK_SelfEmployedPersonUNP")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<int>("FkUser")
                        .HasColumnName("FK_User")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FkEntityPersonUnp");

                    b.HasIndex("FkIndividualPersonUnp");

                    b.HasIndex("FkSelfEmployedPersonUnp");

                    b.HasIndex("FkUser")
                        .IsUnique()
                        .HasName("UQ__Persons__E7E87D0C7892CF49");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Positions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FkUnitStructure")
                        .IsRequired()
                        .HasColumnName("FK_Unit_structure")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("FkUnitStructure");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Priorities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PriorityTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.SelfEmployed", b =>
                {
                    b.Property<string>("Unp")
                        .HasColumnName("UNP")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("OrgAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ShortOrgTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Unp")
                        .HasName("PK__SelfEmpl__C5B17EBFD250C566");

                    b.ToTable("SelfEmployed");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.ToVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FkDeparture")
                        .HasColumnName("FK_Departure")
                        .HasColumnType("int");

                    b.Property<int>("FkPerson")
                        .HasColumnName("FK_Person")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FkDeparture");

                    b.HasIndex("FkPerson");

                    b.ToTable("ToVisit");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Units", b =>
                {
                    b.Property<string>("UnitTitle")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("UnitTitle")
                        .HasName("PK__Units__9499A7475F7E13D2");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FkPriority")
                        .HasColumnName("FK_Priority")
                        .HasColumnType("int");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("UserPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("FkPriority");

                    b.HasIndex("UserLogin")
                        .IsUnique()
                        .HasName("UQ__Users__7F8E8D5E2DC0F791");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.BankChecks", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.PersonRegistrations", "FkRegPersonNavigation")
                        .WithMany("BankChecks")
                        .HasForeignKey("FkRegPerson")
                        .HasConstraintName("FK_BankChecks_PersonRegistrations")
                        .IsRequired();
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Debts", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.BankChecks", "FkBankCheckNavigation")
                        .WithMany("Debts")
                        .HasForeignKey("FkBankCheck")
                        .HasConstraintName("FK_Debts_BankChecks")
                        .IsRequired();
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.DeparturesExecutors", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.Departures", "FkDepartureNavigation")
                        .WithMany("DeparturesExecutors")
                        .HasForeignKey("FkDeparture")
                        .HasConstraintName("FK_DeparturesExecutors_Departures")
                        .IsRequired();

                    b.HasOne("TaxOfficeWebApp.Models.Executors", "FkExecutorNavigation")
                        .WithMany("DeparturesExecutors")
                        .HasForeignKey("FkExecutor")
                        .HasConstraintName("FK_DeparturesExecutors_Executors")
                        .IsRequired();
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Executors", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.Employees", "FkEmployeeNavigation")
                        .WithMany("Executors")
                        .HasForeignKey("FkEmployee")
                        .HasConstraintName("FK_Executors_Employees")
                        .IsRequired();

                    b.HasOne("TaxOfficeWebApp.Models.Positions", "FkPositionNavigation")
                        .WithMany("Executors")
                        .HasForeignKey("FkPosition")
                        .HasConstraintName("FK_Executors_Positions")
                        .IsRequired();

                    b.HasOne("TaxOfficeWebApp.Models.Users", "FkUserNavigation")
                        .WithMany("Executors")
                        .HasForeignKey("FkUser")
                        .HasConstraintName("FK_Executors_Users")
                        .IsRequired();
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.PayedTaxes", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.BankChecks", "FkBankCheckNavigation")
                        .WithMany("PayedTaxes")
                        .HasForeignKey("FkBankCheck")
                        .HasConstraintName("FK_PayedTaxes_BankChecks")
                        .IsRequired();

                    b.HasOne("TaxOfficeWebApp.Models.EconomicActivityTypes", "FkNceaNavigation")
                        .WithMany("PayedTaxes")
                        .HasForeignKey("FkNcea")
                        .HasConstraintName("FK_PayedTaxes_EconomicActivityTypes")
                        .IsRequired();
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.PersonRegistrations", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.Executors", "FkEmployeeNavigation")
                        .WithMany("PersonRegistrations")
                        .HasForeignKey("FkEmployee")
                        .HasConstraintName("FK_PersonRegistrations_Executors")
                        .IsRequired();

                    b.HasOne("TaxOfficeWebApp.Models.EconomicActivityTypes", "FkInitNceaNavigation")
                        .WithMany("PersonRegistrations")
                        .HasForeignKey("FkInitNcea")
                        .HasConstraintName("FK_PersonRegistrations_EconomicActivityTypes")
                        .IsRequired();

                    b.HasOne("TaxOfficeWebApp.Models.Persons", "FkPersonNavigation")
                        .WithMany("PersonRegistrations")
                        .HasForeignKey("FkPerson")
                        .HasConstraintName("FK_PersonRegistrations_Persons")
                        .IsRequired();
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Persons", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.Entity", "FkEntityPersonUnpNavigation")
                        .WithMany("Persons")
                        .HasForeignKey("FkEntityPersonUnp")
                        .HasConstraintName("FK_Persons_Entity");

                    b.HasOne("TaxOfficeWebApp.Models.NaturalPersons", "FkIndividualPersonUnpNavigation")
                        .WithMany("Persons")
                        .HasForeignKey("FkIndividualPersonUnp")
                        .HasConstraintName("FK_Persons_NaturalPersons");

                    b.HasOne("TaxOfficeWebApp.Models.SelfEmployed", "FkSelfEmployedPersonUnpNavigation")
                        .WithMany("Persons")
                        .HasForeignKey("FkSelfEmployedPersonUnp")
                        .HasConstraintName("FK_Persons_SelfEmployed");

                    b.HasOne("TaxOfficeWebApp.Models.Users", "FkUserNavigation")
                        .WithOne("Persons")
                        .HasForeignKey("TaxOfficeWebApp.Models.Persons", "FkUser")
                        .HasConstraintName("FK_Persons_Users")
                        .IsRequired();
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Positions", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.Units", "FkUnitStructureNavigation")
                        .WithMany("Positions")
                        .HasForeignKey("FkUnitStructure")
                        .HasConstraintName("FK_Positions_Units")
                        .IsRequired();
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.ToVisit", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.Departures", "FkDepartureNavigation")
                        .WithMany("ToVisit")
                        .HasForeignKey("FkDeparture")
                        .HasConstraintName("FK_ToVisit_Departures")
                        .IsRequired();

                    b.HasOne("TaxOfficeWebApp.Models.Persons", "FkPersonNavigation")
                        .WithMany("ToVisit")
                        .HasForeignKey("FkPerson")
                        .HasConstraintName("FK_ToVisit_Persons")
                        .IsRequired();
                });

            modelBuilder.Entity("TaxOfficeWebApp.Models.Users", b =>
                {
                    b.HasOne("TaxOfficeWebApp.Models.Priorities", "FkPriorityNavigation")
                        .WithMany("Users")
                        .HasForeignKey("FkPriority")
                        .HasConstraintName("FK_User_Priorities")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
