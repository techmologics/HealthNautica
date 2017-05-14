using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HealthNautica.Physician.DataAccess
{
    public partial class CommonContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingDatabase"].ConnectionString);

            optionsBuilder.UseSqlServer(@"Server=PAPOLU\SQLEXPRESS;Database=Common;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DbName).HasColumnType("varchar(50)");

                entity.Property(e => e.Hospital).HasColumnType("varchar(50)");
            });
        }

        public virtual DbSet<MasterData> MasterData { get; set; }
    }
}