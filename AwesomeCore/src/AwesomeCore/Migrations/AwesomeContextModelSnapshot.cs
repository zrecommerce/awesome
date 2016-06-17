using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AwesomeCore.Models;

namespace AwesomeCore.Migrations
{
    [DbContext(typeof(AwesomeContext))]
    partial class AwesomeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901");

            modelBuilder.Entity("AwesomeCore.Models.ACLPermission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ACLResourceID");

                    b.Property<int?>("ACLRoleID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("ACLResourceID");

                    b.HasIndex("ACLRoleID");

                    b.ToTable("ACLPermissions");
                });

            modelBuilder.Entity("AwesomeCore.Models.ACLResource", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ACLResources");
                });

            modelBuilder.Entity("AwesomeCore.Models.ACLRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ACLResourceID");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name");

                    b.Property<int>("Weight");

                    b.HasKey("ID");

                    b.HasIndex("ACLResourceID");

                    b.ToTable("ACLRoles");
                });

            modelBuilder.Entity("AwesomeCore.Models.Channel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("OwnerID");

                    b.Property<string>("Title");

                    b.Property<bool>("Visibility");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("AwesomeCore.Models.IdentityUser", b =>
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

                    b.HasIndex("ChannelID");

                    b.HasIndex("ChannelID1");

                    b.HasIndex("RoleID");

                    b.HasIndex("StatusID");

                    b.ToTable("IdentityUsers");
                });

            modelBuilder.Entity("AwesomeCore.Models.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int?>("IdentityUserID");

                    b.Property<DateTime>("Timestamp");

                    b.Property<int?>("TypeID");

                    b.HasKey("ID");

                    b.HasIndex("IdentityUserID");

                    b.HasIndex("TypeID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("AwesomeCore.Models.MessageType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("MessageTypes");
                });

            modelBuilder.Entity("AwesomeCore.Models.UserStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("UserStatuses");
                });

            modelBuilder.Entity("AwesomeCore.Models.ACLPermission", b =>
                {
                    b.HasOne("AwesomeCore.Models.ACLResource")
                        .WithMany()
                        .HasForeignKey("ACLResourceID");

                    b.HasOne("AwesomeCore.Models.ACLRole")
                        .WithMany()
                        .HasForeignKey("ACLRoleID");
                });

            modelBuilder.Entity("AwesomeCore.Models.ACLRole", b =>
                {
                    b.HasOne("AwesomeCore.Models.ACLResource")
                        .WithMany()
                        .HasForeignKey("ACLResourceID");
                });

            modelBuilder.Entity("AwesomeCore.Models.Channel", b =>
                {
                    b.HasOne("AwesomeCore.Models.IdentityUser")
                        .WithMany()
                        .HasForeignKey("OwnerID");
                });

            modelBuilder.Entity("AwesomeCore.Models.IdentityUser", b =>
                {
                    b.HasOne("AwesomeCore.Models.Channel")
                        .WithMany()
                        .HasForeignKey("ChannelID");

                    b.HasOne("AwesomeCore.Models.Channel")
                        .WithMany()
                        .HasForeignKey("ChannelID1");

                    b.HasOne("AwesomeCore.Models.ACLRole")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.HasOne("AwesomeCore.Models.UserStatus")
                        .WithMany()
                        .HasForeignKey("StatusID");
                });

            modelBuilder.Entity("AwesomeCore.Models.Message", b =>
                {
                    b.HasOne("AwesomeCore.Models.IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserID");

                    b.HasOne("AwesomeCore.Models.MessageType")
                        .WithMany()
                        .HasForeignKey("TypeID");
                });
        }
    }
}
