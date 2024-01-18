using System;
using Microsoft.EntityFrameworkCore;
public class TrackingContext : DbContext{


    public TrackingContext(DbContextOptions<TrackingContext> options) : base(options)
    {
    }

    public DbSet<PageInteraction> TrackingData {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configureer relaties of andere modelconfiguraties indien nodig.
    }
}

