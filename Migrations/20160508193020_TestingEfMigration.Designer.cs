using DrinkCounter.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;

namespace DrinkCounter.Migrations
{
    [DbContext(typeof(DrinkingData))]
    [Migration("20160508193020_TestingEfMigration")]
    partial class TestingEfMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DrinkType", b =>
                {
                    b.Property<int>("DrinkTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("DrinkName");

                    b.Property<string>("Temperature");

                    b.HasKey("DrinkTypeId");
                });
        }
    }
}
