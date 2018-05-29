namespace WebAppService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string User_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string User_Email { get; set; }

        [Required]
        [StringLength(100)]
        public string User_Password { get; set; }

        [Required]
        [StringLength(100)]
        public string User_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
