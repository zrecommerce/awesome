using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AwesomeCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACLResources",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACLResources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACLRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ACLResourceID = table.Column<int>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACLRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACLRoles_ACLResources_ACLResourceID",
                        column: x => x.ACLResourceID,
                        principalTable: "ACLResources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACLPermissions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ACLResourceID = table.Column<int>(nullable: true),
                    ACLRoleID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACLPermissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACLPermissions_ACLResources_ACLResourceID",
                        column: x => x.ACLResourceID,
                        principalTable: "ACLResources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACLPermissions_ACLRoles_ACLRoleID",
                        column: x => x.ACLRoleID,
                        principalTable: "ACLRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
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
                    table.PrimaryKey("PK_IdentityUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IdentityUsers_ACLRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "ACLRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentityUsers_UserStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "UserStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    OwnerID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Visibility = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Channels_IdentityUsers_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "IdentityUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Content = table.Column<string>(nullable: true),
                    IdentityUserID = table.Column<int>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    TypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_IdentityUsers_IdentityUserID",
                        column: x => x.IdentityUserID,
                        principalTable: "IdentityUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_MessageTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "MessageTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACLPermissions_ACLResourceID",
                table: "ACLPermissions",
                column: "ACLResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_ACLPermissions_ACLRoleID",
                table: "ACLPermissions",
                column: "ACLRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ACLRoles_ACLResourceID",
                table: "ACLRoles",
                column: "ACLResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_OwnerID",
                table: "Channels",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsers_ChannelID",
                table: "IdentityUsers",
                column: "ChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsers_ChannelID1",
                table: "IdentityUsers",
                column: "ChannelID1");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsers_RoleID",
                table: "IdentityUsers",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUsers_StatusID",
                table: "IdentityUsers",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_IdentityUserID",
                table: "Messages",
                column: "IdentityUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TypeID",
                table: "Messages",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsers_Channels_ChannelID",
                table: "IdentityUsers",
                column: "ChannelID",
                principalTable: "Channels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUsers_Channels_ChannelID1",
                table: "IdentityUsers",
                column: "ChannelID1",
                principalTable: "Channels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACLRoles_ACLResources_ACLResourceID",
                table: "ACLRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUsers_ACLRoles_RoleID",
                table: "IdentityUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Channels_IdentityUsers_OwnerID",
                table: "Channels");

            migrationBuilder.DropTable(
                name: "ACLPermissions");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MessageTypes");

            migrationBuilder.DropTable(
                name: "ACLResources");

            migrationBuilder.DropTable(
                name: "ACLRoles");

            migrationBuilder.DropTable(
                name: "IdentityUsers");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "UserStatuses");
        }
    }
}
