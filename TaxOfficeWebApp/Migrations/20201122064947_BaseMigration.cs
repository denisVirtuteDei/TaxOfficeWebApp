using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxOfficeWebApp.Migrations
{
    public partial class BaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    DepartureAddress = table.Column<string>(maxLength: 50, nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EconomicActivityTypes",
                columns: table => new
                {
                    NCEA = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Economic__D94007192703BA2E", x => x.NCEA);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    PersonalNumber = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    UNP = table.Column<string>(maxLength: 9, nullable: false),
                    ShortOrgTitle = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    SecondName = table.Column<string>(maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 20, nullable: true),
                    PassportNumber = table.Column<string>(maxLength: 20, nullable: false),
                    OrgAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Entity__C5B17EBF54F75199", x => x.UNP);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersons",
                columns: table => new
                {
                    UNP = table.Column<string>(maxLength: 9, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    PassportCode = table.Column<string>(maxLength: 20, nullable: false),
                    PersonalNumber = table.Column<string>(maxLength: 20, nullable: false),
                    PersonalAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NaturalP__C5B17EBF5377D29A", x => x.UNP);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriorityTitle = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelfEmployed",
                columns: table => new
                {
                    UNP = table.Column<string>(maxLength: 9, nullable: false),
                    ShortOrgTitle = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    SecondName = table.Column<string>(maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 20, nullable: true),
                    PassportNumber = table.Column<string>(maxLength: 20, nullable: false),
                    OrgAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SelfEmpl__C5B17EBFD250C566", x => x.UNP);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitTitle = table.Column<string>(maxLength: 50, nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Units__9499A7475F7E13D2", x => x.UnitTitle);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLogin = table.Column<string>(maxLength: 50, nullable: false),
                    UserPassword = table.Column<byte[]>(maxLength: 256, nullable: false),
                    FK_Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Priorities",
                        column: x => x.FK_Priority,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    FK_Unit_structure = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Units",
                        column: x => x.FK_Unit_structure,
                        principalTable: "Units",
                        principalColumn: "UnitTitle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_IndividualPersonUNP = table.Column<string>(maxLength: 9, nullable: true),
                    FK_EntityPersonUNP = table.Column<string>(maxLength: 9, nullable: true),
                    FK_SelfEmployedPersonUNP = table.Column<string>(maxLength: 9, nullable: true),
                    FK_User = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Entity",
                        column: x => x.FK_EntityPersonUNP,
                        principalTable: "Entity",
                        principalColumn: "UNP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_NaturalPersons",
                        column: x => x.FK_IndividualPersonUNP,
                        principalTable: "NaturalPersons",
                        principalColumn: "UNP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_SelfEmployed",
                        column: x => x.FK_SelfEmployedPersonUNP,
                        principalTable: "SelfEmployed",
                        principalColumn: "UNP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Users",
                        column: x => x.FK_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Executors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_User = table.Column<int>(nullable: false),
                    FK_Employee = table.Column<int>(nullable: false),
                    FK_Position = table.Column<int>(nullable: false),
                    StartWorkDate = table.Column<DateTime>(type: "date", nullable: false),
                    LastWorkDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Executors_Employees",
                        column: x => x.FK_Employee,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Executors_Positions",
                        column: x => x.FK_Position,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Executors_Users",
                        column: x => x.FK_User,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToVisit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Departure = table.Column<int>(nullable: false),
                    FK_Person = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToVisit_Departures",
                        column: x => x.FK_Departure,
                        principalTable: "Departures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToVisit_Persons",
                        column: x => x.FK_Person,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeparturesExecutors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Executor = table.Column<int>(nullable: false),
                    FK_Departure = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeparturesExecutors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeparturesExecutors_Departures",
                        column: x => x.FK_Departure,
                        principalTable: "Departures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeparturesExecutors_Executors",
                        column: x => x.FK_Executor,
                        principalTable: "Executors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Employee = table.Column<int>(nullable: false),
                    FK_Person = table.Column<int>(nullable: false),
                    FK_Init_NCEA = table.Column<int>(nullable: false),
                    RegDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Bankrupt = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRegistrations_Executors",
                        column: x => x.FK_Employee,
                        principalTable: "Executors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonRegistrations_EconomicActivityTypes",
                        column: x => x.FK_Init_NCEA,
                        principalTable: "EconomicActivityTypes",
                        principalColumn: "NCEA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonRegistrations_Persons",
                        column: x => x.FK_Person,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankChecks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_RegPerson = table.Column<int>(nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    FinalSum = table.Column<decimal>(type: "money", nullable: false),
                    PayedDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsDebtRepayment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankChecks_PersonRegistrations",
                        column: x => x.FK_RegPerson,
                        principalTable: "PersonRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_BankCheck = table.Column<int>(nullable: false),
                    DebtSum = table.Column<decimal>(type: "money", nullable: false),
                    DebtPayedDate = table.Column<DateTime>(type: "date", nullable: true),
                    DebtBillingDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsPayed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debts_BankChecks",
                        column: x => x.FK_BankCheck,
                        principalTable: "BankChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayedTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_NCEA = table.Column<int>(nullable: false),
                    FK_BankCheck = table.Column<int>(nullable: false),
                    TaxAmount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayedTaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayedTaxes_BankChecks",
                        column: x => x.FK_BankCheck,
                        principalTable: "BankChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayedTaxes_EconomicActivityTypes",
                        column: x => x.FK_NCEA,
                        principalTable: "EconomicActivityTypes",
                        principalColumn: "NCEA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankChecks_FK_RegPerson",
                table: "BankChecks",
                column: "FK_RegPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_FK_BankCheck",
                table: "Debts",
                column: "FK_BankCheck");

            migrationBuilder.CreateIndex(
                name: "IX_DeparturesExecutors_FK_Departure",
                table: "DeparturesExecutors",
                column: "FK_Departure");

            migrationBuilder.CreateIndex(
                name: "IX_DeparturesExecutors_FK_Executor",
                table: "DeparturesExecutors",
                column: "FK_Executor");

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__AC2CC42EABA8C620",
                table: "Employees",
                column: "PersonalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Executors_FK_Employee",
                table: "Executors",
                column: "FK_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Executors_FK_Position",
                table: "Executors",
                column: "FK_Position");

            migrationBuilder.CreateIndex(
                name: "IX_Executors_FK_User",
                table: "Executors",
                column: "FK_User");

            migrationBuilder.CreateIndex(
                name: "IX_PayedTaxes_FK_BankCheck",
                table: "PayedTaxes",
                column: "FK_BankCheck");

            migrationBuilder.CreateIndex(
                name: "IX_PayedTaxes_FK_NCEA",
                table: "PayedTaxes",
                column: "FK_NCEA");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistrations_FK_Employee",
                table: "PersonRegistrations",
                column: "FK_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistrations_FK_Init_NCEA",
                table: "PersonRegistrations",
                column: "FK_Init_NCEA");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistrations_FK_Person",
                table: "PersonRegistrations",
                column: "FK_Person");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FK_EntityPersonUNP",
                table: "Persons",
                column: "FK_EntityPersonUNP");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FK_IndividualPersonUNP",
                table: "Persons",
                column: "FK_IndividualPersonUNP");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FK_SelfEmployedPersonUNP",
                table: "Persons",
                column: "FK_SelfEmployedPersonUNP");

            migrationBuilder.CreateIndex(
                name: "UQ__Persons__E7E87D0C7892CF49",
                table: "Persons",
                column: "FK_User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_FK_Unit_structure",
                table: "Positions",
                column: "FK_Unit_structure");

            migrationBuilder.CreateIndex(
                name: "IX_ToVisit_FK_Departure",
                table: "ToVisit",
                column: "FK_Departure");

            migrationBuilder.CreateIndex(
                name: "IX_ToVisit_FK_Person",
                table: "ToVisit",
                column: "FK_Person");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FK_Priority",
                table: "Users",
                column: "FK_Priority");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__7F8E8D5E2DC0F791",
                table: "Users",
                column: "UserLogin",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "DeparturesExecutors");

            migrationBuilder.DropTable(
                name: "PayedTaxes");

            migrationBuilder.DropTable(
                name: "ToVisit");

            migrationBuilder.DropTable(
                name: "BankChecks");

            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "PersonRegistrations");

            migrationBuilder.DropTable(
                name: "Executors");

            migrationBuilder.DropTable(
                name: "EconomicActivityTypes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropTable(
                name: "NaturalPersons");

            migrationBuilder.DropTable(
                name: "SelfEmployed");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Priorities");
        }
    }
}
