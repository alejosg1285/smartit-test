using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<AppUser, AppRole, string>(options)
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<HotelRoom> HotelRoom { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RoleConfiguration());

        builder.Entity<Hotel>()
            .HasMany(e => e.Rooms)
            .WithOne(e => e.Hotel)
            .HasForeignKey(e => e.HotelId)
            .IsRequired();

        builder.Entity<Room>()
            .Property(r => r.Price).HasPrecision(10, 2);

        builder.Entity<Room>()
            .Property(r => r.Taxes).HasPrecision(10, 2);

        builder.Entity<HotelRoom>()
            .HasOne(e => e.Hotel)
            .WithMany(e => e.Rooms)
            .HasForeignKey(h => h.HotelId);

        builder.Entity<HotelRoom>()
            .HasOne(e => e.Room)
            .WithMany(e => e.Hotels)
            .HasForeignKey(r => r.RoomId);

        builder.Entity<Book>()
            .HasMany(e => e.Passengers)
            .WithOne(e => e.Book)
            .HasForeignKey(e => e.BookId)
            .IsRequired();

        builder.Entity<Book>()
            .HasOne(e => e.Contact)
            .WithOne(e => e.Book)
            .HasForeignKey<Contact>(e => e.BookId)
            .IsRequired();

        builder.Entity<Passenger>()
            .Property(e => e.Genre)
            .HasConversion(
                v => v.ToString(),
                v => (GenderEnum)Enum.Parse(typeof(GenderEnum), v)
            );
    }
}
