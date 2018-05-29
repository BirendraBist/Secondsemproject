namespace WebAppService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            MonitorTasks = new HashSet<MonitorTask>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Task_ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Task_Description { get; set; }

        [Required]
        [StringLength(500)]
        public string Task_Schedule { get; set; }

        [Required]
        [StringLength(500)]
        public string Task_Type { get; set; }

        [Required]
        [StringLength(500)]
        public string Task_Status { get; set; }

        public int User_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonitorTask> MonitorTasks { get; set; }

        public virtual User User { get; set; }
    }
}
