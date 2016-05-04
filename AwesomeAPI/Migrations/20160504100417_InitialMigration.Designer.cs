using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using AwesomeAPI.Models;

namespace AwesomeAPI.Migrations
{
    [DbContext(typeof(AwesomeContext))]
    [Migration("20160504100417_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("AwesomeAPI.Models.ACLPermission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ACLResourceID");

                    b.Property<int?>("ACLRoleID");

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.ACLResource", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.ACLRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ACLResourceID");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name");

                    b.Property<int>("Weight");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.Channel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("OwnerID");

                    b.Property<string>("Title");

                    b.Property<bool>("Visibility");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.IdentityUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChannelID");

                    b.Property<int?>("ChannelID1");

                    b.Property<string>("Email");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Handle");

                    b.Property<string>("Name");

                    b.Property<int?>("RoleID");

                    b.Property<int?>("StatusID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int?>("IdentityUserID");

                    b.Property<DateTime>("Timestamp");

                    b.Property<int?>("TypeID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.MessageType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.UserStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.ACLPermission", b =>
                {
                    b.HasOne("AwesomeAPI.Models.ACLResource")
                        .WithMany()
                        .HasForeignKey("ACLResourceID");

                    b.HasOne("AwesomeAPI.Models.ACLRole")
                        .WithMany()
                        .HasForeignKey("ACLRoleID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.ACLRole", b =>
                {
                    b.HasOne("AwesomeAPI.Models.ACLResource")
                        .WithMany()
                        .HasForeignKey("ACLResourceID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.Channel", b =>
                {
                    b.HasOne("AwesomeAPI.Models.IdentityUser")
                        .WithMany()
                        .HasForeignKey("OwnerID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.IdentityUser", b =>
                {
                    b.HasOne("AwesomeAPI.Models.Channel")
                        .WithMany()
                        .HasForeignKey("ChannelID");

                    b.HasOne("AwesomeAPI.Models.Channel")
                        .WithMany()
                        .HasForeignKey("ChannelID1");

                    b.HasOne("AwesomeAPI.Models.ACLRole")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.HasOne("AwesomeAPI.Models.UserStatus")
                        .WithMany()
                        .HasForeignKey("StatusID");
                });

            modelBuilder.Entity("AwesomeAPI.Models.Message", b =>
                {
                    b.HasOne("AwesomeAPI.Models.IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserID");

                    b.HasOne("AwesomeAPI.Models.MessageType")
                        .WithMany()
                        .HasForeignKey("TypeID");
                });
        }
    }
}
