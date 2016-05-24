using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DrinkCounter.Models;

namespace DrinkCounter.Migrations
{
    [DbContext(typeof(DrinkingData))]
    [Migration("20160510031359_AddUserInfo")]
    partial class AddUserInfo
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

                    b.Property<int>("DrinkTypeId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DrinkCounter.Models.DrinkType", b =>
                {
                    b.Property<int>("DrinkTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

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

            modelBuilder.Entity("DrinkCounter.Models.UserInfo", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("Firstname");

                    b.Property<string>("Gender");

                    b.Property<string>("Lastname");

                    b.HasKey("Id");
                });
        }
    }
}
