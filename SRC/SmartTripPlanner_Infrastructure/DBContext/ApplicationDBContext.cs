using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartTripPlanner_Domain.Models.LocationType;


public class ApplicationDBContext:IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Meuseum> Meuseums { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<FilmLocation> FilmLocations { get; set; }
    public DbSet<Film> Films { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>()
            .HasDiscriminator<string>("LocationType")
            .HasValue<Hotel>("Hotel")
            .HasValue<Restaurant>("Restaurant")
            .HasValue<Meuseum>("Meuseum")
            .HasValue<Cinema>("Cinema")
            .HasValue<FilmLocation>("FilmLocation");
        base.OnModelCreating(modelBuilder);
    }
}

