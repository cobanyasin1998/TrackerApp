using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migEntityConf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEntities_OrganizationEntity_OrganizationEntityId",
                table: "UserEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEntities_UserEntities_UserEntityId",
                table: "UserEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupEntity_UserEntities_UserEntityId",
                table: "UserGroupEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntities",
                table: "UserEntities");

            migrationBuilder.RenameTable(
                name: "UserEntities",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UserEntities_UserEntityId",
                table: "Users",
                newName: "IX_Users_UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserEntities_OrganizationEntityId",
                table: "Users",
                newName: "IX_Users_OrganizationEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "Users",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupEntity_Users_UserEntityId",
                table: "UserGroupEntity",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_OrganizationEntity_OrganizationEntityId",
                table: "Users",
                column: "OrganizationEntityId",
                principalTable: "OrganizationEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserEntityId",
                table: "Users",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupEntity_Users_UserEntityId",
                table: "UserGroupEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_OrganizationEntity_OrganizationEntityId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserEntityId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntities");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserEntityId",
                table: "UserEntities",
                newName: "IX_UserEntities_UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OrganizationEntityId",
                table: "UserEntities",
                newName: "IX_UserEntities_OrganizationEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "UserEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldUnicode: false,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "UserEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntities",
                table: "UserEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntities_OrganizationEntity_OrganizationEntityId",
                table: "UserEntities",
                column: "OrganizationEntityId",
                principalTable: "OrganizationEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntities_UserEntities_UserEntityId",
                table: "UserEntities",
                column: "UserEntityId",
                principalTable: "UserEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupEntity_UserEntities_UserEntityId",
                table: "UserGroupEntity",
                column: "UserEntityId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
