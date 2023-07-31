using BilgeHotel.DAL.Init;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.DAL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("MyConnection")
        {
            Database.SetInitializer(new MyInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new BedMap());
            modelBuilder.Configurations.Add(new CampaignMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new ExtraShiftMap());
            modelBuilder.Configurations.Add(new GuestMap());
            modelBuilder.Configurations.Add(new HotelInfoAndImageMap());
            modelBuilder.Configurations.Add(new HotelInfoMap());
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new ReservationMap());
            modelBuilder.Configurations.Add(new RoomAndBedMap());
            modelBuilder.Configurations.Add(new RoomAndImageMap());
            modelBuilder.Configurations.Add(new RoomAndReservationMap());
            modelBuilder.Configurations.Add(new RoomMap());
            modelBuilder.Configurations.Add(new ShiftMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new RoomFeatureMap());

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ExtraShift> ExtraShifts { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<HotelInfo> HotelInfos { get; set; }
        public DbSet<HotelInfoAndImage> HotelInfoAndImages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAndBed> RoomAndBeds { get; set; }
      
        public DbSet<RoomAndImage> RoomAndImages { get; set; }
        public DbSet<RoomAndReservation> RoomAndReservations { get; set; }
       
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }


    }

            
    
}
