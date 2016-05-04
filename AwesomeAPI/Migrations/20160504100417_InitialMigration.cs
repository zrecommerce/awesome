using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace AwesomeAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACLResource",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACLResource", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "MessageType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageType", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "UserStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatus", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "ACLRole",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ACLResourceID = table.Column<int>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACLRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACLRole_ACLResource_ACLResourceID",
                        column: x => x.ACLResourceID,
                        principalTable: "ACLResource",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "ACLPermission",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ACLResourceID = table.Column<int>(nullable: true),
                    ACLRoleID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACLPermission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACLPermission_ACLResource_ACLResourceID",
                        column: x => x.ACLResourceID,
                        principalTable: "ACLResource",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACLPermission_ACLRole_ACLRoleID",
                        column: x => x.ACLRoleID,
                        principalTable: "ACLRole",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    OwnerID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Visibility = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChannelID = table.Column<int>(nullable: true),
                    ChannelID1 = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Handle = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: true),
                    StatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IdentityUser_Channel_ChannelID",
                        column: x => x.ChannelID,
                        principalTable: "Channel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentityUser_Channel_ChannelID1",
                        column: x => x.ChannelID1,
                        principalTable: "Channel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentityUser_ACLRole_RoleID",
                        column: x => x.RoleID,
                        principalTable: "ACLRole",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentityUser_UserStatus_StatusID",
                        column: x => x.StatusID,
                        principalTable: "UserStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(nullable: true),
                    IdentityUserID = table.Column<int>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    TypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Message_IdentityUser_IdentityUserID",
                        column: x => x.IdentityUserID,
                        principalTable: "IdentityUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_MessageType_TypeID",
                        column: x => x.TypeID,
                        principalTable: "MessageType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_Channel_IdentityUser_OwnerID",
                table: "Channel",
                column: "OwnerID",
                principalTable: "IdentityUser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ACLRole_ACLResource_ACLResourceID", table: "ACLRole");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUser_ACLRole_RoleID", table: "IdentityUser");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUser_Channel_ChannelID", table: "IdentityUser");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUser_Channel_ChannelID1", table: "IdentityUser");
            migrationBuilder.DropTable("ACLPermission");
            migrationBuilder.DropTable("Message");
            migrationBuilder.DropTable("MessageType");
            migrationBuilder.DropTable("ACLResource");
            migrationBuilder.DropTable("ACLRole");
            migrationBuilder.DropTable("Channel");
            migrationBuilder.DropTable("IdentityUser");
            migrationBuilder.DropTable("UserStatus");
        }
    }
}
