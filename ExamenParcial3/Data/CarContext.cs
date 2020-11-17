using ExamenParcial3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ExamenParcial3.Data
{
    public class CarContext : IdentityDbContext<User>
    {
        public CarContext(DbContextOptions<CarContext> options) : base (options)
        {

        }
        public DbSet<VehicleManufacter> VehicleManufacters {get; set;}
        public DbSet<VehicleModel> VehicleModels {get; set;}
        public DbSet<VehicleColour> VehicleColours {get; set;}
        public DbSet<VehicleFeature> VehicleFeatures {get; set;}
        public DbSet<VehicleFuelType> VehicleFuelTypes {get; set;}
        public DbSet<VehicleDetail> VehicleDetails {get; set;}
        public DbSet<LinkFeatureToVehicle> LinkFeatureToVehicles {get; set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleManufacter>().ToTable("Manufacter");
            modelBuilder.Entity<VehicleModel>().ToTable("Model");
            modelBuilder.Entity<VehicleColour>().ToTable("Colour");
            modelBuilder.Entity<VehicleFeature>().ToTable("Feature");
            modelBuilder.Entity<VehicleFuelType>().ToTable("FuelType");
            modelBuilder.Entity<VehicleDetail>().ToTable("Detail");
            modelBuilder.Entity<LinkFeatureToVehicle>().ToTable("FeatureToVehicle");

            modelBuilder.Entity<LinkFeatureToVehicle>().HasKey(l=> new {l.CarRegistration, l.FeatureID});
        }
    }
}