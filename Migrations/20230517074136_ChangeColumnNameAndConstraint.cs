using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameAndConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountRoles",
                table: "AccountRoles");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "tb_m_universities");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "tb_m_rooms");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tb_m_roles");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "tb_m_employees");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "tb_m_educations");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "tb_tr_bookings");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "tb_m_accounts");

            migrationBuilder.RenameTable(
                name: "AccountRoles",
                newName: "tb_m_account_roles");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_universities",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_universities",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_universities",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_rooms",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_rooms",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_rooms",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_roles",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_roles",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_roles",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_employees",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_employees",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_employees",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_educations",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_educations",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_educations",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_tr_bookings",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_tr_bookings",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_tr_bookings",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_accounts",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_accounts",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_accounts",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_account_roles",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_account_roles",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_account_roles",
                newName: "created_date");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "tb_m_universities",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "tb_m_universities",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "capacity",
                table: "tb_m_rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "floor",
                table: "tb_m_rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "tb_m_rooms",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "tb_m_roles",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "birth_date",
                table: "tb_m_employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "tb_m_employees",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "tb_m_employees",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "tb_m_employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "hiring_date",
                table: "tb_m_employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "tb_m_employees",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nik",
                table: "tb_m_employees",
                type: "nchar(6)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "tb_m_employees",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "degree",
                table: "tb_m_educations",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "gpa",
                table: "tb_m_educations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "major",
                table: "tb_m_educations",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "university_guid",
                table: "tb_m_educations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "employee_guid",
                table: "tb_tr_bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "end_date",
                table: "tb_tr_bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "remarks",
                table: "tb_tr_bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "room_guid",
                table: "tb_tr_bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "start_date",
                table: "tb_tr_bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tb_tr_bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "tb_m_accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_used",
                table: "tb_m_accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "otp",
                table: "tb_m_accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "tb_m_accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "account_guid",
                table: "tb_m_account_roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "role_guid",
                table: "tb_m_account_roles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_universities",
                table: "tb_m_universities",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_rooms",
                table: "tb_m_rooms",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_employees",
                table: "tb_m_employees",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_educations",
                table: "tb_m_educations",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_bookings",
                table: "tb_tr_bookings",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_account_roles",
                table: "tb_m_account_roles",
                column: "guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_bookings",
                table: "tb_tr_bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_universities",
                table: "tb_m_universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_rooms",
                table: "tb_m_rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_employees",
                table: "tb_m_employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_educations",
                table: "tb_m_educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_account_roles",
                table: "tb_m_account_roles");

            migrationBuilder.DropColumn(
                name: "employee_guid",
                table: "tb_tr_bookings");

            migrationBuilder.DropColumn(
                name: "end_date",
                table: "tb_tr_bookings");

            migrationBuilder.DropColumn(
                name: "remarks",
                table: "tb_tr_bookings");

            migrationBuilder.DropColumn(
                name: "room_guid",
                table: "tb_tr_bookings");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "tb_tr_bookings");

            migrationBuilder.DropColumn(
                name: "status",
                table: "tb_tr_bookings");

            migrationBuilder.DropColumn(
                name: "code",
                table: "tb_m_universities");

            migrationBuilder.DropColumn(
                name: "name",
                table: "tb_m_universities");

            migrationBuilder.DropColumn(
                name: "capacity",
                table: "tb_m_rooms");

            migrationBuilder.DropColumn(
                name: "floor",
                table: "tb_m_rooms");

            migrationBuilder.DropColumn(
                name: "name",
                table: "tb_m_rooms");

            migrationBuilder.DropColumn(
                name: "name",
                table: "tb_m_roles");

            migrationBuilder.DropColumn(
                name: "birth_date",
                table: "tb_m_employees");

            migrationBuilder.DropColumn(
                name: "email",
                table: "tb_m_employees");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "tb_m_employees");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "tb_m_employees");

            migrationBuilder.DropColumn(
                name: "hiring_date",
                table: "tb_m_employees");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "tb_m_employees");

            migrationBuilder.DropColumn(
                name: "nik",
                table: "tb_m_employees");

            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "tb_m_employees");

            migrationBuilder.DropColumn(
                name: "degree",
                table: "tb_m_educations");

            migrationBuilder.DropColumn(
                name: "gpa",
                table: "tb_m_educations");

            migrationBuilder.DropColumn(
                name: "major",
                table: "tb_m_educations");

            migrationBuilder.DropColumn(
                name: "university_guid",
                table: "tb_m_educations");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "tb_m_accounts");

            migrationBuilder.DropColumn(
                name: "is_used",
                table: "tb_m_accounts");

            migrationBuilder.DropColumn(
                name: "otp",
                table: "tb_m_accounts");

            migrationBuilder.DropColumn(
                name: "password",
                table: "tb_m_accounts");

            migrationBuilder.DropColumn(
                name: "account_guid",
                table: "tb_m_account_roles");

            migrationBuilder.DropColumn(
                name: "role_guid",
                table: "tb_m_account_roles");

            migrationBuilder.RenameTable(
                name: "tb_tr_bookings",
                newName: "Bookings");

            migrationBuilder.RenameTable(
                name: "tb_m_universities",
                newName: "Universities");

            migrationBuilder.RenameTable(
                name: "tb_m_rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "tb_m_roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "tb_m_employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "tb_m_educations",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "tb_m_accounts",
                newName: "Accounts");

            migrationBuilder.RenameTable(
                name: "tb_m_account_roles",
                newName: "AccountRoles");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Bookings",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Bookings",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Bookings",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Universities",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Universities",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Universities",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Rooms",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Rooms",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Rooms",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Roles",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Roles",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Roles",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Employees",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Employees",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Employees",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Educations",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Educations",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Educations",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Accounts",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Accounts",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Accounts",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "AccountRoles",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "AccountRoles",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "AccountRoles",
                newName: "CreatedDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountRoles",
                table: "AccountRoles",
                column: "Guid");
        }
    }
}
