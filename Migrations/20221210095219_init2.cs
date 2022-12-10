using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstASP.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "2bdf605c-a8a5-4a15-a591-462d7af75839");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c46bbbae-3c45-438e-9ee9-594306aeb8f0",
                column: "ConcurrencyStamp",
                value: "f5ce19f4-fd0e-40b6-91b8-6fd95659eaf5");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c46bbbae-3c45-438e-9ee9-594306aeb8f0", "eac74484-b5ab-4acc-a36c-17a27cf418c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "49171ef7-ea2a-4f6a-bfbe-8da9496ba956", "AQAAAAEAACcQAAAAEMQ9B9XT6+vz+LIJIEINCngRFxuglVxos51FNl9WeUmHaL47XnThwuVvruVSqNk7EQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eac74484-b5ab-4acc-a36c-17a27cf417c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f2adad32-75ae-4715-898c-82a827a75526", "AQAAAAEAACcQAAAAECwaAuCtXNIb7JEbPCn8uf3MT0LXzQ+mli3Mh/Ar3d8uy+L+DMqkac/MoRN6G7hDVQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eac74484-b5ab-4acc-a36c-17a27cf418c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "58db4249-5f67-41af-9358-07f8dac05050", "AQAAAAEAACcQAAAAEKtt2PovGe0IrFFbUyDX16w+sNW1MctwDB2rh15v/UjznoWN/PcgHbaFNPpeXMsH9g==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 10, 9, 52, 19, 500, DateTimeKind.Utc).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 10, 9, 52, 19, 500, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 10, 9, 52, 19, 500, DateTimeKind.Utc).AddTicks(9430));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c46bbbae-3c45-438e-9ee9-594306aeb8f0", "eac74484-b5ab-4acc-a36c-17a27cf418c8" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "b4839e98-acf7-4d06-b7d2-1755ecdcb8b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c46bbbae-3c45-438e-9ee9-594306aeb8f0",
                column: "ConcurrencyStamp",
                value: "389f5ceb-2a9b-4399-9ace-0cd80efb8741");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0e9ba8b5-eba5-4137-a4e9-06350ce16e2f", "AQAAAAEAACcQAAAAEHnGojce0MJb4dSC0BEKGnCifl+JWw4KTJu27vhQpSRlAaqkz9HphCiP9QyhkF/CGg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eac74484-b5ab-4acc-a36c-17a27cf417c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6011a9a7-018c-4e23-97e4-503d5fb4c0ec", "AQAAAAEAACcQAAAAEFFe0xIK9GSv1MdpcXXnIDLtkfUdtVs1aeP/n0v58IiazO2fJ6d4BI+ogDS6DbLgqA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eac74484-b5ab-4acc-a36c-17a27cf418c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ef79102-bbfe-4aae-a5b0-002e6cf76e3f", "AQAAAAEAACcQAAAAEKnJz07bLnnGCnAfoijQ+bnGSfcPlEk2jgYBH5XL6GVbx/JbY5++lpQX0/+tRuOWUA==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 10, 9, 49, 7, 139, DateTimeKind.Utc).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 10, 9, 49, 7, 139, DateTimeKind.Utc).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2022, 12, 10, 9, 49, 7, 139, DateTimeKind.Utc).AddTicks(1055));
        }
    }
}
