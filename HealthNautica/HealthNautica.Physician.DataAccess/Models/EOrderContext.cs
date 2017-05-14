﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HealthNautica.Physician.DataAccess
{
    public partial class EOrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
             
            optionsBuilder.UseSqlServer(@"Server=PAPOLU\SQLEXPRESS;Database=EOrder1;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eorder>(entity =>
            {
                entity.ToTable("EOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("varchar(50)");
            });
        }

        public virtual DbSet<Eorder> Eorder { get; set; }
    }
}