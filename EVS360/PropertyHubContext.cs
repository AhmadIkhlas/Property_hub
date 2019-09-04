using EVS360;
using EVS360.PropertyHub;
using EVS360.UsersMgt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVS360
{
    public class PropertyHubContext : DbContext 
    {
        public PropertyHubContext()  
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-JIUQB1F;initial catalog=APropertyHub362;persist security info=True;integrated security=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<City>()
                .HasOne<Province>(c => c.Province)
                .WithMany(p=>p.Cities)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Province>()
                .HasOne<Country>(p => p.Country)
                .WithMany(c=>c.Provinces)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne<Role>(u => u.Role)
                //.WithMany(r=>r.Users)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne<Address>(u => u.Address)
                .WithOne(a=>a.User)
                .HasForeignKey<Address>(u=>u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

          

           

            modelBuilder.Entity<PropertyArea>()
                .HasOne<AreaUnit>(pa => pa.Unit)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
                .HasOne<PropertyArea>(adv => adv.Area)
                .WithOne()
                .IsRequired()
                .HasForeignKey<PropertyArea>(pa=>pa.PropertyAdvId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<AdvType>(adv => adv.AdvType)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<AdvStatus>(adv => adv.AdvStatus)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Neighborhood>()
            .HasOne<City>(hs => hs.City)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NeighborhoodBlock>()
            .HasOne<Neighborhood>(b => b.Neighborhood)
            .WithMany(n => n.Blocks)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<NeighborhoodBlock>(adv => adv.SchemeBlock)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<User>(adv => adv.PostedBy)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasMany<PropertyImage>(adv => adv.Images)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdvsPropertyFeatures>()
                .HasOne<PropertyAdv>(paf => paf.Advertisement)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdvsPropertyFeatures>()
                .HasOne<PropertyFeature>(paf => paf.Feature)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);


        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User>  Users { get; set; }

        public DbSet<AdvType> AdvTypes { get; set; }
        public DbSet<AdvStatus> AdvStatus { get; set; }

        public DbSet<AreaUnit> AreaUnits { get; set; }

        public DbSet<Neighborhood> HousingSchemes { get; set; }

        public DbSet<NeighborhoodBlock> SchemeBlocks { get; set; }
        
        public DbSet<PropertyAdv> PropertyAdvs { get; set; }


    }
}
