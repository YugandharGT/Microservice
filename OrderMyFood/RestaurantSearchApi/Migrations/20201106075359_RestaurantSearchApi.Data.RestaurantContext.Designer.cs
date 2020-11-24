﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderMyFood.RestaurantSearchApi.Data;

namespace RestaurantSearchApi.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    [Migration("20201106075359_RestaurantSearchApi.Data.RestaurantContext")]
    partial class RestaurantSearchApiDataRestaurantContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantSearchApi.Model.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("RestaurantId");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");

                    b.HasData(
                        new { MenuId = 1, Name = "Chicken Biryani", Price = 250m, RestaurantId = 1 },
                        new { MenuId = 2, Name = "Chicken Korma", Price = 200m, RestaurantId = 2 },
                        new { MenuId = 3, Name = "Shahi Paneer", Price = 250m, RestaurantId = 3 },
                        new { MenuId = 4, Name = "Tandoori Roti", Price = 250m, RestaurantId = 1 },
                        new { MenuId = 5, Name = "Choley Bhaturey", Price = 100m, RestaurantId = 2 }
                    );
                });

            modelBuilder.Entity("RestaurantSearchApi.Model.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Budget");

                    b.Property<string>("Cuisine");

                    b.Property<int>("Distance");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<short>("Ratings");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new { RestaurantId = 1, Budget = 0m, Cuisine = "Indian", Distance = 20, Location = "JP Nagar, Bangalore 560006", Name = "Barbequnation", Ratings = (short)5 },
                        new { RestaurantId = 2, Budget = 0m, Cuisine = "Indian", Distance = 5, Location = "Koramangala", Name = "Paradize", Ratings = (short)4 },
                        new { RestaurantId = 3, Budget = 0m, Cuisine = "Italian", Distance = 12, Location = "Brigade Road", Name = "Thirteenth floor", Ratings = (short)2 },
                        new { RestaurantId = 4, Budget = 0m, Cuisine = "Caribbean", Distance = 18, Location = "JP Nagar, Bangalore 560009", Name = "Mango Tree", Ratings = (short)4 },
                        new { RestaurantId = 5, Budget = 0m, Cuisine = "German", Distance = 25, Location = "JP Nagar, Bangalore 564555", Name = "Brewsky", Ratings = (short)5 }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
