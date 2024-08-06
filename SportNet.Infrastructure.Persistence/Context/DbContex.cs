
using Microsoft.EntityFrameworkCore;
using SportNet.Core.Domain.Common;
using SportNet.Core.Domain.Entities;

namespace SportNet.Infrastructure.Persistence.Context
{
    public class DbContex : DbContext
    {
        public DbContex(DbContextOptions<DbContex> options)
        : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventParticipation> EventParticipations { get; set; }

        //SaveChangesAsync Extension method
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }
        //metodo para llenar los campos auditable automaticamente 
        //cuando se vaya a guardar algo en la base de datos
        private void UpdateAuditFields()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreateBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API

            #region Tablas
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Events>().ToTable("Events");
            modelBuilder.Entity<EventParticipation>().ToTable("EventParticipations");
            #endregion


            // Definir claves primarias
            #region Primary key
            modelBuilder.Entity<Users>().HasKey(e => e.Id);
            modelBuilder.Entity<Events>().HasKey(e => e.Id);
            modelBuilder.Entity<EventParticipation>().HasKey(e => e.Id);
            #endregion

            // Definir relaciones
            #region Relations
            // Relación User -> Event (Uno a muchos)
            modelBuilder.Entity<Users>()
                .HasMany(e => e.CreatedEvents)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación User -> EventParticipation (Uno a muchos)
            modelBuilder.Entity<Users>()
                .HasMany(e => e.EventParticipations)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Event -> EventParticipation (Uno a muchos)
            modelBuilder.Entity<Events>()
                .HasMany(e => e.EventParticipations)
                .WithOne(e => e.Event)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            // Configuración de propiedades
            #region Property Configurations
            // Configuraciones de propiedades para User
            modelBuilder.Entity<Users>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Users>().Property(e => e.LastName).IsRequired();
            modelBuilder.Entity<Users>().Property(e => e.Email).IsRequired();
            modelBuilder.Entity<Users>().Property(e => e.Password).IsRequired();

            // Configuraciones de propiedades para Event
            modelBuilder.Entity<Events>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Events>().Property(e => e.Caption).IsRequired(false);
            modelBuilder.Entity<Events>().Property(e => e.Date).IsRequired();
            modelBuilder.Entity<Events>().Property(e => e.Hour).IsRequired();
            modelBuilder.Entity<Events>().Property(e => e.Location).IsRequired();
            modelBuilder.Entity<Events>().Property(e => e.Sport).IsRequired();

            // Configuraciones de propiedades para EventParticipation
            modelBuilder.Entity<EventParticipation>().Property(e => e.RegistrationDate).IsRequired();
            #endregion
        }
    }
}