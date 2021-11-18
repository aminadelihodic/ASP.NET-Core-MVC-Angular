using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rentacar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rentacar.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Adresa> Adresa { get; set; }
        public virtual DbSet<Automobil> Automobil { get; set; }
        public virtual DbSet<DetaljiKarakteristika> DetaljiKarakteristika { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<KarakteristikeDetaljaAutomobila> KarakteristikeDetaljaAutomobila { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<KomentariAutomobila> KomentariAutomobila { get; set; }
       // public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<NacinPlacanja> NacinPlacanja { get; set; }
        public virtual DbSet<Novosti> Novosti { get; set; }
        public virtual DbSet<Pregled> Pregled { get; set; }
        public virtual DbSet<Proizvodjac> Proizvodjac { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<Slika> Slika { get; set; }
        public virtual DbSet<Ugovor> Ugovor { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=app.fit.ba,1431;
                                                            Database=p2083_;
                                                            Trusted_Connection=false;
                                                            User ID=p2083;
                                                            Password=MWMMsS!;
                                                            MultipleActiveResultSets=true;
           ");
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<>();
        }
    }
}
