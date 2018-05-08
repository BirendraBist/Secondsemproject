namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
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
    }
}
