namespace MyWebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Monitor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Monitor()
        {
            MonitorTasks = new HashSet<MonitorTask>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Monitor_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Monitor_Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Monitor_Type { get; set; }

        public int Station_ID { get; set; }

        public virtual Station Station { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonitorTask> MonitorTasks { get; set; }
    }
}
