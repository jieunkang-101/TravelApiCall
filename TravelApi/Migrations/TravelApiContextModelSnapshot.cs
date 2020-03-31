﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApi.Models;

namespace TravelApi.Migrations
{
    [DbContext(typeof(TravelApiContext))]
    partial class TravelApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TravelApi.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Landmark")
                        .IsRequired();

                    b.Property<int>("Rating");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            Author = "user1",
                            City = "Paris",
                            Country = "France",
                            Description = "I loved this place. If your are an art lover, this place is a paradise for you. One day is not enough to visit the entire museum. But still you can visit the main attractions including the famous Mona Lisa.",
                            Landmark = "Louvre Museum",
                            Rating = 5
                        },
                        new
                        {
                            ReviewId = 2,
                            Author = "user2",
                            City = "Sydney",
                            Country = "Australia",
                            Description = "Wow! Sydney Opera House is absolutely FABULOUS! What an elegant, gorgeous, impressive display of truly artistic architecture.  The beauty of this site is enhanced with each different view.",
                            Landmark = "Opera House",
                            Rating = 4
                        },
                        new
                        {
                            ReviewId = 3,
                            Author = "user2",
                            City = "Portland",
                            Country = "USA",
                            Description = "This was a great way to get to know the city of Portland! It was fascinating to learn about one of the first wealthy families to live there. The mansion is really cool and the hike through forest park is a fun way to get there!",
                            Landmark = "Pittock Mansion",
                            Rating = 4
                        },
                        new
                        {
                            ReviewId = 4,
                            Author = "user1",
                            City = "Bangkok",
                            Country = "Thailand",
                            Description = "A place to be definitely included in must visit tourist destination. Place is well maintained and mermerizing. It is my first time to see buildings crafted with real gold.",
                            Landmark = "Temple of the Emerald Buddha",
                            Rating = 3
                        },
                        new
                        {
                            ReviewId = 5,
                            Author = "user3",
                            City = "Seoul",
                            Country = "Korea",
                            Description = "It is one of the best places on South Korea to see the old architecture of a palace. Even traditional events are demonstrate times to time. The most interesting thing in this place is that you can take photographs with soldiers with traditional costumes.",
                            Landmark = "Gyeongbokgung Palace",
                            Rating = 5
                        });
                });

            modelBuilder.Entity("TravelApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Token");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Test",
                            LastName = "User",
                            Password = "test",
                            Username = "test"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
