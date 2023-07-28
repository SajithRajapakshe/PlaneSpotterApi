using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PlaneSpotterDL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterDL
{
    /// <summary>
    /// Db context class for Aircraft spotter db operations
    /// </summary>
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }

        /// <summary>
        /// Based on the requirement, more dbsets can be added
        /// </summary>
        public DbSet<AircraftSpotterDataModel> AircraftSpotters { get; set; }


        /// <summary>
        /// Binding data model to table 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AircraftSpotterDataModel>().ToTable("AircraftSpotters");
        }

      


    }
}
