namespace Console
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AirMantenanceContext : DbContext
    {
        public AirMantenanceContext()
            : base("name=AirMantenanceContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.User_Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_Type)
                .IsUnicode(false);
        }
    }
}
