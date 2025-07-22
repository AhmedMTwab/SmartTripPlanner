using System;
using Microsoft.EntityFrameworkCore;
using SmartTripPlanner_Domain.Models.LocationType;


public class ApplicationDBContext:DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<LocationTypes> LocationTypes { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Meuseum> Meuseums { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<FilmLocation> FilmLocations { get; set; }
    public DbSet<Film> Films { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

