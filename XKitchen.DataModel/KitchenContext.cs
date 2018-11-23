namespace XKitchen.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KitchenContext : DbContext
    {
        public KitchenContext()
            : base("name=KitchenContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.initial)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.initial)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.reference)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.guest)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Reservation)
                .HasForeignKey(e => e.reservid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.initial)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Desc)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.ModifyBy)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Table)
                .WillCascadeOnDelete(false);
        }
    }
}
