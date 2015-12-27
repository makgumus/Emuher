using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Emuher.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Emuher.DAL
{
    public class EmuherContext : DbContext
    {
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Araba> Araba { get; set; }
        public DbSet<Renk> Renk { get; set; }
        public DbSet<Plaza> Plaza { get; set; }
        public DbSet<AracRenk> AracRenk { get; set; }
        public DbSet<AracPlaza> AracPlaza { get; set; }
        public DbSet<Admin> Admin { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}