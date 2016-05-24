using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DrinkCounter.Models;

namespace DrinkCounter.Migrations
{
    [DbContext(typeof(DrinkingData))]
    [Migration("20160510023308_Team")]
    partial class Team
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

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });
        }
    }
}
