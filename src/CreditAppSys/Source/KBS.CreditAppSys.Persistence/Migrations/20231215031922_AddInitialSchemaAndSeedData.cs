using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KBS.CreditAppSys.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialSchemaAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Credit");

            migrationBuilder.CreateTable(
                name: "ApplicationResult",
                schema: "Credit",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationResult", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Credit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityStatusType = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    IdentityNumber = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "EntityStatus",
                schema: "Credit",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityStatus", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "CreditApplication",
                schema: "Credit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityStatusType = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationResultType = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    Amount = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    LoanTerm = table.Column<byte>(type: "tinyint", nullable: false),
                    InterestRate = table.Column<decimal>(type: "DECIMAL(4,2)", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditApplication", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CreditApplication_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Credit",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCriteria",
                schema: "Credit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityStatusType = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditScore = table.Column<short>(type: "smallint", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    MonthlyDebt = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    AdverseCreditHistory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCriteria", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CustomerCriteria_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Credit",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Credit",
                table: "ApplicationResult",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "RequestReceived" },
                    { (byte)10, "Accepted" },
                    { (byte)20, "Denied" },
                    { (byte)30, "ReviewNeeded" }
                });

            migrationBuilder.InsertData(
                schema: "Credit",
                table: "Customer",
                columns: new[] { "Id", "CreatedById", "DeletedAt", "DeletedById", "Email", "EntityStatusType", "IdentityNumber", "Name", "Surname", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("42614cfd-7d0f-471b-9718-c0287776dde4"), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "ufuk.elibol@test.email.com", (byte)1, "12345678901", "Ufuk", "Elibol", null, null },
                    { new Guid("799e8936-31e4-48db-a751-b378a083ea55"), new Guid("00000000-0000-0000-0000-000000000000"), null, null, "yasemin.elibol@test.email.com", (byte)1, "98765432109", "Yaseminnur", "Elibol", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Credit",
                table: "EntityStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Active" },
                    { (byte)2, "Passive" },
                    { (byte)3, "Deleted" }
                });

            migrationBuilder.InsertData(
                schema: "Credit",
                table: "CreditApplication",
                columns: new[] { "Id", "Amount", "ApplicationDate", "ApplicationResultType", "CreatedById", "CustomerId", "DeletedAt", "DeletedById", "EntityStatusType", "InterestRate", "LoanTerm", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("826df2db-7db8-4b3c-8a7b-7e0b90e5a0e6"), 500000m, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("42614cfd-7d0f-471b-9718-c0287776dde4"), null, null, (byte)1, 1.9m, (byte)48, null, null },
                    { new Guid("8b93a4f0-8e4c-4c0e-99c8-549b953a1c23"), 100000m, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)2, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("799e8936-31e4-48db-a751-b378a083ea55"), null, null, (byte)1, 1.9m, (byte)60, null, null }
                });

            migrationBuilder.InsertData(
                schema: "Credit",
                table: "CustomerCriteria",
                columns: new[] { "Id", "AdverseCreditHistory", "CreatedById", "CreditScore", "CustomerId", "DeletedAt", "DeletedById", "EntityStatusType", "MonthlyDebt", "MonthlyIncome", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("035c056c-a62e-4d9c-9771-3abc43962608"), false, new Guid("00000000-0000-0000-0000-000000000000"), (short)900, new Guid("799e8936-31e4-48db-a751-b378a083ea55"), null, null, (byte)1, 15000m, 40000m, null, null },
                    { new Guid("45ba2cf1-6824-43b9-93bd-0b2a5ef30565"), false, new Guid("00000000-0000-0000-0000-000000000000"), (short)900, new Guid("42614cfd-7d0f-471b-9718-c0287776dde4"), null, null, (byte)1, 10000m, 50000m, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplication_CustomerId",
                schema: "Credit",
                table: "CreditApplication",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCriteria_CustomerId",
                schema: "Credit",
                table: "CustomerCriteria",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationResult",
                schema: "Credit");

            migrationBuilder.DropTable(
                name: "CreditApplication",
                schema: "Credit");

            migrationBuilder.DropTable(
                name: "CustomerCriteria",
                schema: "Credit");

            migrationBuilder.DropTable(
                name: "EntityStatus",
                schema: "Credit");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Credit");
        }
    }
}
