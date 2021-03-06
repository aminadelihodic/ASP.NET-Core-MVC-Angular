// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rentacar.Data;

namespace rentacar.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210822080607_comment")]
    partial class comment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("rentacar.Models.Adresa", b =>
                {
                    b.Property<int>("AdresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Broj")
                        .HasColumnType("int");

                    b.Property<int?>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdresaId");

                    b.HasIndex("GradId");

                    b.ToTable("Adresa");
                });

            modelBuilder.Entity("rentacar.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaProfilaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("rentacar.Models.Automobil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cijena")
                        .HasColumnType("real");

                    b.Property<int>("IznosZarade")
                        .HasColumnType("int");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProizvodjacID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("ProizvodjacID");

                    b.ToTable("Automobil");
                });

            modelBuilder.Entity("rentacar.Models.DetaljiKarakteristika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DetaljiKarakteristika");
                });

            modelBuilder.Entity("rentacar.Models.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("rentacar.Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostanskiBroj")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("rentacar.Models.KarakteristikeDetaljaAutomobila", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomobilId")
                        .HasColumnType("int");

                    b.Property<int>("DetaljiKarakteristikaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutomobilId");

                    b.HasIndex("DetaljiKarakteristikaId");

                    b.ToTable("KarakteristikeDetaljaAutomobila");
                });

            modelBuilder.Entity("rentacar.Models.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("rentacar.Models.KomentariAutomobila", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomobilId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumIzdavanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnikId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutomobilId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("KomentariAutomobila");
                });

            modelBuilder.Entity("rentacar.Models.NacinPlacanja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrojKartice")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("Ostalo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NacinPlacanja");
                });

            modelBuilder.Entity("rentacar.Models.Novosti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumIzmjene")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<string>("KorisnikId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadržaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sažetak")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Novosti");
                });

            modelBuilder.Entity("rentacar.Models.Pregled", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutomobilId")
                        .HasColumnType("int");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutomobilId");

                    b.ToTable("Pregled");
                });

            modelBuilder.Entity("rentacar.Models.Proizvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("rentacar.Models.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomobilId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Do")
                        .HasColumnType("datetime2");

                    b.Property<string>("KorisnikId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Od")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Verifikovan")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AutomobilId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Rent");
                });

            modelBuilder.Entity("rentacar.Models.Slika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomobilId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutomobilId");

                    b.ToTable("Slika");
                });

            modelBuilder.Entity("rentacar.Models.Ugovor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomobilId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<float>("FinalnaCijena")
                        .HasColumnType("real");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutomobilId");

                    b.HasIndex("RentId");

                    b.ToTable("Ugovor");
                });

            modelBuilder.Entity("rentacar.Models.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomobilId")
                        .HasColumnType("int");

                    b.Property<string>("KorisnikId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AutomobilId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("rentacar.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("rentacar.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rentacar.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("rentacar.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("rentacar.Models.Adresa", b =>
                {
                    b.HasOne("rentacar.Models.Grad", "Grad")
                        .WithMany("Adrese")
                        .HasForeignKey("GradId");

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("rentacar.Models.Automobil", b =>
                {
                    b.HasOne("rentacar.Models.Kategorija", "Kategorija")
                        .WithMany("Automobili")
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rentacar.Models.Proizvodjac", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorija");

                    b.Navigation("Proizvodjac");
                });

            modelBuilder.Entity("rentacar.Models.Grad", b =>
                {
                    b.HasOne("rentacar.Models.Drzava", "Drzava")
                        .WithMany("Gradovi")
                        .HasForeignKey("DrzavaId");

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("rentacar.Models.KarakteristikeDetaljaAutomobila", b =>
                {
                    b.HasOne("rentacar.Models.Automobil", "Automobil")
                        .WithMany("KarakteristikeDetaljaAutomobila")
                        .HasForeignKey("AutomobilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rentacar.Models.DetaljiKarakteristika", "DetaljiKarakteristika")
                        .WithMany()
                        .HasForeignKey("DetaljiKarakteristikaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Automobil");

                    b.Navigation("DetaljiKarakteristika");
                });

            modelBuilder.Entity("rentacar.Models.KomentariAutomobila", b =>
                {
                    b.HasOne("rentacar.Models.Automobil", "Automobil")
                        .WithMany("KomentariAutomobila")
                        .HasForeignKey("AutomobilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rentacar.Models.ApplicationUser", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.Navigation("Automobil");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("rentacar.Models.Novosti", b =>
                {
                    b.HasOne("rentacar.Models.ApplicationUser", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("rentacar.Models.Pregled", b =>
                {
                    b.HasOne("rentacar.Models.Automobil", "Automobil")
                        .WithMany()
                        .HasForeignKey("AutomobilId");

                    b.Navigation("Automobil");
                });

            modelBuilder.Entity("rentacar.Models.Rent", b =>
                {
                    b.HasOne("rentacar.Models.Automobil", "Automobil")
                        .WithMany()
                        .HasForeignKey("AutomobilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rentacar.Models.ApplicationUser", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.Navigation("Automobil");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("rentacar.Models.Slika", b =>
                {
                    b.HasOne("rentacar.Models.Automobil", "Automobil")
                        .WithMany("Slike")
                        .HasForeignKey("AutomobilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Automobil");
                });

            modelBuilder.Entity("rentacar.Models.Ugovor", b =>
                {
                    b.HasOne("rentacar.Models.Automobil", "Automobil")
                        .WithMany()
                        .HasForeignKey("AutomobilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rentacar.Models.Rent", "Rent")
                        .WithMany()
                        .HasForeignKey("RentId");

                    b.Navigation("Automobil");

                    b.Navigation("Rent");
                });

            modelBuilder.Entity("rentacar.Models.Wishlist", b =>
                {
                    b.HasOne("rentacar.Models.Automobil", "Automobil")
                        .WithMany()
                        .HasForeignKey("AutomobilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rentacar.Models.ApplicationUser", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.Navigation("Automobil");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("rentacar.Models.Automobil", b =>
                {
                    b.Navigation("KarakteristikeDetaljaAutomobila");

                    b.Navigation("KomentariAutomobila");

                    b.Navigation("Slike");
                });

            modelBuilder.Entity("rentacar.Models.Drzava", b =>
                {
                    b.Navigation("Gradovi");
                });

            modelBuilder.Entity("rentacar.Models.Grad", b =>
                {
                    b.Navigation("Adrese");
                });

            modelBuilder.Entity("rentacar.Models.Kategorija", b =>
                {
                    b.Navigation("Automobili");
                });
#pragma warning restore 612, 618
        }
    }
}
