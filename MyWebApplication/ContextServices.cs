namespace MyWebApplication
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextServices : DbContext
    {
        public ContextServices()
            : base("name=ContextServices")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;

        }

        public virtual DbSet<Monitor> Monitors { get; set; }
        public virtual DbSet<MonitorTask> MonitorTasks { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monitor>()
                .Property(e => e.Monitor_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .Property(e => e.Monitor_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .HasMany(e => e.MonitorTasks)
                .WithRequired(e => e.Monitor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Station_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Monitors)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Task_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Task_Status)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.MonitorTasks)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_Type)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
