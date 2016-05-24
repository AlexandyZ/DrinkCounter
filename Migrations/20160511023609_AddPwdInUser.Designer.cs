using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DrinkCounter.Models;

namespace DrinkCounter.Migrations
{
    [DbContext(typeof(DrinkingData))]
    [Migration("20160511023609_AddPwdInUser")]
    partial class AddPwdInUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DrinkCounter.Models.DrinkCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DrinkCounter.Models.DrinkCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("TypeId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DrinkCounter.Models.DrinkType", b =>
                {
                    b.Property<int>("DrinkTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<int?>("DrinkCategoryId");

                    b.Property<string>("DrinkName");

                    b.Property<string>("Temperature");

                    b.HasKey("DrinkTypeId");
                });

            modelBuilder.Entity("DrinkCounter.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DrinkCounter.Models.TeamMember", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("TeamId");

                    b.Property<bool>("Activated")
                        .HasAnnotation("Relational:DefaultValue", "True")
                        .HasAnnotation("Relational:DefaultValueType", "System.Boolean");

                    b.HasKey("UserId", "TeamId");
                });

            modelBuilder.Entity("DrinkCounter.Models.UserInfo", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Gender")
                        .HasAnnotation("MaxLength", 1)
                        .HasAnnotation("Relational:ColumnType", "char");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Password");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DrinkCounter.Models.DrinkCount", b =>
                {
                    b.HasOne("DrinkCounter.Models.DrinkType")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.HasOne("DrinkCounter.Models.UserInfo")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DrinkCounter.Models.DrinkType", b =>
                {
                    b.HasOne("DrinkCounter.Models.DrinkCategory")
                        .WithMany()
                        .HasForeignKey("DrinkCategoryId");
                });

            modelBuilder.Entity("DrinkCounter.Models.TeamMember", b =>
                {
                    b.HasOne("DrinkCounter.Models.Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("DrinkCounter.Models.UserInfo")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
