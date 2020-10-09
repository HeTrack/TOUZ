using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using TourSearchDatabaseImplement.Models;

namespace TourSearchDatabaseImplement
{
    public class TourSearchDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TourSearchDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Tour> Tours { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Resort> Resorts { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet <Room> Rooms { get; set; }
        public virtual DbSet <Departure> Departures { get; set; }
        public virtual DbSet <TourOperator> TourOperators { get; set; }
        public virtual DbSet<ProfileCountry> ProfileCountries { get; set; }
        public virtual DbSet<ProfileTourOperator> ProfileTourOperators { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileDeparture> ProfileDepartures { get; set; }
        public virtual DbSet<ProfileMeal> ProfileMeals { get; set; }
        public virtual DbSet<ProfileStar> ProfileStars { get; set; }
    
    }
}
